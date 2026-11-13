using System;

namespace TwistApp;

public sealed class InventoryGain
{
	public string Id = Guid.NewGuid().ToString("N");

	public string Name;

	public string AtUtc;

	public int Count;

	public bool Fishing;
}
