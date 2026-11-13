using System.IO;
using System.Web.Script.Serialization;

namespace B;

internal sealed class RecoveredType342
{
	public bool HardwareAcceleration = true;

	public static RecoveredType342 RecoveredMethod834(string P_0)
	{
		try
		{
			return new JavaScriptSerializer().Deserialize<RecoveredType342>(File.ReadAllText(Path.Combine(P_0, "ui-preferences.json"))) ?? new RecoveredType342();
		}
		catch
		{
			return new RecoveredType342();
		}
	}

	public void RecoveredMethod414(string P_0)
	{
		RecoveredType351.RecoveredMethod82(Path.Combine(P_0, "ui-preferences.json"), new JavaScriptSerializer().Serialize(this));
	}
}
