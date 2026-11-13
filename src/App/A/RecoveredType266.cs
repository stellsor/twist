using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TwistApp;

namespace a;

internal sealed class RecoveredType266
{
	private sealed class RecoveredType267
	{
		public string Id;

		public string UserId;

		public string Name;

		public string Rarity;

		public DateTime At;
	}

	private sealed class RecoveredType268
	{
		public CatchRecord Record;

		public DateTime At;
	}

	[CompilerGenerated]
	private sealed class RecoveredType269
	{
		public InventorySnapshot snapshot;

		public bool RecoveredMethod351(CatchRecord P_0)
		{
			return P_0.UserId == snapshot.UserId;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType270
	{
		public string id;

		public bool RecoveredMethod351(CatchRecord P_0)
		{
			if (!string.IsNullOrEmpty(id))
			{
				return P_0.UserId == id;
			}
			return true;
		}
	}

	private const string Unidentified = "Unidentified fish";

	private readonly string file;

	private readonly DateTime cutover;

	private readonly List<CatchRecord> records = new List<CatchRecord>();

	private readonly HashSet<string> ids = new HashSet<string>();

	private readonly Dictionary<string, RecoveredType267> evidence = new Dictionary<string, RecoveredType267>();

	public volatile string Error = "";

	private readonly O<CatchRecord> writer;

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

	public RecoveredType266(string P_0)
	{
		Directory.CreateDirectory(P_0);
		file = Path.Combine(P_0, "catches.json");
		string text = file;
		Action<string> action = delegate(string text2)
		{
			Error = ((text2 == "") ? "" : ("Catch history could not be saved: " + text2));
		};
		writer = new O<CatchRecord>(text, action);
		string path = Path.Combine(P_0, "catch-round-counting.txt");
		cutover = DateTime.UtcNow;
		try
		{
			if (File.Exists(path) && DateTime.TryParse(File.ReadAllText(path), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result))
			{
				cutover = result.ToUniversalTime();
			}
			else
			{
				File.WriteAllText(path, cutover.ToString("o"));
			}
			if (!File.Exists(file))
			{
				return;
			}
			CatchRecord[] array = new JavaScriptSerializer
			{
				MaxJsonLength = 16000000
			}.Deserialize<CatchRecord[]>(File.ReadAllText(file));
			if (array == null)
			{
				return;
			}
			CatchRecord[] array2 = array;
			foreach (CatchRecord catchRecord in array2)
			{
				if (catchRecord != null && !string.IsNullOrEmpty(catchRecord.Id) && catchRecord.Count > 0 && ids.Add(catchRecord.Id))
				{
					records.Add(catchRecord);
				}
			}
		}
		catch (Exception ex)
		{
			Error = "Catch history could not be loaded: " + ex.Message;
		}
	}

	private static bool RecoveredMethod723(string P_0, out DateTime P_1)
	{
		if (!DateTime.TryParse(P_0, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out P_1))
		{
			return false;
		}
		P_1 = P_1.ToUniversalTime();
		return true;
	}

	public bool RecoveredMethod724(IEnumerable<RoundRecord> P_0)
	{
		bool flag = false;
		List<CatchRecord> list = new List<CatchRecord>();
		foreach (RoundRecord item2 in P_0)
		{
			if (item2 != null && item2.Full && !string.IsNullOrEmpty(item2.Id) && !string.IsNullOrEmpty(item2.UserId) && RecoveredMethod723(item2.AtUtc, out var dateTime) && !(dateTime < cutover) && ids.Add("round:" + item2.Id))
			{
				CatchRecord catchRecord = new CatchRecord();
				catchRecord.Id = "round:" + item2.Id;
				catchRecord.UserId = item2.UserId;
				catchRecord.Account = item2.Account;
				catchRecord.Name = "Unidentified fish";
				catchRecord.Rarity = "Unknown";
				catchRecord.Count = 1;
				catchRecord.AtUtc = item2.AtUtc;
				CatchRecord item = catchRecord;
				records.Add(item);
				list.Add(item);
				flag = true;
			}
		}
		if (flag)
		{
			RecoveredMethod726(list);
			RecoveredMethod45();
		}
		return flag;
	}

	public bool RecoveredMethod725(InventorySnapshot P_0)
	{
		if (!P_0.Valid || string.IsNullOrEmpty(P_0.UserId))
		{
			return false;
		}
		bool flag = false;
		bool flag2 = false;
		Dictionary<string, ItemMetadata> dictionary = P_0.Items.ToDictionary((InventoryEntry inventoryEntry) => inventoryEntry.Name, (InventoryEntry inventoryEntry) => inventoryEntry.Metadata, StringComparer.Ordinal);
		InventoryGain[] gains = P_0.Gains;
		foreach (InventoryGain inventoryGain in gains)
		{
			if (!inventoryGain.Fishing || inventoryGain.Count <= 0 || string.IsNullOrEmpty(inventoryGain.Id) || !RecoveredMethod723(inventoryGain.AtUtc, out var dateTime) || dateTime < cutover || !dictionary.TryGetValue(inventoryGain.Name, out var value) || !value.IsFish)
			{
				continue;
			}
			for (int num2 = 0; num2 < Math.Min(inventoryGain.Count, 200); num2++)
			{
				string text = inventoryGain.Id + ":" + num2;
				if (!evidence.ContainsKey(text))
				{
					flag2 = true;
					evidence[text] = new RecoveredType267
					{
						Id = text,
						UserId = P_0.UserId,
						Name = inventoryGain.Name,
						Rarity = value.Rarity,
						At = dateTime
					};
				}
			}
		}
		foreach (CatchRecord item in records.Where((CatchRecord catchRecord) => catchRecord.UserId == P_0.UserId))
		{
			if (dictionary.TryGetValue(item.Name, out var value2) && value2.Rarity != "Unknown" && item.Rarity != value2.Rarity)
			{
				item.Rarity = value2.Rarity;
				flag = true;
			}
		}
		if (flag2)
		{
			flag = RecoveredMethod726() || flag;
		}
		if (evidence.Count > 2000)
		{
			string[] array = (from recoveredType in evidence.Values.OrderByDescending((RecoveredType267 recoveredType) => recoveredType.At).Skip(2000)
				select recoveredType.Id).ToArray();
			foreach (string key in array)
			{
				evidence.Remove(key);
			}
		}
		if (flag)
		{
			RecoveredMethod45();
		}
		return flag;
	}

	private bool RecoveredMethod726(IEnumerable<CatchRecord> P_0 = null)
	{
		bool result = false;
		HashSet<string> hashSet = new HashSet<string>(from catchRecord2 in records
			where !string.IsNullOrEmpty(catchRecord2.EvidenceId)
			select catchRecord2.EvidenceId);
		Dictionary<string, RecoveredType268[]> dictionary = new Dictionary<string, RecoveredType268[]>();
		foreach (IGrouping<string, CatchRecord> item in from catchRecord2 in P_0 ?? records
			where catchRecord2.Id.StartsWith("round:", StringComparison.Ordinal) && catchRecord2.Name == "Unidentified fish"
			group catchRecord2 by catchRecord2.UserId)
		{
			dictionary[item.Key] = (from catchRecord2 in item
				select new RecoveredType268
				{
					Record = catchRecord2,
					At = (RecoveredMethod723(catchRecord2.AtUtc, out var dateTime3) ? dateTime3 : DateTime.MinValue)
				} into recoveredType2
				orderby recoveredType2.At
				select recoveredType2).ToArray();
		}
		foreach (RecoveredType267 item2 in evidence.Values.OrderBy((RecoveredType267 recoveredType2) => recoveredType2.At).ThenBy((RecoveredType267 recoveredType2) => recoveredType2.Id, StringComparer.Ordinal))
		{
			if (hashSet.Contains(item2.Id) || !dictionary.TryGetValue(item2.UserId, out var value))
			{
				continue;
			}
			DateTime dateTime = item2.At.AddSeconds(-8.0);
			DateTime dateTime2 = item2.At.AddSeconds(2.0);
			int num = 0;
			int num2 = value.Length;
			while (num < num2)
			{
				int num3 = (num + num2) / 2;
				if (value[num3].At < dateTime)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3;
				}
			}
			CatchRecord catchRecord = null;
			double num4 = double.MaxValue;
			for (int num5 = num; num5 < value.Length && value[num5].At <= dateTime2; num5++)
			{
				RecoveredType268 recoveredType = value[num5];
				if (!(recoveredType.Record.Name != "Unidentified fish"))
				{
					double num6 = Math.Abs((item2.At - recoveredType.At).TotalSeconds);
					if (num6 < num4)
					{
						num4 = num6;
						catchRecord = recoveredType.Record;
					}
				}
			}
			if (catchRecord != null)
			{
				catchRecord.Name = item2.Name;
				catchRecord.Rarity = item2.Rarity;
				catchRecord.EvidenceId = item2.Id;
				hashSet.Add(item2.Id);
				result = true;
			}
		}
		return result;
	}

