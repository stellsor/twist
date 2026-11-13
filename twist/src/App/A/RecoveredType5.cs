using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TwistApp;

namespace A;

internal static class RecoveredType5
{
	private static string RecoveredMethod3(RecoveredType2 P_0)
	{
		if (string.IsNullOrEmpty(P_0.State.UserId))
		{
			if (P_0.Inventory == null || string.IsNullOrEmpty(P_0.Inventory.UserId))
			{
				return "client:" + P_0.Key;
			}
			return "user:" + P_0.Inventory.UserId;
		}
		return "user:" + P_0.State.UserId;
	}

	public static RecoveredType3 RecoveredMethod4(IEnumerable<RecoveredType2> P_0)
	{
		RecoveredType2[] array = (from source in P_0.Where((RecoveredType2 recoveredType3) => recoveredType3 != null && recoveredType3.State != null).GroupBy(RecoveredMethod3, StringComparer.Ordinal)
			select (from recoveredType3 in source
				orderby recoveredType3.State.Attached descending, (recoveredType3.Inventory != null) ? recoveredType3.Inventory.Updated : DateTime.MinValue descending
				select recoveredType3).First()).ToArray();
		RecoveredType3 recoveredType = new RecoveredType3();
		recoveredType.Accounts = array;
		RecoveredType3 recoveredType2 = recoveredType;
		recoveredType2.Running = array.Count((RecoveredType2 recoveredType3) => recoveredType3.State.Running && recoveredType3.State.AutoFish);
		recoveredType2.Ready = array.Count((RecoveredType2 recoveredType3) => recoveredType3.State.Attached);
		recoveredType2.LiveInventories = array.Count((RecoveredType2 recoveredType3) => recoveredType3.Inventory != null && recoveredType3.Inventory.Valid);
		recoveredType2.Seconds = array.Select((RecoveredType2 recoveredType3) => recoveredType3.State.ActiveSeconds).DefaultIfEmpty(0.0).Max();
		recoveredType2.Tracked = array.Sum((RecoveredType2 recoveredType3) => recoveredType3.State.TrackedSeconds);
		recoveredType2.Contact = array.Sum((RecoveredType2 recoveredType3) => recoveredType3.State.OnTargetSeconds);
		recoveredType2.Caught = ((IEnumerable<RecoveredType2>)array).Sum((Func<RecoveredType2, long>)((RecoveredType2 recoveredType3) => recoveredType3.Caught));
		recoveredType2.Rate = array.Where((RecoveredType2 recoveredType3) => recoveredType3.State.ActiveSeconds >= 30.0).Sum((RecoveredType2 recoveredType3) => (double)recoveredType3.Caught * 3600.0 / recoveredType3.State.ActiveSeconds);
		InventorySnapshot[] array2 = (from recoveredType3 in array
			where recoveredType3.Inventory != null
			select recoveredType3.Inventory).ToArray();
		InventoryEntry[] array3 = (from inventoryEntry in array2.SelectMany((InventorySnapshot inventorySnapshot) => inventorySnapshot.Items ?? new InventoryEntry[0])
			where inventoryEntry != null && inventoryEntry.Metadata != null && (inventoryEntry.Metadata.IsFish || inventoryEntry.Metadata.IsFruit) && inventoryEntry.Count > 0
			select inventoryEntry).GroupBy((InventoryEntry inventoryEntry) => inventoryEntry.Name, StringComparer.Ordinal).Select(delegate(IGrouping<string, InventoryEntry> grouping)
		{
			ItemMetadata metadata = (from inventoryEntry in grouping
				orderby inventoryEntry.Metadata.Rarity != "Unknown" descending, (inventoryEntry.Metadata.Parts != null) ? inventoryEntry.Metadata.Parts.Count : 0 descending
				select inventoryEntry).First().Metadata;
			return new InventoryEntry
			{
				Name = grouping.Key,
				Count = (int)Math.Min(2147483647L, ((IEnumerable<InventoryEntry>)grouping).Sum((Func<InventoryEntry, long>)((InventoryEntry inventoryEntry) => inventoryEntry.Count))),
				Metadata = metadata
			};
		}).OrderBy((InventoryEntry inventoryEntry) => inventoryEntry.Name, StringComparer.OrdinalIgnoreCase)
			.ToArray();
		recoveredType2.Owned = array3.Where((InventoryEntry inventoryEntry) => inventoryEntry.Metadata.IsFish).Sum((Func<InventoryEntry, long>)((InventoryEntry inventoryEntry) => inventoryEntry.Count));
		recoveredType2.LegendaryOwned = RecoveredType4.RecoveredMethod0(new InventorySnapshot
		{
			Items = array3
		});
		int num = array2.Count((InventorySnapshot inventorySnapshot) => !inventorySnapshot.Valid);
		recoveredType2.Inventory = new InventorySnapshot
		{
			Account = "Total",
			UserId = "total",
			Items = array3,
			Valid = (array2.Length > 0 && num == 0),
			Updated = array2.Select((InventorySnapshot inventorySnapshot) => inventorySnapshot.Updated).DefaultIfEmpty(DateTime.MinValue).Max(),
			Status = array.Length + " accounts · " + recoveredType2.LiveInventories + " live inventories" + ((num > 0) ? (" · " + num + " last known") : "")
		};
		return recoveredType2;
	}

