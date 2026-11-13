using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Script.Serialization;
using B;
using TwistApp;
using a;
using b;
using c;

namespace A;

internal static class RecoveredType112
{
	private sealed class RecoveredType113 : RecoveredType105
	{
		public readonly List<string> Actions = new List<string>();

		public Dictionary<string, int> Counts = new Dictionary<string, int> { { "Common Fish Bait", 100 } };

		public string Selected = "";

		public string Quantity = "";

		public int Stage;

		public int Requested = 100;

		public int Delivery = 100;

		public int ConfirmationOverride;

		public bool BlockedUi;

		public bool Vendor = true;

		public bool BadQuantity;

		public bool ExtraConfirm;

		public bool HideMenuAfterClick;

		public bool MenuInitiallyHidden;

		public int Reads;

		public int Buys;

		public int ElapsedMs;

		public int ReadyAt;

		public int FocusAt;

		public bool PendingClick;

		public int YesClicksRequired = 1;

		public int YesClicks;

		public int Waits;

		public int CancelAfterMs = 60000;

		public int VendorAfterWaits;

		public int DeliveryDelayMs;

		public int DeliveryDue = -1;

		public int CloseFailures;

		public bool AdvanceToDoneOnEntry;

		public bool ThrowAfterAdvance;

		public bool DoneNamesCommon;

		public RecoveredType104 RecoveredMethod401()
		{
			Reads++;
			if (DeliveryDue >= 0 && ElapsedMs >= DeliveryDue)
			{
				Counts["Common Fish Bait"] += Delivery;
				DeliveryDue = -1;
			}
			if (PendingClick)
			{
				PendingClick = false;
				Stage = 2;
			}
			RecoveredType104 recoveredType = new RecoveredType104();
			recoveredType.Counts = new Dictionary<string, int>(Counts);
			recoveredType.BaitMenu = Stage == 0 && (!MenuInitiallyHidden || Reads >= 4);
			recoveredType.Selected = Selected;
			recoveredType.CommonVendor = Vendor;
			recoveredType.Dialog = Stage == 1 || Stage == 3 || Stage == 4;
			recoveredType.CommonDialog = Stage == 1 || Stage == 4 || (DoneNamesCommon && Stage == 3);
			recoveredType.ConfirmationAmount = ((Stage != 4) ? ((Stage == 1) ? 1 : 0) : ((ConfirmationOverride > 0) ? ConfirmationOverride : Requested));
			recoveredType.Done = Stage == 3;
			recoveredType.Quantity = Stage == 2;
			recoveredType.QuantityText = Quantity;
			return recoveredType;
		}

		private void RecoveredMethod53()
		{
			ReadyAt = ElapsedMs + 600;
			if (DeliveryDelayMs > 0)
			{
				DeliveryDue = ElapsedMs + DeliveryDelayMs;
			}
			else
			{
				Counts["Common Fish Bait"] += Delivery;
			}
			Stage = 3;
		}

		public void RecoveredMethod402(RecoveredType103 P_0, string P_1, Action P_2 = null)
		{
			if (BlockedUi)
			{
				throw new Exception("UI movement blocked");
			}
			if (P_0 != RecoveredType103.Bait && ElapsedMs < ReadyAt)
			{
				throw new Exception("Purchase animation is not ready.");
			}
			if (P_0 == RecoveredType103.Quantity)
			{
				FocusAt = ElapsedMs + 300;
			}
			Actions.Add(string.Concat(P_0, ":", P_1));
			switch (P_0)
			{
			case RecoveredType103.Bait:
				Selected = P_1;
				if (HideMenuAfterClick)
				{
					Stage = 5;
				}
				return;
			case RecoveredType103.Yes:
				if (Stage == 1)
				{
					YesClicks++;
					PendingClick = YesClicks >= YesClicksRequired;
					ReadyAt = ElapsedMs + 700;
					return;
				}
				if (Stage == 4)
				{
					P_2?.Invoke();
					RecoveredMethod53();
					return;
				}
				throw new Exception("Wrong yes stage");
			case RecoveredType103.Quantity:
				if (Stage != 2)
				{
					throw new Exception("Wrong quantity stage");
				}
				break;
			}
			switch (P_0)
			{
			case RecoveredType103.Buy:
				RecoveredMethod42(Stage == 2 && Quantity == Requested.ToString(), "Fake verifies quantity before commit");
				P_2?.Invoke();
				Buys++;
				if (ExtraConfirm)
				{
					Stage = 4;
					ReadyAt = ElapsedMs + 700;
				}
				else
				{
					RecoveredMethod53();
				}
				break;
			case RecoveredType103.Done:
				RecoveredMethod42(Stage == 3, "Dismiss only after completion");
				if (CloseFailures > 0)
				{
					CloseFailures--;
				}
				else
				{
					Stage = 0;
				}
				break;
			}
		}