	private void RecoveredMethod45()
	{
		Revision++;
		while (records.Count > 10000)
		{
			records.RemoveAt(0);
		}
		writer.RecoveredMethod669(records.Select((CatchRecord P_0) => new CatchRecord
		{
			Id = P_0.Id,
			EvidenceId = P_0.EvidenceId,
			UserId = P_0.UserId,
			Account = P_0.Account,
			Name = P_0.Name,
			Rarity = P_0.Rarity,
			AtUtc = P_0.AtUtc,
			Count = P_0.Count
		}).ToArray());
	}

	public CatchRecord[] RecoveredMethod727(string P_0)
	{
		return records.Where((CatchRecord catchRecord) => string.IsNullOrEmpty(P_0) || catchRecord.UserId == P_0).OrderByDescending((CatchRecord catchRecord) => catchRecord.AtUtc, StringComparer.Ordinal).ToArray();
	}

	private static string RecoveredMethod52(string P_0)
	{
		P_0 = P_0 ?? "";
		if (P_0.Length > 0 && "=+-@".Contains(P_0[0]))
		{
			P_0 = "'" + P_0;
		}
		return "\"" + P_0.Replace("\"", "\"\"") + "\"";
	}

	public void RecoveredMethod82(string P_0, string P_1)
	{
		List<string> list = new List<string>();
		list.Add("Time UTC,Account,User ID,Fish,Rarity,Quantity");
		List<string> list2 = list;
		list2.AddRange(from catchRecord in RecoveredMethod727(P_1)
			select string.Join(",", RecoveredMethod52(catchRecord.AtUtc), RecoveredMethod52(catchRecord.Account), RecoveredMethod52(catchRecord.UserId), RecoveredMethod52(catchRecord.Name), RecoveredMethod52(catchRecord.Rarity), catchRecord.Count.ToString(CultureInfo.InvariantCulture)));
		File.WriteAllLines(P_0, list2, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
	}

	[CompilerGenerated]
	private void RecoveredMethod422(string P_0)
	{
		Error = ((P_0 == "") ? "" : ("Catch history could not be saved: " + P_0));
	}

	[CompilerGenerated]
	private static string RecoveredMethod709(InventoryEntry P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static ItemMetadata RecoveredMethod728(InventoryEntry P_0)
	{
		return P_0.Metadata;
	}

	[CompilerGenerated]
	private static DateTime RecoveredMethod729(RecoveredType267 P_0)
	{
		return P_0.At;
	}

	[CompilerGenerated]
	private static string RecoveredMethod730(RecoveredType267 P_0)
	{
		return P_0.Id;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod351(CatchRecord P_0)
	{
		return !string.IsNullOrEmpty(P_0.EvidenceId);
	}

	[CompilerGenerated]
	private static string RecoveredMethod731(CatchRecord P_0)
	{
		return P_0.EvidenceId;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod732(CatchRecord P_0)
	{
		if (P_0.Id.StartsWith("round:", StringComparison.Ordinal))
		{
			return P_0.Name == "Unidentified fish";
		}
		return false;
	}

	[CompilerGenerated]
	private static string RecoveredMethod733(CatchRecord P_0)
	{
		return P_0.UserId;
	}

	[CompilerGenerated]
	private static RecoveredType268 RecoveredMethod734(CatchRecord P_0)
	{
		DateTime dateTime;
		return new RecoveredType268
		{
			Record = P_0,
			At = (RecoveredMethod723(P_0.AtUtc, out dateTime) ? dateTime : DateTime.MinValue)
		};
	}

	[CompilerGenerated]
	private static DateTime RecoveredMethod735(RecoveredType268 P_0)
	{
		return P_0.At;
	}

	[CompilerGenerated]
	private static DateTime RecoveredMethod736(RecoveredType267 P_0)
	{
		return P_0.At;
	}

	[CompilerGenerated]
	private static string RecoveredMethod737(RecoveredType267 P_0)
	{
		return P_0.Id;
	}

	[CompilerGenerated]
	private static CatchRecord RecoveredMethod738(CatchRecord P_0)
	{
		return new CatchRecord
		{
			Id = P_0.Id,
			EvidenceId = P_0.EvidenceId,
			UserId = P_0.UserId,
			Account = P_0.Account,
			Name = P_0.Name,
			Rarity = P_0.Rarity,
			AtUtc = P_0.AtUtc,
			Count = P_0.Count
		};
	}

	[CompilerGenerated]
	private static string RecoveredMethod739(CatchRecord P_0)
	{
		return P_0.AtUtc;
	}

	[CompilerGenerated]
	private static string RecoveredMethod740(CatchRecord P_0)
	{
		return string.Join(",", RecoveredMethod52(P_0.AtUtc), RecoveredMethod52(P_0.Account), RecoveredMethod52(P_0.UserId), RecoveredMethod52(P_0.Name), RecoveredMethod52(P_0.Rarity), P_0.Count.ToString(CultureInfo.InvariantCulture));
	}
}
