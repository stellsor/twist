using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using B;
using TwistApp;

namespace a;

internal sealed class RecoveredType204
{
	private readonly RecoveredType208 memory;

	private readonly RecoveredType285 reader;

	private readonly RecoveredType163 map;

	private readonly RecoveredType384 text;

	private readonly Func<ulong, WorldPoint> point;

	public RecoveredType204(RecoveredType208 P_0, RecoveredType285 P_1, RecoveredType163 P_2, Func<ulong, WorldPoint> P_3)
	{
		memory = P_0;
		reader = P_1;
		map = P_2;
		text = new RecoveredType384(P_0, P_1, map.Core.Version);
		point = P_3;
	}

	private string RecoveredMethod472(ulong P_0)
	{
		string text = this.text.RecoveredMethod636(P_0);
		if (RecoveredType196.RecoveredMethod591("", text) != null)
		{
			return text;
		}
		IOrderedEnumerable<ulong> source = (from num in reader.RecoveredMethod755(P_0)
			where Regex.IsMatch(reader.RecoveredMethod754(num), "^Line[0-9]+$")
			select num).OrderBy(reader.RecoveredMethod754, StringComparer.Ordinal);
		return string.Join(" ", source.Select(delegate(ulong num2)
		{
			ulong num = reader.RecoveredMethod756(num2, "Container");
			return RecoveredType196.RecoveredMethod592(from num3 in reader.RecoveredMethod755(num)
				select new KeyValuePair<string, string>(reader.RecoveredMethod754(num3), this.text.RecoveredMethod636(num3)));
		}));
	}

	public RecoveredType194[] RecoveredMethod604(ulong P_0)
	{
		ulong num = reader.RecoveredMethod756(P_0, "Notifications");
		if (!RecoveredType285.RecoveredMethod572(num))
		{
			return new RecoveredType194[0];
		}
		List<RecoveredType194> list = new List<RecoveredType194>();
		Queue<Tuple<ulong, int>> queue = new Queue<Tuple<ulong, int>>();
		queue.Enqueue(Tuple.Create(num, 0));
		int num2 = 0;
		while (queue.Count > 0 && num2++ < 2000)
		{
			Tuple<ulong, int> tuple = queue.Dequeue();
			string text = RecoveredMethod472(tuple.Item1);
			RecoveredType194 recoveredType = RecoveredType196.RecoveredMethod591(tuple.Item1.ToString("X"), text);
			if (recoveredType != null)
			{
				list.Add(recoveredType);
			}
			else
			{
				if (tuple.Item2 >= 4)
				{
					continue;
				}
				foreach (ulong item in reader.RecoveredMethod755(tuple.Item1))
				{
					queue.Enqueue(Tuple.Create(item, tuple.Item2 + 1));
				}
			}
		}
		return list.ToArray();
	}

	public RecoveredType195[] RecoveredMethod605(ulong P_0)
	{
		List<RecoveredType195> list = new List<RecoveredType195>();
		ulong num = reader.RecoveredMethod756(P_0, "Effects");
		foreach (ulong item in reader.RecoveredMethod755(num))
		{
			if (reader.RecoveredMethod607(item) != "Part" || reader.RecoveredMethod754(item) != "sphere")
			{
				continue;
			}
			ulong[] source = (from num2 in reader.RecoveredMethod755(item)
				where reader.RecoveredMethod607(num2) == "BillboardGui"
				select num2).ToArray();
			if (source.Any((ulong num2) => reader.RecoveredMethod754(num2) == "BillboardGui") && source.Any((ulong num2) => reader.RecoveredMethod754(num2) == "d"))
			{
				WorldPoint worldPoint = point(item);
				if (worldPoint != null)
				{
					list.Add(new RecoveredType195
					{
						Key = item.ToString("X"),
						Position = worldPoint
					});
				}
			}
		}
		return list.ToArray();
	}

	[CompilerGenerated]
	private bool RecoveredMethod606(ulong P_0)
	{
		return Regex.IsMatch(reader.RecoveredMethod754(P_0), "^Line[0-9]+$");
	}

	[CompilerGenerated]
	private string RecoveredMethod607(ulong P_0)
	{
		ulong num = reader.RecoveredMethod756(P_0, "Container");
		return RecoveredType196.RecoveredMethod592(from num2 in reader.RecoveredMethod755(num)
			select new KeyValuePair<string, string>(reader.RecoveredMethod754(num2), text.RecoveredMethod636(num2)));
	}

	[CompilerGenerated]
	private KeyValuePair<string, string> RecoveredMethod608(ulong P_0)
	{
		return new KeyValuePair<string, string>(reader.RecoveredMethod754(P_0), text.RecoveredMethod636(P_0));
	}

	[CompilerGenerated]
	private bool RecoveredMethod484(ulong P_0)
	{
		return reader.RecoveredMethod607(P_0) == "BillboardGui";
	}

	[CompilerGenerated]
	private bool RecoveredMethod486(ulong P_0)
	{
		return reader.RecoveredMethod754(P_0) == "BillboardGui";
	}

	[CompilerGenerated]
	private bool RecoveredMethod487(ulong P_0)
	{
		return reader.RecoveredMethod754(P_0) == "d";
	}
}
