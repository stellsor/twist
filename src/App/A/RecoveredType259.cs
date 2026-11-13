using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Script.Serialization;
using TwistApp;

namespace a;

internal static class RecoveredType259
{
	public static Dictionary<string, int> RecoveredMethod712(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0) || !P_0.TrimStart().StartsWith("{"))
		{
			throw new Exception("Inventory data is incomplete.");
		}
		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
		javaScriptSerializer.MaxJsonLength = 2097152;
		if (!(javaScriptSerializer.DeserializeObject(P_0) is Dictionary<string, object> { Count: <=10000 } dictionary))
		{
			throw new Exception("Inventory schema is not supported.");
		}
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>(StringComparer.Ordinal);
		foreach (KeyValuePair<string, object> item in dictionary)
		{
			if (!string.IsNullOrWhiteSpace(item.Key) && item.Key.Length <= 250)
			{
				if (!long.TryParse(Convert.ToString(item.Value, CultureInfo.InvariantCulture), out var result) || result < 0 || result > int.MaxValue)
				{
					throw new Exception("Invalid item quantity.");
				}
				if (result > 0)
				{
					dictionary2[item.Key] = (int)result;
				}
			}
		}
		return dictionary2;
	}

	public static InventoryGain[] RecoveredMethod713(IDictionary<string, int> P_0, InventorySnapshot P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return new InventoryGain[0];
		}
		List<InventoryGain> list = new List<InventoryGain>();
		InventoryEntry[] items = P_1.Items;
		foreach (InventoryEntry inventoryEntry in items)
		{
			P_0.TryGetValue(inventoryEntry.Name, out var value);
			if (inventoryEntry.Count > value)
			{
				list.Add(new InventoryGain
				{
					Name = inventoryEntry.Name,
					Count = inventoryEntry.Count - value,
					AtUtc = DateTime.UtcNow.ToString("o"),
					Fishing = P_2
				});
			}
		}
		return list.ToArray();
	}
}
