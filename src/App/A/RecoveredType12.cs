using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TwistApp;
using a;

namespace A;

internal static class RecoveredType12
{
	[CompilerGenerated]
	private sealed class RecoveredType13
	{
		public RecoveredType2 first;

		public TaskCompletionSource<bool> one;

		public TaskCompletionSource<bool> two;

		public int invoked;

		public Task RecoveredMethod47(RecoveredType2 P_0)
		{
			invoked++;
			if (P_0 != first)
			{
				return two.Task;
			}
			return one.Task;
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Account totals: " + P_1);
		}
	}

	private static InventoryEntry RecoveredMethod43(string P_0, int P_1, string P_2 = "Common", string P_3 = "Fish")
	{
		InventoryEntry inventoryEntry = new InventoryEntry();
		inventoryEntry.Name = P_0;
		inventoryEntry.Count = P_1;
		inventoryEntry.Metadata = new ItemMetadata
		{
			Name = P_0,
			Rarity = P_2,
			Category = P_3
		};
		return inventoryEntry;
	}

	private static RecoveredType2 RecoveredMethod44(string P_0, string P_1, int P_2, double P_3, bool P_4, params InventoryEntry[] items)
	{
		RecoveredType2 recoveredType = new RecoveredType2();
		recoveredType.Key = P_1 + P_0;
		recoveredType.Scope = P_1;
		recoveredType.Caught = P_2;
		recoveredType.State = new RecoveredType174
		{
			UserId = P_0,
			Account = P_0,
			Attached = true,
			Running = P_4,
			AutoFish = P_4,
			ActiveSeconds = P_3
		};
		recoveredType.Inventory = new InventorySnapshot
		{
			UserId = P_0,
			Account = P_0,
			Valid = true,
			Updated = DateTime.UtcNow,
			Items = items
		};
		return recoveredType;
	}

