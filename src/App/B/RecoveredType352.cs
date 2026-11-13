using System.IO;
using System.Web.Script.Serialization;

namespace B;

internal sealed class RecoveredType352
{
	public bool AutoWorkers = true;

	public int Port;

	public static RecoveredType352 RecoveredMethod846(string P_0)
	{
		try
		{
			RecoveredType352 recoveredType = new JavaScriptSerializer().Deserialize<RecoveredType352>(File.ReadAllText(Path.Combine(P_0, "controller-preferences.json")));
			if (recoveredType != null && (recoveredType.Port == 0 || (recoveredType.Port >= 1024 && recoveredType.Port <= 65535)))
			{
				return recoveredType;
			}
		}
		catch
		{
		}
		return new RecoveredType352();
	}
}
