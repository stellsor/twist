using System;
using System.Collections.Generic;
using TwistApp;

namespace a;

internal static class RecoveredType210
{
	private static readonly Dictionary<string, string> Known = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
	{
		{ "Blue-Lip Grouper", "Common" },
		{ "Tigerfin", "Common" },
		{ "Candy Corn Squid", "Rare" },
		{ "Crimson Polka Puffer", "Rare" },
		{ "Crimson Snapper", "Rare" },
		{ "Exotic Tigerfin", "Rare" },
		{ "Fangfish", "Rare" },
		{ "Zebra Ribbon Angelfish", "Rare" },
		{ "Skeletal Shark", "Epic" },
		{ "Anglerfish", "Legendary" },
		{ "Dark Skeletal Shark", "Legendary" },
		{ "Golden Polka Puffer", "Legendary" },
		{ "Golden Ribbon Angelfish", "Legendary" },
		{ "Golden Tigerfin", "Legendary" },
		{ "Swordfish", "Legendary" },
		{ "Jack-O'-Bite", "Legendary" },
		{ "Jack-O-Bite", "Legendary" }
	};

	public static bool RecoveredMethod39(string P_0)
	{
		if (P_0 != null)
		{
			return Known.ContainsKey(P_0.Replace('’', '\''));
		}
		return false;
	}

	public static void RecoveredMethod619(ItemMetadata P_0)
	{
		if (P_0 != null && P_0.Name != null && Known.TryGetValue(P_0.Name.Replace('’', '\''), out var value))
		{
			P_0.Category = "Fish";
			P_0.Rarity = value;
		}
	}
}
