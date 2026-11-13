using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace a;

internal sealed class RecoveredType285
{
	private sealed class RecoveredType286
	{
		public ulong Address;

		public string Parent;

		public int Depth;
	}

	[CompilerGenerated]
	private sealed class RecoveredType287
	{
		public string name;

		public bool RecoveredMethod39(string P_0)
		{
			return name.IndexOf(P_0, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}

	private readonly RecoveredType208 mem;

	private readonly RecoveredType280 RecoveredField1568;

	public int Failures;

	public bool Truncated;

	public RecoveredType285(RecoveredType208 P_0, RecoveredType280 P_1)
	{
		mem = P_0;
		RecoveredField1568 = P_1;
	}

	public static bool RecoveredMethod572(ulong P_0)
	{
		if (P_0 >= 65536)
		{
			return P_0 < 140737488355328L;
		}
		return false;
	}

	private byte[] RecoveredMethod609(ulong P_0, int P_1)
	{
		byte[] array = mem.RecoveredMethod609(P_0, P_1);
		if (array == null)
		{
			Failures++;
		}
		return array;
	}

	public ulong RecoveredMethod753(ulong P_0)
	{
		byte[] array = RecoveredMethod609(P_0, 8);
		if (array != null)
		{
			return BitConverter.ToUInt64(array, 0);
		}
		return 0uL;
	}

	public string RecoveredMethod475(ulong P_0)
	{
		if (!RecoveredMethod572(P_0))
		{
			return "";
		}
		ulong num = RecoveredMethod753(P_0 + RecoveredField1568.StringLength);
		if (num == 0 || num > 1024)
		{
			return "";
		}
		ulong num2 = ((num >= 16) ? RecoveredMethod753(P_0) : P_0);
		byte[] array = RecoveredMethod609(num2, (int)num);
		if (array == null)
		{
			return "";
		}
		string text = Encoding.UTF8.GetString(array);
		if (!text.Any((char c) => char.IsControl(c)))
		{
			return text;
		}
		return "";
	}

	public string RecoveredMethod754(ulong P_0)
	{
		return RecoveredMethod475(RecoveredMethod753(P_0 + RecoveredField1568.NameContainer) + RecoveredField1568.Name);
	}

	public string RecoveredMethod607(ulong P_0)
	{
		ulong num = RecoveredMethod753(P_0 + RecoveredField1568.ClassDescriptor);
		if (!RecoveredMethod572(num))
		{
			return "";
		}
		return RecoveredMethod475(RecoveredMethod753(num + RecoveredField1568.ClassName));
	}

	public List<ulong> RecoveredMethod755(ulong P_0)
	{
		List<ulong> list = new List<ulong>();
		ulong num = RecoveredMethod753(P_0 + RecoveredField1568.Children);
		if (!RecoveredMethod572(num))
		{
			return list;
		}
		ulong num2 = RecoveredMethod753(num);
		ulong num3 = RecoveredMethod753(num + RecoveredField1568.ChildrenEnd);
		if (num2 == 0 && num3 == 0)
		{
			return list;
		}
		if (!RecoveredMethod572(num2) || num3 < num2 || (num3 - num2) % 16 != 0 || num3 - num2 > 16000000)
		{
			Failures++;
			return list;
		}
		ulong num4 = (num3 - num2) / 16;
		if (num4 > 10000)
		{
			num4 = 10000uL;
			Truncated = true;
		}
		if (num4 == 0)
		{
			return list;
		}
		byte[] array = RecoveredMethod609(num2, (int)num4 * 16);
		if (array == null)
		{
			return list;
		}
		for (int i = 0; i < (int)num4; i++)
		{
			ulong num5 = BitConverter.ToUInt64(array, i * 16);
			if (RecoveredMethod572(num5))
			{
				list.Add(num5);
			}
		}
		return list;
	}

	public ulong RecoveredMethod756(ulong P_0, string P_1)
	{
		foreach (ulong item in RecoveredMethod755(P_0))
		{
			if (RecoveredMethod754(item) == P_1 || RecoveredMethod607(item) == P_1)
			{
				return item;
			}
		}
		return 0uL;
	}

	public ulong RecoveredMethod649(ulong P_0)
	{
		ulong num = RecoveredMethod753(P_0 + RecoveredField1568.FakePointer);
		ulong num2 = (RecoveredMethod572(num) ? RecoveredMethod753(num + RecoveredField1568.RealDataModel) : 0);
		if (!RecoveredMethod572(num2) || RecoveredMethod607(num2) != "DataModel")
		{
			throw new Exception("Could not resolve a valid DataModel. Join a game; the offsets may be outdated or the memory may be unreadable.");
		}
		return num2;
	}

	public ulong RecoveredMethod757(ulong P_0)
	{
		ulong num = RecoveredMethod756(P_0, "Players");
		if (!RecoveredMethod572(num))
		{
			throw new Exception("Players service is not readable. Join a game and try again.");
		}
		ulong num2 = RecoveredMethod753(num + RecoveredField1568.LocalPlayer);
		if (!RecoveredMethod572(num2))
		{
			throw new Exception("LocalPlayer is not available yet.");
		}
		ulong num3 = RecoveredMethod756(num2, "PlayerGui");
		if (!RecoveredMethod572(num3))
		{
			throw new Exception("Your PlayerGui is not available yet.");
		}
		return num3;
	}

	private string RecoveredMethod758(ulong P_0, string P_1)
	{
		ulong num;
		if (P_1 == "ScreenGui")
		{
			num = RecoveredField1568.Enabled;
		}
		else
		{
			if (!new string[10] { "Frame", "ScrollingFrame", "CanvasGroup", "TextLabel", "TextButton", "TextBox", "ImageLabel", "ImageButton", "ViewportFrame", "VideoFrame" }.Contains(P_1))
			{
				return "—";
			}
			num = RecoveredField1568.Visible;
		}
		byte[] array = RecoveredMethod609(P_0 + num, 1);
		if (array == null || array[0] > 1)
		{
			return "Unreadable";
		}
		return ((P_1 == "ScreenGui") ? "Enabled: " : "Visible: ") + ((array[0] == 1) ? "true" : "false");
	}

	public RecoveredType284 RecoveredMethod759(ulong P_0, string P_1, string[] P_2, CancellationToken P_3)
	{
		RecoveredType284 recoveredType = new RecoveredType284();
		recoveredType.Scope = P_1;
		RecoveredType284 recoveredType2 = recoveredType;
		HashSet<ulong> hashSet = new HashSet<ulong>();
		Queue<RecoveredType286> queue = new Queue<RecoveredType286>();
		queue.Enqueue(new RecoveredType286
		{
			Address = P_0,
			Parent = "",
			Depth = 0
		});
		Stopwatch stopwatch = Stopwatch.StartNew();
		while (queue.Count > 0)
		{
			P_3.ThrowIfCancellationRequested();
			if (recoveredType2.Nodes >= 500000 || stopwatch.ElapsedMilliseconds > 15000)
			{
				recoveredType2.Limited = true;
				break;
			}
			RecoveredType286 recoveredType3 = queue.Dequeue();
			if (!hashSet.Add(recoveredType3.Address))
			{
				continue;
			}
			recoveredType2.Nodes++;
			string name = RecoveredMethod754(recoveredType3.Address);
			string text = RecoveredMethod607(recoveredType3.Address);
			string text2 = (string.IsNullOrEmpty(name) ? "[unnamed]" : name.Replace("/", "\\/"));
			string text3 = (string.IsNullOrEmpty(recoveredType3.Parent) ? text2 : (recoveredType3.Parent + "/" + text2));
			if (P_2.Any((string value) => name.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0))
			{
				recoveredType2.Hits.Add(new RecoveredType283
				{
					Name = name,
					Class = text,
					Path = text3,
					Address = recoveredType3.Address,
					State = RecoveredMethod758(recoveredType3.Address, text)
				});
			}
			List<ulong> list = RecoveredMethod755(recoveredType3.Address);
			if (recoveredType3.Depth >= 64)
			{
				if (list.Count > 0)
				{
					recoveredType2.Limited = true;
				}
				continue;
			}
			foreach (ulong item in list)
			{
				if (queue.Count >= 500000)
				{
					recoveredType2.Limited = true;
					break;
				}
				queue.Enqueue(new RecoveredType286
				{
					Address = item,
					Parent = text3,
					Depth = recoveredType3.Depth + 1
				});
			}
		}
		recoveredType2.Failures = Failures;
		recoveredType2.Limited |= Truncated;
		return recoveredType2;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod530(char P_0)
	{
		return char.IsControl(P_0);
	}
}
