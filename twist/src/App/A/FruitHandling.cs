using A;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace a;

internal sealed class RecoveredType215
{
	private sealed class RecoveredType216
	{
		public ulong Tool;

		public ulong Rod;

		public string Name;

		public int Baseline;

		public bool Duplicate;

		public bool Sent;

		public bool Finished;
	}

	[CompilerGenerated]
	private sealed class RecoveredType217
	{
		public RecoveredType215 _003C_003E4__this;

		public RecoveredType170 profile;
	}

	[CompilerGenerated]
	private sealed class RecoveredType218
	{
		public RecoveredType217 CS_0024_003C_003E8__locals15;

		public RecoveredType212 view;

		public bool RecoveredMethod621(RecoveredType211 P_0)
		{
			if (P_0.Fruit)
			{
				if (view.InventoryReady && view.RecoveredMethod403(P_0.Name) != 0)
				{
					return CS_0024_003C_003E8__locals15.profile.DropDuplicateFruits;
				}
				return true;
			}
			return false;
		}
	}

	private readonly RecoveredType214 port;

	private readonly Action<string> log;

	private readonly Action<string> status;

	private RecoveredType216 pending;

	private string lastError = "";

	private DateTime logged = DateTime.MinValue;

	public RecoveredType215(RecoveredType214 P_0, Action<string> P_1, Action<string> P_2 = null)
	{
		port = P_0;
		log = P_1;
		status = P_2 ?? ((Action<string>)delegate
		{
		});
	}

	private void RecoveredMethod48(string P_0)
	{
		status(P_0);
		log(P_0);
	}

