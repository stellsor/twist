using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using a;

namespace TwistApp;

public sealed class FruitStoredRecord
{
	[CompilerGenerated]
	private sealed class RecoveredType226
	{
		public int tier;

		public bool RecoveredMethod399(KeyValuePair<string, int> P_0)
		{
			return RecoveredType106.RecoveredMethod403(P_0.Key) == tier;
		}
	}

	public string Id;

	public string UserId;

	public string Account;

	public string Name;

	public string Rarity;

	public string AtUtc;

	public int FishCaught;

	public int Common = -1;

	public int Rare = -1;

	public int Legendary = -1;

	public double Seconds;

	internal static int RecoveredMethod637(RecoveredType212 P_0, int P_1)
	{
		if (P_0 != null && P_0.InventoryReady)
		{
			return (int)Math.Min(2147483647L, P_0.Stored.Where((KeyValuePair<string, int> keyValuePair) => RecoveredType106.RecoveredMethod403(keyValuePair.Key) == P_1).Sum((Func<KeyValuePair<string, int>, long>)((KeyValuePair<string, int> keyValuePair) => keyValuePair.Value)));
		}
		return -1;
	}

	[CompilerGenerated]
	private static long RecoveredMethod638(KeyValuePair<string, int> P_0)
	{
		return P_0.Value;
	}
}
