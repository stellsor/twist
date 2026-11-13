using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace a;

internal static class RecoveredType298
{
	private sealed class RecoveredType299 : RecoveredType208
	{
		private readonly Dictionary<ulong, byte> bytes = new Dictionary<ulong, byte>();

		public byte[] RecoveredMethod609(ulong P_0, int P_1)
		{
			byte[] array = new byte[P_1];
			for (int i = 0; i < P_1; i++)
			{
				if (!bytes.TryGetValue(P_0 + (ulong)i, out var value))
				{
					return null;
				}
				array[i] = value;
			}
			return array;
		}

		public void RecoveredMethod610(ulong P_0, byte[] P_1)
		{
			for (int i = 0; i < P_1.Length; i++)
			{
				bytes[P_0 + (ulong)i] = P_1[i];
			}
		}

		public void RecoveredMethod613(ulong P_0, string P_1)
		{
			byte[] array = new byte[32];
			Encoding.ASCII.GetBytes(P_1).CopyTo(array, 0);
			BitConverter.GetBytes((ulong)P_1.Length).CopyTo(array, 16);
			BitConverter.GetBytes(15uL).CopyTo(array, 24);
			RecoveredMethod610(P_0, array);
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Quantity text reader: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredType299 recoveredType = new RecoveredType299();
		recoveredType.RecoveredMethod610(1050624uL, new byte[4096]);
		recoveredType.RecoveredMethod613(1052216uL, "100");
		recoveredType.RecoveredMethod613(1052576uL, "1");
		RecoveredType296 recoveredType2 = new RecoveredType296(recoveredType, 1048576uL);
		recoveredType.RecoveredMethod613(1052576uL, "");
		Dictionary<string, string> dictionary = recoveredType2.RecoveredMethod768();
		recoveredType.RecoveredMethod613(1052576uL, "100");
		Dictionary<string, string> dictionary2 = recoveredType2.RecoveredMethod768();
		RecoveredMethod42(recoveredType2.RecoveredMethod769(dictionary, dictionary2) && recoveredType2.RecoveredMethod470() == "100", "learns changed TextBox storage instead of stale label-offset value");
		recoveredType.RecoveredMethod613(1052576uL, "10");
		RecoveredMethod42(recoveredType2.RecoveredMethod470() == "10", "later edits invalidate the 100 check");
		RecoveredType296 recoveredType3 = new RecoveredType296(recoveredType, 1048576uL);
		Dictionary<string, string> dictionary3 = recoveredType3.RecoveredMethod768();
		RecoveredMethod42(!recoveredType3.RecoveredMethod769(dictionary3, dictionary3) && recoveredType3.RecoveredMethod470() == "", "unchanged unrelated 100 is never sufficient");
		recoveredType.RecoveredMethod610(1052776uL, BitConverter.GetBytes(2097152uL));
		recoveredType.RecoveredMethod613(2097152uL, "");
		RecoveredType296 recoveredType4 = new RecoveredType296(recoveredType, 1048576uL);
		dictionary = recoveredType4.RecoveredMethod768();
		recoveredType.RecoveredMethod613(2097152uL, "100");
		dictionary2 = recoveredType4.RecoveredMethod768();
		RecoveredMethod42(recoveredType4.RecoveredMethod769(dictionary, dictionary2) && recoveredType4.RecoveredMethod470() == "100", "supports indirection while requiring observed empty-to-100 transition");
		recoveredType.RecoveredMethod613(2097152uL, "999");
		RecoveredMethod42(recoveredType4.RecoveredMethod470() == "999", "indirect edits read live");
		recoveredType.RecoveredMethod613(1052576uL, "37");
		RecoveredType296 recoveredType5 = new RecoveredType296(recoveredType, 1048576uL);
		Dictionary<string, string> dictionary4 = recoveredType5.RecoveredMethod768();
		recoveredType.RecoveredMethod613(1052576uL, "100");
		RecoveredMethod42(recoveredType5.RecoveredMethod769(dictionary4, recoveredType5.RecoveredMethod768(), "37") && recoveredType5.RecoveredMethod470() == "100", "two concrete edits verify quantity when the game immediately restores an empty field");
		recoveredType.RecoveredMethod613(1052576uL, "37");
		RecoveredMethod42(recoveredType5.RecoveredMethod470() == "37", "probe value itself never authorizes purchase");
		recoveredType.RecoveredMethod613(1052576uL, "37");
		RecoveredType296 recoveredType6 = new RecoveredType296(recoveredType, 1048576uL);
		Dictionary<string, string> dictionary5 = recoveredType6.RecoveredMethod768();
		recoveredType.RecoveredMethod613(1052576uL, "250");
		RecoveredMethod42(recoveredType6.RecoveredMethod769(dictionary5, recoveredType6.RecoveredMethod768(), "37", "250") && recoveredType6.RecoveredMethod470() == "250", "custom purchase amounts use verified edits");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: quantity TextBox storage learning from clear-to-100 transition, differing label/TextBox layouts, stale unrelated 100 rejection, direct and indirect live edits. Synthetic memory only; no game input.\r\n");
	}
}
