using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using D;

namespace B;

internal sealed class RecoveredType332 : IDisposable
{
	[CompilerGenerated]
	private sealed class RecoveredType333
	{
		public TcpClient client;

		public RecoveredType332 _003C_003E4__this;

		public void RecoveredMethod45()
		{
			_003C_003E4__this.RecoveredMethod806(client);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType334
	{
		public RecoveredType312 hello;

		public bool RecoveredMethod281(RecoveredType327 P_0)
		{
			if (P_0.Connected && P_0.SessionId == hello.SessionId)
			{
				return P_0.Id != hello.WorkerId;
			}
			return false;
		}
	}

	private readonly ConcurrentDictionary<string, RecoveredType327> peers = new ConcurrentDictionary<string, RecoveredType327>();

	private readonly ConcurrentQueue<RecoveredType325> retired = new ConcurrentQueue<RecoveredType325>();

	private readonly TcpListener listener;

	private readonly RecoveredType321 pairing;

	private readonly string icons;

	private readonly Action changed;

	private readonly Timer heartbeat;

	private int closed;

	private int handshakes;

	private long ownerTick = DateTime.UtcNow.Ticks;

	public RecoveredType332(RecoveredType321 P_0, string P_1, Action P_2)
	{
		pairing = P_0;
		icons = P_1;
		changed = P_2;
		listener = new TcpListener(IPAddress.Loopback, P_0.Port);
		listener.Start(16);
		Task.Run((Action)RecoveredMethod53);
		TimerCallback callback = delegate
		{
			if (DateTime.UtcNow - new DateTime(Interlocked.Read(ref ownerTick), DateTimeKind.Utc) > TimeSpan.FromSeconds(3.0))
			{
				foreach (RecoveredType327 value in peers.Values)
				{
					value.RecoveredMethod55();
				}
				return;
			}
			foreach (RecoveredType327 item in peers.Values.Where((RecoveredType327 recoveredType) => recoveredType.Connected))
			{
				item.RecoveredMethod51();
			}
			RecoveredMethod805(DateTime.UtcNow);
		};
		heartbeat = new Timer(callback, null, 500, 750);
	}

	public void RecoveredMethod45()
	{
		Interlocked.Exchange(ref ownerTick, DateTime.UtcNow.Ticks);
	}

	public RecoveredType327[] RecoveredMethod803()
	{
		return peers.Values.ToArray();
	}

	public RecoveredType325[] RecoveredMethod804()
	{
		List<RecoveredType325> list = new List<RecoveredType325>();
		RecoveredType325 result;
		while (retired.TryDequeue(out result))
		{
			list.Add(result);
		}
		return list.ToArray();
	}

	internal void RecoveredMethod805(DateTime P_0)
	{
		KeyValuePair<string, RecoveredType327>[] array = peers.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			KeyValuePair<string, RecoveredType327> item = array[i];
			if (!item.Value.Connected && P_0 - item.Value.LastSeen > TimeSpan.FromSeconds(30.0) && ((ICollection<KeyValuePair<string, RecoveredType327>>)peers).Remove(item))
			{
				RecoveredType325[] array2 = item.Value.RecoveredMethod795();
				foreach (RecoveredType325 item2 in array2)
				{
					retired.Enqueue(item2);
				}
			}
		}
	}

	private void RecoveredMethod53()
	{
		while (Volatile.Read(ref closed) == 0)
		{
			try
			{
				TcpClient client = listener.AcceptTcpClient();
				if (Interlocked.Increment(ref handshakes) > 16)
				{
					Interlocked.Decrement(ref handshakes);
					client.Close();
				}
				else
				{
					Task.Run(delegate
					{
						RecoveredMethod806(client);
					});
				}
			}
			catch
			{
				if (Volatile.Read(ref closed) != 0)
				{
					break;
				}
			}
		}
	}

