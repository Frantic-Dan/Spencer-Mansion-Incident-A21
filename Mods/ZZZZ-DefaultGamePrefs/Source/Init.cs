using Logger = HarmonyLib.Tools.Logger;

public class Init : IModApi
{
	public void InitMod(Mod _modInstance)
	{
#if DEBUG
		Logger.ChannelFilter = Logger.LogChannel.All ^ Logger.LogChannel.IL;
#endif
		Harmony.CreateAndPatchAll(typeof(Init).Assembly);
	}
}