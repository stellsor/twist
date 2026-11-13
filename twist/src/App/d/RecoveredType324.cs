using System;
using A;
using TwistApp;

namespace D;

internal sealed class RecoveredType324 : RecoveredType133, IDisposable
{
	private readonly object gate = new object();

	private InventorySnapshot current = new InventorySnapshot
	{
		Status = "Waiting for worker inventory"
	};

	public InventorySnapshot RecoveredMethod515()
	{
		lock (gate)
		{
			return current;
		}
	}

	public void RecoveredMethod791(InventorySnapshot P_0)
	{
		lock (gate)
		{
			current = P_0;
		}
	}

	public void RecoveredMethod50()
	{
		lock (gate)
		{
			current = new InventorySnapshot
			{
				Account = current.Account,
				UserId = current.UserId,
				Items = current.Items,
				Gains = current.Gains,
				Updated = current.Updated,
				Valid = false,
				Status = "Worker offline · last known inventory"
			};
		}
	}

	public void Dispose()
	{
	}
}
