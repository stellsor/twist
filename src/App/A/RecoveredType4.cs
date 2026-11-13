using System;
using System.Linq;
using System.Runtime.CompilerServices;
using TwistApp;

namespace A;

internal static class RecoveredType4
{
	public static long RecoveredMethod0(InventorySnapshot P_0)
	{
		if (P_0 != null)
		{
			return (P_0.Items ?? new InventoryEntry[0]).Where((InventoryEntry inventoryEntry) => inventoryEntry != null && inventoryEntry.Count > 0 && inventoryEntry.Metadata != null && inventoryEntry.Metadata.IsFish && string.Equals(inventoryEntry.Metadata.Rarity, "Legendary", StringComparison.OrdinalIgnoreCase)).Sum((Func<InventoryEntry, long>)((InventoryEntry inventoryEntry) => inventoryEntry.Count));
		}
		return 0L;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod1(InventoryEntry P_0)
	{
		if (P_0 != null && P_0.Count > 0 && P_0.Metadata != null && P_0.Metadata.IsFish)
		{
			return string.Equals(P_0.Metadata.Rarity, "Legendary", StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	[CompilerGenerated]
	private static long RecoveredMethod2(InventoryEntry P_0)
	{
		return P_0.Count;
	}
}
