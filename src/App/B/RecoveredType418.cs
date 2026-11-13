using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using TwistApp;

namespace b;

internal static class RecoveredType418
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Spawn history: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		string text = Path.Combine(Path.GetTempPath(), "twist-world-history-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text);
		try
		{
			RecoveredType416 recoveredType = new RecoveredType416(text);
			DateTime utcNow = DateTime.UtcNow;
			Func<string, string, string, WorldFruitRecord> func = (string P_0, string P_1, string P_2) => new WorldFruitRecord
			{
				Id = P_0,
				Account = P_1,
				Name = "Suke",
				Rarity = "Common",
				Server = "server",
				Hub = "Fishing Hub",
				Announcement = "A SUKE has spawned at FISHING HUB",
				Source = "Eye pulse",
				Position = new WorldPoint
				{
					RecoveredField2015 = -300.378,
					RecoveredField2016 = 24.217,
					RecoveredField2017 = -1939.673
				},
				AtUtc = P_2
			};
			WorldFruitRecord worldFruitRecord = func("first", "One", utcNow.ToString("o"));
			RecoveredMethod42(recoveredType.RecoveredMethod898(new WorldFruitRecord[1] { worldFruitRecord }) && !recoveredType.RecoveredMethod898(new WorldFruitRecord[1] { worldFruitRecord }), "new spawn saved once");
			RecoveredMethod42(recoveredType.RecoveredMethod898(new WorldFruitRecord[1] { func("second-worker", "Two", utcNow.AddSeconds(1.0).ToString("o")) }) && recoveredType.RecoveredMethod899("").Length == 1, "same-server duplicate retains both observing accounts");
			RecoveredMethod42(recoveredType.RecoveredMethod899("One").Length == 1 && recoveredType.RecoveredMethod899("Two").Length == 1, "per-account history includes shared sightings");
			RecoveredMethod42(recoveredType.RecoveredMethod898(new WorldFruitRecord[1] { func("next-spawn", "One", utcNow.AddMinutes(35.0).ToString("o")) }) && recoveredType.RecoveredMethod899("").Length == 2, "a later identical announcement is a separate spawn");
			WorldFruitRecord worldFruitRecord2 = func("missing", "One", utcNow.AddMinutes(70.0).ToString("o"));
			worldFruitRecord2.Position = null;
			recoveredType.RecoveredMethod898(new WorldFruitRecord[1] { worldFruitRecord2 });
			WorldFruitRecord worldFruitRecord3 = func("resolved-worker", "Two", utcNow.AddMinutes(70.0).AddSeconds(1.0).ToString("o"));
			recoveredType.RecoveredMethod898(new WorldFruitRecord[1] { worldFruitRecord3 });
			RecoveredMethod42(recoveredType.RecoveredMethod899("").Length == 3 && recoveredType.RecoveredMethod899("")[0].Position != null, "another worker can resolve previously unavailable coordinates");
			recoveredType.Completion.GetAwaiter().GetResult();
			RecoveredType416 recoveredType2 = new RecoveredType416(text);
			RecoveredMethod42(recoveredType2.RecoveredMethod899("").Length == 3 && !recoveredType2.RecoveredMethod898(new WorldFruitRecord[1] { worldFruitRecord }) && recoveredType2.RecoveredMethod899("Two").Length == 2, "AFK history and cross-worker dedup survive reopening");
			RecoveredMethod42(recoveredType2.RecoveredMethod899("").Last().Position.Compact == "-301, 24, -1940", "saved pulse coordinates preserved");
			Console.WriteLine("PASS: durable AFK spawn history, observer/account scope, cross-worker/restart dedup, repeated later spawns and late coordinate resolution.");
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
	private static WorldFruitRecord RecoveredMethod904(string P_0, string P_1, string P_2)
	{
		return new WorldFruitRecord
		{
			Id = P_0,
			Account = P_1,
			Name = "Suke",
			Rarity = "Common",
			Server = "server",
			Hub = "Fishing Hub",
			Announcement = "A SUKE has spawned at FISHING HUB",
			Source = "Eye pulse",
			Position = new WorldPoint
			{
				RecoveredField2015 = -300.378,
				RecoveredField2016 = 24.217,
				RecoveredField2017 = -1939.673
			},
			AtUtc = P_2
		};
	}
}
