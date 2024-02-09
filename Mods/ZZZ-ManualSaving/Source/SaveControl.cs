using System.Linq;

namespace ManualSaving;

public static class SaveControl
{
	const string ManualSaveStateFolderName = "ManualSaveState";

	public static string GetCurrentSaveManualSaveFolderPath() =>
		Path.Combine(GameIO.GetSaveGameDir(), "ManualSaveState");

	public static string GetGamePrefSaveGameFolder() =>
		GamePrefs.GetString(EnumGamePrefs.SaveGameFolder);

	static void StoreSaveState()
	{
		DirectoryInfo manualSaveDirInfo = new(GetCurrentSaveManualSaveFolderPath());
		DirectoryInfo normalSaveDirInfo = new(GameIO.GetSaveGameDir());

		if(!manualSaveDirInfo.Exists){
			manualSaveDirInfo.Create();
		}

		CopyRecursive(normalSaveDirInfo, manualSaveDirInfo.FullName);
	}

	public static void Save(
			bool showSavingTT = false,
			bool showSavedTT = true,
			bool skipItemCheck = false)
	{
		if(!SingletonMonoBehaviour<ConnectionManager>.Instance.IsServer){
			// Only the server can save!
			return;
		}

		if(skipItemCheck || (View.PlayerHasSaveItem() && View.TakeSaveItemFromPlayer())){
			Logging.Debug("Saving...");
			var epl = GameManager.Instance.World.GetPrimaryPlayer();

			// if(epl is {} && showSavingTT){
			// 	GameManager.ShowTooltip(epl, Localization.Get("xuiSavingInProgress"));
			// }

			GameManager.Instance.SaveLocalPlayerData();
			GameManager.Instance.SaveWorld();
			StoreSaveState();

			if(epl is {} && showSavedTT){
				GameManager.ShowTooltip(epl, Localization.Get("xuiGameSaved"));
			}

			Logging.Debug("Game saved.");
		}
	}

	static void MakeStoredSaveStatesPersistent()
	{
		string saveFolderPath = GetGamePrefSaveGameFolder();
		DirectoryInfo saveDirInfo = new(saveFolderPath);
		
		foreach(DirectoryInfo di in saveDirInfo.EnumerateDirectories(
					"*", SearchOption.AllDirectories).
				Where(a => a.Name.Equals(ManualSaveStateFolderName))){
			CopyRecursive(di, di.Parent.FullName);
		}
	}

	static void CopyRecursive(DirectoryInfo di, string dst)
	{
		DirectoryInfo dstDirInfo = new(dst);

		if(!dstDirInfo.Exists){
			dstDirInfo.Create();
		}

		FileInfo[] files = di.GetFiles();

		for(int i = 0; i < files.Length; i++){
			string dstPath = Path.Combine(dstDirInfo.FullName, files[i].Name);
			Logging.Debug($"Copying '{files[i].FullName}' to '{dstPath}");
			files[i].CopyTo(dstPath, true);
		}

		DirectoryInfo[] dirs = di.GetDirectories();

		for(int i = 0; i < dirs.Length; i++){
			if(dirs[i].FullName == dstDirInfo.FullName){
				continue;
			}

			CopyRecursive(dirs[i], Path.Combine(dstDirInfo.FullName, dirs[i].Name));
		}
	}

	/// <summary>
	/// Save once when the player first spawns so we don't lose their starting
	/// equipment if they quit before manually saving.
	/// </summary>
	[HarmonyPatch(typeof(EntityPlayerLocal), "AfterPlayerRespawn")]
	static class Patches__EntityPlayerLocal__AfterPlayerRespawn
	{
		static void Postfix(RespawnType _type)
		{
			if(_type is RespawnType.NewGame or RespawnType.EnterMultiplayer){
				StoreSaveState();
			}
		}
	}

	[HarmonyPatch(typeof(XUiC_NewContinueGame), "OnOpen")]
	static class Patches__XUiC_NewContinueGame__OnOpen
	{
		static void Prefix()
		{
			MakeStoredSaveStatesPersistent();
		}
	}
}