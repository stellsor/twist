using System;
using A;
using a;

namespace B;

internal static class RecoveredType382
{
	public static RecoveredType381 RecoveredMethod874(RecoveredType381 P_0, RecoveredType170 P_1)
	{
		P_0.RecoveredField1938 += P_1.UiOffsetX;
		P_0.RecoveredField1939 += P_1.UiOffsetY;
		return P_0;
	}

	public static RecoveredType170 RecoveredMethod875(RecoveredType170 P_0, RecoveredType381 P_1, RecoveredType126 P_2, double P_3, double P_4)
	{
		if (double.IsNaN(P_3) || double.IsInfinity(P_3) || double.IsNaN(P_4) || double.IsInfinity(P_4) || P_3 < 0.0 || P_3 > 1.0 || P_4 < 0.0 || P_4 > 1.0 || P_2.Width < 10 || P_2.Height < 10)
		{
			throw new Exception("The alignment point is outside Roblox.");
		}
		RecoveredType170 recoveredType = P_0.RecoveredMethod568();
		recoveredType.UiOffsetX = P_3 * (double)(P_2.Width - 1) - (P_1.RecoveredField1938 + P_1.Width / 2.0);
		recoveredType.UiOffsetY = P_4 * (double)(P_2.Height - 1) - (P_1.RecoveredField1939 + P_1.Height / 2.0);
		recoveredType.RecoveredMethod50();
		return recoveredType;
	}
}
