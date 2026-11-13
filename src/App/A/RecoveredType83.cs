using System;

namespace A;

internal static class RecoveredType83
{
	public static string RecoveredMethod362(bool P_0, string P_1, Exception P_2)
	{
		if (!P_0 && P_2 != null)
		{
			return "Error";
		}
		string text = (P_1 ?? "").ToLowerInvariant();
		if (!P_0 || !(text != "") || text.Contains("user") || text.Contains("twist") || text.Contains("another client"))
		{
			return "Info";
		}
		return "Warning";
	}

	public static string RecoveredMethod363(bool P_0, string P_1, Exception P_2, string P_3)
	{
		return RecoveredType84.RecoveredMethod364((!P_0) ? ((P_2 != null) ? P_2.Message : (P_3 ?? "Fishing loop ended.")) : (string.IsNullOrEmpty(P_1) ? "Stopped by user." : P_1));
	}
}
