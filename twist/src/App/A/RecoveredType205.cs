using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TwistApp;

namespace a;

internal static class RecoveredType205
{
	private sealed class RecoveredType206 : RecoveredType208
	{
		private readonly Dictionary<ulong, byte> data = new Dictionary<ulong, byte>();

		private ulong next = 1048576uL;

		private readonly RecoveredType163 map;

		public RecoveredType206(RecoveredType163 P_0)
		{
			map = P_0;
		}

		public byte[] RecoveredMethod609(ulong P_0, int P_1)
		{
			byte[] array = new byte[P_1];
			for (int i = 0; i < P_1; i++)
			{
				if (!data.TryGetValue(P_0 + (ulong)i, out array[i]))
				{
					return null;
				}
			}
			return array;
		}

		private void RecoveredMethod610(ulong P_0, byte[] P_1)
		{
			for (int i = 0; i < P_1.Length; i++)
			{
				data[P_0 + (ulong)i] = P_1[i];
			}
		}

		private ulong RecoveredMethod611()
		{
			ulong num = next;
			next += 65536uL;
			RecoveredMethod610(num, new byte[4096]);
			return num;
		}

		private void RecoveredMethod612(ulong P_0, ulong P_1)
		{
			RecoveredMethod610(P_0, BitConverter.GetBytes(P_1));
		}

		private void RecoveredMethod613(ulong P_0, string P_1)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(P_1);
			RecoveredMethod610(P_0, new byte[32]);
			if (bytes.Length < 16)
			{
				RecoveredMethod610(P_0, bytes);
				RecoveredMethod612(P_0 + 24, 15uL);
			}
			else
			{
				ulong num = RecoveredMethod611();
				byte[] second = new byte[1];
				RecoveredMethod610(num, bytes.Concat(second).ToArray());
				RecoveredMethod612(P_0, num);
				RecoveredMethod612(P_0 + 24, (ulong)bytes.Length);
			}
			RecoveredMethod612(P_0 + 16, (ulong)bytes.Length);
		}

		public ulong RecoveredMethod554(string P_0, string P_1)
		{
			ulong num = RecoveredMethod611();
			ulong num2 = RecoveredMethod611();
			ulong num3 = RecoveredMethod611();
			ulong num4 = RecoveredMethod611();
			RecoveredMethod612(num + map.Core.NameContainer, num2);
			RecoveredMethod613(num2 + map.Core.Name, P_0);
			RecoveredMethod612(num + map.Core.ClassDescriptor, num3);
			RecoveredMethod612(num3 + map.Core.ClassName, num4);
			RecoveredMethod613(num4, P_1);
			return num;
		}

		public void RecoveredMethod614(ulong P_0, string P_1)
		{
			RecoveredMethod613(P_0 + 2976, P_1);
			RecoveredMethod613(P_0 + 3640, P_1);
			RecoveredMethod613(P_0 + 3592, P_1);
		}

