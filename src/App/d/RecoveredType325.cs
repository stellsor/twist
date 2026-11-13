using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using A;
using B;
using TwistApp;
using a;

namespace D;

internal sealed class RecoveredType325 : RecoveredType131, IDisposable
{
	private readonly object gate = new object();

	private RecoveredType174 state;

	private RoundRecord[] rounds = new RoundRecord[0];

	private RecoveredType170 profile = new RecoveredType170();

	private string profileVersion;

	public readonly RecoveredType327 Peer;

	public readonly string Key;

	public readonly RecoveredType324 Inventory = new RecoveredType324();

	public DateTime LastState;

	public int Pid => RecoveredMethod509().Pid;

	public long Created => RecoveredMethod509().Created;

	public string InputScope => "session:" + Peer.SessionId;

	public RecoveredType170 Profile
	{
		get
		{
			lock (gate)
			{
				return profile;
			}
		}
	}

	public string ProfileVersion
	{
		get
		{
			lock (gate)
			{
				return profileVersion ?? (profileVersion = RecoveredType341.RecoveredMethod831().Serialize(profile));
			}
		}
	}

	public RecoveredType325(RecoveredType327 P_0, RecoveredType310 P_1)
	{
		Peer = P_0;
		Key = P_1.Key;
		RecoveredMethod792(P_1);
	}

	public void RecoveredMethod792(RecoveredType310 P_0)
	{
		lock (gate)
		{
			if (P_0.State.Activity == null)
			{
				P_0.State.Activity = ((state == null) ? new RecoveredType82[0] : state.Activity);
			}
			if (P_0.State.World == null)
			{
				P_0.State.World = ((state == null) ? new WorldSnapshot() : state.World);
			}
			if (P_0.State.FruitStores == null)
			{
				P_0.State.FruitStores = ((state == null) ? new FruitStoredRecord[0] : state.FruitStores);
			}
			state = P_0.State;
			if (P_0.Profile != null)
			{
				profile = P_0.Profile;
				profileVersion = RecoveredType341.RecoveredMethod831().Serialize(profile);
			}
			if (P_0.Rounds != null)
			{
				rounds = P_0.Rounds;
			}
			LastState = DateTime.UtcNow;
		}
	}

	public RecoveredType174 RecoveredMethod509()
	{
		lock (gate)
		{
			RecoveredType174 recoveredType = state.RecoveredMethod509();
			if (!Peer.Connected || DateTime.UtcNow - LastState > TimeSpan.FromSeconds(4.0))
			{
				recoveredType.Running = (recoveredType.Reeling = (recoveredType.Held = (recoveredType.Attached = false)));
				recoveredType.Status = "Worker offline";
				recoveredType.StopReason = "Worker disconnected · " + RecoveredType84.RecoveredMethod364(Peer.Failure);
			}
			else if (Peer.Desktop != "Ready")
			{
				recoveredType.Running = (recoveredType.Reeling = (recoveredType.Held = (recoveredType.Attached = false)));
				recoveredType.Status = Peer.Desktop;
				recoveredType.StopReason = Peer.Desktop;
			}
			return recoveredType;
		}
	}

	public RoundRecord[] RecoveredMethod510()
	{
		lock (gate)
		{
			return rounds;
		}
	}

	public Task RecoveredMethod511()
	{
		return Peer.RecoveredMethod125(new RecoveredType318
		{
			Key = Key,
			Action = "attach"
		});
	}

	public async Task RecoveredMethod512(RecoveredType170 P_0, bool P_1)
	{
		RecoveredType322.RecoveredMethod128(P_0);
		await Peer.RecoveredMethod125(new RecoveredType318
		{
			Key = Key,
			Action = "start",
			Profile = P_0,
			AutoFish = P_1
		});
	}

	public void RecoveredMethod48(string P_0 = "Stopped by user.")
	{
		Peer.RecoveredMethod125(new RecoveredType318
		{
			Key = Key,
			Action = "stop",
			Reason = RecoveredType84.RecoveredMethod364(P_0)
		}).ContinueWith(delegate(Task<string> task)
		{
			_ = task.Exception;
		}, TaskContinuationOptions.OnlyOnFaulted);
	}

	public Task RecoveredMethod513(string P_0 = "Stopped by user.")
	{
		if (!Peer.Connected)
		{
			return Task.FromResult("");
		}
		return Peer.RecoveredMethod125(new RecoveredType318
		{
			Key = Key,
			Action = "stop",
			Reason = RecoveredType84.RecoveredMethod364(P_0)
		});
	}

	public Task<string> RecoveredMethod514()
	{
		return Peer.RecoveredMethod125(new RecoveredType318
		{
			Key = Key,
			Action = "diagnose"
		});
	}

	public Task RecoveredMethod793(RecoveredType170 P_0)
	{
		return Peer.RecoveredMethod125(new RecoveredType318
		{
			Key = Key,
			Action = "profile",
			Profile = P_0
		});
	}

	public void Dispose()
	{
	}

	[CompilerGenerated]
	private static void RecoveredMethod794(Task<string> P_0)
	{
		_ = P_0.Exception;
	}
}
