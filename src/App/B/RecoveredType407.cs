using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TwistApp;
using a;

namespace b;

internal sealed class RecoveredType407
{
	private sealed class RecoveredType408
	{
		public WorldFruitRecord Record;

		public DateTime First;

		public DateTime Last;
	}

	[CompilerGenerated]
	private sealed class RecoveredType409
	{
		public HashSet<string> visible;

		public WorldFruitRecord RecoveredMethod887(KeyValuePair<string, RecoveredType408> P_0)
		{
			RecoveredType408 value = P_0.Value;
			WorldFruitRecord record = value.Record;
			return new WorldFruitRecord
			{
				Id = record.Id,
				Name = record.Name,
				Rarity = record.Rarity,
				Server = record.Server,
				Hub = record.Hub,
				Account = record.Account,
				AtUtc = record.AtUtc,
				LastSeenUtc = value.Last.ToString("o"),
				Visible = visible.Contains(P_0.Key),
				Source = record.Source,
				Announcement = record.Announcement,
				Position = record.Position
			};
		}
	}

	private string server = "";

	private bool initialized;

	private readonly Dictionary<string, RecoveredType408> known = new Dictionary<string, RecoveredType408>();

	private readonly List<WorldFruitRecord> events = new List<WorldFruitRecord>();

	public WorldFruitRecord[] Events => events.ToArray();

	public WorldFruitRecord[] RecoveredMethod886(IEnumerable<RecoveredType405> P_0, string P_1, string P_2, string P_3, bool P_4, DateTime P_5, WorldPoint P_6 = null)
	{
		if (server != P_1)
		{
			server = P_1;
			initialized = false;
			known.Clear();
			events.Clear();
		}
		HashSet<string> visible = new HashSet<string>();
		foreach (RecoveredType405 item in P_0.Where(RecoveredType406.RecoveredMethod885))
		{
			WorldFruitRecord worldFruitRecord = new WorldFruitRecord();
			worldFruitRecord.Id = Guid.NewGuid().ToString("N");
			worldFruitRecord.Name = item.Name;
			worldFruitRecord.Rarity = RecoveredType219.RecoveredMethod52(item.Name);
			worldFruitRecord.Server = P_1;
			worldFruitRecord.Hub = P_2;
			worldFruitRecord.Account = P_3;
			worldFruitRecord.AtUtc = P_5.ToString("o");
			worldFruitRecord.LastSeenUtc = P_5.ToString("o");
			worldFruitRecord.Source = "Pickup prompt";
			worldFruitRecord.Position = item.Position;
			WorldFruitRecord worldFruitRecord2 = worldFruitRecord;
			string text = worldFruitRecord2.Fingerprint();
			if (!visible.Add(text))
			{
				continue;
			}
			if (!known.TryGetValue(text, out var value))
			{
				value = (known[text] = new RecoveredType408
				{
					Record = worldFruitRecord2,
					First = P_5
				});
				if (initialized && P_4)
				{
					events.Add(worldFruitRecord2);
				}
			}
			value.Last = P_5;
		}
		string[] array = known.Keys.ToArray();
		foreach (string text2 in array)
		{
			RecoveredType408 recoveredType2 = known[text2];
			if (!visible.Contains(text2) && (P_6 == null || P_6.Distance(recoveredType2.Record.Position) <= 150.0 || P_5 - recoveredType2.First >= TimeSpan.FromHours(1.0)))
			{
				known.Remove(text2);
			}
		}
		while (events.Count > 64)
		{
			events.RemoveAt(0);
		}
		initialized = true;
		return known.Select(delegate(KeyValuePair<string, RecoveredType408> keyValuePair)
		{
			RecoveredType408 value2 = keyValuePair.Value;
			WorldFruitRecord record = value2.Record;
			return new WorldFruitRecord
			{
				Id = record.Id,
				Name = record.Name,
				Rarity = record.Rarity,
				Server = record.Server,
				Hub = record.Hub,
				Account = record.Account,
				AtUtc = record.AtUtc,
				LastSeenUtc = value2.Last.ToString("o"),
				Visible = visible.Contains(keyValuePair.Key),
				Source = record.Source,
				Announcement = record.Announcement,
				Position = record.Position
			};
		}).ToArray();
	}
}
