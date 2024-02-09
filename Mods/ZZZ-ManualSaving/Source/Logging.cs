using System.Diagnostics;

namespace ManualSaving;

public static class Logging
{
	[Conditional("DEBUG")]
	public static void Debug(string text)
	{
		Log.Out($"Debug: {text}");
	}
}