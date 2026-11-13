using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using A;
using TwistApp;

namespace a;

internal static class RecoveredType262
{
	[CompilerGenerated]
	private sealed class RecoveredType263
	{
		public DateTime now;

		public RoundRecord RecoveredMethod722(string P_0, string P_1, int P_2, bool P_3)
		{
			return new RoundRecord
			{
				Id = P_0,
				UserId = P_1,
				Account = "tester",
				AtUtc = now.AddSeconds(P_2).ToString("o"),
				Full = P_3,
				Peak = (P_3 ? 1.0 : 0.2)
			};
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Inventory test: " + P_1);
		}
	}

	private static InventorySnapshot RecoveredMethod715(string P_0, int P_1, int P_2, bool P_3)
	{
		InventorySnapshot inventorySnapshot = new InventorySnapshot();
		inventorySnapshot.Valid = true;
		inventorySnapshot.UserId = P_0;
		inventorySnapshot.Account = "tester";
		inventorySnapshot.Updated = DateTime.UtcNow;
		inventorySnapshot.Items = new InventoryEntry[2]
		{
			new InventoryEntry
			{
				Name = "Test Fish",
				Count = P_1,
				Metadata = new ItemMetadata
				{
					Name = "Test Fish",
					Category = "Fish",
					Rarity = "Rare"
				}
			},
			new InventoryEntry
			{
				Name = "Bait",
				Count = P_2,
				Metadata = new ItemMetadata
				{
					Name = "Bait",
					Category = "Item",
					Rarity = "Common"
				}
			}
		};
		return inventorySnapshot;
	}

