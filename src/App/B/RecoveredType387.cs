using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace b;

internal static class RecoveredType387
{
	private sealed class RecoveredType388
	{
		public ulong Id;

		public int Depth;
	}

	public static bool RecoveredMethod39(string P_0)
	{
		return Regex.IsMatch(Regex.Replace(Regex.Replace(P_0 ?? "", "<[^>]*>", ""), "\\s+", " ").Trim(), "^Common Fish Baits?$", RegexOptions.IgnoreCase);
	}

	public static bool RecoveredMethod876(ulong P_0, Func<ulong, List<ulong>> P_1, Func<ulong, string> P_2, Func<ulong, string> P_3, Func<ulong, string> P_4, Func<ulong, bool> P_5)
	{
		foreach (ulong item in P_1(P_0))
		{
			if (P_2(item) != "ProximityPrompts")
			{
				continue;
			}
			Queue<RecoveredType388> queue = new Queue<RecoveredType388>();
			HashSet<ulong> hashSet = new HashSet<ulong>();
			queue.Enqueue(new RecoveredType388
			{
				Id = item
			});
			while (queue.Count > 0 && hashSet.Count < 2000)
			{
				RecoveredType388 recoveredType = queue.Dequeue();
				if (!hashSet.Add(recoveredType.Id))
				{
					continue;
				}
				if (P_2(recoveredType.Id) == "ObjectText" && (P_3(recoveredType.Id) == "TextLabel" || P_3(recoveredType.Id) == "TextButton") && P_5(recoveredType.Id) && RecoveredMethod39(P_4(recoveredType.Id)))
				{
					return true;
				}
				if (recoveredType.Depth >= 12)
				{
					continue;
				}
				foreach (ulong item2 in P_1(recoveredType.Id))
				{
					if (queue.Count < 2000)
					{
						queue.Enqueue(new RecoveredType388
						{
							Id = item2,
							Depth = recoveredType.Depth + 1
						});
					}
				}
			}
		}
		return false;
	}
}