	private void RecoveredMethod806(TcpClient P_0)
	{
		RecoveredType341 recoveredType = null;
		bool flag = false;
		try
		{
			recoveredType = new RecoveredType341(P_0);
			RecoveredType313 recoveredType2 = new RecoveredType313();
			recoveredType2.Nonce = RecoveredType321.RecoveredMethod357();
			RecoveredType313 recoveredType3 = recoveredType2;
			recoveredType.RecoveredMethod807(recoveredType3);
			RecoveredType312 hello = RecoveredType341.RecoveredMethod833<RecoveredType312>(recoveredType.RecoveredMethod470());
			if (hello == null || hello.Type != "hello" || hello.Protocol != 1 || !Guid.TryParseExact(hello.WorkerId, "N", out var _) || hello.SessionId < 1 || string.IsNullOrWhiteSpace(hello.Name) || hello.Name.Length > 100 || hello.User == null || hello.User.Length > 100 || !RecoveredType321.RecoveredMethod784(hello.Proof, RecoveredType321.RecoveredMethod783(pairing.Secret, "worker|" + recoveredType3.Nonce + "|" + RecoveredType321.RecoveredMethod785(hello))))
			{
				throw new Exception("Worker authentication failed.");
			}
			if (hello.SessionId == RecoveredType309.SessionId)
			{
				recoveredType.RecoveredMethod807(new RecoveredType314
				{
					Type = "reject",
					Error = "Open the worker inside a separate RDP session. The controller desktop is reserved for your own mouse."
				});
				return;
			}
			if (peers.Values.Any((RecoveredType327 recoveredType5) => recoveredType5.Connected && recoveredType5.SessionId == hello.SessionId && recoveredType5.Id != hello.WorkerId))
			{
				throw new Exception("One worker is already connected in this Windows session.");
			}
			recoveredType.RecoveredMethod807(new RecoveredType314
			{
				Proof = RecoveredType321.RecoveredMethod783(pairing.Secret, "controller|" + recoveredType3.Nonce + "|" + RecoveredType321.RecoveredMethod785(hello))
			});
			RecoveredType327 recoveredType4 = new RecoveredType327(hello, recoveredType, icons, changed, delegate(RecoveredType325 item2)
			{
				retired.Enqueue(item2);
			});
			if (peers.TryGetValue(hello.WorkerId, out var value))
			{
				value.RecoveredMethod55();
				RecoveredType325[] array = value.RecoveredMethod795();
				foreach (RecoveredType325 item in array)
				{
					retired.Enqueue(item);
				}
			}
			peers[hello.WorkerId] = recoveredType4;
			flag = true;
			changed();
			recoveredType4.RecoveredMethod53();
		}
		catch
		{
		}
		finally
		{
			Interlocked.Decrement(ref handshakes);
			if (!flag && recoveredType != null)
			{
				recoveredType.Dispose();
			}
			else if (!flag)
			{
				P_0.Close();
			}
		}
	}

	public void Dispose()
	{
		if (Interlocked.Exchange(ref closed, 1) != 0)
		{
			return;
		}
		heartbeat.Dispose();
		listener.Stop();
		foreach (RecoveredType327 value in peers.Values)
		{
			value.RecoveredMethod55();
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod807(object P_0)
	{
		if (DateTime.UtcNow - new DateTime(Interlocked.Read(ref ownerTick), DateTimeKind.Utc) > TimeSpan.FromSeconds(3.0))
		{
			foreach (RecoveredType327 value in peers.Values)
			{
				value.RecoveredMethod55();
			}
			return;
		}
		foreach (RecoveredType327 item in peers.Values.Where((RecoveredType327 recoveredType) => recoveredType.Connected))
		{
			item.RecoveredMethod51();
		}
		RecoveredMethod805(DateTime.UtcNow);
	}

	[CompilerGenerated]
	private static bool RecoveredMethod281(RecoveredType327 P_0)
	{
		return P_0.Connected;
	}

	[CompilerGenerated]
	private void RecoveredMethod347(RecoveredType325 P_0)
	{
		retired.Enqueue(P_0);
	}
}
