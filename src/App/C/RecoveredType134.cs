using System;
using A;
using TwistApp;

namespace c;

internal sealed class RecoveredType134 : RecoveredType133, IDisposable
{
	public bool Disposed;

	public InventorySnapshot Value = new InventorySnapshot();

	public InventorySnapshot RecoveredMethod515()
	{
		return Value;
	}

	public void Dispose()
	{
		Disposed = true;
	}
}
