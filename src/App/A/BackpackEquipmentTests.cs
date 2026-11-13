using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using B;
using c;

namespace A;

internal static class RecoveredType101
{
	private sealed class RecoveredType102 : RecoveredType99
	{
		public bool Carried = true;

		public bool Equipped;

		public bool OpenState;

		public bool Filtered;

		public bool Loading;

		public bool Missing;

		public bool NoSearch;

		public bool SlotAfterOpen;

		public int Slot = -1;

		public int Elapsed;

		public int CancelAt = 30000;

		public int LoadAt = 600;

		public int Clears;

		public int Reopens;

		public int Selections;

		public int MissedClicks;

		public int Recoveries;

		public List<string> Failures = new List<string>();

		public int Scrolls;

		public int LastSlot = -1;

		public bool EverOpened;

		public List<string> Events = new List<string>();

		public RecoveredType381 Tile = new RecoveredType381
		{
			RecoveredField1938 = 20.0,
			RecoveredField1939 = 30.0,
			Width = 50.0,
			Height = 50.0
		};

		public RecoveredType98 RecoveredMethod390()
		{
			if (Loading && Elapsed >= LoadAt)
			{
				Loading = false;
			}
			RecoveredType98 recoveredType = new RecoveredType98();
			recoveredType.Carried = Carried;
			recoveredType.Equipped = Equipped;
			recoveredType.Open = OpenState;
			recoveredType.Slot = Slot;
			recoveredType.ListReady = OpenState && !Loading;
			recoveredType.TileVisible = OpenState && !Loading && !Filtered && !Missing;
			recoveredType.SearchReady = OpenState && !NoSearch;
			recoveredType.Tile = Tile;
			recoveredType.Viewport = new RecoveredType381
			{
				RecoveredField1938 = 10.0,
				RecoveredField1939 = 20.0,
				Width = 200.0,
				Height = 200.0
			};
			return recoveredType;
		}

		public void RecoveredMethod391(bool P_0, CancellationToken P_1)
		{
			P_1.ThrowIfCancellationRequested();
			if (OpenState == P_0)
			{
				return;
			}
			Events.Add(P_0 ? "open" : "close");
			OpenState = P_0;
			if (P_0)
			{
				if (EverOpened)
				{
					Reopens++;
				}
				EverOpened = true;
				if (SlotAfterOpen)
				{
					Slot = 4;
					SlotAfterOpen = false;
				}
			}
		}

		public void RecoveredMethod392(CancellationToken P_0)
		{
			P_0.ThrowIfCancellationRequested();
			RecoveredMethod42(OpenState, "search clearing requires an open backpack");
			Clears++;
			Events.Add("clear");
			Filtered = false;
		}

		public void RecoveredMethod393(int P_0, CancellationToken P_1)
		{
			RecoveredMethod42(!OpenState && P_0 == Slot && Carried && !Equipped, "re-read exact slot after closing backpack");
			LastSlot = P_0;
			Selections++;
			Equipped = true;
			Events.Add("slot");
		}

		public void RecoveredMethod394(CancellationToken P_0)
		{
			RecoveredType98 recoveredType = RecoveredMethod390();
			RecoveredMethod42(recoveredType.Open && recoveredType.TileVisible && recoveredType.ListReady && RecoveredType232.RecoveredMethod657(Tile, recoveredType.Viewport), "only exact fully visible tile can be clicked");
			Selections++;
			Equipped = Selections > MissedClicks;
			Events.Add("tile");
		}

		public void ReportBackpackClickFailure(string reason)
		{
			Failures.Add(reason);
		}

		public void RecoverBackpackClick(CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			Recoveries++;
			RecoveredMethod391(false, cancellationToken);
			RecoveredMethod396(250, cancellationToken);
			RecoveredMethod391(true, cancellationToken);
			RecoveredMethod396(450, cancellationToken);
		}

		public void RecoveredMethod395(int P_0, CancellationToken P_1)
		{
			RecoveredMethod42(OpenState, "scroll in open backpack");
			Scrolls++;
			Tile.RecoveredField1939 += ((P_0 > 0) ? 40 : (-40));
		}

