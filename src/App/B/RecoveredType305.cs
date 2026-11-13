using System;
using a;

namespace B;

internal static class RecoveredType305
{
	private static int RecoveredMethod776(int P_0, double P_1)
	{
		if (P_0 == 0)
		{
			return 0;
		}
		int num = (int)Math.Round((double)P_0 / P_1);
		if (num == 0)
		{
			num = Math.Sign(P_0);
		}
		return Math.Max(-32, Math.Min(32, num));
	}

	public static void RecoveredMethod777(RecoveredType246 P_0, int P_1, int P_2)
	{
		double num = 1.0;
		double num2 = 1.0;
		int num3 = 0;
		for (int i = 0; i < 100; i++)
		{
			P_0.RecoveredMethod50();
			RecoveredType304 recoveredType = P_0.RecoveredMethod677();
			int num4 = P_1 - recoveredType.RecoveredField1628;
			int num5 = P_2 - recoveredType.RecoveredField1629;
			if (Math.Abs(num4) <= 2 && Math.Abs(num5) <= 2)
			{
				return;
			}
			int num6 = RecoveredMethod776(num4, num);
			int num7 = RecoveredMethod776(num5, num2);
			P_0.RecoveredMethod678(num6, num7);
			P_0.RecoveredMethod51();
			P_0.RecoveredMethod50();
			RecoveredType304 recoveredType2 = P_0.RecoveredMethod677();
			if (recoveredType2.RecoveredField1628 == recoveredType.RecoveredField1628 && recoveredType2.RecoveredField1629 == recoveredType.RecoveredField1629)
			{
				if (++num3 >= 6)
				{
					throw new Exception("Relative mouse movement is blocked or the cursor is locked.");
				}
			}
			else
			{
				num3 = 0;
			}
			if (num6 != 0)
			{
				double num8 = (double)(recoveredType2.RecoveredField1628 - recoveredType.RecoveredField1628) / (double)num6;
				if (num8 > 0.2 && num8 < 8.0)
				{
					num = num8;
				}
			}
			if (num7 != 0)
			{
				double num9 = (double)(recoveredType2.RecoveredField1629 - recoveredType.RecoveredField1629) / (double)num7;
				if (num9 > 0.2 && num9 < 8.0)
				{
					num2 = num9;
				}
			}
		}
		throw new Exception("The worker cursor could not settle at the UI target using relative movement.");
	}
}
