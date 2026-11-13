using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using B;
using c;

namespace a;

internal static class RecoveredType227
{
	private sealed class RecoveredType228 : RecoveredType214
	{
		[CompilerGenerated]
		private sealed class RecoveredType229
		{
			public ulong id;

			public bool RecoveredMethod621(RecoveredType211 P_0)
			{
				return P_0.Id != id;
			}
		}

		[CompilerGenerated]
		private sealed class RecoveredType230
		{
			public ulong id;

			public bool RecoveredMethod621(RecoveredType211 P_0)
			{
				return P_0.Id != id;
			}
		}

		public RecoveredType212 View = new RecoveredType212
		{
			InventoryReady = true,
			Tools = new RecoveredType211[2]
			{
				new RecoveredType211
				{
					Id = 1uL,
					Name = "Ope",
					Fruit = true,
					Slot = 3
				},
				new RecoveredType211
				{
					Id = 2uL,
					Name = "Lovestruck Rod",
					Rod = true,
					Equipped = true,
					Slot = 1
				}
			}
		};

		public List<string> Actions = new List<string>();

		public int Stores;

		public int Drops;

		public int Elapsed;

		public int CancelAt = 60000;

		public int MissStores;

		public int MissDrops;

		public int RestoreFailures;

		public int ReceiptDelay;

		public int ReceiptAt = -1;

		public bool Unavailable;

		public bool BlockedStore;

		public bool BackpackFailure;

		public string PendingName;

		public RecoveredType212 RecoveredMethod622()
		{
			if (ReceiptAt >= 0 && Elapsed >= ReceiptAt)
			{
				View.Stored[PendingName] = View.RecoveredMethod403(PendingName) + 1;
				ReceiptAt = -1;
			}
			View.InventoryReady = !Unavailable;
			return View;
		}

		public void RecoveredMethod623(ulong P_0, CancellationToken P_1)
		{
			P_1.ThrowIfCancellationRequested();
			if (BackpackFailure)
			{
				throw new BackpackEquipmentException("Backpack click failed twice");
			}
			RecoveredType211 recoveredType = View.RecoveredMethod620(P_0);
			if (recoveredType == null)
			{
				throw new Exception("No matching tool");
			}
			if (recoveredType.Rod && RestoreFailures > 0)
			{
				RestoreFailures--;
				throw new Exception("Rod equip temporarily unavailable");
			}
			if (!recoveredType.Equipped)
			{
				Actions.Add(((recoveredType.Slot >= 0) ? "hotbar:" : "backpack:") + recoveredType.Name);
				RecoveredType211[] tools = View.Tools;
				foreach (RecoveredType211 recoveredType2 in tools)
				{
					recoveredType2.Equipped = recoveredType2.Id == P_0;
				}
			}
			View.BackpackOpen = false;
			View.StoreReady = recoveredType.Fruit;
		}

		public void RecoveredMethod624(ulong P_0, Action P_1, CancellationToken P_2)
		{
			P_2.ThrowIfCancellationRequested();
			if (BlockedStore)
			{
				throw new Exception("UI movement blocked");
			}
			RecoveredType211 recoveredType = View.RecoveredMethod620(P_0);
			RecoveredMethod42(recoveredType != null && recoveredType.Equipped && recoveredType.Fruit && View.RecoveredMethod403(recoveredType.Name) == 0 && View.InventoryReady, "Store verifies the exact unowned fruit");
			P_1();
			Stores++;
			Actions.Add("store:" + recoveredType.Name);
			if (MissStores > 0)
			{
				MissStores--;
				return;
			}
			PendingName = recoveredType.Name;
			View.Tools = View.Tools.Where((RecoveredType211 recoveredType2) => recoveredType2.Id != P_0).ToArray();
			if (ReceiptDelay > 0)
			{
				ReceiptAt = Elapsed + ReceiptDelay;
			}
			else
			{
				View.Stored[recoveredType.Name] = View.RecoveredMethod403(recoveredType.Name) + 1;
			}
		}

		public void RecoveredMethod625(ulong P_0, Action P_1, CancellationToken P_2)
		{
			P_2.ThrowIfCancellationRequested();
			RecoveredType211 recoveredType = View.RecoveredMethod620(P_0);
			RecoveredMethod42(recoveredType != null && recoveredType.Equipped && recoveredType.Fruit && View.RecoveredMethod403(recoveredType.Name) > 0 && View.InventoryReady, "Drop verifies the exact already-stored fruit");
			P_1();
			Drops++;
			Actions.Add("drop:" + recoveredType.Name);
			if (MissDrops > 0)
			{
				MissDrops--;
				return;
			}
			View.Tools = View.Tools.Where((RecoveredType211 recoveredType2) => recoveredType2.Id != P_0).ToArray();
		}

