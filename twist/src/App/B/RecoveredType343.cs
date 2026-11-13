namespace B;

internal static class RecoveredType343
{
	public static bool RecoveredMethod835(int P_0, int P_1, int P_2, int P_3, out double P_4, out double P_5)
	{
		P_4 = (P_5 = 0.0);
		if (P_2 < 10 || P_3 < 10 || P_0 < 0 || P_1 < 0 || P_0 >= P_2 || P_1 >= P_3)
		{
			return false;
		}
		P_4 = (double)P_0 / (double)(P_2 - 1);
		P_5 = (double)P_1 / (double)(P_3 - 1);
		return true;
	}
}