	public static void RecoveredMethod45()
	{
		InventorySnapshot inventorySnapshot = RecoveredMethod715("123", 7, 90, false);
		RecoveredMethod42(RecoveredType259.RecoveredMethod713(null, inventorySnapshot, true).Length == 0, "Initial stock establishes a baseline");
		Dictionary<string, int> dictionary = inventorySnapshot.Items.ToDictionary((InventoryEntry P_0) => P_0.Name, (InventoryEntry P_0) => P_0.Count);
		InventorySnapshot inventorySnapshot2 = RecoveredMethod715("123", 8, 95, true);
		inventorySnapshot2.Gains = RecoveredType259.RecoveredMethod713(dictionary, inventorySnapshot2, true);
		RecoveredMethod42(inventorySnapshot2.Gains.Length == 2 && inventorySnapshot2.Gains.All((InventoryGain P_0) => P_0.Count > 0), "Positive changes only");
		RecoveredMethod42(RecoveredType259.RecoveredMethod713(dictionary, RecoveredMethod715("123", 6, 80, true), true).Length == 0, "Selling and consumption do not count");
		bool flag = false;
		try
		{
			RecoveredType259.RecoveredMethod712("{\"Fish\":-1}");
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag, "Invalid quantity rejected");
		flag = false;
		try
		{
			RecoveredType259.RecoveredMethod712("{\"Fish\":2");
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag, "Incomplete snapshot rejected");
		RecoveredMethod42(RecoveredType259.RecoveredMethod712("{}").Count == 0, "Empty inventory is valid");
		string text = Path.Combine(Path.GetTempPath(), "twist-inventory-test-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text);
		try
		{
			File.WriteAllText(Path.Combine(text, "catches.json"), new JavaScriptSerializer().Serialize(new CatchRecord[1]
			{
				new CatchRecord
				{
					Id = "legacy",
					UserId = "legacy-user",
					Account = "previous",
					Name = "Tigerfin",
					Rarity = "Common",
					Count = 9,
					AtUtc = DateTime.UtcNow.AddDays(-1.0).ToString("o")
				}
			}));
			RecoveredType266 recoveredType = new RecoveredType266(text);
			RecoveredMethod42(recoveredType.RecoveredMethod727("legacy-user").Sum((CatchRecord P_0) => P_0.Count) == 9, "Legacy catch history is preserved on upgrade");
			DateTime now = DateTime.UtcNow;
			Func<string, string, int, bool, RoundRecord> func = (string P_0, string P_1, int P_2, bool P_3) => new RoundRecord
			{
				Id = P_0,
				UserId = P_1,
				Account = "tester",
				AtUtc = now.AddSeconds(P_2).ToString("o"),
				Full = P_3,
				Peak = (P_3 ? 1.0 : 0.2)
			};
			inventorySnapshot2.Gains[0].AtUtc = now.ToString("o");
			RecoveredMethod42(!recoveredType.RecoveredMethod725(inventorySnapshot2) && recoveredType.RecoveredMethod727("123").Length == 0, "Inventory gains alone never increment the catch count");
			RoundRecord roundRecord = func("complete", "123", 0, arg4: true);
			RecoveredMethod42(recoveredType.RecoveredMethod724(new RoundRecord[1] { roundRecord }) && recoveredType.RecoveredMethod727("123").Sum((CatchRecord P_0) => P_0.Count) == 1, "One completed minigame creates exactly one catch");
			RecoveredMethod42(recoveredType.RecoveredMethod727("123")[0].Name == "Test Fish", "Inventory evidence received before the round supplies the species");
			RecoveredMethod42(!recoveredType.RecoveredMethod724(new RoundRecord[1] { roundRecord }) && !recoveredType.RecoveredMethod725(inventorySnapshot2), "Repeated round and inventory snapshots never double count");
			InventorySnapshot inventorySnapshot3 = RecoveredMethod715("123", 40, 95, true);
			RoundRecord roundRecord2 = func("at-cap", "123", 20, arg4: true);
			RecoveredMethod42(!recoveredType.RecoveredMethod725(inventorySnapshot3) && recoveredType.RecoveredMethod724(new RoundRecord[1] { roundRecord2 }), "A completed minigame counts with no inventory increase at the 40-fish cap");
			RecoveredMethod42(recoveredType.RecoveredMethod727("123").Sum((CatchRecord P_0) => P_0.Count) == 2 && recoveredType.RecoveredMethod727("123").Any((CatchRecord P_0) => P_0.Name == "Unidentified fish"), "Capped catches preserve honest unknown species");
			RecoveredMethod42(!recoveredType.RecoveredMethod724(new RoundRecord[1] { func("failed", "123", 30, arg4: false) }), "An early or failed round is not a catch");
			InventorySnapshot inventorySnapshot4 = RecoveredMethod715("123", 9, 95, false);
			inventorySnapshot4.Gains = RecoveredType259.RecoveredMethod713(inventorySnapshot2.Items.ToDictionary((InventoryEntry P_0) => P_0.Name, (InventoryEntry P_0) => P_0.Count), inventorySnapshot4, false);
			RecoveredMethod42(!recoveredType.RecoveredMethod725(inventorySnapshot4), "Non-fishing gains cannot label catches");
			inventorySnapshot2.Items[0].Metadata.Rarity = "Legendary";
			RecoveredMethod42(recoveredType.RecoveredMethod725(inventorySnapshot2) && recoveredType.RecoveredMethod727("123").Single((CatchRecord P_0) => P_0.Name == "Test Fish").Rarity == "Legendary", "Known rarity can update past records");
			RoundRecord roundRecord3 = func("third", "123", 40, arg4: true);
			recoveredType.RecoveredMethod724(new RoundRecord[1] { roundRecord3 });
			InventorySnapshot inventorySnapshot5 = RecoveredMethod715("123", 40, 95, true);
			inventorySnapshot5.Items[0].Metadata.Rarity = "Legendary";
			inventorySnapshot5.Gains = new InventoryGain[1]
			{
				new InventoryGain
				{
					Name = "Test Fish",
					Count = 1,
					Fishing = true,
					AtUtc = now.AddSeconds(41.0).ToString("o")
				}
			};
			RecoveredMethod42(recoveredType.RecoveredMethod725(inventorySnapshot5) && recoveredType.RecoveredMethod727("123").Sum((CatchRecord P_0) => P_0.Count) == 3, "Delayed inventory evidence enriches without adding another catch");
			InventorySnapshot inventorySnapshot6 = RecoveredMethod715("456", 10, 95, true);
			inventorySnapshot6.Gains = new InventoryGain[1]
			{
				new InventoryGain
				{
					Name = "Test Fish",
					Count = 2,
					Fishing = true,
					AtUtc = now.AddSeconds(50.0).ToString("o")
				}
			};
			recoveredType.RecoveredMethod725(inventorySnapshot6);
			RoundRecord[] array = new RoundRecord[2]
			{
				func("other-1", "456", 49, arg4: true),
				func("other-2", "456", 50, arg4: true)
			};
			recoveredType.RecoveredMethod724(array);
			recoveredType.Completion.GetAwaiter().GetResult();
			RecoveredType266 recoveredType2 = new RecoveredType266(text);
			RecoveredMethod42(!recoveredType2.RecoveredMethod724(array) && !recoveredType2.RecoveredMethod725(inventorySnapshot6) && recoveredType2.RecoveredMethod727("123").Sum((CatchRecord P_0) => P_0.Count) == 3 && recoveredType2.RecoveredMethod727("456").Sum((CatchRecord P_0) => P_0.Count) == 2, "Counts and evidence mappings survive reload and reconnect replays");
			RecoveredMethod42(!recoveredType2.RecoveredMethod724(new RoundRecord[1] { func("old-round", "123", -3600, arg4: true) }), "Pre-upgrade rounds are not added to preserved legacy history");
			string text2 = Path.Combine(text, "export.csv");
			recoveredType2.RecoveredMethod82(text2, "123");
			RecoveredMethod42(File.ReadAllText(text2).Contains("Legendary") && !File.ReadAllText(text2).Contains(",\"456\","), "CSV respects account selection");
		}
		finally
		{
			string[] files = Directory.GetFiles(text);
			foreach (string path in files)
			{
				File.Delete(path);
			}
			Directory.Delete(text);
		}
		byte[] array2 = new byte[120];
		byte[] array3 = new byte[12];
		Buffer.BlockCopy(BitConverter.GetBytes(1u), 0, array3, 4, 4);
		Buffer.BlockCopy(BitConverter.GetBytes(2u), 0, array3, 8, 4);
		RecoveredMethod42(RecoveredType135.RecoveredMethod517(array2, array3), "Bounded cached geometry accepted");
		Buffer.BlockCopy(BitConverter.GetBytes(3u), 0, array3, 8, 4);
		RecoveredMethod42(!RecoveredType135.RecoveredMethod517(array2, array3), "Out-of-range geometry rejected");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: inventory baseline, completion-based counting at inventory cap, failed-round exclusion, before/after inventory enrichment, sales, non-fishing gains, rarity refresh, round/evidence de-duplication, persisted replay protection and account separation, CSV, incomplete snapshots, mesh bounds.\r\n");
	}

	[CompilerGenerated]
	private static string RecoveredMethod709(InventoryEntry P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static int RecoveredMethod714(InventoryEntry P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod716(InventoryGain P_0)
	{
		return P_0.Count > 0;
	}

	[CompilerGenerated]
	private static int RecoveredMethod353(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static int RecoveredMethod253(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static int RecoveredMethod255(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod256(CatchRecord P_0)
	{
		return P_0.Name == "Unidentified fish";
	}

	[CompilerGenerated]
	private static string RecoveredMethod22(InventoryEntry P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static int RecoveredMethod717(InventoryEntry P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod718(CatchRecord P_0)
	{
		return P_0.Name == "Test Fish";
	}

	[CompilerGenerated]
	private static int RecoveredMethod719(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static int RecoveredMethod720(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static int RecoveredMethod721(CatchRecord P_0)
	{
		return P_0.Count;
	}
}
