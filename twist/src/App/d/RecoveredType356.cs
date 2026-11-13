using System;
using System.Threading.Tasks;
using A;
using TwistApp;
using a;

namespace D;

internal sealed class RecoveredType356 : RecoveredType131, IDisposable
{
	public RecoveredType174 State;

	public int Starts;

	public int Stops;

	public string Scope;

	public RoundRecord[] Rounds = new RoundRecord[0];

	public int Pid => State.Pid;

	public long Created => State.Created;

	public string InputScope => Scope;

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
		return Task.FromResult(0);
	}

	public Task RecoveredMethod512(RecoveredType170 P_0, bool P_1)
	{
		Starts++;
		State.Running = true;
		State.AutoFish = P_1;
		State.Status = "Waiting for a bite";
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
		return Task.FromResult("mock");
	}

	public void Dispose()
	{
	}
}
