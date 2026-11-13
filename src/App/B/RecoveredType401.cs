using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using TwistApp;

namespace b;

internal static class RecoveredType401
{
	private static string RecoveredMethod381(string P_0)
	{
		return new string((P_0 ?? "").Where((char c) => !char.IsControl(c)).Take(120).ToArray()).Replace("@", "＠").Replace("<", "‹").Replace(">", "›");
	}

	public static string RecoveredMethod884(WorldFruitRecord P_0)
	{
		return new JavaScriptSerializer().Serialize(new L<string, string, l<string[]>, M<string, string, int, j<string, string, bool>[], K<string>, string>[]>("twist", string.IsNullOrEmpty(P_0.Announcement) ? (RecoveredMethod381(P_0.Name) + " spawned at " + RecoveredMethod381(P_0.Hub)) : P_0.Announcement, new l<string[]>(new string[0]), new M<string, string, int, j<string, string, bool>[], K<string>, string>[1]
		{
			new M<string, string, int, j<string, string, bool>[], K<string>, string>("Alert", RecoveredMethod381(P_0.Name) + " spawned\nCoords: " + ((P_0.Position == null) ? "Unavailable — pulse target was not readable" : P_0.Position.Compact), 12495603, new j<string, string, bool>[5]
			{
				new j<string, string, bool>("Fruit", RecoveredMethod381(P_0.Name), true),
				new j<string, string, bool>("Rarity", RecoveredMethod381(P_0.Rarity), true),
				new j<string, string, bool>("Coordinates", (P_0.Position == null) ? "Unavailable — pulse target was not readable" : P_0.Position.Compact, false),
				new j<string, string, bool>("Detected by", "@" + RecoveredMethod381(P_0.Account), true),
				new j<string, string, bool>("Location", RecoveredMethod381(P_0.Hub), true)
			}, new K<string>("twist · All Seeing Eye spawn alert"), P_0.AtUtc)
		}));
	}

	[CompilerGenerated]
	private static bool RecoveredMethod530(char P_0)
	{
		return !char.IsControl(P_0);
	}
}
