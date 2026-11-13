using System;

namespace TwistApp;

public sealed class InventorySnapshot
{
	public string Account;

	public string UserId;

	public string Status;

	public DateTime Updated;

	public InventoryEntry[] Items = new InventoryEntry[0];

	public InventoryGain[] Gains = new InventoryGain[0];

	public bool Valid;
}