	public static RecoveredType2[] RecoveredMethod5(IEnumerable<RecoveredType2> P_0)
	{
		return (from source in P_0.Where((RecoveredType2 recoveredType) => recoveredType.State.Attached).GroupBy((RecoveredType2 recoveredType) => recoveredType.Scope, StringComparer.Ordinal)
			where !source.Any((RecoveredType2 recoveredType) => recoveredType.State.Running && recoveredType.State.AutoFish)
			select source.OrderBy((RecoveredType2 recoveredType) => recoveredType.State.Account, StringComparer.OrdinalIgnoreCase).First()).ToArray();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod6(RecoveredType2 P_0)
	{
		if (P_0 != null)
		{
			return P_0.State != null;
		}
		return false;
	}

	[CompilerGenerated]
	private static RecoveredType2 RecoveredMethod7(IGrouping<string, RecoveredType2> P_0)
	{
		return (from recoveredType in P_0
			orderby recoveredType.State.Attached descending, (recoveredType.Inventory != null) ? recoveredType.Inventory.Updated : DateTime.MinValue descending
			select recoveredType).First();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod8(RecoveredType2 P_0)
	{
		if (P_0.State.Running)
		{
			return P_0.State.AutoFish;
		}
		return false;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod9(RecoveredType2 P_0)
	{
		return P_0.State.Attached;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod10(RecoveredType2 P_0)
	{
		if (P_0.Inventory != null)
		{
			return P_0.Inventory.Valid;
		}
		return false;
	}

	[CompilerGenerated]
	private static double RecoveredMethod11(RecoveredType2 P_0)
	{
		return P_0.State.ActiveSeconds;
	}

	[CompilerGenerated]
	private static double RecoveredMethod12(RecoveredType2 P_0)
	{
		return P_0.State.TrackedSeconds;
	}

	[CompilerGenerated]
	private static double RecoveredMethod13(RecoveredType2 P_0)
	{
		return P_0.State.OnTargetSeconds;
	}

	[CompilerGenerated]
	private static long RecoveredMethod14(RecoveredType2 P_0)
	{
		return P_0.Caught;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod15(RecoveredType2 P_0)
	{
		return P_0.State.ActiveSeconds >= 30.0;
	}

	[CompilerGenerated]
	private static double RecoveredMethod16(RecoveredType2 P_0)
	{
		return (double)P_0.Caught * 3600.0 / P_0.State.ActiveSeconds;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod17(RecoveredType2 P_0)
	{
		return P_0.Inventory != null;
	}

	[CompilerGenerated]
	private static InventorySnapshot RecoveredMethod18(RecoveredType2 P_0)
	{
		return P_0.Inventory;
	}

	[CompilerGenerated]
	private static IEnumerable<InventoryEntry> RecoveredMethod19(InventorySnapshot P_0)
	{
		return P_0.Items ?? new InventoryEntry[0];
	}

	[CompilerGenerated]
	private static bool RecoveredMethod1(InventoryEntry P_0)
	{
		if (P_0 != null && P_0.Metadata != null && (P_0.Metadata.IsFish || P_0.Metadata.IsFruit))
		{
			return P_0.Count > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private static string RecoveredMethod20(InventoryEntry P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static InventoryEntry RecoveredMethod21(IGrouping<string, InventoryEntry> P_0)
	{
		ItemMetadata metadata = (from inventoryEntry in P_0
			orderby inventoryEntry.Metadata.Rarity != "Unknown" descending, (inventoryEntry.Metadata.Parts != null) ? inventoryEntry.Metadata.Parts.Count : 0 descending
			select inventoryEntry).First().Metadata;
		return new InventoryEntry
		{
			Name = P_0.Key,
			Count = (int)Math.Min(2147483647L, ((IEnumerable<InventoryEntry>)P_0).Sum((Func<InventoryEntry, long>)((InventoryEntry inventoryEntry) => inventoryEntry.Count))),
			Metadata = metadata
		};
	}

	[CompilerGenerated]
	private static string RecoveredMethod22(InventoryEntry P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod23(InventoryEntry P_0)
	{
		return P_0.Metadata.IsFish;
	}

	[CompilerGenerated]
	private static long RecoveredMethod24(InventoryEntry P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod25(InventorySnapshot P_0)
	{
		return !P_0.Valid;
	}

	[CompilerGenerated]
	private static DateTime RecoveredMethod26(InventorySnapshot P_0)
	{
		return P_0.Updated;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod27(RecoveredType2 P_0)
	{
		return P_0.State.Attached;
	}

	[CompilerGenerated]
	private static DateTime RecoveredMethod28(RecoveredType2 P_0)
	{
		if (P_0.Inventory != null)
		{
			return P_0.Inventory.Updated;
		}
		return DateTime.MinValue;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod29(InventoryEntry P_0)
	{
		return P_0.Metadata.Rarity != "Unknown";
	}

	[CompilerGenerated]
	private static int RecoveredMethod30(InventoryEntry P_0)
	{
		if (P_0.Metadata.Parts != null)
		{
			return P_0.Metadata.Parts.Count;
		}
		return 0;
	}

	[CompilerGenerated]
	private static long RecoveredMethod31(InventoryEntry P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod32(RecoveredType2 P_0)
	{
		return P_0.State.Attached;
	}

	[CompilerGenerated]
	private static string RecoveredMethod33(RecoveredType2 P_0)
	{
		return P_0.Scope;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod34(IGrouping<string, RecoveredType2> P_0)
	{
		return !P_0.Any((RecoveredType2 recoveredType) => recoveredType.State.Running && recoveredType.State.AutoFish);
	}

	[CompilerGenerated]
	private static RecoveredType2 RecoveredMethod35(IGrouping<string, RecoveredType2> P_0)
	{
		return P_0.OrderBy((RecoveredType2 recoveredType) => recoveredType.State.Account, StringComparer.OrdinalIgnoreCase).First();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod36(RecoveredType2 P_0)
	{
		if (P_0.State.Running)
		{
			return P_0.State.AutoFish;
		}
		return false;
	}

	[CompilerGenerated]
	private static string RecoveredMethod37(RecoveredType2 P_0)
	{
		return P_0.State.Account;
	}
}