		public void RecoveredMethod50()
		{
			RecoveredMethod42(!View.BackpackOpen, "Close the backpack before returning to the cast point");
			Actions.Add("return");
		}

		public void RecoveredMethod393(int P_0, CancellationToken P_1)
		{
			P_1.ThrowIfCancellationRequested();
			Elapsed += P_0;
			if (Elapsed >= CancelAt)
			{
				throw new OperationCanceledException("Simulated human Stop");
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType231
	{
		public int stored;

		public int dropped;

		public int twoStored;

		public int twoDropped;

		public int receipts;

		public int recorded;

		public void RecoveredMethod49(string P_0, bool P_1)
		{
			if (P_1)
			{
				dropped++;
			}
			else
			{
				stored++;
			}
		}

		public void RecoveredMethod85(string P_0, bool P_1)
		{
			if (P_1)
			{
				twoDropped++;
			}
			else
			{
				twoStored++;
			}
		}

		public void RecoveredMethod639(string P_0, bool P_1)
		{
			receipts++;
		}

		public void RecoveredMethod640(string P_0, bool P_1)
		{
			recorded++;
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Fruit test: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		var failedBackpack = new RecoveredType228 { BackpackFailure = true };
		bool failurePropagated = false;
		try
		{
			new RecoveredType215(failedBackpack, delegate { }).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate { });
		}
		catch (BackpackEquipmentException)
		{
			failurePropagated = true;
		}
		RecoveredMethod42(failurePropagated && failedBackpack.Elapsed == 0 && failedBackpack.Stores == 0 && failedBackpack.Drops == 0, "terminal backpack failure exits fruit handling without retrying, storing or dropping");
        var failedDuplicate = new RecoveredType228 { BackpackFailure = true };
        failedDuplicate.View.Stored["Ope"] = 1;
        bool duplicateStopped = false;
        var duplicateEvents = new List<string>();
        try
        {
            new RecoveredType215(failedDuplicate, duplicateEvents.Add).RecoveredMethod626(new RecoveredType170 { DropDuplicateFruits = true }, CancellationToken.None, delegate { });
        }
        catch (BackpackEquipmentException)
        {
            duplicateStopped = true;
        }
        RecoveredMethod42(duplicateStopped && failedDuplicate.Drops == 0 && failedDuplicate.Stores == 0 && failedDuplicate.View.RecoveredMethod403("Ope") == 1 && duplicateEvents.Any(message => message.Contains("stored count=1") && message.Contains("drop duplicates=True")), "duplicate option preserves stored stock and sends no drop after failed backpack equip, with decision logged");
        string export = ActivityTextExport.Format(new[] { new RecoveredType82 { Account = "one", Message = "Backpack click failed https://discord.com/api/webhooks/123/private" }, new RecoveredType82 { Account = "two", Message = "Fruit decision" } });
        RecoveredMethod42(export.Contains("one") && export.Contains("two") && export.Contains("Fruit decision") && export.Contains("[webhook hidden]") && !export.Contains("/123/private"), "activity TXT includes all supplied accounts and redacts webhook secrets");
		RecoveredType101.RecoveredMethod45();
		RecoveredType223.RecoveredMethod45();
		RecoveredType228 recoveredType = new RecoveredType228();
		recoveredType.BlockedStore = true;
		recoveredType.CancelAt = 4000;
		RecoveredType228 recoveredType2 = recoveredType;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		try
		{
			new RecoveredType215(recoveredType2, list2.Add, list.Add).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate
			{
			});
		}
		catch (OperationCanceledException)
		{
		}
		RecoveredMethod42(recoveredType2.Stores == 0 && list.Count((string P_0) => P_0.Contains("UI movement blocked")) >= 4 && list2.Count((string P_0) => P_0.Contains("UI movement blocked")) == 1 && list.Last().Contains("UI movement blocked"), "every retry exposes its actual failure even when repeated log lines are suppressed");
		RecoveredType228 recoveredType3 = new RecoveredType228();
		int stored = 0;
		int dropped = 0;
		new RecoveredType215(recoveredType3, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate(string P_0, bool P_1)
		{
			if (P_1)
			{
				dropped++;
			}
			else
			{
				stored++;
			}
		});
		RecoveredMethod42(stored == 1 && dropped == 0 && recoveredType3.Stores == 1 && recoveredType3.Drops == 0 && recoveredType3.View.RecoveredMethod403("Ope") == 1 && recoveredType3.View.RecoveredMethod620(2uL).Equipped, "Hotbar fruit is stored once and the rod restored");
		RecoveredType228 recoveredType4 = new RecoveredType228();
		recoveredType4.View.RecoveredMethod620(1uL).Slot = -1;
		new RecoveredType215(recoveredType4, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate
		{
		});
		RecoveredMethod42(recoveredType4.Actions.Contains("backpack:Ope") && recoveredType4.Actions.Last() == "return", "Backpack-only fruit equips before Store and returns to the cast point");
		RecoveredType228 recoveredType5 = new RecoveredType228();
		recoveredType5.View.Stored["Ope"] = 1;
		new RecoveredType215(recoveredType5, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate(string P_0, bool P_1)
		{
			RecoveredMethod42(P_1, "Duplicate completion");
		});
		RecoveredMethod42(recoveredType5.Drops == 1 && recoveredType5.Stores == 0 && recoveredType5.View.RecoveredMethod403("Ope") == 1 && recoveredType5.View.RecoveredMethod620(2uL).Equipped, "Only the loose duplicate is dropped; stored stock is unchanged");
		RecoveredType228 recoveredType6 = new RecoveredType228();
		recoveredType6.View.Tools = recoveredType6.View.Tools.Concat(new RecoveredType211[1]
		{
			new RecoveredType211
			{
				Id = 3uL,
				Name = "Ope",
				Fruit = true,
				Slot = -1
			}
		}).ToArray();
		int twoStored = 0;
		int twoDropped = 0;
		new RecoveredType215(recoveredType6, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate(string P_0, bool P_1)
		{
			if (P_1)
			{
				twoDropped++;
			}
			else
			{
				twoStored++;
			}
		});
		RecoveredMethod42(twoStored == 1 && twoDropped == 1 && recoveredType6.Stores == 1 && recoveredType6.Drops == 1 && recoveredType6.View.RecoveredMethod403("Ope") == 1 && recoveredType6.View.RecoveredMethod620(2uL).Equipped, "Two same-name tools are handled by identity: store the first, drop only the second");
		RecoveredType228 recoveredType7 = new RecoveredType228();
		recoveredType7.Unavailable = true;
		recoveredType7.CancelAt = 4000;
		RecoveredType228 recoveredType8 = recoveredType7;
		bool flag = false;
		try
		{
			new RecoveredType215(recoveredType8, delegate
			{
			}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate
			{
			});
		}
		catch (OperationCanceledException)
		{
			flag = true;
		}
		RecoveredMethod42(flag && recoveredType8.Stores == 0 && recoveredType8.Drops == 0 && recoveredType8.Actions.Count == 0, "Unknown stored inventory never authorizes a Store or Drop");
		RecoveredType228 recoveredType9 = new RecoveredType228();
		recoveredType9.ReceiptDelay = 18000;
		RecoveredType228 recoveredType10 = recoveredType9;
		int receipts = 0;
		new RecoveredType215(recoveredType10, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate
		{
			receipts++;
		});
		RecoveredMethod42(recoveredType10.Stores == 1 && recoveredType10.Drops == 0 && receipts == 1, "Delayed storage receipt never sends a duplicate Store or converts into a Drop");
		RecoveredType228 recoveredType11 = new RecoveredType228();
		recoveredType11.MissStores = 2;
		RecoveredType228 recoveredType12 = recoveredType11;
		new RecoveredType215(recoveredType12, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate
		{
		});
		RecoveredMethod42(recoveredType12.Stores == 3 && recoveredType12.Drops == 0, "A missed Store retries only the same remaining unowned tool");
		RecoveredType228 recoveredType13 = new RecoveredType228();
		recoveredType13.RestoreFailures = 2;
		RecoveredType228 recoveredType14 = recoveredType13;
		int recorded = 0;
		new RecoveredType215(recoveredType14, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate
		{
			recorded++;
		});
		RecoveredMethod42(recorded == 1 && recoveredType14.Stores == 1 && recoveredType14.Drops == 0 && recoveredType14.View.RecoveredMethod620(2uL).Equipped, "Rod restoration retries without repeating or recounting the fruit action");
		RecoveredType228 recoveredType15 = new RecoveredType228();
		recoveredType15.View.Stored["Ope"] = 1;
		new RecoveredType215(recoveredType15, delegate
		{
		}).RecoveredMethod626(new RecoveredType170
		{
			DropDuplicateFruits = false
		}, CancellationToken.None, delegate
		{
		});
		RecoveredMethod42(recoveredType15.Actions.Count == 0 && recoveredType15.View.RecoveredMethod620(1uL) != null, "Disabled duplicate dropping leaves the fruit untouched");
		RecoveredType228 recoveredType16 = new RecoveredType228();
		new RecoveredType215(recoveredType16, delegate
		{
		}).RecoveredMethod626(new RecoveredType170
		{
			AutoStoreFruits = false
		}, CancellationToken.None, delegate
		{
		});
		RecoveredMethod42(recoveredType16.Actions.Count == 0, "Disabled fruit handling sends no inputs");
		RecoveredType228 recoveredType17 = new RecoveredType228();
		recoveredType17.View.RecoveredMethod620(1uL).Fruit = false;
		recoveredType17.View.RecoveredMethod620(1uL).Name = "Fruit Bag";
		new RecoveredType215(recoveredType17, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate
		{
		});
		RecoveredMethod42(recoveredType17.Actions.Count == 0, "Fruit equipment names do not make ordinary tools into fruits");
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		cancellationTokenSource.Cancel();
		RecoveredType228 recoveredType18 = new RecoveredType228();
		flag = false;
		try
		{
			new RecoveredType215(recoveredType18, delegate
			{
			}).RecoveredMethod626(new RecoveredType170(), cancellationTokenSource.Token, delegate
			{
			});
		}
		catch (OperationCanceledException)
		{
			flag = true;
		}
		RecoveredMethod42(flag && recoveredType18.Actions.Count == 0, "Stop cancels before equipping or dropping");
		RecoveredType228 recoveredType19 = new RecoveredType228();
		recoveredType19.MissDrops = 1;
		RecoveredType228 recoveredType20 = recoveredType19;
		recoveredType20.View.Stored["Ope"] = 1;
		new RecoveredType215(recoveredType20, delegate
		{
		}).RecoveredMethod626(new RecoveredType170(), CancellationToken.None, delegate
		{
		});
		RecoveredMethod42(recoveredType20.Drops == 2 && recoveredType20.View.RecoveredMethod620(2uL).Equipped, "A missed Backspace retries only the same carried duplicate");
		RecoveredMethod42(RecoveredType232.RecoveredMethod657(new RecoveredType381
		{
			RecoveredField1938 = 15.0,
			RecoveredField1939 = 25.0,
			Width = 40.0,
			Height = 40.0
		}, new RecoveredType381
		{
			RecoveredField1938 = 10.0,
			RecoveredField1939 = 20.0,
			Width = 200.0,
			Height = 200.0
		}), "Fully visible backpack tile can be selected");
		RecoveredMethod42(!RecoveredType232.RecoveredMethod657(new RecoveredType381
		{
			RecoveredField1938 = 15.0,
			RecoveredField1939 = 190.0,
			Width = 40.0,
			Height = 40.0
		}, new RecoveredType381
		{
			RecoveredField1938 = 10.0,
			RecoveredField1939 = 20.0,
			Width = 200.0,
			Height = 200.0
		}), "Partly clipped backpack tile must be scrolled before clicking");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: fruit hotbar/backpack routing, exact-tool Store/Drop, stored-ownership guard, delayed receipts without duplicate actions, missed Store/Drop retries, rod restoration, optional handling/duplicate settings, non-fruit exclusion and Stop cancellation. Inputs mocked; no fruit was stored or dropped by tests.\r\n");
	}

	[CompilerGenerated]
	private static void RecoveredMethod49(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static bool RecoveredMethod39(string P_0)
	{
		return P_0.Contains("UI movement blocked");
	}

	[CompilerGenerated]
	private static bool RecoveredMethod40(string P_0)
	{
		return P_0.Contains("UI movement blocked");
	}

	[CompilerGenerated]
	private static void RecoveredMethod422(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod85(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod424(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod639(string P_0, bool P_1)
	{
		RecoveredMethod42(P_1, "Duplicate completion");
	}

	[CompilerGenerated]
	private static void RecoveredMethod84(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod93(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod640(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod99(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod428(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod641(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod431(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod119(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod642(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod160(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod643(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod169(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod644(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod192(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod645(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod248(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod646(string P_0, bool P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod273(string P_0)
	{
	}
}
