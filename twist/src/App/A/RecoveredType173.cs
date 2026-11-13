using System;

namespace a;

internal static class RecoveredType173
{
	public static bool RecoveredMethod578(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, bool P_6)
	{
		double num = P_0 + P_2 * P_4 - (P_1 + P_3 * Math.Min(P_4, 0.04));
		if (num > P_5)
		{
			return true;
		}
		if (num < 0.0 - P_5)
		{
			return false;
		}
		return P_6;
	}
}
