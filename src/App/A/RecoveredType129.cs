using System;
using B;
using a;

namespace A;

internal static class RecoveredType129
{
	public static RecoveredType170 RecoveredMethod507(RecoveredType170 P_0, RecoveredType170 P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			throw new Exception("Fishing settings are not ready.");
		}
		RecoveredType170 recoveredType = P_0.RecoveredMethod568();
		recoveredType.CastX = P_1.CastX;
		recoveredType.CastY = P_1.CastY;
		recoveredType.UiOffsetX = P_1.UiOffsetX;
		recoveredType.UiOffsetY = P_1.UiOffsetY;
		RecoveredType322.RecoveredMethod128(recoveredType);
		return recoveredType;
	}
}
