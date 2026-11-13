using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using A;
using C;
using TwistApp;

namespace b;

internal static class RecoveredType413
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("World fruit: " + P_1);
		}
	}

	private static RecoveredType405 RecoveredMethod891(string P_0, double P_1)
	{
		RecoveredType405 recoveredType = new RecoveredType405();
		recoveredType.Key = P_0;
		recoveredType.Name = "Kilo";
		recoveredType.Position = new WorldPoint
		{
			RecoveredField2015 = ((P_0 == "old") ? 584.6673 : 594.6673),
			RecoveredField2016 = 1.672852,
			RecoveredField2017 = -1485.757
		};
		recoveredType.HoldSeconds = P_1;
		return recoveredType;
	}

	public static void RecoveredMethod45()
	{
		ulong[] array = RecoveredType414.RecoveredMethod894(new ulong[1] { 1uL }, (ulong P_0) => (P_0 >= 202) ? new ulong[1] { 1uL } : new ulong[1] { P_0 + 1 }, (ulong P_0) => true).ToArray();
		RecoveredMethod42(array.Length == 202 && array.Last() == 202, "natural fruit hierarchy deeper than 100 folders is read with cycle protection");
		WorldPoint worldPoint = new WorldPoint();
		worldPoint.RecoveredField2015 = -0.1;
		worldPoint.RecoveredField2016 = 1.9;
		worldPoint.RecoveredField2017 = -1485.757;
		RecoveredMethod42(worldPoint.Label == "X -1   Y 1   Z -1486", "negative coordinates floor like Minecraft");
		string[] array2 = new string[8] { "All Seeing Eye", "Chromatic All Seeing Eye", "All Seeing Egg", "All Seeing Holly", "Cupid's All Seeing Eye", "All Seeing Shamrock", "All Seeing Blossom", "All Seeing Nightfall" };
		foreach (string text in array2)
		{
			RecoveredMethod42(RecoveredType406.RecoveredMethod39(text), "variant " + text);
		}
		RecoveredMethod42(!RecoveredType406.RecoveredMethod39("Devil Fruit Rod"), "non-Eye tools excluded");
		RecoveredMethod42(!RecoveredType406.RecoveredMethod885(RecoveredMethod891("drop", 0.5)), "upright dropped Kira/held prompts never qualify");
		RecoveredMethod42(RecoveredType406.RecoveredMethod885(RecoveredMethod891("spawn", 0.0)), "zero-hold pickup qualifies");
		RecoveredType405 recoveredType = RecoveredMethod891("unreadable", 0.0);
		recoveredType.HoldSeconds = null;
		RecoveredMethod42(!RecoveredType406.RecoveredMethod885(recoveredType), "missing pickup metadata cannot invent a spawn");
		recoveredType = RecoveredMethod891("invalid", 0.0);
		recoveredType.Position.RecoveredField2015 = double.NaN;
		RecoveredMethod42(!RecoveredType406.RecoveredMethod885(recoveredType), "invalid coordinates excluded");
		RecoveredType407 recoveredType2 = new RecoveredType407();
		DateTime utcNow = DateTime.UtcNow;
		RecoveredMethod42(recoveredType2.RecoveredMethod886(new RecoveredType405[1] { RecoveredMethod891("old", 0.0) }, "server-a", "Fishing Hub", "Demo", true, utcNow).Length == 1 && recoveredType2.Events.Length == 0, "existing fruit shown without replaying old spawn alerts");
		recoveredType2.RecoveredMethod886(new RecoveredType405[3]
		{
			RecoveredMethod891("old", 0.0),
			RecoveredMethod891("new", 0.0),
			RecoveredMethod891("drop", 0.5)
		}, "server-a", "Fishing Hub", "Demo", true, utcNow);
		RecoveredMethod42(recoveredType2.Events.Length == 1, "new tap fruit creates one event");
		recoveredType2.RecoveredMethod886(new RecoveredType405[2]
		{
			RecoveredMethod891("old", 0.0),
			RecoveredMethod891("new", 0.0)
		}, "server-a", "Fishing Hub", "Demo", true, utcNow);
		RecoveredMethod42(recoveredType2.Events.Length == 1, "unchanged readings do not duplicate events");
		WorldFruitRecord worldFruitRecord = recoveredType2.Events[0];
		RecoveredMethod42(RecoveredType401.RecoveredMethod884(worldFruitRecord).Contains("594, 1, -1486") && RecoveredType401.RecoveredMethod884(worldFruitRecord).Contains("Kilo spawned at Fishing Hub") && !RecoveredType401.RecoveredMethod884(worldFruitRecord).Contains("<@"), "spawn payload contains verified coordinates and no unrequested pings");
		recoveredType2.RecoveredMethod886(new RecoveredType405[1] { RecoveredMethod891("new", 0.0) }, "server-b", "Trade Hub", "Demo", true, utcNow);
		RecoveredMethod42(recoveredType2.Events.Length == 0, "server changes establish a new baseline");
		recoveredType2.RecoveredMethod886(new RecoveredType405[1] { RecoveredMethod891("another", 0.0) }, "server-b", "Trade Hub", "Demo", false, utcNow);
		RecoveredMethod42(recoveredType2.Events.Length == 0, "no Eye means no spawn webhook events");
		RecoveredType407 recoveredType3 = new RecoveredType407();
		recoveredType3.RecoveredMethod886(new RecoveredType405[1] { RecoveredMethod891("cache", 0.0) }, "cache-server", "Fishing Hub", "Demo", true, utcNow, new WorldPoint
		{
			RecoveredField2015 = 593.0,
			RecoveredField2016 = 4.0,
			RecoveredField2017 = -1483.0
		});
		WorldFruitRecord[] array3 = recoveredType3.RecoveredMethod886(new RecoveredType405[0], "cache-server", "Fishing Hub", "Demo", true, utcNow.AddMinutes(1.0), new WorldPoint
		{
			RecoveredField2015 = -80.0,
			RecoveredField2016 = 4.0,
			RecoveredField2017 = -1350.0
		});
		RecoveredMethod42(array3.Length == 1 && !array3[0].Visible, "unstreamed distant fruit retains a labelled last-seen coordinate");
		recoveredType3.RecoveredMethod886(new RecoveredType405[1] { RecoveredMethod891("cache-new-pointer", 0.0) }, "cache-server", "Fishing Hub", "Demo", true, utcNow.AddMinutes(2.0), new WorldPoint
		{
			RecoveredField2015 = 593.0,
			RecoveredField2016 = 4.0,
			RecoveredField2017 = -1483.0
		});
		RecoveredMethod42(recoveredType3.Events.Length == 0, "streaming the same fruit back in does not replay a spawn");
		RecoveredMethod42(recoveredType3.RecoveredMethod886(new RecoveredType405[0], "cache-server", "Fishing Hub", "Demo", true, utcNow.AddMinutes(3.0), new WorldPoint
		{
			RecoveredField2015 = 593.0,
			RecoveredField2016 = 4.0,
			RecoveredField2017 = -1483.0
		}).Length == 0, "missing nearby fruit clears the marker");
		RecoveredMethod892(worldFruitRecord);
		Console.WriteLine("PASS: Eye variants, negative XYZ, held/missing/invalid pickup rejection, spawn baseline/event dedup/server reset, coordinate webhook and cross-worker/restart deduplication. No game input or Discord messages.");
	}

	private static void RecoveredMethod892(WorldFruitRecord P_0)
	{
		string text = Path.Combine(Path.GetTempPath(), "twist-world-alerts-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text);
		RecoveredType90 recoveredType = new RecoveredType90();
		try
		{
			using (RecoveredType150 recoveredType2 = new RecoveredType150(text, delegate
			{
			}, recoveredType, (int num2, CancellationToken cancellationToken) => Task.FromResult(0), DateTime.MinValue))
			{
				recoveredType2.RecoveredMethod532(new RecoveredType141
				{
					Enabled = false,
					SpawnEnabled = true,
					Url = "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890"
				});
				recoveredType2.RecoveredMethod536(new WorldFruitRecord[1] { P_0 });
				DateTime dateTime = DateTime.UtcNow.AddSeconds(5.0);
				while (recoveredType.Calls < 1 && DateTime.UtcNow < dateTime)
				{
					Thread.Sleep(10);
				}
				RecoveredMethod42(recoveredType.Calls == 1, "spawn alerts work independently of stored-fruit alerts");
				WorldFruitRecord worldFruitRecord = new JavaScriptSerializer().Deserialize<WorldFruitRecord>(new JavaScriptSerializer().Serialize(P_0));
				worldFruitRecord.Id = "another-worker";
				recoveredType2.RecoveredMethod536(new WorldFruitRecord[1] { worldFruitRecord });
				Thread.Sleep(100);
				RecoveredMethod42(recoveredType.Calls == 1, "same-server duplicate across workers suppressed");
				while (recoveredType2.Status.Contains("pending") && DateTime.UtcNow < dateTime)
				{
					Thread.Sleep(10);
				}
			}
			using RecoveredType150 recoveredType3 = new RecoveredType150(text, delegate
			{
			}, recoveredType, (int num2, CancellationToken cancellationToken) => Task.FromResult(0), DateTime.MinValue);
			recoveredType3.RecoveredMethod536(new WorldFruitRecord[1] { P_0 });
			Thread.Sleep(100);
			RecoveredMethod42(recoveredType.Calls == 1, "persisted receipt suppresses reconnect/restart replay");
		}
		finally
		{
			string[] files = Directory.GetFiles(text);
			foreach (string path in files)
			{
				File.Delete(path);
			}
			Directory.Delete(text);
		}
	}

	[CompilerGenerated]
	private static IEnumerable<ulong> RecoveredMethod893(ulong P_0)
	{
		if (P_0 >= 202)
		{
			return new ulong[1] { 1uL };
		}
		return new ulong[1] { P_0 + 1 };
	}

	[CompilerGenerated]
	private static bool RecoveredMethod473(ulong P_0)
	{
		return true;
	}

	[CompilerGenerated]
	private static void RecoveredMethod48(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod193(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static void RecoveredMethod414(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod313(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}
}
