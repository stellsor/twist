using System;
using System.IO;
using System.Runtime.InteropServices;
using A;
using B;

namespace a;

internal static class RecoveredType293
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Native input packet: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredType378.RecoveredMethod45();
		RecoveredMethod42(RecoveredType292.RecoveredMethod765(500, 400, new RecoveredType126
		{
			Width = 1920,
			Height = 1080
		}).Data.Mouse.Flags == 57345, "UI absolute movement covers the virtual desktop and disables move coalescing");
		RecoveredType291 recoveredType = RecoveredType292.RecoveredMethod761(-240);
		RecoveredMethod42(recoveredType.Type == 0 && recoveredType.Data.Mouse.Flags == 2048 && recoveredType.Data.Mouse.Data == 4294967056u, "signed backpack wheel scroll");
		RecoveredType291 recoveredType2 = RecoveredType292.RecoveredMethod763(-17, 23);
		RecoveredMethod42(recoveredType2.Data.Mouse.Flags == 1 && recoveredType2.Data.Mouse.RecoveredField1576 == -17 && recoveredType2.Data.Mouse.RecoveredField1577 == 23, "relative movement preserves signed deltas without absolute-coordinate flags");
		RecoveredMethod42(Marshal.SizeOf(typeof(RecoveredType291)) == 40, "x64 size");
		RecoveredMethod42(Marshal.OffsetOf(typeof(RecoveredType291), "Data").ToInt32() == 8, "payload alignment");
		RecoveredType291 recoveredType3 = RecoveredType292.RecoveredMethod760(18u, true);
		RecoveredType291 recoveredType4 = RecoveredType292.RecoveredMethod760(18u, false);
		RecoveredMethod42(recoveredType3.Type == 1 && recoveredType3.Data.Key.Key == 0 && recoveredType3.Data.Key.Scan == 18 && recoveredType3.Data.Key.Flags == 8, "E scan-code key down");
		RecoveredMethod42(recoveredType4.Data.Key.Flags == 10 && recoveredType4.Data.Key.Scan == recoveredType3.Data.Key.Scan, "paired key up");
		RecoveredMethod42(RecoveredType292.RecoveredMethod760(57421u, true).Data.Key.Flags == 9, "extended key");
		RecoveredType126[] array = new RecoveredType126[2]
		{
			new RecoveredType126
			{
				Left = 0,
				Top = 0,
				Width = 1920,
				Height = 1080
			},
			new RecoveredType126
			{
				Left = -2560,
				Top = -300,
				Width = 6400,
				Height = 2460
			}
		};
		for (int i = 0; i < array.Length; i++)
		{
			RecoveredType126 recoveredType5 = array[i];
			int[] array2 = new int[3]
			{
				recoveredType5.Left,
				recoveredType5.Left + recoveredType5.Width / 2,
				recoveredType5.Left + recoveredType5.Width - 1
			};
			foreach (int num in array2)
			{
				RecoveredType291 recoveredType6 = RecoveredType292.RecoveredMethod766(num, recoveredType5.Top + recoveredType5.Height / 2, recoveredType5);
				int num2 = recoveredType5.Left + (int)((long)recoveredType6.Data.Mouse.RecoveredField1576 * (long)recoveredType5.Width / 65536);
				RecoveredMethod42(num2 == num, "absolute mouse pixel roundtrip including negative origins");
				RecoveredMethod42(recoveredType6.Data.Mouse.Flags == 49153, "absolute move uses this session's entire desktop");
			}
		}
		bool flag = false;
		try
		{
			RecoveredType292.RecoveredMethod766(-1, 0, new RecoveredType126
			{
				Width = 1920,
				Height = 1080
			});
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag, "out-of-desktop coordinates rejected");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: native scan-code E/down/up and extended-key packet layouts; aligned x64 INPUT; absolute mouse packets across session desktop and negative origins. Packets inspected only; no real input sent.\r\n");
	}
}
