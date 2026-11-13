using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace a;

internal sealed class RecoveredType296
{
	[CompilerGenerated]
	private sealed class RecoveredType297
	{
		public RecoveredType296 _003C_003E4__this;

		public IDictionary<string, string> before;

		public string prior;

		public string expected;

		public bool RecoveredMethod593(KeyValuePair<string, string> P_0)
		{
			if (P_0.Value == expected && before.ContainsKey(P_0.Key))
			{
				return before[P_0.Key] == prior;
			}
			return false;
		}
	}

	private readonly RecoveredType208 memory;

	public readonly ulong Node;

	private readonly Dictionary<string, RecoveredType295> slots = new Dictionary<string, RecoveredType295>();

	private RecoveredType295[] learned = new RecoveredType295[0];

	public string Description => string.Join(", ", learned.Select((RecoveredType295 P_0) => "TextBox +0x" + P_0.Offset.ToString("X") + (P_0.Indirect ? " indirect" : " inline")));

	public RecoveredType296(RecoveredType208 P_0, ulong P_1)
	{
		memory = P_0;
		Node = P_1;
	}

	private string RecoveredMethod472(ulong P_0)
	{
		if (!RecoveredType285.RecoveredMethod572(P_0))
		{
			return null;
		}
		byte[] array = memory.RecoveredMethod609(P_0, 32);
		if (array == null)
		{
			return null;
		}
		ulong num = BitConverter.ToUInt64(array, 16);
		ulong num2 = BitConverter.ToUInt64(array, 24);
		if (num > 8 || num2 < 15 || num2 > 4096 || num2 < num)
		{
			return null;
		}
		byte[] array2;
		if (num2 < 16)
		{
			array2 = array;
		}
		else
		{
			ulong num3 = BitConverter.ToUInt64(array, 0);
			if (!RecoveredType285.RecoveredMethod572(num3))
			{
				return null;
			}
			array2 = memory.RecoveredMethod609(num3, (int)num + 1);
			if (array2 == null)
			{
				return null;
			}
		}
		if (array2[(uint)num] != 0)
		{
			return null;
		}
		for (int i = 0; i < (int)num; i++)
		{
			if (array2[i] < 48 || array2[i] > 57)
			{
				return null;
			}
		}
		return Encoding.ASCII.GetString(array2, 0, (int)num);
	}

	private string RecoveredMethod767(RecoveredType295 P_0)
	{
		ulong num = Node + (ulong)P_0.Offset;
		if (P_0.Indirect)
		{
			byte[] array = memory.RecoveredMethod609(num, 8);
			if (array == null)
			{
				return null;
			}
			num = BitConverter.ToUInt64(array, 0);
		}
		return RecoveredMethod472(num);
	}

	public Dictionary<string, string> RecoveredMethod768()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 2048; i <= 6112; i += 8)
		{
			bool[] array = new bool[2] { false, true };
			foreach (bool indirect in array)
			{
				RecoveredType295 recoveredType = new RecoveredType295();
				recoveredType.Offset = i;
				recoveredType.Indirect = indirect;
				RecoveredType295 recoveredType2 = recoveredType;
				string text = RecoveredMethod767(recoveredType2);
				if (text != null)
				{
					slots[recoveredType2.Key] = recoveredType2;
					dictionary[recoveredType2.Key] = text;
				}
			}
		}
		return dictionary;
	}

	public bool RecoveredMethod769(IDictionary<string, string> P_0, IDictionary<string, string> P_1, string P_2 = "", string P_3 = "100")
	{
		learned = (from keyValuePair in P_1
			where keyValuePair.Value == P_3 && P_0.ContainsKey(keyValuePair.Key) && P_0[keyValuePair.Key] == P_2
			select slots[keyValuePair.Key]).ToArray();
		if (learned.Length > 0)
		{
			return learned.Length <= 16;
		}
		return false;
	}

	public string RecoveredMethod470()
	{
		if (learned.Length == 0 || learned.Length > 16)
		{
			return "";
		}
		string text = null;
		RecoveredType295[] array = learned;
		foreach (RecoveredType295 recoveredType in array)
		{
			string text2 = RecoveredMethod767(recoveredType);
			if (text2 == null || (text != null && text != text2))
			{
				return "";
			}
			text = text2;
		}
		return text ?? "";
	}

	[CompilerGenerated]
	private RecoveredType295 RecoveredMethod770(KeyValuePair<string, string> P_0)
	{
		return slots[P_0.Key];
	}

	[CompilerGenerated]
	private static string RecoveredMethod771(RecoveredType295 P_0)
	{
		return "TextBox +0x" + P_0.Offset.ToString("X") + (P_0.Indirect ? " indirect" : " inline");
	}
}
