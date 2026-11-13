using System;
using System.Threading.Tasks;
using A;
using TwistApp;
using a;

namespace c;

internal sealed class RecoveredType132 : RecoveredType131, IDisposable
{
	public RecoveredType174 State;

	public bool Ready;

	public bool Disposed;

	public int Attaches;

	public int Starts;

	public int Stops;

	public string User;

	public RoundRecord[] Rounds = new RoundRecord[0];

	public int Pid => State.Pid;

	public long Created => State.Created;

	public string InputScope => "session:lifecycle-test";

	public RecoveredType174 RecoveredMethod509()
	{
		return State.RecoveredMethod509();
	}

	public RoundRecord[] RecoveredMethod510()
	{
		return Rounds;
	}

	public Task RecoveredMethod511()
	{
		Attaches++;
		State.Attached = Ready;
		if (Ready)
		{
			State.Account = "Lifecycle";
			State.UserId = User;
			State.Status = "Idle";
		}
		else
		{
			State.Status = "LocalPlayer is not ready.";
		}
		return Task.FromResult(0);
	}

	public Task RecoveredMethod512(RecoveredType170 P_0, bool P_1)
	{
		Starts++;
		State.Running = true;
		return Task.FromResult(0);
	}

	public void RecoveredMethod48(string P_0 = "Stopped by user.")
	{
		State.Running = false;
	}

	public Task RecoveredMethod513(string P_0 = "Stopped by user.")
	{
		Stops++;
		State.Running = false;
		return Task.FromResult(0);
	}

	public Task<string> RecoveredMethod514()
	{
		return Task.FromResult("");
	}

	public void Dispose()
	{
		Disposed = true;
	}
}