	public void RecoveredMethod626(RecoveredType170 P_0, CancellationToken P_1, Action<string, bool> P_2)
	{
		if (!P_0.AutoStoreFruits)
		{
			return;
		}
		while (true)
		{
			P_1.ThrowIfCancellationRequested();
			try
			{
				RecoveredType212 view = port.RecoveredMethod622();
				if (pending == null)
				{
					if (view.Busy)
					{
						break;
					}
					RecoveredType211 recoveredType = (from recoveredType4 in view.Tools
						where recoveredType4.Fruit && (!view.InventoryReady || view.RecoveredMethod403(recoveredType4.Name) == 0 || P_0.DropDuplicateFruits)
						orderby recoveredType4.Equipped descending
						select recoveredType4).ThenBy((RecoveredType211 recoveredType4) => recoveredType4.Name, StringComparer.Ordinal).FirstOrDefault();
					if (recoveredType == null)
					{
						break;
					}
					if (!view.InventoryReady)
					{
						throw new Exception("Waiting for stored-fruit inventory before handling " + recoveredType.Name + ".");
					}
					RecoveredType211 recoveredType2 = (from recoveredType4 in view.Tools
						where recoveredType4.Rod
						orderby recoveredType4.Equipped descending, recoveredType4.Slot >= 0 descending, recoveredType4.Slot
						select recoveredType4).FirstOrDefault();
					pending = new RecoveredType216
					{
						Tool = recoveredType.Id,
						Name = recoveredType.Name,
						Baseline = view.RecoveredMethod403(recoveredType.Name),
						Duplicate = (view.RecoveredMethod403(recoveredType.Name) > 0),
						Rod = (recoveredType2?.Id ?? 0)
					};
					RecoveredMethod48((pending.Duplicate ? "Duplicate fruit detected · " : "Devil fruit detected · ") + pending.Name);
					RecoveredMethod48("Fruit decision · " + pending.Name + " · stored count=" + pending.Baseline + " · drop duplicates=" + P_0.DropDuplicateFruits + " · intended action=" + (pending.Duplicate ? "drop duplicate" : "store"));
				}
				if (!pending.Finished)
				{
					if (view.Busy)
					{
						throw new Exception("Waiting for the current game menu to close before handling " + pending.Name + ".");
					}
					if (!pending.Sent)
					{
						RecoveredType211 recoveredType3 = view.RecoveredMethod620(pending.Tool);
						if (recoveredType3 == null || !recoveredType3.Fruit || recoveredType3.Name != pending.Name)
						{
							RecoveredMethod48("Fruit no longer carried · " + pending.Name);
							pending.Finished = true;
						}
						else
						{
							port.RecoveredMethod623(pending.Tool, P_1);
							view = port.RecoveredMethod622();
							recoveredType3 = view.RecoveredMethod620(pending.Tool);
							if (recoveredType3 == null || recoveredType3.Name != pending.Name || !recoveredType3.Equipped || !recoveredType3.Fruit)
							{
								throw new Exception("Waiting to equip the exact fruit " + pending.Name + ".");
							}
							if (!view.InventoryReady)
							{
								throw new Exception("Stored-fruit inventory is unavailable; no fruit action sent.");
							}
							pending.Baseline = view.RecoveredMethod403(pending.Name);
							pending.Duplicate = pending.Baseline > 0;
							if (pending.Duplicate && !P_0.DropDuplicateFruits)
							{
								pending.Finished = true;
							}
							else if (pending.Duplicate)
							{
								RecoveredMethod48("Dropping already-owned fruit · " + pending.Name);
								port.RecoveredMethod625(pending.Tool, delegate
								{
									pending.Sent = true;
								}, P_1);
							}
							else
							{
								RecoveredMethod48("Storing fruit · " + pending.Name);
								port.RecoveredMethod624(pending.Tool, delegate
								{
									pending.Sent = true;
								}, P_1);
							}
						}
					}
					if (pending.Sent)
					{
						bool flag = false;
						for (int num = 0; num < 60; num++)
						{
							P_1.ThrowIfCancellationRequested();
							view = port.RecoveredMethod622();
							if (view.RecoveredMethod620(pending.Tool) == null && (pending.Duplicate || (view.InventoryReady && view.RecoveredMethod403(pending.Name) > pending.Baseline)))
							{
								flag = true;
								break;
							}
							port.RecoveredMethod393(100, P_1);
						}
						if (!flag)
						{
							if (!pending.Duplicate && view.InventoryReady && view.RecoveredMethod403(pending.Name) == pending.Baseline && view.RecoveredMethod620(pending.Tool) != null)
							{
								pending.Sent = false;
								throw new Exception("Store was not acknowledged; retrying the same fruit.");
							}
							if (pending.Duplicate && view.InventoryReady && view.RecoveredMethod403(pending.Name) > 0 && view.RecoveredMethod620(pending.Tool) != null)
							{
								pending.Sent = false;
								throw new Exception("Drop was not acknowledged; retrying the same duplicate.");
							}
							throw new Exception("Waiting for the existing fruit action to finish · " + pending.Name);
						}
						pending.Finished = true;
						P_2(pending.Name, pending.Duplicate);
						RecoveredMethod48((pending.Duplicate ? "Duplicate dropped · " : "Fruit stored · ") + pending.Name);
						pending.Finished = true;
					}
				}
				if (pending.Finished)
				{
					if (pending.Rod != 0 && port.RecoveredMethod622().RecoveredMethod620(pending.Rod) != null)
					{
						port.RecoveredMethod623(pending.Rod, P_1);
					}
					port.RecoveredMethod50();
					pending = null;
					lastError = "";
				}
			}
			catch (OperationCanceledException)
			{
				throw;
			}
			catch (BackpackEquipmentException)
			{
				throw;
			}
			catch (Exception ex2)
			{
				string text = "Fruit handling paused; retrying · " + ex2.Message;
				status(text);
				if (text != lastError || DateTime.UtcNow - logged > TimeSpan.FromSeconds(10.0))
				{
					RecoveredMethod48(text);
					lastError = text;
					logged = DateTime.UtcNow;
				}
				port.RecoveredMethod393(1000, P_1);
			}
		}
	}

	[CompilerGenerated]
	private static void RecoveredMethod414(string P_0)
	{
	}

	[CompilerGenerated]
	private static bool RecoveredMethod621(RecoveredType211 P_0)
	{
		return P_0.Equipped;
	}

	[CompilerGenerated]
	private static string RecoveredMethod627(RecoveredType211 P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod628(RecoveredType211 P_0)
	{
		return P_0.Rod;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod629(RecoveredType211 P_0)
	{
		return P_0.Equipped;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod630(RecoveredType211 P_0)
	{
		return P_0.Slot >= 0;
	}

	[CompilerGenerated]
	private static int RecoveredMethod631(RecoveredType211 P_0)
	{
		return P_0.Slot;
	}

	[CompilerGenerated]
	private void RecoveredMethod45()
	{
		pending.Sent = true;
	}

	[CompilerGenerated]
	private void RecoveredMethod50()
	{
		pending.Sent = true;
	}
}
