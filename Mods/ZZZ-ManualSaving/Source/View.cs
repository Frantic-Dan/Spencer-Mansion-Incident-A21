namespace ManualSaving;

public static class View
{
	public static XUiC_SimpleButton? BtnSaveManual;
	public static XUiV_Sprite? SpriteSaveStatus;

	public static ItemClass? GetSaveItemClass() =>
		WorldEnvironment.Properties.GetString("SaveItemName") is not {} name
				|| string.IsNullOrWhiteSpace(name)
			? null
			: ItemClass.GetItemClass(name, true);

	public static bool PlayerHasSaveItem()
	{
		if(GameManager.Instance?.World?.GetPrimaryPlayer() is not {} epl){
			Log.Warning($"{nameof(ManualSaving)}.{nameof(View)}.{nameof(PlayerHasSaveItem)} failed to acquire {nameof(EntityPlayerLocal)} instance.");
			return false;
		}

		if(GetSaveItemClass() is not {} ic){
			return false;
		}

		ItemValue val = new(ic.Id);
		return epl.inventory.GetItemCount(val) > 0 || epl.bag.GetItemCount(val) > 0;
	}

	public static bool TakeSaveItemFromPlayer()
	{
		if(GetSaveItemClass() is not {} ic
				|| GameManager.Instance?.World?.GetPrimaryPlayer() is not {} epl){
			return false;
		}

		ItemValue iv = new(ic.Id);

		if(epl.inventory.DecItem(iv, 1) != 1 && epl.bag.DecItem(iv, 1) != 1){
			Log.Warning($"{nameof(ManualSaving)}.{nameof(View)}.{nameof(PlayerHasSaveItem)} tried to take save item but the local player had none.");
			return false;
		}

		return true;
	}
}

[HarmonyPatch(typeof(XUiC_InGameMenuWindow), "Init")]
static class Patches__XUiC_InGameMenuWindow__Init
{
	static void Postfix(XUiC_InGameMenuWindow __instance)
	{
		View.BtnSaveManual = __instance.GetChildById("btnSaveManual").
			GetChildByType<XUiC_SimpleButton>();
		View.BtnSaveManual.OnPressed += BtnSaveManual_OnPressed;
		View.SpriteSaveStatus = (XUiV_Sprite)__instance.
			GetChildById("spriteSaveStatus").ViewComponent;
	}

	static void BtnSaveManual_OnPressed(XUiController sender, int mouseButton)
	{
		if(mouseButton != -1){
			return;
		}

		SaveControl.Save();

		if(View.SpriteSaveStatus is {} sprite){
			Color c = sprite.Color;
			c.a = 1f;
			sprite.Color = c;
		}

		if(View.BtnSaveManual is {} btn){
			btn.Enabled = View.PlayerHasSaveItem();
		}
	}
}

[HarmonyPatch(typeof(XUiC_InGameMenuWindow), "OnOpen")]
static class Patches__XUiC_InGameMenuWindow__OnOpen
{
	static void Postfix()
	{
		if(View.SpriteSaveStatus is {} sprite){
			Color c = sprite.Color;
			c.a = 0f;
			sprite.Color = c;
		}

		if(View.BtnSaveManual is {} btn){
			btn.Enabled = View.PlayerHasSaveItem();
		}
	}
}