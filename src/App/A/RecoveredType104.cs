using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace A;

internal sealed class RecoveredType104
{
	public Dictionary<string, int> Counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

	public bool BaitMenu;

	public bool CommonVendor;

	public bool Dialog;

	public bool CommonDialog;

	public bool Done;

	public bool Quantity;

	public int ConfirmationAmount;

	public string QuantityText = "";

	public string Selected = "";

	public string DialogText = "";

	public string Debug = "";

	public int Common => Counts.Where((KeyValuePair<string, int> P_0) => RecoveredType106.RecoveredMethod403(P_0.Key) == 1).Sum((KeyValuePair<string, int> P_0) => P_0.Value);

	[CompilerGenerated]
	private static bool RecoveredMethod399(KeyValuePair<string, int> P_0)
	{
		return RecoveredType106.RecoveredMethod403(P_0.Key) == 1;
	}

	[CompilerGenerated]
	private static int RecoveredMethod400(KeyValuePair<string, int> P_0)
	{
		return P_0.Value;
	}
}