		public void RecoveredMethod615(ulong P_0, params ulong[] children)
		{
			ulong num = RecoveredMethod611();
			ulong num2 = RecoveredMethod611();
			RecoveredMethod612(P_0 + map.Core.Children, num);
			RecoveredMethod612(num, num2);
			RecoveredMethod612(num + map.Core.ChildrenEnd, num2 + (ulong)((long)children.Length * 16L));
			for (int i = 0; i < children.Length; i++)
			{
				RecoveredMethod612(num2 + (ulong)((long)i * 16L), children[i]);
				RecoveredMethod612(children[i] + map.RecoveredMethod554("Instance", "Parent"), P_0);
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType207
	{
		public RecoveredType206 memory;

		public ulong sphere;

		public WorldPoint point;

		public ulong RecoveredMethod616(string P_0, int P_1)
		{
			ulong num = memory.RecoveredMethod554("Group" + (P_1 + 1).ToString("000"), "TextLabel");
			memory.RecoveredMethod614(num, P_0);
			ulong num2 = memory.RecoveredMethod554("Char001", "TextLabel");
			memory.RecoveredMethod614(num2, P_0);
			memory.RecoveredMethod615(num, num2);
			return num;
		}

		public WorldPoint RecoveredMethod617(ulong P_0)
		{
			if (P_0 != sphere)
			{
				return null;
			}
			return point;
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredType163 recoveredType = new RecoveredType163(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "offsets.json")));
		RecoveredType206 memory = new RecoveredType206(recoveredType);
		RecoveredType285 recoveredType2 = new RecoveredType285(memory, recoveredType.Core);
		ulong num = memory.RecoveredMethod554("PlayerGui", "PlayerGui");
		ulong num2 = memory.RecoveredMethod554("Notifications", "ScreenGui");
		ulong num3 = memory.RecoveredMethod554("Frame", "Frame");
		ulong num4 = memory.RecoveredMethod554("TextLabel", "Frame");
		ulong num5 = memory.RecoveredMethod554("Line001", "Frame");
		ulong num6 = memory.RecoveredMethod554("Container", "Frame");
		memory.RecoveredMethod615(num, num2);
		memory.RecoveredMethod615(num2, num3);
		memory.RecoveredMethod615(num3, num4);
		memory.RecoveredMethod615(num4, num5);
		memory.RecoveredMethod615(num5, num6);
		string[] source = new string[13]
		{
			"A", " ", "SUKE", " ", "has", " ", "spawned", " ", "at", " ",
			"FISHING", " ", "HUB"
		};
		ulong[] children = source.Select(delegate(string P_0, int P_1)
		{
			ulong num12 = memory.RecoveredMethod554("Group" + (P_1 + 1).ToString("000"), "TextLabel");
			memory.RecoveredMethod614(num12, P_0);
			ulong num13 = memory.RecoveredMethod554("Char001", "TextLabel");
			memory.RecoveredMethod614(num13, P_0);
			memory.RecoveredMethod615(num12, num13);
			return num12;
		}).Reverse().ToArray();
		memory.RecoveredMethod615(num6, children);
		ulong num7 = memory.RecoveredMethod554("Workspace", "Workspace");
		ulong num8 = memory.RecoveredMethod554("Effects", "Folder");
		ulong sphere = memory.RecoveredMethod554("sphere", "Part");
		ulong num9 = memory.RecoveredMethod554("BillboardGui", "BillboardGui");
		ulong num10 = memory.RecoveredMethod554("d", "BillboardGui");
		ulong num11 = memory.RecoveredMethod554("sphere", "Part");
		memory.RecoveredMethod615(num7, num8);
		memory.RecoveredMethod615(num8, sphere, num11);
		memory.RecoveredMethod615(sphere, num9, num10);
		memory.RecoveredMethod615(num11);
		WorldPoint point = new WorldPoint
		{
			RecoveredField2015 = -300.378143,
			RecoveredField2016 = 24.2176819,
			RecoveredField2017 = -1939.673
		};
		RecoveredType204 recoveredType3 = new RecoveredType204(memory, recoveredType2, recoveredType, (ulong P_0) => (P_0 != sphere) ? null : point);
		RecoveredType194[] array = recoveredType3.RecoveredMethod604(num);
		RecoveredType195[] array2 = recoveredType3.RecoveredMethod605(num7);
		if (array.Length != 1 || array[0].Text != "A SUKE has spawned at FISHING HUB" || array2.Length != 1 || array2[0].Position.Compact != "-301, 24, -1940")
		{
			throw new Exception("Actual Eye reader did not reconstruct captured hierarchy and reject unrelated sphere.");
		}
		Console.WriteLine("PASS: actual Eye reader over captured notification/pulse hierarchy, reversed rich-text groups, duplicate character nodes and unrelated combat sphere. Synthetic memory only.");
	}
}
