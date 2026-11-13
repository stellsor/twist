using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TwistApp;

namespace a;

internal sealed class RecoveredType197
{
	private sealed class RecoveredType198
	{
		public RecoveredType194 Announcement;

		public string Id = Guid.NewGuid().ToString("N");

		public DateTime At;

		public WorldPoint Position;

		public bool Sent;
	}

	[CompilerGenerated]
	private sealed class RecoveredType199
	{
		private sealed class RecoveredType200
		{
			public RecoveredType199 CS_0024_003C_003E8__locals10;

			public RecoveredType198 RecoveredField1192;

			public bool RecoveredMethod598(RecoveredType195 P_0)
			{
				return P_0.Position.Distance(RecoveredField1192.Position) < 1.0;
			}
		}

		public RecoveredType195[] markers;

		public HashSet<string> markerKeys;

		public RecoveredType197 _003C_003E4__this;

		public string serverId;

		public string account;

		public DateTime now;

		public bool RecoveredMethod39(string P_0)
		{
			return !markerKeys.Contains(P_0);
		}

		public bool RecoveredMethod600(RecoveredType198 P_0)
		{
			if (P_0.Position == null)
			{
				return now - P_0.At < TimeSpan.FromSeconds(40.0);
			}
			return false;
		}

		public bool RecoveredMethod601(RecoveredType198 P_0)
		{
			if (!P_0.Sent)
			{
				if (P_0.Position == null)
				{
					return now - P_0.At >= TimeSpan.FromSeconds(40.0);
				}
				return true;
			}
			return false;
		}

		public bool RecoveredMethod602(RecoveredType198 P_0)
		{
			return now - P_0.At > TimeSpan.FromHours(1.0);
		}

