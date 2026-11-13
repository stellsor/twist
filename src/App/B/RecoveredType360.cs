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
using a;

namespace B;

internal sealed class RecoveredType360
{
	[CompilerGenerated]
	private sealed class RecoveredType361
	{
		public string id;

		public bool RecoveredMethod850(RoundRecord P_0)
		{
			if (!string.IsNullOrEmpty(id))
			{
				return P_0.UserId == id;
			}
			return true;
		}
	}

	private readonly string file;

	private readonly List<RoundRecord> records = new List<RoundRecord>();

	private readonly HashSet<string> ids = new HashSet<string>();

	public volatile string Error = "";

	private readonly O<RoundRecord> writer;

	public Task Completion => writer.Completion;

	public RecoveredType360(string P_0)
	{
		Directory.CreateDirectory(P_0);
		file = Path.Combine(P_0, "rounds.json");
		string text = file;
		Action<string> action = delegate(string text2)
		{
			Error = ((text2 == "") ? "" : ("History could not be saved: " + text2));
		};
		writer = new O<RoundRecord>(text, action);
		if (!File.Exists(file))
		{
			return;
		}
		try
		{
			RoundRecord[] array = new JavaScriptSerializer
			{
				MaxJsonLength = 16000000
			}.Deserialize<RoundRecord[]>(File.ReadAllText(file));
			if (array == null)
			{
				return;
			}
			RoundRecord[] array2 = array;
			foreach (RoundRecord roundRecord in array2)
			{
				if (roundRecord != null && !string.IsNullOrEmpty(roundRecord.Id) && ids.Add(roundRecord.Id))
				{
					records.Add(roundRecord);
				}
			}
		}
		catch (Exception ex)
		{
			Error = "History could not be loaded: " + ex.Message;
		}
	}

	public bool RecoveredMethod724(IEnumerable<RoundRecord> P_0)
	{
		bool flag = false;
		foreach (RoundRecord item in P_0)
		{
			if (ids.Add(item.Id))
			{
				records.Add(item);
				flag = true;
			}
		}
		if (flag)
		{
			while (records.Count > 5000)
			{
				records.RemoveAt(0);
			}
			RecoveredMethod45();
		}
		return flag;
	}

	private void RecoveredMethod45()
	{
		writer.RecoveredMethod669(records.ToArray());
	}

	public RoundRecord[] RecoveredMethod848(string P_0)
	{
		return records.Where((RoundRecord roundRecord) => string.IsNullOrEmpty(P_0) || roundRecord.UserId == P_0).OrderByDescending((RoundRecord roundRecord) => roundRecord.AtUtc, StringComparer.Ordinal).ToArray();
	}

	private static string RecoveredMethod52(string P_0)
	{
		if (P_0.Length > 0 && "=+-@\t\r".IndexOf(P_0[0]) >= 0)
		{
			P_0 = "'" + P_0;
		}
		return "\"" + P_0.Replace("\"", "\"\"") + "\"";
	}

	public void RecoveredMethod82(string P_0, string P_1)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		List<string> list = new List<string>();
		list.Add("Time UTC,Account,Duration seconds,Tracking contact,Peak progress,Result");
		List<string> list2 = list;
		RoundRecord[] array = RecoveredMethod848(P_1);
		foreach (RoundRecord roundRecord in array)
		{
			list2.Add(string.Join(",", new string[6]
			{
				roundRecord.AtUtc,
				roundRecord.Account,
				roundRecord.Seconds.ToString("0.000", invariantCulture),
				roundRecord.Contact.ToString("0.0000", invariantCulture),
				roundRecord.Peak.ToString("0.0000", invariantCulture),
				roundRecord.ResultLabel
			}.Select(RecoveredMethod52)));
		}
		File.WriteAllLines(P_0, list2, Encoding.UTF8);
	}

	[CompilerGenerated]
	private void RecoveredMethod422(string P_0)
	{
		Error = ((P_0 == "") ? "" : ("History could not be saved: " + P_0));
	}

	[CompilerGenerated]
	private static string RecoveredMethod849(RoundRecord P_0)
	{
		return P_0.AtUtc;
	}
}