		public void RecoveredMethod51()
		{
			if (PendingClick || Stage != 0)
			{
				throw new Exception("Returned to cast point before the UI acknowledged the click.");
			}
			Actions.Add("return");
		}

		public void RecoveredMethod377(int P_0)
		{
			Requested = P_0;
			if (AdvanceToDoneOnEntry)
			{
				AdvanceToDoneOnEntry = false;
				Counts["Common Fish Bait"] += 100;
				Stage = 3;
				if (ThrowAfterAdvance)
				{
					throw new Exception("Quantity editor changed before typing");
				}
			}
			if (ElapsedMs < FocusAt)
			{
				throw new Exception("Quantity field has not focused yet.");
			}
			Quantity = ((!BadQuantity) ? P_0.ToString() : ((P_0 == 1) ? "2" : "1"));
			Actions.Add("type:" + P_0);
		}

		public void RecoveredMethod50()
		{
			Actions.Add("E");
			Stage = 1;
			ReadyAt = ElapsedMs + 700;
		}

		public void RecoveredMethod393(int P_0, CancellationToken P_1)
		{
			P_1.ThrowIfCancellationRequested();
			ElapsedMs += P_0;
			if (ElapsedMs >= CancelAfterMs)
			{
				throw new OperationCanceledException("Simulated human Stop");
			}
		}

		public void RecoveredMethod395(int P_0, CancellationToken P_1)
		{
			Waits++;
			if (VendorAfterWaits > 0 && Waits >= VendorAfterWaits)
			{
				Vendor = true;
			}
			RecoveredMethod393(P_0, P_1);
		}
	}

	private sealed class RecoveredType114 : RecoveredType117
	{
		public bool InFocus = true;

		public bool LoseOnSelect;

		public bool ThrowOnARelease;

		public Action OnSelect;

		public readonly HashSet<int> HeldKeys = new HashSet<int>();

		public readonly List<int> Digits = new List<int>();

		public bool Focused => InFocus;

		public bool LeftIsDown => false;

		public void RecoveredMethod348(double P_0, double P_1)
		{
		}

		public void RecoveredMethod72(bool P_0)
		{
		}

