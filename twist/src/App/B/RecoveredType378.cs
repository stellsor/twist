using System;
using System.IO;
using A;
using a;
using c;

namespace B;

internal static class RecoveredType378
{
	private sealed class RecoveredType379 : RecoveredType247, RecoveredType246
	{
		public int RecoveredField1928;

		public int RecoveredField1929;

		public int AbsoluteCalls;

		public int RelativeCalls;

		public bool IgnoreAbsolute;

		public bool BlockAll;

		public bool LoseFocus;

		public RecoveredType304 RecoveredMethod677()
		{
			return new RecoveredType304
			{
				RecoveredField1628 = RecoveredField1928,
				RecoveredField1629 = RecoveredField1929
			};
		}

		public void RecoveredMethod679(int P_0, int P_1)
		{
			AbsoluteCalls++;
			if (!IgnoreAbsolute && !BlockAll)
			{
				RecoveredField1928 = P_0;
				RecoveredField1929 = P_1;
			}
		}

		public void RecoveredMethod678(int P_0, int P_1)
		{
			RelativeCalls++;
			if (!BlockAll)
			{
				RecoveredField1928 += P_0;
				RecoveredField1929 += P_1;
			}
		}

		public void RecoveredMethod50()
		{
			if (LoseFocus && AbsoluteCalls > 0)
			{
				throw new Exception("Focus lost");
			}
		}

		public void RecoveredMethod51()
		{
		}
	}

	private sealed class RecoveredType380 : RecoveredType117, RecoveredType248
	{
		public int Normal;

		public int Ui;

		public int Down;

		public bool Focused => true;

		public bool LeftIsDown => false;

		public void RecoveredMethod348(double P_0, double P_1)
		{
			Normal++;
		}

		public void RecoveredMethod672(double P_0, double P_1)
		{
			Ui++;
		}

		public void RecoveredMethod72(bool P_0)
		{
			if (P_0)
			{
				Down++;
			}
		}

		public void RecoveredMethod469(int P_0, bool P_1)
		{
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("UI pointer: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredType380 recoveredType = new RecoveredType380();
		using (RecoveredType245 recoveredType2 = new RecoveredType245(recoveredType, 8822))
		{
			recoveredType2.RecoveredMethod672(0.5, 0.8);
			recoveredType2.RecoveredMethod565(true, 0.5, 0.8);
			recoveredType2.RecoveredMethod565(false, 0.0, 0.0);
			RecoveredMethod42(recoveredType.Ui == 2 && recoveredType.Normal == 0 && recoveredType.Down == 1, "UI hover and click use the same absolute route");
			recoveredType2.RecoveredMethod45();
			recoveredType2.RecoveredMethod565(true, 0.5, 0.42);
			recoveredType2.RecoveredMethod565(false, 0.0, 0.0);
			RecoveredMethod42(recoveredType.Normal == 2 && recoveredType.Ui == 2 && recoveredType.Down == 2, "returning to cast point restores normal casting route");
		}
		RecoveredType379 recoveredType3 = new RecoveredType379();
		recoveredType3.RecoveredField1928 = 900;
		recoveredType3.RecoveredField1929 = 400;
		RecoveredType379 recoveredType4 = recoveredType3;
		RecoveredType377.RecoveredMethod870(recoveredType4, 500, 700);
		RecoveredMethod42(recoveredType4.RecoveredField1928 == 500 && recoveredType4.RecoveredField1929 == 700 && recoveredType4.AbsoluteCalls == 1 && recoveredType4.RelativeCalls == 0, "UI uses absolute movement first");
		RecoveredType377.RecoveredMethod870(recoveredType4, 500, 700);
		RecoveredMethod42(recoveredType4.AbsoluteCalls == 2, "settled pointer still emits UI hover movement");
		RecoveredType379 recoveredType5 = new RecoveredType379();
		RecoveredType377.RecoveredMethod870(recoveredType5, -1200, -200);
		RecoveredMethod42(recoveredType5.RecoveredField1928 == -1200 && recoveredType5.RecoveredField1929 == -200, "negative desktop origins preserved");
		RecoveredType379 recoveredType6 = new RecoveredType379();
		recoveredType6.IgnoreAbsolute = true;
		RecoveredType379 recoveredType7 = recoveredType6;
		RecoveredType377.RecoveredMethod870(recoveredType7, 500, 400);
		RecoveredMethod42(recoveredType7.AbsoluteCalls == 3 && recoveredType7.RelativeCalls > 0 && recoveredType7.RecoveredField1928 == 500 && recoveredType7.RecoveredField1929 == 400, "verified relative fallback if absolute movement is ignored");
		RecoveredType379 recoveredType8 = new RecoveredType379();
		recoveredType8.BlockAll = true;
		RecoveredType379 recoveredType9 = recoveredType8;
		bool flag = false;
		try
		{
			RecoveredType377.RecoveredMethod870(recoveredType9, 300, 400);
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag && recoveredType9.AbsoluteCalls == 3 && recoveredType9.RelativeCalls == 6, "locked cursor fails without authorizing a click");
		RecoveredType379 recoveredType10 = new RecoveredType379();
		recoveredType10.LoseFocus = true;
		RecoveredType379 recoveredType11 = recoveredType10;
		flag = false;
		try
		{
			RecoveredType377.RecoveredMethod870(recoveredType11, 100, 100);
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag && recoveredType11.AbsoluteCalls == 1 && recoveredType11.RelativeCalls == 0, "focus loss aborts before retry");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: absolute UI cursor path, always-emitted hover moves, negative origins, verified relative fallback, blocked cursor and focus loss. Simulated input only.\r\n");
	}
}
