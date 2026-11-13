using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TwistApp;
using a;

namespace b;

internal sealed class RecoveredType411 : IDisposable
{
	[CompilerGenerated]
	private sealed class RecoveredType412
	{
		public RecoveredType411 _003C_003E4__this;

		public int pid;

		public long created;

		public RecoveredType163 map;

		public void RecoveredMethod45()
		{
			while (!_003C_003E4__this.stop.IsCancellationRequested)
			{
				try
				{
					using RecoveredType410 recoveredType = new RecoveredType410(pid, created, map);
					while (!_003C_003E4__this.stop.IsCancellationRequested)
					{
						WorldSnapshot current = recoveredType.RecoveredMethod889();
						lock (_003C_003E4__this.gate)
						{
							_003C_003E4__this.current = current;
						}
						if (_003C_003E4__this.stop.Token.WaitHandle.WaitOne(500))
						{
							return;
						}
					}
				}
				catch (Exception ex)
				{
					lock (_003C_003E4__this.gate)
					{
						_003C_003E4__this.current = new WorldSnapshot
						{
							Status = ex.Message,
							Updated = DateTime.UtcNow
						};
					}
					if (_003C_003E4__this.stop.Token.WaitHandle.WaitOne(3000))
					{
						break;
					}
				}
			}
		}
	}

	private readonly object gate = new object();

	private readonly CancellationTokenSource stop = new CancellationTokenSource();

	private WorldSnapshot current = new WorldSnapshot();

	public RecoveredType411(int P_0, long P_1, RecoveredType163 P_2)
	{
		RecoveredType411 recoveredType = this;
		Action action = delegate
		{
			while (!recoveredType.stop.IsCancellationRequested)
			{
				try
				{
					using RecoveredType410 recoveredType2 = new RecoveredType410(P_0, P_1, P_2);
					while (!recoveredType.stop.IsCancellationRequested)
					{
						WorldSnapshot worldSnapshot = recoveredType2.RecoveredMethod889();
						lock (recoveredType.gate)
						{
							recoveredType.current = worldSnapshot;
						}
						if (recoveredType.stop.Token.WaitHandle.WaitOne(500))
						{
							return;
						}
					}
				}
				catch (Exception ex)
				{
					lock (recoveredType.gate)
					{
						recoveredType.current = new WorldSnapshot
						{
							Status = ex.Message,
							Updated = DateTime.UtcNow
						};
					}
					if (recoveredType.stop.Token.WaitHandle.WaitOne(3000))
					{
						break;
					}
				}
			}
		};
		Task.Run(action);
	}

	public WorldSnapshot RecoveredMethod889()
	{
		lock (gate)
		{
			return current;
		}
	}

	public void Dispose()
	{
		stop.Cancel();
	}
}
