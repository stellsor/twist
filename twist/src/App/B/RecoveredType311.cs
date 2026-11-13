using System;
using System.Collections.Generic;
using A;
using TwistApp;

namespace B;

internal sealed class RecoveredType311
{
	public RecoveredType82[] Activity;

	public RecoveredType310[] Accounts;

	public Dictionary<string, InventorySnapshot> Inventories = new Dictionary<string, InventorySnapshot>();

	public void RecoveredMethod779(string P_0, InventorySnapshot P_1)
	{
		if (P_1 != null && !string.IsNullOrEmpty(P_1.UserId) && P_1.Updated != DateTime.MinValue)
		{
			Inventories[P_0] = P_1;
		}
	}
}
