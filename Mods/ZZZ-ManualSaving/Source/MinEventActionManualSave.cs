using UnityEngine.Scripting;

[Preserve]
public class MinEventActionManualSave : MinEventActionBase
{
	public override void Execute(MinEventParams _params)
	{
		ManualSaving.SaveControl.Save(true, true, true);
	}
}