using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TwistApp;
using a;

namespace b;

internal sealed class RecoveredType416
{
	[CompilerGenerated]
	private sealed class RecoveredType417
	{
		public string account;

		public bool RecoveredMethod903(WorldFruitRecord P_0)
		{
			if (!string.IsNullOrEmpty(account))
			{
				return (P_0.Observers ?? new string[1] { P_0.Account }).Contains(account, StringComparer.OrdinalIgnoreCase);
			}
			return true;
		}
	}

	private readonly List<WorldFruitRecord> records = new List<WorldFruitRecord>();

	private readonly HashSet<string> ids = new HashSet<string>();

	private readonly Dictionary<string, WorldFruitRecord> latest = new Dictionary<string, WorldFruitRecord>();

	private readonly O<WorldFruitRecord> writer;

	public volatile string Error = "";

	[CompilerGenerated]
	private int _003CRevision_003Ek__BackingField;

	public int Revision
	{
		[CompilerGenerated]
		get
		{
			return _003CRevision_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CRevision_003Ek__BackingField = value;
		}
	}

	public Task Completion => writer.Completion;

	private static string RecoveredMethod884(WorldFruitRecord P_0)
	{
		return P_0.Server + "|" + (P_0.Announcement ?? P_0.Name);
	}

	private static DateTime RecoveredMethod895(WorldFruitRecord P_0)
	{
		if (!DateTime.TryParse(P_0.AtUtc, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result))
		{
			return DateTime.MinValue;
		}
		return result.ToUniversalTime();
	}

	private static WorldFruitRecord RecoveredMethod896(WorldFruitRecord P_0)
	{
		WorldFruitRecord worldFruitRecord = new WorldFruitRecord();
		worldFruitRecord.Id = P_0.Id;
		worldFruitRecord.Name = P_0.Name;
		worldFruitRecord.Rarity = P_0.Rarity;
		worldFruitRecord.Server = P_0.Server;
		worldFruitRecord.Hub = P_0.Hub;
		worldFruitRecord.Account = P_0.Account;
		worldFruitRecord.AtUtc = P_0.AtUtc;
		worldFruitRecord.LastSeenUtc = P_0.LastSeenUtc;
		worldFruitRecord.Announcement = P_0.Announcement;
		worldFruitRecord.Source = P_0.Source;
		worldFruitRecord.Visible = false;
		worldFruitRecord.Position = ((P_0.Position == null) ? null : new WorldPoint
		{
			RecoveredField2015 = P_0.Position.RecoveredField2015,
			RecoveredField2016 = P_0.Position.RecoveredField2016,
			RecoveredField2017 = P_0.Position.RecoveredField2017
		});
		worldFruitRecord.Observers = (from value in (P_0.Observers ?? new string[0]).Concat(new string[1] { P_0.Account })
			where !string.IsNullOrEmpty(value)
			select value).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
		return worldFruitRecord;
	}

	public RecoveredType416(string P_0)
	{
		Directory.CreateDirectory(P_0);
		string text = Path.Combine(P_0, "world-spawns.json");
		Action<string> action = delegate(string text2)
		{
			Error = ((text2 == "") ? "" : ("Spawn history could not be saved: " + text2));
		};
		writer = new O<WorldFruitRecord>(text, action);
		try
		{
			if (!File.Exists(text))
			{
				return;
			}
			WorldFruitRecord[] array = new JavaScriptSerializer
			{
				MaxJsonLength = 16000000
			}.Deserialize<WorldFruitRecord[]>(File.ReadAllText(text));
			foreach (WorldFruitRecord item in (array ?? new WorldFruitRecord[0]).Where(RecoveredMethod897).OrderBy((WorldFruitRecord worldFruitRecord2) => worldFruitRecord2.AtUtc, StringComparer.Ordinal).Take(5000))
			{
				if (ids.Add(item.Id))
				{
					WorldFruitRecord worldFruitRecord = RecoveredMethod896(item);
					records.Add(worldFruitRecord);
					latest[RecoveredMethod884(worldFruitRecord)] = worldFruitRecord;
				}
			}
		}
		catch (Exception ex)
		{
			Error = "Spawn history could not be loaded: " + ex.Message;
		}
	}

	private static bool RecoveredMethod897(WorldFruitRecord P_0)
	{
		if (P_0 != null && !string.IsNullOrEmpty(P_0.Id) && P_0.Id.Length <= 100 && RecoveredType219.RecoveredMethod39(P_0.Name) && !string.IsNullOrEmpty(P_0.Server) && RecoveredMethod895(P_0) != DateTime.MinValue)
		{
			if (P_0.Position != null)
			{
				return P_0.Position.Valid;
			}
			return true;
		}
		return false;
	}

	public bool RecoveredMethod898(IEnumerable<WorldFruitRecord> P_0)
	{
		bool flag = false;
		foreach (WorldFruitRecord item in P_0.Where(RecoveredMethod897))
		{
			if (!ids.Add(item.Id))
			{
				continue;
			}
			string key = RecoveredMethod884(item);
			if (latest.TryGetValue(key, out var value) && Math.Abs((RecoveredMethod895(item) - RecoveredMethod895(value)).TotalSeconds) <= 120.0)
			{
				string[] array = (from value2 in (value.Observers ?? new string[0]).Concat((item.Observers ?? new string[0]).Concat(new string[1] { item.Account }))
					where !string.IsNullOrEmpty(value2)
					select value2).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
				if (array.Length != (value.Observers ?? new string[0]).Length)
				{
					value.Observers = array;
					flag = true;
				}
				if (value.Position == null && item.Position != null)
				{
					value.Position = RecoveredMethod896(item).Position;
					flag = true;
				}
			}
			else
			{
				WorldFruitRecord worldFruitRecord = RecoveredMethod896(item);
				records.Add(worldFruitRecord);
				latest[key] = worldFruitRecord;
				flag = true;
			}
		}
		if (flag)
		{
			while (records.Count > 5000)
			{
				records.RemoveAt(0);
			}
			Revision++;
			writer.RecoveredMethod669(records.Select(RecoveredMethod896).ToArray());
		}
		return flag;
	}

	public WorldFruitRecord[] RecoveredMethod899(string P_0)
	{
		return records.Where((WorldFruitRecord worldFruitRecord) => string.IsNullOrEmpty(P_0) || (worldFruitRecord.Observers ?? new string[1] { worldFruitRecord.Account }).Contains(P_0, StringComparer.OrdinalIgnoreCase)).OrderByDescending((WorldFruitRecord worldFruitRecord) => worldFruitRecord.AtUtc, StringComparer.Ordinal).ToArray();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod40(string P_0)
	{
		return !string.IsNullOrEmpty(P_0);
	}

	[CompilerGenerated]
	private void RecoveredMethod422(string P_0)
	{
		Error = ((P_0 == "") ? "" : ("Spawn history could not be saved: " + P_0));
	}

	[CompilerGenerated]
	private static string RecoveredMethod900(WorldFruitRecord P_0)
	{
		return P_0.AtUtc;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod901(string P_0)
	{
		return !string.IsNullOrEmpty(P_0);
	}

	[CompilerGenerated]
	private static string RecoveredMethod902(WorldFruitRecord P_0)
	{
		return P_0.AtUtc;
	}
}
