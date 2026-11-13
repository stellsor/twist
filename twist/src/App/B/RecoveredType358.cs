using a;

namespace B;

internal static class RecoveredType358
{
	public static string RecoveredMethod847(RecoveredType170 P_0, double P_1, int P_2, bool P_3)
	{
		if (P_3)
		{
			return null;
		}
		if (P_0.StopAfterRounds > 0 && P_2 >= P_0.StopAfterRounds)
		{
			return "Round goal reached";
		}
		if (P_0.StopAfterMinutes > 0.0 && P_1 >= P_0.StopAfterMinutes * 60.0)
		{
			return "Time limit reached";
		}
		return null;
	}
}
