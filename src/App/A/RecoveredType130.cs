using System;
using System.IO;
using a;

namespace A;

internal static class RecoveredType130
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Cursor regression: " + P_1);
		}
	}

	private static void RecoveredMethod508(RecoveredType126 P_0, int P_1, int P_2)
	{
		RecoveredMethod42(P_0.RecoveredMethod495(P_1, P_2, out var num, out var num2), "Point is inside worker client");
		P_0.RecoveredMethod496(num, num2, out var num3, out var num4);
		RecoveredMethod42(num3 == P_1 && num4 == P_2, "Physical pick/playback roundtrip");
	}

	public static void RecoveredMethod45()
	{
		RecoveredMethod508(new RecoveredType126
		{
			Left = 200,
			Top = 80,
			Width = 1920,
			Height = 1080
		}, 1160, 620);
		RecoveredMethod508(new RecoveredType126
		{
			Left = -2560,
			Top = 160,
			Width = 2560,
			Height = 1440
		}, -1280, 880);
		RecoveredMethod508(new RecoveredType126
		{
			Left = 2880,
			Top = -300,
			Width = 3840,
			Height = 2160
		}, 4800, 780);
		RecoveredType126 recoveredType = new RecoveredType126
		{
			Left = 300,
			Top = 100,
			Width = 2880,
			Height = 1620
		};
		RecoveredMethod42(recoveredType.RecoveredMethod495(1740, 910, out var num, out var num2) && Math.Abs(num - 0.5) < 0.001 && Math.Abs(num2 - 0.5) < 0.001, "150 percent scaled center remains center");
		RecoveredType170 recoveredType2 = new RecoveredType170();
		recoveredType2.CastX = 0.09;
		recoveredType2.CastY = 0.25;
		recoveredType2.BaitMode = "best";
		recoveredType2.StopAfterRounds = 7;
		recoveredType2.AutoRestockCommon = false;
		recoveredType2.AutoStoreFruits = false;
		recoveredType2.DropDuplicateFruits = false;
		RecoveredType170 recoveredType3 = recoveredType2;
		RecoveredType170 recoveredType4 = new RecoveredType170();
		recoveredType4.CastX = 0.5;
		recoveredType4.CastY = 0.42;
		recoveredType4.UiOffsetY = 58.0;
		RecoveredType170 recoveredType5 = recoveredType4;
		RecoveredType170 recoveredType6 = new RecoveredType170();
		recoveredType6.CastX = 0.73;
		recoveredType6.CastY = 0.61;
		RecoveredType170 recoveredType7 = recoveredType6;
		RecoveredType170 recoveredType8 = RecoveredType129.RecoveredMethod507(recoveredType3, recoveredType5);
		RecoveredType170 recoveredType9 = RecoveredType129.RecoveredMethod507(recoveredType3, recoveredType7);
		RecoveredMethod42(recoveredType8.CastX == 0.5 && recoveredType8.CastY == 0.42 && recoveredType9.CastX == 0.73 && recoveredType9.CastY == 0.61, "Stale controller coordinates cannot overwrite either worker");
		RecoveredMethod42(recoveredType8.UiOffsetY == 58.0 && recoveredType9.UiOffsetY == 0.0, "Worker UI alignment remains independent from controller settings");
		RecoveredMethod42(recoveredType8.BaitMode == "best" && recoveredType8.StopAfterRounds == 7 && !recoveredType8.AutoRestockCommon, "Other controller settings still apply");
		RecoveredMethod42(!recoveredType8.AutoStoreFruits && !recoveredType8.DropDuplicateFruits, "Fruit settings transfer without changing worker-owned coordinates");
		RecoveredMethod42(recoveredType3.CastX == 0.09 && recoveredType5.CastX == 0.5, "Settings objects remain independent");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: worker-owned cast points reject stale controller coordinates; independent worker points; physical screen/client roundtrips with offsets, negative monitor origins, 150 percent scaling and differing resolutions. No mouse movement or hook installation in these tests.\r\n");
	}
}
