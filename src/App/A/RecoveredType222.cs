using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace a;

internal static class RecoveredType222
{
	public static ulong RecoveredMethod633(ulong P_0, Func<ulong, List<ulong>> P_1, Func<ulong, string> P_2, Func<ulong, string> P_3, Func<ulong, string> P_4, Func<ulong, bool> P_5)
	{
		foreach (ulong item in P_1(P_0))
		{
			if (P_2(item) != "StoreFruit")
			{
				continue;
			}
			Queue<KeyValuePair<ulong, int>> queue = new Queue<KeyValuePair<ulong, int>>();
			HashSet<ulong> hashSet = new HashSet<ulong>();
			queue.Enqueue(new KeyValuePair<ulong, int>(item, 0));
			while (queue.Count > 0 && hashSet.Count < 300)
			{
				KeyValuePair<ulong, int> keyValuePair = queue.Dequeue();
				if (!hashSet.Add(keyValuePair.Key))
				{
					continue;
				}
				string text = P_3(keyValuePair.Key);
				if (P_2(keyValuePair.Key) == "Store" && (text == "ImageButton" || text == "TextButton") && P_5(keyValuePair.Key))
				{
					List<ulong> list = new List<ulong>(P_1(keyValuePair.Key));
					list.Add(keyValuePair.Key);
					foreach (ulong item2 in list)
					{
						if (P_3(item2).StartsWith("Text", StringComparison.Ordinal) && P_5(item2) && Regex.Replace(Regex.Replace(P_4(item2) ?? "", "<[^>]*>", ""), "\\s+", " ").Trim().Equals("Store Fruit", StringComparison.OrdinalIgnoreCase))
						{
							return keyValuePair.Key;
						}
					}
				}
				if (keyValuePair.Value >= 6)
				{
					continue;
				}
				foreach (ulong item3 in P_1(keyValuePair.Key))
				{
					queue.Enqueue(new KeyValuePair<ulong, int>(item3, keyValuePair.Value + 1));
				}
			}
		}
		return 0uL;
	}

	public static string RecoveredMethod634(RecoveredType212 P_0, ulong P_1)
	{
		RecoveredType211 recoveredType = P_0.RecoveredMethod620(P_1);
		if (recoveredType == null || !recoveredType.Fruit)
		{
			return "The exact fruit is no longer carried.";
		}
		if (!recoveredType.Equipped)
		{
			return "Waiting for the fruit to finish equipping.";
		}
		if (P_0.BackpackOpen)
		{
			return "Waiting for the backpack to close.";
		}
		if (!P_0.InventoryReady)
		{
			return "Waiting for stored-fruit inventory.";
		}
		if (P_0.RecoveredMethod403(recoveredType.Name) > 0)
		{
			return "Stored inventory already contains this fruit; rechecking ownership.";
		}
		if (P_0.Busy)
		{
			return "Waiting for the active game menu or reel to close.";
		}
		if (!P_0.StoreReady)
		{
			return "Waiting for the active Store Fruit button.";
		}
		return "";
	}
}
