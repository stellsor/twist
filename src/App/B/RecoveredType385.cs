using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using a;

namespace B;

internal static class RecoveredType385
{
	private sealed class RecoveredType386 : RecoveredType208
	{
		private readonly Dictionary<ulong, byte> bytes = new Dictionary<ulong, byte>();

		public byte[] RecoveredMethod609(ulong P_0, int P_1)
		{
			byte[] array = new byte[P_1];
			for (int i = 0; i < P_1; i++)
			{
				if (!bytes.TryGetValue(P_0 + (ulong)i, out array[i]))
				{
					return null;
				}
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
			byte[] array = Encoding.UTF8.GetBytes(P_1);
			byte[] array2 = new byte[32];
			if (array.Length < 16)
			{
				array.CopyTo(array2, 0);
				BitConverter.GetBytes(15uL).CopyTo(array2, 24);
			}
			else
			{
				ulong num = P_0 + 65536;
				byte[] second = new byte[1];
				RecoveredMethod610(num, array.Concat(second).ToArray());
				BitConverter.GetBytes(num).CopyTo(array2, 0);
				BitConverter.GetBytes((ulong)array.Length).CopyTo(array2, 24);
			}
			BitConverter.GetBytes((ulong)array.Length).CopyTo(array2, 16);
			RecoveredMethod610(P_0, array2);
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("UI text layout: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredType163 recoveredType = new RecoveredType163(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "offsets.json")));
		RecoveredType386 recoveredType2 = new RecoveredType386();
		recoveredType2.RecoveredMethod610(1048576 + recoveredType.Core.ClassDescriptor, BitConverter.GetBytes(2097152uL));
		recoveredType2.RecoveredMethod610(2097152 + recoveredType.Core.ClassName, BitConverter.GetBytes(3145728uL));
		recoveredType2.RecoveredMethod613(3145728uL, "TextLabel");
		RecoveredType285 recoveredType3 = new RecoveredType285(recoveredType2, recoveredType.Core);
		RecoveredType384 recoveredType4 = new RecoveredType384(recoveredType2, recoveredType3, "version-5a21b87bbc2641cf");
		recoveredType2.RecoveredMethod613(1051552uL, "Store Fruit");
		recoveredType2.RecoveredMethod613(1052216uL, "wrong stale value");
		RecoveredMethod42(recoveredType4.RecoveredMethod636(1048576uL) == "Store Fruit", "current live label uses canonical text instead of stale legacy layout");
		recoveredType2.RecoveredMethod613(1051552uL, "1");
		RecoveredMethod42(recoveredType4.RecoveredMethod636(1048576uL) == "1", "hotbar number uses current layout");
		recoveredType2.RecoveredMethod613(1051552uL, "");
		RecoveredMethod42(recoveredType4.RecoveredMethod636(1048576uL) == "", "valid empty current text never falls back to stale nonempty text");
		recoveredType2.RecoveredMethod613(3145728uL, "TextBox");
		recoveredType2.RecoveredMethod613(1051544uL, "100");
		RecoveredMethod42(recoveredType4.RecoveredMethod636(1048576uL) == "100", "current TextBox uses separately verified quantity layout");
		recoveredType2.RecoveredMethod613(3145728uL, "TextButton");
		recoveredType2.RecoveredMethod613(1052192uL, "Buy");
		RecoveredMethod42(recoveredType4.RecoveredMethod636(1048576uL) == "Buy", "current TextButton uses separately verified Buy layout");
		recoveredType2.RecoveredMethod613(3145728uL, "TextLabel");
		RecoveredType384 recoveredType5 = new RecoveredType384(recoveredType2, recoveredType3, "version-9ac8595712b447a7");
		recoveredType2.RecoveredMethod613(1052216uL, "Store Fruit");
		RecoveredMethod42(recoveredType5.RecoveredMethod636(1048576uL) == "Store Fruit", "older verified build keeps its own layout");
		RecoveredType384 recoveredType6 = new RecoveredType384(recoveredType2, recoveredType3, "version-1111111111111111");
		recoveredType2.RecoveredMethod613(1051552uL, "Common Fish Bait");
		recoveredType2.RecoveredMethod613(1052168uL, "Other vendor");
		RecoveredMethod42(recoveredType6.RecoveredMethod636(1048576uL) == "", "unknown build rejects disagreeing copies");
		recoveredType2.RecoveredMethod613(1052168uL, "Common Fish Bait");
		RecoveredMethod42(recoveredType6.RecoveredMethod636(1048576uL) == "Common Fish Bait", "unknown build requires matching canonical/rendered copies");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: live-version UI caption/hotbar text layout, legacy layout isolation, valid empty text, unknown-layout agreement and stale-value rejection. Synthetic memory only.\r\n");
	}
}
