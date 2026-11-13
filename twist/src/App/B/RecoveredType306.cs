using System;
using System.IO;
using a;

namespace B;

internal static class RecoveredType306
{
	private sealed class RecoveredType307 : RecoveredType246
	{
		public int RecoveredField1630;

		public int RecoveredField1631;

		public int Calls;

		public double Gain = 1.0;

		public bool Block;

		public bool FocusLost;

		public RecoveredType304 RecoveredMethod677()
		{
			return new RecoveredType304
			{
				RecoveredField1628 = RecoveredField1630,
				RecoveredField1629 = RecoveredField1631
			};
		}

		public void RecoveredMethod678(int P_0, int P_1)
		{
			Calls++;
			if (!Block)
			{
				RecoveredField1630 += (int)Math.Round((double)P_0 * Gain);
				RecoveredField1631 += (int)Math.Round((double)P_1 * Gain);
			}
		}

		public void RecoveredMethod50()
		{
			if (FocusLost && Calls > 0)
			{
				throw new Exception("focus lost");
			}
		}

		public void RecoveredMethod51()
		{
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Relative pointer: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		double[] array = new double[5] { 0.5, 1.0, 1.5, 2.0, 3.0 };
		foreach (double gain in array)
		{
			RecoveredType307 recoveredType = new RecoveredType307();
			recoveredType.RecoveredField1630 = -1800;
			recoveredType.RecoveredField1631 = 100;
			recoveredType.Gain = gain;
			RecoveredType307 recoveredType2 = recoveredType;
			RecoveredType305.RecoveredMethod777(recoveredType2, -1280, 620);
			RecoveredMethod42(Math.Abs(recoveredType2.RecoveredField1630 + 1280) <= 2 && Math.Abs(recoveredType2.RecoveredField1631 - 620) <= 2 && recoveredType2.Calls > 0, "converges with acceleration/negative monitor coordinates");
			int calls = recoveredType2.Calls;
			RecoveredType305.RecoveredMethod777(recoveredType2, -1280, 620);
			RecoveredMethod42(recoveredType2.Calls == calls, "settled cursor sends no movement packets");
		}
		RecoveredType307 recoveredType3 = new RecoveredType307();
		recoveredType3.Block = true;
		RecoveredType307 recoveredType4 = recoveredType3;
		bool flag = false;
		try
		{
			RecoveredType305.RecoveredMethod777(recoveredType4, 100, 100);
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag && recoveredType4.Calls == 6, "blocked cursor stops before clicking");
		RecoveredType307 recoveredType5 = new RecoveredType307();
		recoveredType5.FocusLost = true;
		RecoveredType307 recoveredType6 = recoveredType5;
		flag = false;
		try
		{
			RecoveredType305.RecoveredMethod777(recoveredType6, 100, 100);
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag && recoveredType6.Calls == 1, "focus loss stops movement immediately");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: relative-pointer feedback convergence with multiple acceleration factors and negative origins; already-settled cursor, blocked cursor and focus-loss interruption. Simulated motion only; no real input sent.\r\n");
	}
}
