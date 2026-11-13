using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace A;

internal sealed class RecoveredType85
{
	private readonly object gate = new object();

	private readonly Queue<RecoveredType82> records = new Queue<RecoveredType82>();

	private readonly Dictionary<string, DateTime> repeated = new Dictionary<string, DateTime>();

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

	public void RecoveredMethod367(RecoveredType82 P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		lock (gate)
		{
			string key = P_0.Category + "|" + P_0.Message;
			if (!(P_0.Level != "Info") || !repeated.TryGetValue(key, out var value) || !(DateTime.UtcNow - value < TimeSpan.FromSeconds(60.0)))
			{
				if (repeated.Count > 128)
				{
					repeated.Clear();
				}
				repeated[key] = DateTime.UtcNow;
				records.Enqueue(P_0);
				while (records.Count > 128)
				{
					records.Dequeue();
				}
				Revision++;
			}
		}
	}

	public RecoveredType82[] RecoveredMethod368()
	{
		lock (gate)
		{
			return records.Select((RecoveredType82 P_0) => P_0.RecoveredMethod361()).ToArray();
		}
	}

	[CompilerGenerated]
	private static RecoveredType82 RecoveredMethod366(RecoveredType82 P_0)
	{
		return P_0.RecoveredMethod361();
	}
}
