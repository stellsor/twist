using System;
using c;

namespace B;

internal static class RecoveredType377
{
	public static void RecoveredMethod870(RecoveredType247 P_0, int P_1, int P_2)
	{
		for (int i = 0; i < 3; i++)
		{
			P_0.RecoveredMethod50();
			P_0.RecoveredMethod679(P_1, P_2);
			P_0.RecoveredMethod51();
			P_0.RecoveredMethod50();
			RecoveredType304 recoveredType = P_0.RecoveredMethod677();
			if (Math.Abs(recoveredType.RecoveredField1628 - P_1) <= 2 && Math.Abs(recoveredType.RecoveredField1629 - P_2) <= 2)
			{
				return;
			}
		}
		RecoveredType305.RecoveredMethod777(P_0, P_1, P_2);
		P_0.RecoveredMethod50();
		RecoveredType304 recoveredType2 = P_0.RecoveredMethod677();
		if (Math.Abs(recoveredType2.RecoveredField1628 - P_1) > 2 || Math.Abs(recoveredType2.RecoveredField1629 - P_2) > 2)
		{
			throw new Exception("The UI cursor did not reach the control; no click sent.");
		}
	}
}
