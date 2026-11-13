using System;
using B;

namespace A;

internal struct RecoveredType126
{
	public int Left;

	public int Top;

	public int Width;

	public int Height;

	public bool RecoveredMethod495(int P_0, int P_1, out double P_2, out double P_3)
	{
		return RecoveredType343.RecoveredMethod835(P_0 - Left, P_1 - Top, Width, Height, out P_2, out P_3);
	}

	public void RecoveredMethod496(double P_0, double P_1, out int P_2, out int P_3)
	{
		if (double.IsNaN(P_0) || double.IsInfinity(P_0) || double.IsNaN(P_1) || double.IsInfinity(P_1) || P_0 < 0.0 || P_0 > 1.0 || P_1 < 0.0 || P_1 > 1.0 || Width < 10 || Height < 10)
		{
			throw new Exception("Invalid saved client point.");
		}
		P_2 = Left + (int)Math.Round(P_0 * (double)(Width - 1));
		P_3 = Top + (int)Math.Round(P_1 * (double)(Height - 1));
	}
}
