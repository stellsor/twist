using System;
using System.Threading;
using A;

namespace C;

internal sealed class RecoveredType90 : RecoveredType89
{
	public int Calls;

	public RecoveredType145 RecoveredMethod378(Uri P_0, string P_1, CancellationToken P_2)
	{
		Interlocked.Increment(ref Calls);
		RecoveredType145 recoveredType = new RecoveredType145();
		recoveredType.Status = 200;
		return recoveredType;
	}
}
