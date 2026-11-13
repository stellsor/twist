using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace b;

internal static class RecoveredType414
{
	public static IEnumerable<ulong> RecoveredMethod894(IEnumerable<ulong> P_0, Func<ulong, IEnumerable<ulong>> P_1, Func<ulong, bool> P_2, int P_3 = 12000, int P_4 = 80)
	{
		Queue<ulong> queue = new Queue<ulong>(P_0);
		HashSet<ulong> seen = new HashSet<ulong>();
		Stopwatch clock = Stopwatch.StartNew();
		while (queue.Count > 0)
		{
			if (seen.Count >= P_3 || clock.ElapsedMilliseconds > P_4)
			{
				throw new Exception("Fruit hierarchy scan exceeded its budget; retrying");
			}
			ulong node = queue.Dequeue();
			if (!seen.Add(node))
			{
				continue;
			}
			yield return node;
			if (!P_2(node))
			{
				continue;
			}
			foreach (ulong item in P_1(node))
			{
				if (queue.Count >= P_3)
				{
					throw new Exception("Fruit hierarchy is too large; retrying");
				}
				queue.Enqueue(item);
			}
		}
	}
}
