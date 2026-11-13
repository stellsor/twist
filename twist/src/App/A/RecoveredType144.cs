using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using TwistApp;
using b;

namespace A;

internal static class RecoveredType144
{
	private static string RecoveredMethod381(string P_0)
	{
		return new string((P_0 ?? "").Where((char c) => !char.IsControl(c)).Take(120).ToArray()).Replace("@", "＠").Replace("<", "‹").Replace(">", "›");
	}

	private static string RecoveredMethod380(int P_0)
	{
		if (P_0 >= 0)
		{
			return P_0.ToString("N0", CultureInfo.InvariantCulture);
		}
		return "unknown";
	}

	public static string RecoveredMethod96(double P_0)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(Math.Max(0.0, Math.Min(315360000.0, P_0)));
		return ((int)timeSpan.TotalHours).ToString("00") + ":" + timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
	}

	public static string RecoveredMethod529(FruitStoredRecord P_0, RecoveredType141 P_1, bool P_2 = false)
	{
		P_1.RecoveredMethod50();
		bool flag = !P_2 && P_1.PingMythical && string.Equals(P_0.Rarity, "Mythical", StringComparison.OrdinalIgnoreCase);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("parse", new string[0]);
		Dictionary<string, object> dictionary2 = dictionary;
		string text = "";
		string text2 = P_1.RecoveredMethod525();
		if (flag)
		{
			if (P_1.PingKind == "Everyone")
			{
				text = "@everyone ";
				dictionary2["parse"] = new string[1] { "everyone" };
			}
			else if (text2 == "")
			{
				string text3 = RecoveredMethod381((P_1.PingId ?? "").Trim().TrimStart('@'));
				if (text3 != "")
				{
					text = "@" + text3 + " ";
				}
			}
			else if (P_1.PingKind == "Role")
			{
				text = "<@&" + text2 + "> ";
				dictionary2["roles"] = new string[1] { text2 };
			}
			else
			{
				text = "<@" + text2 + "> ";
				dictionary2["users"] = new string[1] { text2 };
			}
		}
		string text4 = "Common: " + RecoveredMethod380(P_0.Common) + " · Rare: " + RecoveredMethod380(P_0.Rare) + " · Legendary: " + RecoveredMethod380(P_0.Legendary);
		if (P_0.Common >= 0 && P_0.Rare >= 0 && P_0.Legendary >= 0)
		{
			text4 = ((long)P_0.Common + (long)P_0.Rare + P_0.Legendary).ToString("N0", CultureInfo.InvariantCulture) + " total\n" + text4;
		}
		j<string, string, bool>[] array = new j<string, string, bool>[5]
		{
			new j<string, string, bool>("Account", RecoveredMethod381(P_0.Account), true),
			new j<string, string, bool>("Rarity", RecoveredMethod381(P_0.Rarity), true),
			new j<string, string, bool>("Fish caught", RecoveredMethod380(P_0.FishCaught), true),
			new j<string, string, bool>("Fishing time", RecoveredMethod96(P_0.Seconds), true),
			new j<string, string, bool>("Bait remaining", text4, false)
		};
		return new JavaScriptSerializer().Serialize(new L<string, string, Dictionary<string, object>, k<string, int, j<string, string, bool>[], K<string>, string>[]>("twist", P_2 ? "twist webhook test — connection successful" : (text + RecoveredMethod381(P_0.Name) + " was stored successfully"), dictionary2, new k<string, int, j<string, string, bool>[], K<string>, string>[1]
		{
			new k<string, int, j<string, string, bool>[], K<string>, string>(P_2 ? "Test notification" : "Fruit stored", string.Equals(P_0.Rarity, "Mythical", StringComparison.OrdinalIgnoreCase) ? 15372957 : 12495603, array, new K<string>("twist · account runtime statistics"), P_0.AtUtc)
		}));
	}

	[CompilerGenerated]
	private static bool RecoveredMethod530(char P_0)
	{
		return !char.IsControl(P_0);
	}
}
