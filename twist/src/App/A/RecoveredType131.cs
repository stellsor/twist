using System;
using System.Threading.Tasks;
using TwistApp;
using a;

namespace A;

internal interface RecoveredType131 : IDisposable
{
	int Pid { get; }

	long Created { get; }

	string InputScope { get; }

	RecoveredType174 RecoveredMethod509();

	RoundRecord[] RecoveredMethod510();

	Task RecoveredMethod511();

	Task RecoveredMethod512(RecoveredType170 P_0, bool P_1);

	void RecoveredMethod48(string P_0 = "Stopped by user.");

	Task RecoveredMethod513(string P_0 = "Stopped by user.");

	Task<string> RecoveredMethod514();
}
