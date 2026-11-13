using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace a;

internal sealed class RecoveredType212
{
	[CompilerGenerated]
	private sealed class RecoveredType213
	{
		public ulong id;

		public bool RecoveredMethod621(RecoveredType211 P_0)
		{
			return P_0.Id == id;
		}
	}

	public RecoveredType211[] Tools = new RecoveredType211[0];

	public Dictionary<string, int> Stored = new Dictionary<string, int>(StringComparer.Ordinal);

	public bool InventoryReady;

	public bool BackpackOpen;

	public bool StoreReady;

	public bool Busy;

	public int RecoveredMethod403(string P_0)
	{
		if (!Stored.TryGetValue(P_0, out var value))
		{
			return 0;
		}
		return value;
	}

	public RecoveredType211 RecoveredMethod620(ulong P_0)
	{
		return Tools.FirstOrDefault((RecoveredType211 recoveredType) => recoveredType.Id == P_0);
	}
}
