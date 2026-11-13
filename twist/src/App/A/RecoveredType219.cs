using System;
using System.Collections.Generic;
using TwistApp;

namespace a;

internal static class RecoveredType219
{
	private static readonly Dictionary<string, string> known;

	static RecoveredType219()
	{
		known = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		RecoveredMethod82("Common", "Suke Kilo Spin Heal");
		RecoveredMethod82("Rare", "Bari Mero Horo Gomu Bomu Bomb");
		RecoveredMethod82("Epic", "Yomi Spring Kira");
		RecoveredMethod82("Legendary", "Mera Pika Hie Magu Goro Gura Zushi Suna Ito Paw Yuki Kage Yami Goru Smoke Biscuit");
		RecoveredMethod82("Mythical", "Tori Mochi Ope Venom Buddha Pteranodon Ptero Dragon Soul Leopard");
	}

	private static void RecoveredMethod82(string P_0, string P_1)
	{
		string[] array = P_1.Split(' ');
		foreach (string key in array)
		{
			known[key] = P_0;
		}
	}

	public static bool RecoveredMethod39(string P_0)
	{
		if (P_0 != null)
		{
			return known.ContainsKey(P_0);
		}
		return false;
	}

	public static string RecoveredMethod52(string P_0)
	{
		if (P_0 == null || !known.TryGetValue(P_0, out var value))
		{
			return "Unknown";
		}
		return value;
	}

	public static void RecoveredMethod619(ItemMetadata P_0)
	{
		if (P_0 != null && RecoveredMethod39(P_0.Name))
		{
			P_0.Category = "Fruit";
			if (string.IsNullOrEmpty(P_0.Rarity) || P_0.Rarity == "Unknown")
			{
				P_0.Rarity = RecoveredMethod52(P_0.Name);
			}
		}
	}
}
