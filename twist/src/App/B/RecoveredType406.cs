using System;
using TwistApp;
using a;

namespace b;

internal static class RecoveredType406
{
	public static bool RecoveredMethod39(string P_0)
	{
		return (P_0 ?? "").IndexOf("All Seeing", StringComparison.OrdinalIgnoreCase) >= 0;
	}

	public static bool RecoveredMethod885(RecoveredType405 P_0)
	{
		if (P_0 != null && RecoveredType219.RecoveredMethod39(P_0.Name) && P_0.Position != null && P_0.Position.Valid && P_0.HoldSeconds.HasValue && WorldPoint.Finite(P_0.HoldSeconds.Value) && P_0.HoldSeconds.Value >= 0.0)
		{
			return P_0.HoldSeconds.Value <= 0.01;
		}
		return false;
	}
}
