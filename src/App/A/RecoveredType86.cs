using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using a;

namespace A;

internal sealed class RecoveredType86
{
	private readonly object gate = new object();

	private readonly List<RecoveredType82> records = new List<RecoveredType82>();

	private readonly HashSet<string> ids = new HashSet<string>();

	private readonly Queue<string> seen = new Queue<string>();

	private readonly O<RecoveredType82> writer;

	private int revision;

	public volatile string Error = "";

	public int Revision
	{
		get
		{
			lock (gate)
			{
				return revision;
			}
		}
	}

	public Task Completion => writer.Completion;

	public RecoveredType86(string P_0)
	{
		Directory.CreateDirectory(P_0);
		string text = Path.Combine(P_0, "activity.json");
		Action<string> action = delegate(string error)
		{
			Error = error;
		};
		writer = new O<RecoveredType82>(text, action);
		try
		{
			if (!File.Exists(text))
			{
				return;
			}
			RecoveredType82[] array = new JavaScriptSerializer
			{
				MaxJsonLength = 16000000
			}.Deserialize<RecoveredType82[]>(File.ReadAllText(text));
			foreach (RecoveredType82 item in (array ?? new RecoveredType82[0]).Where(RecoveredType84.RecoveredMethod182).OrderBy((RecoveredType82 recoveredType) => recoveredType.AtUtc, StringComparer.Ordinal).Reverse()
				.Take(5000)
				.Reverse())
			{
				if (ids.Add(item.Id))
				{
					seen.Enqueue(item.Id);
					records.Add(RecoveredType84.RecoveredMethod366(item));
				}
			}
		}
		catch (Exception ex)
		{
			Error = "Activity history could not be loaded: " + ex.Message;
		}
	}

	public bool RecoveredMethod369(IEnumerable<RecoveredType82> P_0)
	{
		bool flag = false;
		lock (gate)
		{
			foreach (RecoveredType82 item in P_0)
			{
				if (item != null && (item.Id == null || !ids.Contains(item.Id)) && RecoveredType84.RecoveredMethod182(item) && ids.Add(item.Id))
				{
					seen.Enqueue(item.Id);
					while (seen.Count > 20000)
					{
						ids.Remove(seen.Dequeue());
					}
					records.Add(RecoveredType84.RecoveredMethod366(item));
					flag = true;
				}
			}
			if (flag)
			{
				if (records.Count > 5000)
				{
					records.Sort((RecoveredType82 recoveredType, RecoveredType82 recoveredType2) => StringComparer.Ordinal.Compare(recoveredType.AtUtc, recoveredType2.AtUtc));
					records.RemoveRange(0, records.Count - 5000);
				}
				revision++;
				writer.RecoveredMethod669(records.Select((RecoveredType82 recoveredType) => recoveredType.RecoveredMethod361()).ToArray());
			}
		}
		return flag;
	}

	public void RecoveredMethod367(RecoveredType82 P_0)
	{
		if (P_0 != null)
		{
			RecoveredMethod369(new RecoveredType82[1] { P_0 });
		}
	}

	public RecoveredType82[] RecoveredMethod368()
	{
		lock (gate)
		{
			return records.Select((RecoveredType82 P_0) => P_0.RecoveredMethod361()).OrderByDescending((RecoveredType82 P_0) => P_0.AtUtc, StringComparer.Ordinal).ToArray();
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod48(string P_0)
	{
		Error = P_0;
	}

	[CompilerGenerated]
	private static string RecoveredMethod370(RecoveredType82 P_0)
	{
		return P_0.AtUtc;
	}

	[CompilerGenerated]
	private static int RecoveredMethod371(RecoveredType82 P_0, RecoveredType82 P_1)
	{
		return StringComparer.Ordinal.Compare(P_0.AtUtc, P_1.AtUtc);
	}

	[CompilerGenerated]
	private static RecoveredType82 RecoveredMethod372(RecoveredType82 P_0)
	{
		return P_0.RecoveredMethod361();
	}

	[CompilerGenerated]
	private static RecoveredType82 RecoveredMethod373(RecoveredType82 P_0)
	{
		return P_0.RecoveredMethod361();
	}

	[CompilerGenerated]
	private static string RecoveredMethod374(RecoveredType82 P_0)
	{
		return P_0.AtUtc;
	}
}