		public WorldFruitRecord RecoveredMethod603(RecoveredType198 P_0)
		{
			return _003C_003E4__this.RecoveredMethod596(P_0, serverId, account, P_0.Position != null && markers.Any((RecoveredType195 recoveredType) => recoveredType.Position.Distance(P_0.Position) < 1.0));
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType201
	{
		public RecoveredType199 CS_0024_003C_003E8__locals10;

		public RecoveredType194 announcement;

		public bool RecoveredMethod600(RecoveredType198 P_0)
		{
			if (P_0.Announcement.Text == announcement.Text)
			{
				return CS_0024_003C_003E8__locals10.now - P_0.At < TimeSpan.FromSeconds(30.0);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType202
	{
		public RecoveredType199 CS_0024_003C_003E8__locals10;

		public RecoveredType198 item;

		public bool RecoveredMethod598(RecoveredType195 P_0)
		{
			return CS_0024_003C_003E8__locals10._003C_003E4__this.pulseBorn[P_0.Key] >= item.At - TimeSpan.FromSeconds(2.0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType203
	{
		public RecoveredType202 CS_0024_003C_003E8__locals16;

		public RecoveredType199 CS_0024_003C_003E8__locals10;

		public RecoveredType195[] candidates;

		public bool RecoveredMethod598(RecoveredType195 P_0)
		{
			return P_0.Position.Distance(candidates[0].Position) < 1.0;
		}
	}

	private readonly Dictionary<string, DateTime> seenAnnouncements = new Dictionary<string, DateTime>();

	private readonly Dictionary<string, DateTime> pulseBorn = new Dictionary<string, DateTime>();

	private readonly List<RecoveredType198> pending = new List<RecoveredType198>();

	private readonly List<WorldFruitRecord> events = new List<WorldFruitRecord>();

	private string server = "";

	public WorldFruitRecord[] Events => events.ToArray();

	private WorldFruitRecord RecoveredMethod596(RecoveredType198 P_0, string P_1, string P_2, bool P_3)
	{
		WorldFruitRecord worldFruitRecord = new WorldFruitRecord();
		worldFruitRecord.Id = P_0.Id;
		worldFruitRecord.Name = P_0.Announcement.Name;
		worldFruitRecord.Rarity = RecoveredType219.RecoveredMethod52(P_0.Announcement.Name);
		worldFruitRecord.Server = P_1;
		worldFruitRecord.Hub = P_0.Announcement.Hub;
		worldFruitRecord.Account = P_2;
		worldFruitRecord.AtUtc = P_0.At.ToString("o");
		worldFruitRecord.LastSeenUtc = P_0.At.ToString("o");
		worldFruitRecord.Announcement = P_0.Announcement.Text;
		worldFruitRecord.Source = "Eye pulse";
		worldFruitRecord.Position = P_0.Position;
		worldFruitRecord.Visible = P_3;
		return worldFruitRecord;
	}

	public WorldFruitRecord[] RecoveredMethod597(IEnumerable<RecoveredType194> P_0, IEnumerable<RecoveredType195> P_1, string P_2, string P_3, bool P_4, DateTime P_5)
	{
		if (server != P_2)
		{
			server = P_2;
			pending.Clear();
			events.Clear();
			seenAnnouncements.Clear();
			pulseBorn.Clear();
		}
		RecoveredType195[] markers = P_1.Where((RecoveredType195 recoveredType2) => recoveredType2 != null && recoveredType2.Position != null && recoveredType2.Position.Valid).ToArray();
		HashSet<string> markerKeys = new HashSet<string>(markers.Select((RecoveredType195 recoveredType2) => recoveredType2.Key));
		string[] array = pulseBorn.Keys.Where((string item2) => !markerKeys.Contains(item2)).ToArray();
		foreach (string key in array)
		{
			pulseBorn.Remove(key);
		}
		RecoveredType195[] array2 = markers;
		foreach (RecoveredType195 recoveredType in array2)
		{
			if (!pulseBorn.ContainsKey(recoveredType.Key))
			{
				pulseBorn[recoveredType.Key] = P_5;
			}
		}
		if (P_4)
		{
			foreach (RecoveredType194 announcement in P_0)
			{
				if (announcement != null)
				{
					string key2 = announcement.Key + "|" + announcement.Text;
					DateTime value;
					bool flag = seenAnnouncements.TryGetValue(key2, out value) && P_5 - value < TimeSpan.FromSeconds(30.0);
					seenAnnouncements[key2] = P_5;
					if (!flag && !pending.Any((RecoveredType198 recoveredType2) => recoveredType2.Announcement.Text == announcement.Text && P_5 - recoveredType2.At < TimeSpan.FromSeconds(30.0)))
					{
						pending.Add(new RecoveredType198
						{
							Announcement = announcement,
							At = P_5
						});
					}
				}
			}
		}
		foreach (RecoveredType198 item in pending.Where((RecoveredType198 recoveredType2) => recoveredType2.Position == null && P_5 - recoveredType2.At < TimeSpan.FromSeconds(40.0)))
		{
			RecoveredType195[] source = markers;
			Func<RecoveredType195, bool> predicate = (RecoveredType195 recoveredType2) => pulseBorn[recoveredType2.Key] >= item.At - TimeSpan.FromSeconds(2.0);
			RecoveredType195[] candidates = source.Where(predicate).ToArray();
			if (candidates.Length > 0 && candidates.All((RecoveredType195 recoveredType2) => recoveredType2.Position.Distance(candidates[0].Position) < 1.0))
			{
				item.Position = candidates[0].Position;
			}
		}
		foreach (RecoveredType198 item2 in pending.Where((RecoveredType198 recoveredType2) => !recoveredType2.Sent && (recoveredType2.Position != null || P_5 - recoveredType2.At >= TimeSpan.FromSeconds(40.0))))
		{
			item2.Sent = true;
			events.Add(RecoveredMethod596(item2, P_2, P_3, item2.Position != null));
		}
		while (events.Count > 64)
		{
			events.RemoveAt(0);
		}
		pending.RemoveAll((RecoveredType198 recoveredType2) => P_5 - recoveredType2.At > TimeSpan.FromHours(1.0));
		return pending.Select((RecoveredType198 recoveredType2) => RecoveredMethod596(recoveredType2, P_2, P_3, recoveredType2.Position != null && markers.Any((RecoveredType195 recoveredType3) => recoveredType3.Position.Distance(recoveredType2.Position) < 1.0))).ToArray();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod598(RecoveredType195 P_0)
	{
		if (P_0 != null && P_0.Position != null)
		{
			return P_0.Position.Valid;
		}
		return false;
	}

	[CompilerGenerated]
	private static string RecoveredMethod599(RecoveredType195 P_0)
	{
		return P_0.Key;
	}
}