	public static void RecoveredMethod45()
	{
		RecoveredType2 recoveredType = RecoveredMethod44("a", "session:2", 10, 3600.0, true, RecoveredMethod43("Tigerfin", 3), RecoveredMethod43("Fangfish", 2, "Rare"), RecoveredMethod43("Common Fish Bait", 500, "Common", "Item"));
		recoveredType.State.TrackedSeconds = 100.0;
		recoveredType.State.OnTargetSeconds = 80.0;
		RecoveredType2 recoveredType2 = RecoveredMethod44("b", "session:4", 20, 1800.0, false, RecoveredMethod43("Tigerfin", 4), RecoveredMethod43("Skeletal Shark", 1, "Epic"));
		recoveredType2.State.TrackedSeconds = 50.0;
		recoveredType2.State.OnTargetSeconds = 25.0;
		RecoveredType2 recoveredType3 = RecoveredMethod44("a", "session:old", 10, 3600.0, false, RecoveredMethod43("Tigerfin", 999));
		recoveredType3.State.Attached = false;
		recoveredType3.Inventory.Valid = false;
		RecoveredType3 recoveredType4 = RecoveredType5.RecoveredMethod4(new RecoveredType2[3] { recoveredType, recoveredType2, recoveredType3 });
		RecoveredMethod42(recoveredType4.Accounts.Length == 2 && recoveredType4.Inventory.Items.Single((InventoryEntry P_0) => P_0.Name == "Tigerfin").Count == 7 && recoveredType4.Owned == 10, "unique account inventories merge by fish species and exclude bait");
		RecoveredMethod42(recoveredType4.Caught == 30 && Math.Abs(recoveredType4.Rate - 50.0) < 0.001 && recoveredType4.Seconds == 3600.0, "catch totals, sum of account rates and longest session");
		RecoveredMethod42(Math.Abs(recoveredType4.Contact / recoveredType4.Tracked - 0.7) < 0.001 && recoveredType4.Running == 1, "weighted accuracy and running accounts");
		RecoveredMethod42(recoveredType.Inventory.Items[0].Count == 3, "aggregation does not mutate worker snapshots");
		recoveredType2.Inventory.Valid = false;
		RecoveredMethod42(RecoveredType5.RecoveredMethod4(new RecoveredType2[2] { recoveredType, recoveredType2 }).Inventory.Status.Contains("1 last known"), "stale inventories explicitly labelled");
		RecoveredMethod42(RecoveredType5.RecoveredMethod4(new RecoveredType2[0]).Owned == 0, "empty total is valid");
		RecoveredType2 recoveredType5 = RecoveredMethod44("c", "session:2", 0, 0.0, false);
		RecoveredMethod42(RecoveredType5.RecoveredMethod5(new RecoveredType2[3] { recoveredType, recoveredType2, recoveredType5 }).SequenceEqual(new RecoveredType2[1] { recoveredType2 }), "running desktop is preserved and independent ready desktop selected");
		recoveredType.State.Running = false;
		RecoveredType2[] array = RecoveredType5.RecoveredMethod5(new RecoveredType2[3] { recoveredType, recoveredType2, recoveredType5 });
		RecoveredMethod42(array.Length == 2 && array.Select((RecoveredType2 P_0) => P_0.Scope).Distinct().Count() == 2, "at most one target per input session");
		recoveredType2.State.Attached = false;
		RecoveredMethod42(RecoveredType5.RecoveredMethod5(new RecoveredType2[1] { recoveredType2 }).Length == 0, "offline clients are not started");
		RecoveredType2 recoveredType6 = RecoveredMethod44("legendary-a", "session:20", 0, 100.0, false, RecoveredMethod43("Anglerfish", 3, "Legendary"), RecoveredMethod43("Swordfish", 2, "Legendary"), RecoveredMethod43("Tigerfin", 10), RecoveredMethod43("Mera", 9, "Legendary", "Fruit"), RecoveredMethod43("Legendary Fish Bait", 20, "Legendary", "Item"));
		RecoveredType2 recoveredType7 = RecoveredMethod44("legendary-b", "session:21", 0, 100.0, false, RecoveredMethod43("Anglerfish", 4, "Legendary"));
		RecoveredType2 recoveredType8 = RecoveredMethod44("legendary-a", "old", 0, 100.0, false, RecoveredMethod43("Anglerfish", 999, "Legendary"));
		recoveredType8.State.Attached = false;
		recoveredType8.Inventory.Valid = false;
		RecoveredType3 recoveredType9 = RecoveredType5.RecoveredMethod4(new RecoveredType2[3] { recoveredType6, recoveredType7, recoveredType8 });
		RecoveredMethod42(recoveredType9.LegendaryOwned == 9 && RecoveredType4.RecoveredMethod0(recoveredType6.Inventory) == 5, "Legendary inventory counts combine fish quantities across unique accounts and exclude fruit and bait");
		recoveredType6.Inventory.Items[0].Count = 1;
		RecoveredMethod42(RecoveredType5.RecoveredMethod4(new RecoveredType2[3] { recoveredType6, recoveredType7, recoveredType8 }).LegendaryOwned == 7, "Selling Legendary fish decreases the current-owned total");
		int num;
		if (RecoveredType4.RecoveredMethod0(null) == 0)
		{
			InventorySnapshot inventorySnapshot = new InventorySnapshot();
			inventorySnapshot.Items = null;
			num = ((RecoveredType4.RecoveredMethod0(inventorySnapshot) == 0) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		RecoveredMethod42((byte)num != 0, "Missing inventory produces zero");
		RecoveredMethod46().GetAwaiter().GetResult();
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: total inventory/species merge, rarity metadata, account deduplication, additive catch rates, weighted accuracy, stale-inventory labels, independent-session start planning, concurrent batch dispatch and per-worker failure isolation. No real input.\r\n");
	}

	private static async Task RecoveredMethod46()
	{
		RecoveredType2 first = RecoveredMethod44("one", "s1", 0, 0.0, false);
		RecoveredType2 second = RecoveredMethod44("two", "s2", 0, 0.0, false);
		TaskCompletionSource<bool> one = new TaskCompletionSource<bool>();
		TaskCompletionSource<bool> two = new TaskCompletionSource<bool>();
		int invoked = 0;
		Task<RecoveredType6> task = RecoveredType7.RecoveredMethod38(new RecoveredType2[2] { first, second }, delegate(RecoveredType2 P_0)
		{
			invoked++;
			return (P_0 != first) ? two.Task : one.Task;
		});
		RecoveredMethod42(invoked == 2 && !task.IsCompleted, "start commands dispatch concurrently");
		one.SetResult(result: true);
		two.SetException(new Exception("offline"));
		RecoveredType6 result = await task;
		RecoveredMethod42(result.Started == 1 && result.Failures.Length == 1 && result.Failures[0].Contains("two"), "one failed start does not cancel successful accounts");
	}

	[CompilerGenerated]
	private static bool RecoveredMethod1(InventoryEntry P_0)
	{
		return P_0.Name == "Tigerfin";
	}

	[CompilerGenerated]
	private static string RecoveredMethod3(RecoveredType2 P_0)
	{
		return P_0.Scope;
	}
}
