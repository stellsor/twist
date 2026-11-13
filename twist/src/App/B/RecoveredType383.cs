using System;
using System.IO;
using A;
using a;

namespace B;

internal static class RecoveredType383
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("UI target geometry: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredType385.RecoveredMethod45();
		RecoveredType126 recoveredType = new RecoveredType126
		{
			Left = -1920,
			Top = 80,
			Width = 1920,
			Height = 1017
		};
		RecoveredType381 recoveredType2 = new RecoveredType381
		{
			RecoveredField1938 = 835.2,
			RecoveredField1939 = 737.325,
			Width = 249.6,
			Height = 31.14563
		};
		RecoveredMethod42(recoveredType2.RecoveredMethod872(recoveredType, out var num, out var num2), "bait row valid");
		recoveredType.RecoveredMethod496(num, num2, out var num3, out var num4);
		RecoveredMethod42(Math.Abs(num3 - recoveredType.Left - 960) <= 1 && Math.Abs(num4 - recoveredType.Top - 753) <= 1, "GUI pixels map directly into the worker client without template viewport scaling");
		RecoveredMethod42(!new RecoveredType381
		{
			RecoveredField1938 = 4000.0,
			RecoveredField1939 = 10.0,
			Width = 20.0,
			Height = 20.0
		}.RecoveredMethod872(recoveredType, out num, out num2), "off-client template rejected");
		RecoveredMethod42(!new RecoveredType381
		{
			RecoveredField1938 = double.NaN,
			RecoveredField1939 = 1.0,
			Width = 20.0,
			Height = 20.0
		}.RecoveredMethod872(recoveredType, out num, out num2), "non-finite geometry rejected");
		RecoveredType170 recoveredType3 = new RecoveredType170();
		recoveredType3.CastX = 0.25;
		recoveredType3.CastY = 0.42;
		RecoveredType170 recoveredType4 = recoveredType3;
		double num5 = (recoveredType2.RecoveredField1938 + recoveredType2.Width / 2.0) / (double)(recoveredType.Width - 1);
		double num6 = (recoveredType2.RecoveredField1939 + recoveredType2.Height / 2.0 + 58.0) / (double)(recoveredType.Height - 1);
		RecoveredType170 recoveredType5 = RecoveredType382.RecoveredMethod875(recoveredType4, recoveredType2, recoveredType, num5, num6);
		RecoveredMethod42(Math.Abs(recoveredType5.UiOffsetY - 58.0) < 0.001 && Math.Abs(recoveredType5.UiOffsetX) < 0.001 && recoveredType5.CastX == recoveredType4.CastX && recoveredType4.UiOffsetY == 0.0, "measured GUI offset preserves the cast point and source profile");
		RecoveredMethod42(RecoveredType382.RecoveredMethod874(recoveredType2, recoveredType5).RecoveredMethod872(recoveredType, out var num7, out var num8) && Math.Abs(num7 - num5) < 1E-05 && Math.Abs(num8 - num6) < 1E-05, "aligned geometry returns to the picked bait center");
		RecoveredMethod42(!recoveredType2.RecoveredMethod873(new RecoveredType381
		{
			RecoveredField1938 = recoveredType2.RecoveredField1938 + 20.0,
			RecoveredField1939 = recoveredType2.RecoveredField1939,
			Width = recoveredType2.Width,
			Height = recoveredType2.Height
		}), "moving animation has not settled");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: live UI pixel center mapping without root-template viewport scaling; negative window origin; invalid/off-client geometry and moving-layout rejection. No input sent.\r\n");
	}
}
