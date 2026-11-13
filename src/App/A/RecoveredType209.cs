using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TwistApp;
using b;

namespace a;

internal static class RecoveredType209
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Eye spawn: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		string[] source = new string[13]
		{
			"A", " ", "SUKE", " ", "has", " ", "spawned", " ", "at", " ",
			"FISHING", " ", "HUB"
		};
		KeyValuePair<string, string>[] array = source.Select((string P_0, int P_1) => new KeyValuePair<string, string>("Group" + (P_1 + 1).ToString("000"), P_0)).Reverse().ToArray();
		string text = RecoveredType196.RecoveredMethod592(array);
		RecoveredMethod42(text == "A SUKE has spawned at FISHING HUB", "rendered rich-text groups reconstruct exact announcement in order without duplicate character labels");
		RecoveredType194 recoveredType = RecoveredType196.RecoveredMethod591("notification", text);
		RecoveredMethod42(recoveredType != null && recoveredType.Name == "Suke" && recoveredType.Hub == "Fishing Hub" && recoveredType.Text == text, "captured Suke announcement is preserved exactly");
		RecoveredMethod42(RecoveredType196.RecoveredMethod591("test", "A <font color='green'>HEAL</font> has spawned at FISHING HUB").Text == "A HEAL has spawned at FISHING HUB", "formatting tags removed without rewriting words");
		RecoveredMethod42(RecoveredType196.RecoveredMethod591("test", "A fake object has spawned at FISHING HUB") == null, "unrecognized object cannot become a fruit alert");
		RecoveredMethod42(RecoveredType196.RecoveredMethod591("test", "Suke was stored successfully") == null, "storage messages cannot trigger pulse alerts");
		DateTime utcNow = DateTime.UtcNow;
		WorldPoint worldPoint = new WorldPoint();
		worldPoint.RecoveredField2015 = -300.378143;
		worldPoint.RecoveredField2016 = 24.2176819;
		worldPoint.RecoveredField2017 = -1939.673;
		WorldPoint position = worldPoint;
		RecoveredType195 recoveredType2 = new RecoveredType195();
		recoveredType2.Key = "pulse";
		recoveredType2.Position = position;
		RecoveredType195 recoveredType3 = recoveredType2;
		RecoveredType197 recoveredType4 = new RecoveredType197();
		recoveredType4.RecoveredMethod597(new RecoveredType194[0], new RecoveredType195[0], "server", "Demo", true, utcNow.AddSeconds(-1.0));
		WorldFruitRecord[] array2 = recoveredType4.RecoveredMethod597(new RecoveredType194[1] { recoveredType }, new RecoveredType195[1] { recoveredType3 }, "server", "Demo", true, utcNow);
		RecoveredMethod42(array2.Length == 1 && array2[0].Position.Compact == "-301, 24, -1940" && recoveredType4.Events.Length == 1, "recorded announcement pairs with the captured world pulse coordinate");
		WorldFruitRecord worldFruitRecord = recoveredType4.Events[0];
		string text2 = RecoveredType401.RecoveredMethod884(worldFruitRecord);
		RecoveredMethod42(text2.Contains(text) && text2.Contains("Coords: -301, 24, -1940") && text2.Contains("Suke spawned"), "Discord contains exact source announcement, Alert and Minecraft-style pulse coordinates");
		recoveredType4.RecoveredMethod597(new RecoveredType194[1] { recoveredType }, new RecoveredType195[1] { recoveredType3 }, "server", "Demo", true, utcNow.AddSeconds(1.0));
		RecoveredMethod42(recoveredType4.Events.Length == 1, "repeated animation frames cannot duplicate notifications");
		array2 = recoveredType4.RecoveredMethod597(new RecoveredType194[0], new RecoveredType195[0], "server", "Demo", true, utcNow.AddSeconds(35.0));
		RecoveredMethod42(array2.Length == 1 && array2[0].Position.Compact == "-301, 24, -1940" && !array2[0].Visible, "verified coordinates survive the temporary pulse disappearing");
		RecoveredType197 recoveredType5 = new RecoveredType197();
		recoveredType5.RecoveredMethod597(new RecoveredType194[1] { recoveredType }, new RecoveredType195[2]
		{
			recoveredType3,
			new RecoveredType195
			{
				Key = "other",
				Position = new WorldPoint
				{
					RecoveredField2015 = 500.0,
					RecoveredField2016 = 5.0,
					RecoveredField2017 = 100.0
				}
			}
		}, "server", "Demo", true, utcNow);
		RecoveredMethod42(recoveredType5.Events.Length == 0, "ambiguous pulse targets are not guessed");
		recoveredType5.RecoveredMethod597(new RecoveredType194[0], new RecoveredType195[0], "server", "Demo", true, utcNow.AddSeconds(41.0));
		RecoveredMethod42(recoveredType5.Events.Length == 1 && recoveredType5.Events[0].Position == null && RecoveredType401.RecoveredMethod884(recoveredType5.Events[0]).Contains("Unavailable"), "unresolved target sends announcement with an explicit unavailable coordinate");
		RecoveredType197 recoveredType6 = new RecoveredType197();
		recoveredType6.RecoveredMethod597(new RecoveredType194[0], new RecoveredType195[1] { recoveredType3 }, "server", "Demo", true, utcNow.AddSeconds(-10.0));
		recoveredType6.RecoveredMethod597(new RecoveredType194[1] { recoveredType }, new RecoveredType195[1] { recoveredType3 }, "server", "Demo", true, utcNow);
		RecoveredMethod42(recoveredType6.Events.Length == 0, "an old sphere is not paired with a new announcement");
		recoveredType6.RecoveredMethod597(new RecoveredType194[1] { recoveredType }, new RecoveredType195[1]
		{
			new RecoveredType195
			{
				Key = "new",
				Position = position
			}
		}, "server", "Demo", true, utcNow.AddSeconds(1.0));
		RecoveredMethod42(recoveredType6.Events.Length == 1, "a newly appearing matching pulse resolves the pending alert");
		RecoveredType197 recoveredType7 = new RecoveredType197();
		recoveredType7.RecoveredMethod597(new RecoveredType194[1] { recoveredType }, new RecoveredType195[1] { recoveredType3 }, "server", "Demo", false, utcNow);
		RecoveredMethod42(recoveredType7.Events.Length == 0, "Eye requirement respected");
		Console.WriteLine("PASS: exact live-announcement group reconstruction, captured pulse pairing, retained coordinates, duplicate/old/ambiguous target rejection and explicit unresolved alerts. No game input.");
	}

	[CompilerGenerated]
	private static KeyValuePair<string, string> RecoveredMethod618(string P_0, int P_1)
	{
		return new KeyValuePair<string, string>("Group" + (P_1 + 1).ToString("000"), P_0);
	}
}