		public void RecoveredMethod396(int P_0, CancellationToken P_1)
		{
			P_1.ThrowIfCancellationRequested();
			Elapsed += P_0;
			if (Elapsed >= CancelAt)
			{
				throw new OperationCanceledException();
			}
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Backpack equipment: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		var missedOnce = new RecoveredType102 { MissedClicks = 1 };
		RecoveredType100.RecoveredMethod397(missedOnce, CancellationToken.None);
		RecoveredMethod42(missedOnce.Equipped && !missedOnce.OpenState && missedOnce.Selections == 2 && missedOnce.Recoveries == 1 && missedOnce.Failures.Count == 1, "one missed click reopens and equips the exact tool on the bounded retry");
		var alwaysMisses = new RecoveredType102 { MissedClicks = 100 };
		bool stoppedAfterTwo = false;
		try
		{
			RecoveredType100.RecoveredMethod397(alwaysMisses, CancellationToken.None);
		}
		catch (BackpackEquipmentException error)
		{
			stoppedAfterTwo = error.Message.Contains("Export TXT");
		}
		RecoveredMethod42(stoppedAfterTwo && alwaysMisses.Selections == 2 && alwaysMisses.Recoveries == 1 && alwaysMisses.Failures.Count == 2, "persistent misses stop after two clicks and explain how to send Activity");
		var cancelledRecovery = new RecoveredType102 { MissedClicks = 1, CancelAt = 3500 };
		bool recoveryCancelled = false;
		try
		{
			RecoveredType100.RecoveredMethod397(cancelledRecovery, CancellationToken.None);
		}
		catch (OperationCanceledException)
		{
			recoveryCancelled = true;
		}
		RecoveredMethod42(recoveryCancelled && cancelledRecovery.Selections == 1, "Stop interrupts recovery before a second click");
		var failureEvent = RecoveredType84.RecoveredMethod365("@account fruit input · Backpack click failed · attempt 1/2");
		RecoveredMethod42(failureEvent != null && failureEvent.Category == "Fruits" && failureEvent.Level == "Error", "failed backpack clicks reach Activity despite the verbose input filter");
		RecoveredMethod42(RecoveredType84.RecoveredMethod365("@account fruit input · Moving to fruit control") == null, "ordinary cursor chatter stays filtered");
		RecoveredType102 recoveredType = new RecoveredType102();
		recoveredType.Equipped = true;
		recoveredType.OpenState = true;
		RecoveredType102 recoveredType2 = recoveredType;
		RecoveredType100.RecoveredMethod397(recoveredType2, CancellationToken.None);
		RecoveredMethod42(!recoveredType2.OpenState && recoveredType2.Selections == 0, "already-equipped fruit closes backpack without toggling it off");
		RecoveredType102 recoveredType3 = new RecoveredType102();
		recoveredType3.Filtered = true;
		RecoveredType102 recoveredType4 = recoveredType3;
		RecoveredType100.RecoveredMethod397(recoveredType4, CancellationToken.None);
		RecoveredMethod42(recoveredType4.Clears == 1 && recoveredType4.Equipped && !recoveredType4.OpenState && recoveredType4.Selections == 1, "hidden exact fruit clears the filter, equips once, closes backpack");
		RecoveredType102 recoveredType5 = new RecoveredType102();
		recoveredType5.Loading = true;
		recoveredType5.LoadAt = 1100;
		RecoveredType102 recoveredType6 = recoveredType5;
		RecoveredType100.RecoveredMethod397(recoveredType6, CancellationToken.None);
		RecoveredMethod42(recoveredType6.Clears == 0 && recoveredType6.Reopens == 0 && recoveredType6.Equipped, "loading inventory settles without being mislabeled a search filter");
		RecoveredType102 recoveredType7 = new RecoveredType102();
		recoveredType7.Missing = true;
		recoveredType7.NoSearch = true;
		RecoveredType102 recoveredType8 = recoveredType7;
		string text = "";
		try
		{
			RecoveredType100.RecoveredMethod397(recoveredType8, CancellationToken.None);
		}
		catch (Exception ex)
		{
			text = ex.Message;
		}
		RecoveredMethod42(recoveredType8.Reopens == 1 && recoveredType8.Clears == 0 && recoveredType8.Selections == 0 && text.Contains("exact fruit/rod tile"), "missing tile recovers by reopening once and never clicks another item");
		RecoveredType102 recoveredType9 = new RecoveredType102();
		recoveredType9.SlotAfterOpen = true;
		RecoveredType102 recoveredType10 = recoveredType9;
		RecoveredType100.RecoveredMethod397(recoveredType10, CancellationToken.None);
		RecoveredMethod42(recoveredType10.LastSlot == 4 && recoveredType10.Equipped && !recoveredType10.OpenState, "tool moved to hotbar during opening uses its current slot");
		RecoveredType102 recoveredType11 = new RecoveredType102();
		recoveredType11.Tile.RecoveredField1939 = 290.0;
		RecoveredType100.RecoveredMethod397(recoveredType11, CancellationToken.None);
		RecoveredMethod42(recoveredType11.Scrolls > 0 && recoveredType11.Selections == 1, "off-screen exact tile is scrolled into view before selection");
		RecoveredType102 recoveredType12 = new RecoveredType102();
		recoveredType12.Carried = false;
		RecoveredType102 recoveredType13 = recoveredType12;
		bool flag = false;
		try
		{
			RecoveredType100.RecoveredMethod397(recoveredType13, CancellationToken.None);
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag && recoveredType13.Events.Count == 0, "removed fruit causes no input");
		RecoveredType102 recoveredType14 = new RecoveredType102();
		recoveredType14.Filtered = true;
		recoveredType14.CancelAt = 500;
		RecoveredType102 recoveredType15 = recoveredType14;
		bool flag2 = false;
		try
		{
			RecoveredType100.RecoveredMethod397(recoveredType15, CancellationToken.None);
		}
		catch (OperationCanceledException)
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2 && recoveredType15.Clears == 0 && recoveredType15.Selections == 0, "Stop cancels recovery before filter edits");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: backpack filter recovery, delayed layout, bounded reopen, exact tile and changing hotbar identity, scrolling, missing tool and Stop cancellation. Synthetic input only.\r\n");
	}
}
