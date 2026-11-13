using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using a;

namespace A;

internal sealed class RecoveredType108
{
	private sealed class RecoveredType109
	{
		public int Baseline;

		public int Amount;

		public int Threshold;

		public bool Sent;

		public bool Delivered;

		public bool FinalConfirmationSent;
	}

	[CompilerGenerated]
	private sealed class RecoveredType110
	{
		public string bait;

		public bool RecoveredMethod415(RecoveredType104 P_0)
		{
			if (P_0.BaitMenu)
			{
				return string.Equals(P_0.Selected, bait, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType111
	{
		public string wanted;

		public RecoveredType108 _003C_003E4__this;

		public bool RecoveredMethod415(RecoveredType104 P_0)
		{
			if (P_0.Quantity)
			{
				return P_0.QuantityText.Trim() == wanted;
			}
			return false;
		}
	}

	private readonly RecoveredType105 port;

	private readonly Action<string> log;

	private readonly Action<string> status;

	private RecoveredType109 pending;

	private string lastRetry = "";

	private DateTime retryLogged = DateTime.MinValue;

	public RecoveredType108(RecoveredType105 P_0, Action<string> P_1, Action<string> P_2 = null)
	{
		port = P_0;
		log = P_1;
		status = P_2 ?? ((Action<string>)delegate
		{
		});
	}

	private void RecoveredMethod48(string P_0)
	{
		status(P_0);
		log(P_0);
	}

	private RecoveredType104 RecoveredMethod410(Func<RecoveredType104, bool> P_0, int P_1, CancellationToken P_2, string P_3)
	{
		RecoveredType104 recoveredType = null;
		for (int i = 0; i <= P_1; i += 100)
		{
			P_2.ThrowIfCancellationRequested();
			RecoveredType104 recoveredType2 = port.RecoveredMethod401();
			recoveredType = recoveredType2;
			if (P_0(recoveredType2))
			{
				return recoveredType2;
			}
			port.RecoveredMethod393(100, P_2);
		}
		throw new Exception(P_3 + ((recoveredType == null || recoveredType.Debug == "") ? "" : (" · " + recoveredType.Debug)));
	}

	public string RecoveredMethod411(RecoveredType170 P_0, CancellationToken P_1, Action<RecoveredType104, string> P_2, bool P_3)
	{
		P_0.RecoveredMethod50();
		while (true)
		{
			P_1.ThrowIfCancellationRequested();
			try
			{
				return RecoveredMethod412(P_0, P_1, P_2, P_3);
			}
			catch (OperationCanceledException)
			{
				throw;
			}
			catch (Exception ex2)
			{
				string text = ((pending != null && pending.Sent) ? "Waiting for the existing bait purchase · " : "Supplies paused; retrying · ") + ex2.Message;
				status(text);
				if (text != lastRetry || DateTime.UtcNow - retryLogged > TimeSpan.FromSeconds(10.0))
				{
					RecoveredMethod48(text);
					lastRetry = text;
					retryLogged = DateTime.UtcNow;
				}
				port.RecoveredMethod395(1000, P_1);
			}
		}
	}

	private string RecoveredMethod412(RecoveredType170 P_0, CancellationToken P_1, Action<RecoveredType104, string> P_2, bool P_3)
	{
		RecoveredType104 recoveredType = port.RecoveredMethod401();
		if (P_3 && recoveredType.Dialog && recoveredType.Done)
		{
			if (pending != null && pending.Sent)
			{
				RecoveredMethod394(P_1);
			}
			else
			{
				RecoveredMethod48("Closing the final vendor dialog · Common stock " + recoveredType.Common);
				port.RecoveredMethod402(RecoveredType103.Done, null);
				port.RecoveredMethod393(650, P_1);
				RecoveredMethod410((RecoveredType104 recoveredType2) => !recoveredType2.Dialog && !recoveredType2.Quantity, 3000, P_1, "Waiting for the final vendor prompt to close.");
				pending = null;
			}
			recoveredType = port.RecoveredMethod401();
		}
		if (!P_3)
		{
			P_2(recoveredType, recoveredType.Selected);
			return recoveredType.Selected;
		}
		if (pending != null || (P_0.AutoRestockCommon && RecoveredType106.RecoveredMethod405(recoveredType.Common, P_0.RestockBelow)))
		{
			RecoveredMethod413(recoveredType, P_0, P_1);
			recoveredType = port.RecoveredMethod401();
		}
		if (recoveredType.Dialog || recoveredType.Quantity)
		{
			throw new Exception("Waiting for the purchase prompt to close.");
		}
		string bait = RecoveredType106.RecoveredMethod404(recoveredType.Counts, P_0.BaitMode);
		if (bait == null)
		{
			throw new Exception((P_0.BaitMode == "common") ? "Waiting for Common Fish Bait." : "Waiting for Legendary, Rare, or Common bait.");
		}
		if (!recoveredType.BaitMenu)
		{
			recoveredType = RecoveredMethod410((RecoveredType104 recoveredType2) => recoveredType2.BaitMenu, 5000, P_1, "Waiting for the Fishing Baits list; equip the rod and close other menus.");
		}
		P_2(recoveredType, bait);
		if (!string.Equals(recoveredType.Selected, bait, StringComparison.OrdinalIgnoreCase))
		{
			RecoveredMethod48("Selecting " + bait);
			port.RecoveredMethod402(RecoveredType103.Bait, bait);
			RecoveredMethod410((RecoveredType104 recoveredType2) => recoveredType2.BaitMenu && string.Equals(recoveredType2.Selected, bait, StringComparison.OrdinalIgnoreCase), 4000, P_1, "The bait selection has not updated yet.");
		}
		port.RecoveredMethod51();
		return bait;
	}

	private void RecoveredMethod392(CancellationToken P_0)
	{
		bool flag = false;
		RecoveredType104 recoveredType = null;
		for (int i = 0; i <= 6500; i += 100)
		{
			P_0.ThrowIfCancellationRequested();
			recoveredType = port.RecoveredMethod401();
			if (recoveredType.Quantity)
			{
				return;
			}
			if (i >= 2500 && !flag && recoveredType.Dialog && recoveredType.CommonDialog && !recoveredType.Done && recoveredType.ConfirmationAmount <= 1)
			{
				RecoveredMethod48("Yes was not acknowledged · resetting the pointer and retrying the verified first confirmation");
				port.RecoveredMethod402(RecoveredType103.Yes, "initial-retry");
				port.RecoveredMethod393(900, P_0);
				flag = true;
			}
			port.RecoveredMethod393(100, P_0);
		}
		throw new Exception("The bait quantity screen has not opened yet." + ((recoveredType == null) ? "" : (" · " + recoveredType.Debug)));
	}

	private void RecoveredMethod413(RecoveredType104 P_0, RecoveredType170 P_1, CancellationToken P_2)
	{
		if (pending == null)
		{
			if (P_0.Quantity || (P_0.Dialog && (!P_0.CommonDialog || P_0.Done || P_0.ConfirmationAmount > 1)))
			{
				throw new Exception("Waiting for an unverified purchase prompt to close.");
			}
			if (!P_0.Dialog && !P_0.CommonVendor)
			{
				throw new Exception("Common bait is below " + P_1.RestockBelow + "; waiting for a Common Fish Bait vendor within 12 studs. · " + P_0.Debug);
			}
			pending = new RecoveredType109
			{
				Baseline = P_0.Common,
				Amount = P_1.RestockBuy,
				Threshold = P_1.RestockBelow
			};
			RecoveredMethod48("Restocking Common Fish Bait · buying " + pending.Amount);
		}
		if (!pending.Sent && P_0.Common >= (long)pending.Baseline + (long)pending.Amount)
		{
			pending.Sent = (pending.Delivered = true);
			RecoveredMethod48("Recovered the completed purchase from its +" + pending.Amount + " inventory receipt");
		}
		if (pending.Sent)
		{
			RecoveredMethod394(P_2);
			return;
		}
		if (P_0.Common >= pending.Threshold && !P_0.Dialog && !P_0.Quantity)
		{
			pending = null;
			return;
		}
		if (P_0.Dialog && (!P_0.CommonDialog || P_0.Done || P_0.ConfirmationAmount > 1))
		{
			throw new Exception("Waiting for the verified Common-bait purchase controls. · " + P_0.Debug);
		}
		if (!P_0.Quantity && !P_0.Dialog)
		{
			if (!P_0.CommonVendor)
			{
				throw new Exception("Waiting for a Common Fish Bait vendor within 12 studs. · " + P_0.Debug);
			}
			port.RecoveredMethod50();
			port.RecoveredMethod393(900, P_2);
		}
		else if (P_0.Dialog)
		{
			RecoveredMethod48("Resuming the verified Common bait purchase prompt");
		}
		RecoveredType104 recoveredType = RecoveredMethod410((RecoveredType104 recoveredType2) => recoveredType2.Quantity || (recoveredType2.Dialog && recoveredType2.CommonDialog && !recoveredType2.Done && recoveredType2.ConfirmationAmount <= 1), 8000, P_2, "The Common bait purchase prompt has not become ready.");
		if (!recoveredType.Quantity)
		{
			port.RecoveredMethod402(RecoveredType103.Yes, "initial");
			port.RecoveredMethod393(900, P_2);
		}
		RecoveredMethod392(P_2);
		port.RecoveredMethod402(RecoveredType103.Quantity, null);
		port.RecoveredMethod393(400, P_2);
		port.RecoveredMethod377(pending.Amount);
		port.RecoveredMethod393(300, P_2);
		string wanted = pending.Amount.ToString(CultureInfo.InvariantCulture);
		recoveredType = RecoveredMethod410((RecoveredType104 recoveredType2) => recoveredType2.Quantity && recoveredType2.QuantityText.Trim() == wanted, 4000, P_2, "Waiting to verify quantity " + wanted + "; no purchase sent.");
		port.RecoveredMethod393(400, P_2);
		pending.Baseline = recoveredType.Common;
		RecoveredMethod48("Quantity " + pending.Amount + " verified · confirming purchase");
		port.RecoveredMethod402(RecoveredType103.Buy, null, delegate
		{
			pending.Sent = true;
			RecoveredMethod48("Purchase input sent · waiting for +" + pending.Amount + " Common bait from " + pending.Baseline);
		});
		port.RecoveredMethod393(900, P_2);
		RecoveredMethod394(P_2);
	}

	private void RecoveredMethod394(CancellationToken P_0)
	{
		if (!pending.Delivered)
		{
			for (int i = 0; i < 8000; i += 100)
			{
				P_0.ThrowIfCancellationRequested();
				RecoveredType104 recoveredType = port.RecoveredMethod401();
				if (recoveredType.Common >= (long)pending.Baseline + (long)pending.Amount)
				{
					pending.Delivered = true;
					break;
				}
				if (!pending.FinalConfirmationSent && recoveredType.Dialog && recoveredType.CommonDialog && recoveredType.ConfirmationAmount == pending.Amount && !recoveredType.Done)
				{
					port.RecoveredMethod402(RecoveredType103.Yes, null, delegate
					{
						pending.FinalConfirmationSent = true;
					});
					port.RecoveredMethod393(900, P_0);
				}
				port.RecoveredMethod393(100, P_0);
			}
			if (!pending.Delivered)
			{
				throw new Exception("Inventory has not confirmed +" + pending.Amount + " yet; waiting for this purchase without sending another Buy.");
			}
		}
		port.RecoveredMethod393(400, P_0);
		RecoveredType104 recoveredType2 = port.RecoveredMethod401();
		if (recoveredType2.Dialog)
		{
			RecoveredMethod410((RecoveredType104 recoveredType3) => !recoveredType3.Dialog || recoveredType3.Done, 3000, P_0, "Waiting for the purchase completion control.");
			recoveredType2 = port.RecoveredMethod401();
			if (recoveredType2.Dialog && recoveredType2.Done)
			{
				port.RecoveredMethod402(RecoveredType103.Done, null);
				port.RecoveredMethod393(650, P_0);
			}
		}
		RecoveredMethod410((RecoveredType104 recoveredType3) => !recoveredType3.Dialog && !recoveredType3.Quantity, 3000, P_0, "Waiting for the purchase prompt to close.");
		RecoveredMethod48("Restock confirmed · +" + pending.Amount + " Common Fish Bait");
		pending = null;
	}

	[CompilerGenerated]
	private static void RecoveredMethod414(string P_0)
	{
	}

	[CompilerGenerated]
	private static bool RecoveredMethod415(RecoveredType104 P_0)
	{
		if (!P_0.Dialog)
		{
			return !P_0.Quantity;
		}
		return false;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod416(RecoveredType104 P_0)
	{
		return P_0.BaitMenu;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod417(RecoveredType104 P_0)
	{
		if (!P_0.Quantity)
		{
			if (P_0.Dialog && P_0.CommonDialog && !P_0.Done)
			{
				return P_0.ConfirmationAmount <= 1;
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	private void RecoveredMethod45()
	{
		pending.Sent = true;
		RecoveredMethod48("Purchase input sent · waiting for +" + pending.Amount + " Common bait from " + pending.Baseline);
	}

	[CompilerGenerated]
	private void RecoveredMethod50()
	{
		pending.FinalConfirmationSent = true;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod418(RecoveredType104 P_0)
	{
		if (P_0.Dialog)
		{
			return P_0.Done;
		}
		return true;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod419(RecoveredType104 P_0)
	{
		if (!P_0.Dialog)
		{
			return !P_0.Quantity;
		}
		return false;
	}
}
