using System.Collections;
using UnityEngine;

namespace SpencerMansionIncident.DefaultGamePrefs;

public static class InjectPrefs
{
	[HarmonyPatch(typeof(GameManager), "StartGame")]
	static class Patches__GameManager__StartGame
	{
		static bool Prefix(GameManager __instance)
		{
			Time.timeScale = 1f;
			GamePrefs.Set(EnumGamePrefs.GameGuidClient, "");
			GameSparksManager.Instance()?.PrepareNewSession();

			foreach(var pref in Prefs.Overrides){
				GamePrefs.SetObject(pref.GamePref, pref.DefaultValue);
			}

			Traverse trav = Traverse.Create(__instance).Method("startGameCo");
			__instance.StartCoroutine(trav.GetValue<IEnumerator>());

			return false;
		}
	}
}