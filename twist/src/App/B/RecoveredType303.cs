using System;

namespace B;

internal sealed class RecoveredType303
{
	private readonly RecoveredType301 bar = new RecoveredType301(0.055);

	private readonly RecoveredType301 fish = new RecoveredType301(0.085);

	public double Gain = 6.0;

	public double TargetLookAhead = 0.06;

	public double TargetFeed = 0.65;

	public double InputDelay = 0.02;

	public double MaxVelocity = 1.15;

	public double VelocityBand = 0.045;

	public double BarVelocity;

	public double TargetVelocity;

	public double Target;

	public double DesiredVelocity;

	public double Error;

	private double lastTime = -1.0;

	private double lastGoal;

	private bool command;

	public static double RecoveredMethod774(double P_0, double P_1, double P_2)
	{
		return Math.Max(P_1, Math.Min(P_2, P_0));
	}

	public void RecoveredMethod45()
	{
		bar.RecoveredMethod45();
		fish.RecoveredMethod45();
		lastTime = -1.0;
		command = false;
		BarVelocity = (TargetVelocity = 0.0);
	}

	public bool RecoveredMethod775(double P_0, double P_1, double P_2, double P_3, bool P_4)
	{
		if (double.IsNaN(P_1) || double.IsInfinity(P_1) || double.IsNaN(P_2) || double.IsInfinity(P_2) || double.IsNaN(P_3) || double.IsInfinity(P_3) || double.IsNaN(P_0) || double.IsInfinity(P_0) || P_3 <= 0.0 || P_3 >= 1.0)
		{
			throw new ArgumentException("Invalid reel geometry.");
		}
		if (lastTime >= 0.0 && (P_0 - lastTime > 0.25 || P_0 <= lastTime))
		{
			RecoveredMethod45();
		}
		if (lastTime >= 0.0 && Math.Abs(P_2 - lastGoal) > 0.1)
		{
			fish.RecoveredMethod45();
		}
		BarVelocity = RecoveredMethod774(bar.RecoveredMethod773(P_0, P_1), -3.0, 3.0);
		TargetVelocity = RecoveredMethod774(fish.RecoveredMethod773(P_0, P_2), -1.6, 1.6);
		double num = P_3 * 0.5;
		double num2 = 1.0 - num;
		if ((P_1 <= num + 0.001 && BarVelocity < 0.0) || (P_1 >= num2 - 0.001 && BarVelocity > 0.0))
		{
			BarVelocity = 0.0;
		}
		Target = RecoveredMethod774(P_2 + TargetVelocity * TargetLookAhead, num, num2);
		double num3 = RecoveredMethod774(P_1 + BarVelocity * InputDelay, num, num2);
		Error = Target - num3;
		DesiredVelocity = RecoveredMethod774(Gain * Error + TargetVelocity * TargetFeed, 0.0 - MaxVelocity, MaxVelocity);
		double num4 = BarVelocity - DesiredVelocity;
		command = P_4;
		if (num4 > VelocityBand)
		{
			command = true;
		}
		else if (num4 < 0.0 - VelocityBand)
		{
			command = false;
		}
		if (P_2 < num - 0.005 && P_1 <= num + 0.004)
		{
			command = true;
		}
		if (P_2 > num2 + 0.005 && P_1 >= num2 - 0.004)
		{
			command = false;
		}
		lastTime = P_0;
		lastGoal = P_2;
		return command;
	}
}
