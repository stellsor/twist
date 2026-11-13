using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace B;

internal static class RecoveredType323
{
	public static int Value;

	private static readonly ConcurrentQueue<string> keys = new ConcurrentQueue<string>();

	public static void RecoveredMethod48(string P_0)
	{
		keys.Enqueue(P_0);
		Interlocked.Increment(ref Value);
	}

	public static string[] RecoveredMethod790()
	{
		HashSet<string> hashSet = new HashSet<string>();
		string result;
		while (keys.TryDequeue(out result))
		{
			hashSet.Add(result);
		}
		return hashSet.ToArray();
	}
}
