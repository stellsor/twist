using System;
using System.Globalization;

namespace TwistApp;

public sealed class WorldFruitRecord
{
	public string Id;

	public string Name;

	public string Rarity;

	public string Server;

	public string Hub;

	public string Account;

	public string AtUtc;

	public string LastSeenUtc;

	public string Announcement;

	public string Source;

	public bool Visible = true;

	public string[] Observers = new string[0];

	public WorldPoint Position;

	public string Fingerprint()
	{
		return (Server ?? "") + "|" + Name + "|" + ((Position == null) ? (Announcement ?? "unknown") : (Math.Round(Position.RecoveredField2015).ToString("0", CultureInfo.InvariantCulture) + "|" + Math.Round(Position.RecoveredField2016).ToString("0", CultureInfo.InvariantCulture) + "|" + Math.Round(Position.RecoveredField2017).ToString("0", CultureInfo.InvariantCulture)));
	}
}