		public void RecoveredMethod469(int P_0, bool P_1)
		{
			if (P_1)
			{
				HeldKeys.Add(P_0);
				if (P_0 >= 48 && P_0 <= 57)
				{
					Digits.Add(P_0);
				}
				if (P_0 == 65)
				{
					if (LoseOnSelect)
					{
						InFocus = false;
					}
					if (OnSelect != null)
					{
						OnSelect();
					}
				}
			}
			else
			{
				HeldKeys.Remove(P_0);
				if (P_0 == 65 && ThrowOnARelease)
				{
					throw new Exception("Simulated A-up failure");
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType115
	{
		public CancellationTokenSource canceled;

		public CancellationTokenSource canceledHold;

		public void RecoveredMethod45()
		{
			canceled.Cancel();
		}

		public void RecoveredMethod50()
		{
			canceledHold.Cancel();
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType116
	{
		public string received;

		public bool connected;

		public bool RecoveredMethod387()
		{
			return connected;
		}

		public string RecoveredMethod470()
		{
			return received;
		}

		public void RecoveredMethod48(string P_0)
		{
			received = P_0;
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Bait test: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredType389.RecoveredMethod45();
		RecoveredType419.RecoveredMethod45();
		RecoveredType113 recoveredType = new RecoveredType113();
		recoveredType.BlockedUi = true;
		recoveredType.CancelAfterMs = 4000;
		RecoveredType113 recoveredType2 = recoveredType;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		try
		{
			new RecoveredType108(recoveredType2, list2.Add, list.Add).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
			{
			}, true);
		}
		catch (OperationCanceledException)
		{
		}
		RecoveredMethod42(list.Count((string P_0) => P_0.Contains("UI movement blocked")) >= 4 && list2.Count((string P_0) => P_0.Contains("UI movement blocked")) == 1 && list.Last().Contains("UI movement blocked"), "repeated UI input errors stay visible despite log deduplication");
		RecoveredType114 recoveredType3 = new RecoveredType114();
		using (RecoveredType245 recoveredType4 = new RecoveredType245(recoveredType3, 8711))
		{
			recoveredType4.RecoveredMethod393(100);
		}
		RecoveredMethod42(recoveredType3.HeldKeys.Count == 0 && recoveredType3.Digits.SequenceEqual(new int[3] { 49, 48, 48 }), "Quantity typing releases all keys");
		RecoveredType114 recoveredType5 = new RecoveredType114();
		recoveredType5.LoseOnSelect = true;
		RecoveredType114 recoveredType6 = recoveredType5;
		try
		{
			using RecoveredType245 recoveredType7 = new RecoveredType245(recoveredType6, 8712);
			recoveredType7.RecoveredMethod393(100);
		}
		catch
		{
		}
		RecoveredMethod42(recoveredType6.HeldKeys.Count == 0 && recoveredType6.Digits.Count == 0, "Ctrl+A focus loss releases keys and stops typing");
		RecoveredType114 recoveredType8 = new RecoveredType114();
		recoveredType8.ThrowOnARelease = true;
		RecoveredType114 recoveredType9 = recoveredType8;
		try
		{
			using RecoveredType245 recoveredType10 = new RecoveredType245(recoveredType9, 8713);
			recoveredType10.RecoveredMethod393(100);
		}
		catch
		{
		}
		RecoveredMethod42(recoveredType9.HeldKeys.Count == 0, "Ctrl is released even if A-up fails");
		CancellationTokenSource canceled = new CancellationTokenSource();
		RecoveredType114 recoveredType11 = new RecoveredType114();
		recoveredType11.OnSelect = delegate
		{
			canceled.Cancel();
		};
		RecoveredType114 recoveredType12 = recoveredType11;
		try
		{
			using RecoveredType245 recoveredType13 = new RecoveredType245(recoveredType12, 8714);
			recoveredType13.RecoveredMethod393(100, canceled.Token);
		}
		catch (OperationCanceledException)
		{
		}
		RecoveredMethod42(recoveredType12.HeldKeys.Count == 0 && recoveredType12.Digits.Count == 0, "Cancellation releases selection chord");
		RecoveredMethod42(RecoveredType106.RecoveredMethod403("Legendary Fish Bait Blueprint") == 0 && RecoveredType106.RecoveredMethod403("Common Baitfish") == 0, "Only actual bait names match tiers");
		RecoveredMethod42(!RecoveredType106.RecoveredMethod405(50) && RecoveredType106.RecoveredMethod405(49), "Strict below-50 threshold");
		RecoveredType170 recoveredType14 = new JavaScriptSerializer().Deserialize<RecoveredType170>("{}");
		RecoveredMethod42(recoveredType14.RestockBelow == 50 && recoveredType14.RestockBuy == 100, "Older profiles retain the 50/100 defaults");
		RecoveredMethod42(RecoveredType106.RecoveredMethod406("Would you like to purchase 250 Common Fish Baits for 11250 Peli?") == 250 && RecoveredType106.RecoveredMethod406("Buy 1 Common Fish Bait for 100 Peli?") == 1, "Confirmation amount comes from bait quantity rather than price");
		RecoveredType113 recoveredType15 = new RecoveredType113();
		recoveredType15.Delivery = 250;
		recoveredType15.ExtraConfirm = true;
		RecoveredType113 recoveredType16 = recoveredType15;
		recoveredType16.Counts["Common Fish Bait"] = 72;
		new RecoveredType108(recoveredType16, delegate
		{
		}).RecoveredMethod411(new RecoveredType170
		{
			RestockBelow = 73,
			RestockBuy = 250
		}, CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType16.Buys == 1 && recoveredType16.Counts["Common Fish Bait"] == 322 && recoveredType16.Requested == 250 && recoveredType16.Actions.Contains("type:250"), "Custom threshold purchases and verifies exactly 250 once, including final confirmation");
		RecoveredType113 recoveredType17 = new RecoveredType113();
		recoveredType17.Counts["Common Fish Bait"] = 73;
		new RecoveredType108(recoveredType17, delegate
		{
		}).RecoveredMethod411(new RecoveredType170
		{
			RestockBelow = 73,
			RestockBuy = 250
		}, CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType17.Buys == 0 && !recoveredType17.Actions.Contains("E"), "Exact custom threshold does not restock");
		RecoveredType113 recoveredType18 = new RecoveredType113();
		recoveredType18.Delivery = 1;
		recoveredType18.ExtraConfirm = true;
		RecoveredType113 recoveredType19 = recoveredType18;
		recoveredType19.Counts["Common Fish Bait"] = 79;
		new RecoveredType108(recoveredType19, delegate
		{
		}).RecoveredMethod411(new RecoveredType170
		{
			RestockBelow = 80,
			RestockBuy = 1
		}, CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType19.Buys == 1 && recoveredType19.Counts["Common Fish Bait"] == 80 && recoveredType19.Requested == 1, "One-bait batches support receipt and confirmation checks");
		RecoveredType113 recoveredType20 = new RecoveredType113();
		recoveredType20.Delivery = 200;
		recoveredType20.CancelAfterMs = 25000;
		RecoveredType113 recoveredType21 = recoveredType20;
		recoveredType21.Counts["Common Fish Bait"] = 2;
		try
		{
			new RecoveredType108(recoveredType21, delegate
			{
			}).RecoveredMethod411(new RecoveredType170
			{
				RestockBuy = 250
			}, CancellationToken.None, delegate
			{
			}, true);
		}
		catch (OperationCanceledException)
		{
		}
		RecoveredMethod42(recoveredType21.Buys == 1, "Partial custom delivery never triggers a duplicate Buy");
		RecoveredType113 recoveredType22 = new RecoveredType113();
		recoveredType22.Delivery = 250;
		recoveredType22.ExtraConfirm = true;
		recoveredType22.ConfirmationOverride = 300;
		recoveredType22.CancelAfterMs = 25000;
		RecoveredType113 recoveredType23 = recoveredType22;
		recoveredType23.Counts["Common Fish Bait"] = 2;
		try
		{
			new RecoveredType108(recoveredType23, delegate
			{
			}).RecoveredMethod411(new RecoveredType170
			{
				RestockBuy = 250
			}, CancellationToken.None, delegate
			{
			}, true);
		}
		catch (OperationCanceledException)
		{
		}
		RecoveredMethod42(recoveredType23.Buys == 1 && recoveredType23.Counts["Common Fish Bait"] == 2, "Mismatched final purchase amount is never confirmed");
		RecoveredType170[] array = new RecoveredType170[3]
		{
			new RecoveredType170
			{
				RestockBelow = -1
			},
			new RecoveredType170
			{
				RestockBuy = 0
			},
			new RecoveredType170
			{
				RestockBuy = 100001
			}
		};
		foreach (RecoveredType170 recoveredType24 in array)
		{
			bool flag = false;
			try
			{
				recoveredType24.RecoveredMethod50();
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag, "Invalid restock values rejected");
		}
		RecoveredType113 recoveredType25 = new RecoveredType113();
		recoveredType25.Counts["Common Fish Bait"] = 49;
		RecoveredType108 recoveredType26 = new RecoveredType108(recoveredType25, delegate
		{
		});
		string text = recoveredType26.RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType25.Counts["Common Fish Bait"] == 149 && recoveredType25.Buys == 1 && text == "Common Fish Bait", "Buy exactly 100 once after simulated UI animation and focus delays");
		RecoveredMethod42(recoveredType25.Actions.IndexOf("Done:") > recoveredType25.Actions.IndexOf("Buy:") && recoveredType25.Actions.Last() == "return" && recoveredType25.Actions.IndexOf("Bait:Common Fish Bait") > recoveredType25.Actions.IndexOf("Done:"), "UI acknowledges purchase, dismissal and selection before returning to cast point");
		RecoveredType113 recoveredType27 = new RecoveredType113();
		recoveredType27.YesClicksRequired = 2;
		RecoveredType113 recoveredType28 = recoveredType27;
		recoveredType28.Counts["Common Fish Bait"] = 1;
		new RecoveredType108(recoveredType28, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType28.YesClicks == 2 && recoveredType28.Buys == 1 && recoveredType28.Stage == 0 && recoveredType28.Actions.Contains("Yes:initial-retry"), "Only the unacknowledged first confirmation retries; purchase remains exactly once. Observed " + recoveredType28.YesClicks + "," + recoveredType28.Buys + "," + recoveredType28.Stage + ": " + string.Join(" | ", recoveredType28.Actions));
		RecoveredType113 recoveredType29 = new RecoveredType113();
		recoveredType29.Counts["Common Fish Bait"] = 50;
		new RecoveredType108(recoveredType29, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType29.Buys == 0 && !recoveredType29.Actions.Contains("E"), "50 does not purchase");
		RecoveredType113 recoveredType30 = new RecoveredType113();
		recoveredType30.Counts["Rare Fish Bait"] = 2;
		recoveredType30.Counts["Legendary Fish Bait"] = 1;
		RecoveredType108 recoveredType31 = new RecoveredType108(recoveredType30, delegate
		{
		});
		RecoveredType170 recoveredType32 = new RecoveredType170();
		recoveredType32.BaitMode = "best";
		RecoveredType170 recoveredType33 = recoveredType32;
		RecoveredMethod42(recoveredType31.RecoveredMethod411(recoveredType33, CancellationToken.None, delegate
		{
		}, true) == "Legendary Fish Bait", "Legendary first");
		recoveredType30.Counts["Legendary Fish Bait"] = 0;
		RecoveredMethod42(recoveredType31.RecoveredMethod411(recoveredType33, CancellationToken.None, delegate
		{
		}, true) == "Rare Fish Bait", "Rare fallback");
		recoveredType30.Counts["Rare Fish Bait"] = 0;
		RecoveredMethod42(recoveredType31.RecoveredMethod411(recoveredType33, CancellationToken.None, delegate
		{
		}, true) == "Common Fish Bait", "Common fallback");
		RecoveredType113 recoveredType34 = new RecoveredType113();
		recoveredType34.BadQuantity = true;
		recoveredType34.CancelAfterMs = 15000;
		RecoveredType113 recoveredType35 = recoveredType34;
		recoveredType35.Counts["Common Fish Bait"] = 1;
		bool flag2 = false;
		try
		{
			new RecoveredType108(recoveredType35, delegate
			{
			}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
			{
			}, true);
		}
		catch
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2 && recoveredType35.Buys == 0, "Wrong quantity never commits");
		RecoveredType113 recoveredType36 = new RecoveredType113();
		recoveredType36.Delivery = 50;
		recoveredType36.CancelAfterMs = 25000;
		RecoveredType113 recoveredType37 = recoveredType36;
		recoveredType37.Counts["Common Fish Bait"] = 1;
		flag2 = false;
		try
		{
			new RecoveredType108(recoveredType37, delegate
			{
			}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
			{
			}, true);
		}
		catch
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2 && recoveredType37.Buys == 1, "Unverified delivery keeps waiting until Stop without another Buy");
		RecoveredType113 recoveredType38 = new RecoveredType113();
		recoveredType38.ExtraConfirm = true;
		RecoveredType113 recoveredType39 = recoveredType38;
		recoveredType39.Counts["Common Fish Bait"] = 2;
		new RecoveredType108(recoveredType39, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType39.Buys == 1 && recoveredType39.Counts["Common Fish Bait"] == 102 && recoveredType39.Stage == 0, "Optional final confirmation supported");
		RecoveredType113 recoveredType40 = new RecoveredType113();
		recoveredType40.Vendor = false;
		recoveredType40.CancelAfterMs = 3000;
		RecoveredType113 recoveredType41 = recoveredType40;
		recoveredType41.Counts["Common Fish Bait"] = 1;
		flag2 = false;
		try
		{
			new RecoveredType108(recoveredType41, delegate
			{
			}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
			{
			}, true);
		}
		catch
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2 && recoveredType41.Actions.Count == 0, "No E or purchase at another vendor");
		RecoveredType113 recoveredType42 = new RecoveredType113();
		recoveredType42.Stage = 1;
		recoveredType42.Vendor = false;
		RecoveredType113 recoveredType43 = recoveredType42;
		recoveredType43.Counts["Common Fish Bait"] = 1;
		new RecoveredType108(recoveredType43, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType43.Buys == 1 && !recoveredType43.Actions.Contains("E"), "Known Common confirmation resumes without pressing E again");
		RecoveredType113 recoveredType44 = new RecoveredType113();
		recoveredType44.Stage = 2;
		recoveredType44.CancelAfterMs = 3000;
		RecoveredType113 recoveredType45 = recoveredType44;
		recoveredType45.Counts["Common Fish Bait"] = 1;
		flag2 = false;
		try
		{
			new RecoveredType108(recoveredType45, delegate
			{
			}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
			{
			}, true);
		}
		catch
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2 && recoveredType45.Buys == 0, "Existing unrelated prompt is left alone");
		RecoveredType113 recoveredType46 = new RecoveredType113();
		recoveredType46.Selected = "Common Fish Bait";
		RecoveredType113 recoveredType47 = recoveredType46;
		recoveredType47.Counts["Common Fish Bait"] = 0;
		new RecoveredType108(recoveredType47, delegate
		{
		}).RecoveredMethod411(new RecoveredType170
		{
			AutoRestockCommon = false
		}, CancellationToken.None, delegate
		{
		}, false);
		RecoveredMethod42(recoveredType47.Buys == 0, "Last bait consumption does not interrupt an active cast");
		RecoveredType113 recoveredType48 = new RecoveredType113();
		recoveredType48.YesClicksRequired = 5;
		RecoveredType113 recoveredType49 = recoveredType48;
		recoveredType49.Counts["Common Fish Bait"] = 1;
		new RecoveredType108(recoveredType49, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType49.YesClicks == 5 && recoveredType49.Waits >= 2 && recoveredType49.Buys == 1, "Repeated first-prompt failures recover without ending the fishing session");
		RecoveredType113 recoveredType50 = new RecoveredType113();
		recoveredType50.DeliveryDelayMs = 20000;
		RecoveredType113 recoveredType51 = recoveredType50;
		recoveredType51.Counts["Common Fish Bait"] = 1;
		new RecoveredType108(recoveredType51, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType51.Buys == 1 && recoveredType51.Waits > 0 && recoveredType51.Counts["Common Fish Bait"] == 101, "Delayed receipt across retry cycles never sends a second Buy");
		RecoveredType113 recoveredType52 = new RecoveredType113();
		recoveredType52.CloseFailures = 1;
		RecoveredType113 recoveredType53 = recoveredType52;
		recoveredType53.Counts["Common Fish Bait"] = 1;
		new RecoveredType108(recoveredType53, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType53.Buys == 1 && recoveredType53.Actions.Count((string P_0) => P_0 == "Done:") == 2, "A missed completion dismissal retries without another purchase");
		RecoveredType113 recoveredType54 = new RecoveredType113();
		recoveredType54.AdvanceToDoneOnEntry = true;
		recoveredType54.ThrowAfterAdvance = true;
		RecoveredType113 recoveredType55 = recoveredType54;
		recoveredType55.Counts["Common Fish Bait"] = 49;
		new RecoveredType108(recoveredType55, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType55.Buys == 0 && recoveredType55.Stage == 0 && recoveredType55.Counts["Common Fish Bait"] == 149 && recoveredType55.Actions.Contains("Done:"), "A retry on the final screen dismisses it even when the prior quantity action threw before recording Buy");
		RecoveredType113 recoveredType56 = new RecoveredType113();
		recoveredType56.Stage = 3;
		RecoveredType113 recoveredType57 = recoveredType56;
		recoveredType57.Counts["Common Fish Bait"] = 145;
		new RecoveredType108(recoveredType57, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType57.Stage == 0 && recoveredType57.Buys == 0 && recoveredType57.Actions.Contains("Done:"), "An existing final screen with generic text closes without another purchase after worker restart");
		RecoveredType113 recoveredType58 = new RecoveredType113();
		recoveredType58.Stage = 3;
		recoveredType58.DoneNamesCommon = true;
		recoveredType58.CloseFailures = 2;
		RecoveredType113 recoveredType59 = recoveredType58;
		recoveredType59.Counts["Common Fish Bait"] = 145;
		new RecoveredType108(recoveredType59, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType59.Actions.Count((string P_0) => P_0 == "Done:") == 3 && recoveredType59.Buys == 0, "Final-screen recovery keeps retrying dismissal without reopening the shop");
		RecoveredType113 recoveredType60 = new RecoveredType113();
		recoveredType60.Vendor = false;
		recoveredType60.VendorAfterWaits = 2;
		RecoveredType113 recoveredType61 = recoveredType60;
		recoveredType61.Counts["Common Fish Bait"] = 1;
		new RecoveredType108(recoveredType61, delegate
		{
		}).RecoveredMethod411(new RecoveredType170(), CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType61.Waits == 2 && recoveredType61.Buys == 1, "Vendor availability is retried while enabled");
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		cancellationTokenSource.Cancel();
		RecoveredType113 recoveredType62 = new RecoveredType113();
		recoveredType62.Counts["Common Fish Bait"] = 1;
		flag2 = false;
		try
		{
			new RecoveredType108(recoveredType62, delegate
			{
			}).RecoveredMethod411(new RecoveredType170(), cancellationTokenSource.Token, delegate
			{
			}, true);
		}
		catch (OperationCanceledException)
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2 && recoveredType62.Buys == 0, "Cancellation prevents a purchase");
		RecoveredType113 recoveredType63 = new RecoveredType113();
		recoveredType63.MenuInitiallyHidden = true;
		RecoveredType113 recoveredType64 = recoveredType63;
		new RecoveredType108(recoveredType64, delegate
		{
		}).RecoveredMethod411(new RecoveredType170
		{
			AutoRestockCommon = false
		}, CancellationToken.None, delegate
		{
		}, true);
		RecoveredMethod42(recoveredType64.Selected == "Common Fish Bait" && recoveredType64.Reads >= 4, "Wait for rod bait menu instead of silently skipping selection");
		RecoveredType113 recoveredType65 = new RecoveredType113();
		recoveredType65.HideMenuAfterClick = true;
		recoveredType65.CancelAfterMs = 20000;
		RecoveredType113 recoveredType66 = recoveredType65;
		flag2 = false;
		try
		{
			new RecoveredType108(recoveredType66, delegate
			{
			}).RecoveredMethod411(new RecoveredType170
			{
				AutoRestockCommon = false
			}, CancellationToken.None, delegate
			{
			}, true);
		}
		catch
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2, "Disappearing menu does not falsely confirm a bait change");
		RecoveredType113 recoveredType67 = new RecoveredType113();
		recoveredType67.Counts["Legendary Fish Bait"] = 3;
		recoveredType67.Selected = "Common Fish Bait";
		new RecoveredType108(recoveredType67, delegate
		{
		}).RecoveredMethod411(new RecoveredType170
		{
			BaitMode = "best"
		}, CancellationToken.None, delegate
		{
		}, false);
		RecoveredMethod42(recoveredType67.Actions.Count == 0, "No bait changes while waiting for the active cast");
		RecoveredType251 recoveredType68 = new RecoveredType251();
		using (RecoveredType245 recoveredType69 = new RecoveredType245(recoveredType68, 8715))
		{
			recoveredType69.RecoveredMethod348(0.5, 0.42);
			recoveredType69.RecoveredMethod671(0.8, 0.9);
			recoveredType69.RecoveredMethod45();
			RecoveredMethod42(recoveredType68.Events.SequenceEqual(new string[3] { "move", "move", "move" }) && recoveredType68.Positions[0][0] == 0.5 && recoveredType68.Positions[0][1] == 0.42 && recoveredType68.Positions[1][0] == 0.8 && recoveredType68.Positions[2][0] == 0.5 && recoveredType68.Positions[2][1] == 0.42, "Start and UI return move without clicking");
		}
		CancellationTokenSource canceledHold = new CancellationTokenSource();
		RecoveredType114 recoveredType70 = new RecoveredType114();
		recoveredType70.OnSelect = delegate
		{
			canceledHold.Cancel();
		};
		RecoveredType114 recoveredType71 = recoveredType70;
		flag2 = false;
		try
		{
			using RecoveredType245 recoveredType72 = new RecoveredType245(recoveredType71, 8716);
			recoveredType72.RecoveredMethod675(65, 650, canceledHold.Token);
		}
		catch (OperationCanceledException)
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2 && recoveredType71.HeldKeys.Count == 0, "Canceled long key press releases the key");
		string[] array2 = new string[7] { "Anglerfish", "Dark Skeletal Shark", "Golden Polka Puffer", "Golden Ribbon Angelfish", "Golden Tigerfin", "Jack-O'-Bite", "Swordfish" };
		foreach (string text2 in array2)
		{
			ItemMetadata itemMetadata = new ItemMetadata();
			itemMetadata.Name = text2;
			ItemMetadata itemMetadata2 = itemMetadata;
			RecoveredType210.RecoveredMethod619(itemMetadata2);
			RecoveredMethod42(itemMetadata2.IsFish && itemMetadata2.Rarity == "Legendary", "Legendary fish screenshot mapping: " + text2);
		}
		ItemMetadata itemMetadata3 = new ItemMetadata();
		itemMetadata3.Name = "Skeletal Shark";
		itemMetadata3.Category = "Item";
		ItemMetadata itemMetadata4 = itemMetadata3;
		RecoveredType210.RecoveredMethod619(itemMetadata4);
		RecoveredMethod42(itemMetadata4.IsFish && itemMetadata4.Rarity == "Epic", "Epic fish classified independently of shared meshes");
		ItemMetadata itemMetadata5 = new ItemMetadata();
		itemMetadata5.Name = "Skeletal Shark Mask Blueprint";
		itemMetadata5.Category = "Item";
		int num2;
		if (!itemMetadata5.IsFish)
		{
			ItemMetadata itemMetadata6 = new ItemMetadata();
			itemMetadata6.Name = "Swordfish Rapier";
			itemMetadata6.Category = "Item";
			num2 = ((!itemMetadata6.IsFish) ? 1 : 0);
		}
		else
		{
			num2 = 0;
		}
		RecoveredMethod42((byte)num2 != 0, "Fish equipment names remain excluded");
		RecoveredMethod42(RecoveredType94.RecoveredMethod386("a", "a", false) && RecoveredType94.RecoveredMethod386("a", "b", true) && !RecoveredType94.RecoveredMethod386("a", "b", false), "Discovery requires same Windows user or administrator");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: bait threshold, verified 100-item restock, completion-prompt dismissal, Legendary→Rare→Common fallback, wrong quantity, partial delivery without retry, extra confirmation, vendor identity, existing prompts, active-cast exhaustion, cancellation, Windows discovery authorization. Also verified delayed/hidden menus, active-cast isolation, cursor anchoring, key-release cancellation and supplied fish rarity mappings. Persistent supply retries, pending purchase receipts, repeated missed Yes, delayed delivery, close-control recovery and Stop cancellation are also covered. No game input.\r\n");
	}

	public static void RecoveredMethod50()
	{
		string text = "twist1:26744:" + new string('a', 64);
		string received = null;
		bool connected = false;
		string text2 = "twist-discovery-test-" + Guid.NewGuid().ToString("N");
		string text3 = Guid.NewGuid().ToString("N");
		Func<bool> func = () => connected;
		using (new RecoveredType95(text3, func, () => received, delegate(string P_0)
		{
			received = P_0;
		}, text2))
		{
			string text4 = null;
			for (int num = 0; num < 15; num++)
			{
				try
				{
					text4 = RecoveredType97.RecoveredMethod388(Process.GetCurrentProcess().Id, RecoveredType309.SessionId, text, text2);
				}
				catch (TimeoutException)
				{
					Thread.Sleep(100);
					continue;
				}
				break;
			}
			RecoveredMethod42(text4 != null && received == text, "Actual named-pipe auto-pair exchange");
			connected = true;
			bool flag = false;
			try
			{
				string text5 = RecoveredType97.RecoveredMethod388(Process.GetCurrentProcess().Id, RecoveredType309.SessionId, "twist1:26744:" + new string('b', 64), text2);
				flag = text5.Contains("another controller");
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag && received == text, "Active controller ownership is retained");
		}
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: real Windows-authenticated named-pipe discovery, same-build/process identity checks, automatic pairing and active-controller ownership. No game input.\r\n");
		Console.WriteLine("PASS: Windows-authenticated automatic worker discovery.");
	}

	[CompilerGenerated]
	private static void RecoveredMethod420(RecoveredType104 P_0, string P_1)
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
	private static void RecoveredMethod421(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod422(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod423(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod424(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod425(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod84(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod426(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod93(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod427(RecoveredType104 P_0, string P_1)
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
	private static void RecoveredMethod429(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod430(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod431(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod432(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod119(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod160(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod433(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod434(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod435(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod436(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod169(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod437(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod192(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod438(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod248(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod439(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod273(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod440(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod312(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod441(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod442(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod443(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod444(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod445(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod446(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod447(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod448(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod449(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod450(string P_0)
	{
	}

	[CompilerGenerated]
	private static bool RecoveredMethod451(string P_0)
	{
		return P_0 == "Done:";
	}

	[CompilerGenerated]
	private static void RecoveredMethod452(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod453(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod454(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod455(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod456(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod457(string P_0)
	{
	}

	[CompilerGenerated]
	private static bool RecoveredMethod458(string P_0)
	{
		return P_0 == "Done:";
	}

	[CompilerGenerated]
	private static void RecoveredMethod459(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod460(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod461(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod462(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod463(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod464(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod465(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod466(string P_0)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod467(RecoveredType104 P_0, string P_1)
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod468(string P_0)
	{
	}
}
