using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using A;
using TwistApp;
using a;

namespace c;

internal sealed class RecoveredType260 : RecoveredType133, IDisposable
{
	[CompilerGenerated]
	private sealed class RecoveredType261
	{
		public RecoveredType260 _003C_003E4__this;

		public int pid;

		public long created;

		public RecoveredType163 map;

		private static Func<InventoryEntry, string> CS_0024_003C_003E9__CachedAnonymousMethodDelegatee;

		private static Func<InventoryEntry, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegatef;

		public void RecoveredMethod45()
		{
			Dictionary<string, int> dictionary = null;
			while (!_003C_003E4__this.stop.IsCancellationRequested)
			{
				try
				{
					using RecoveredType258 recoveredType = new RecoveredType258(pid, created, map);
					while (!_003C_003E4__this.stop.IsCancellationRequested)
					{
						InventorySnapshot inventorySnapshot = recoveredType.RecoveredMethod704();
						_003C_003E4__this.gains.AddRange(RecoveredType259.RecoveredMethod713(dictionary, inventorySnapshot, recoveredType.FishingRecently));
						while (_003C_003E4__this.gains.Count > 500)
						{
							_003C_003E4__this.gains.RemoveAt(0);
						}
						dictionary = inventorySnapshot.Items.ToDictionary((InventoryEntry P_0) => P_0.Name, (InventoryEntry P_0) => P_0.Count, StringComparer.Ordinal);
						inventorySnapshot.Gains = _003C_003E4__this.gains.ToArray();
						lock (_003C_003E4__this.gate)
						{
							_003C_003E4__this.current = inventorySnapshot;
						}
						if (_003C_003E4__this.stop.Token.WaitHandle.WaitOne(1200))
						{
							return;
						}
					}
				}
				catch (Exception ex)
				{
					dictionary = null;
					lock (_003C_003E4__this.gate)
					{
						_003C_003E4__this.current = new InventorySnapshot
						{
							Account = _003C_003E4__this.current.Account,
							UserId = _003C_003E4__this.current.UserId,
							Items = _003C_003E4__this.current.Items,
							Gains = _003C_003E4__this.current.Gains,
							Valid = false,
							Updated = _003C_003E4__this.current.Updated,
							Status = ex.Message
						};
					}
					if (_003C_003E4__this.stop.Token.WaitHandle.WaitOne(3000))
					{
						break;
					}
				}
			}
		}

		private static string RecoveredMethod709(InventoryEntry P_0)
		{
			return P_0.Name;
		}

		private static int RecoveredMethod714(InventoryEntry P_0)
		{
			return P_0.Count;
		}
	}

	private readonly object gate = new object();

	private readonly CancellationTokenSource stop = new CancellationTokenSource();

	private readonly Task task;

	private InventorySnapshot current = new InventorySnapshot
	{
		Status = "Connecting inventory…"
	};

	private readonly List<InventoryGain> gains = new List<InventoryGain>();

	public RecoveredType260(int P_0, long P_1, RecoveredType163 P_2)
	{
		RecoveredType260 recoveredType = this;
		Action action = delegate
		{
			Dictionary<string, int> dictionary = null;
			while (!recoveredType.stop.IsCancellationRequested)
			{
				try
				{
					using RecoveredType258 recoveredType2 = new RecoveredType258(P_0, P_1, P_2);
					while (!recoveredType.stop.IsCancellationRequested)
					{
						InventorySnapshot inventorySnapshot = recoveredType2.RecoveredMethod704();
						recoveredType.gains.AddRange(RecoveredType259.RecoveredMethod713(dictionary, inventorySnapshot, recoveredType2.FishingRecently));
						while (recoveredType.gains.Count > 500)
						{
							recoveredType.gains.RemoveAt(0);
						}
						dictionary = inventorySnapshot.Items.ToDictionary((InventoryEntry inventoryEntry) => inventoryEntry.Name, (InventoryEntry inventoryEntry) => inventoryEntry.Count, StringComparer.Ordinal);
						inventorySnapshot.Gains = recoveredType.gains.ToArray();
						lock (recoveredType.gate)
						{
							recoveredType.current = inventorySnapshot;
						}
						if (recoveredType.stop.Token.WaitHandle.WaitOne(1200))
						{
							return;
						}
					}
				}
				catch (Exception ex)
				{
					dictionary = null;
					lock (recoveredType.gate)
					{
						recoveredType.current = new InventorySnapshot
						{
							Account = recoveredType.current.Account,
							UserId = recoveredType.current.UserId,
							Items = recoveredType.current.Items,
							Gains = recoveredType.current.Gains,
							Valid = false,
							Updated = recoveredType.current.Updated,
							Status = ex.Message
						};
					}
					if (recoveredType.stop.Token.WaitHandle.WaitOne(3000))
					{
						break;
					}
				}
			}
		};
		task = Task.Run(action);
	}

	public InventorySnapshot RecoveredMethod515()
	{
		lock (gate)
		{
			return current;
		}
	}

	public void Dispose()
	{
		stop.Cancel();
		try
		{
			task.Wait(3000);
		}
		catch
		{
		}
		if (task.IsCompleted)
		{
			stop.Dispose();
		}
	}
}
