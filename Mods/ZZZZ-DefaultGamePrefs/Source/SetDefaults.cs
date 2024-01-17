namespace SpencerMansionIncident.DefaultGamePrefs;

public static class SetDefaults
{
	[HarmonyPatch(typeof(GameModeSurvival), "GetSupportedGamePrefsInfo")]
	static class Patches__GameModeSurvival__GetSupportedGamePrefsInfo
	{
		static bool Prefix(ref GameMode.ModeGamePref[] __result)
		{
			__result = Prefs.Defaults;
			return false;
		}
	}
}