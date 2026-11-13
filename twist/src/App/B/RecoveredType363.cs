using System;
using System.Collections.Generic;
using System.IO;
using a;

namespace B;

internal static class RecoveredType363
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception(P_1);
		}
	}

	private static double RecoveredMethod774(double P_0, double P_1, double P_2)
	{
		return Math.Max(P_1, Math.Min(P_2, P_0));
	}

	private static double RecoveredMethod851(double P_0, int P_1, int P_2)
	{
		return P_1 switch
		{
			0 => 0.5, 
			1 => 0.5 + 0.3 * Math.Sin(P_0 * 0.75), 
			2 => 0.5 + 0.32 * Math.Sin(P_0 * 2.2) + 0.07 * Math.Sin(P_0 * 4.1), 
			3 => (new double[8] { 0.5, 0.08, 0.55, 0.82, 0.32, 0.68, 0.12, 0.92 })[(int)(P_0 / 1.7 + (double)P_2) % 8], 
			_ => RecoveredMethod774(0.5 + 0.24 * Math.Sin(P_0 * (0.6 + (double)P_2 * 0.03)) + 0.18 * Math.Sin(P_0 * 2.5 + (double)P_2), 0.02, 0.98), 
		};
	}

	private static double[] RecoveredMethod852(bool P_0, int P_1, int P_2)
	{
		RecoveredType303 recoveredType = new RecoveredType303();
		Queue<KeyValuePair<double, bool>> queue = new Queue<KeyValuePair<double, bool>>();
		double num = 0.5;
		double num2 = 0.0;
		double num3 = 0.5;
		double num4 = 0.5;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		double num12 = 2.0 + (double)(P_2 % 4) * 1.5;
		double num13 = 2.5 + (double)(P_2 % 3) * 1.4;
		double num14 = (double)(P_2 % 4) * 0.8;
		double num15 = 0.015 + (double)(P_2 % 5) * 0.015;
		double num16 = 0.9 + (double)(P_2 % 5) * 0.25;
		for (double num17 = 0.0; num17 < 35.0; num17 += 0.004)
		{
			double num18 = RecoveredMethod774(RecoveredMethod851(num17, P_1, P_2), 0.0, 1.0);
			if (num17 >= num8)
			{
				num8 += (P_0 ? (1.0 / 64.0) : (1.0 / 32.0));
				if (P_0)
				{
					flag2 = recoveredType.RecoveredMethod775(num17, num, num18, 0.25, flag2);
				}
				else
				{
					double num19 = num17 - num7;
					if (num7 > 0.0)
					{
						num5 = 0.4 * RecoveredMethod774((num - num3) / num19, -3.0, 3.0) + 0.6 * num5;
						num6 = 0.4 * RecoveredMethod774((num18 - num4) / num19, -3.0, 3.0) + 0.6 * num6;
					}
					num7 = num17;
					num3 = num;
					num4 = num18;
					flag2 = RecoveredType173.RecoveredMethod578(num, num18, num5, num6, 0.055, 0.02, flag2);
				}
				if (flag2 != flag3)
				{
					flag3 = flag2;
					queue.Enqueue(new KeyValuePair<double, bool>(num17 + num15, flag2));
				}
			}
			while (queue.Count > 0 && queue.Peek().Key <= num17)
			{
				flag = queue.Dequeue().Value;
			}
			num2 += ((flag ? (0.0 - num12) : num13) - num14 * num2) * 0.004;
			num2 = RecoveredMethod774(num2, 0.0 - num16, num16);
			num += num2 * 0.004;
			if (num < 0.125)
			{
				num = 0.125;
				if (num2 < 0.0)
				{
					num2 = 0.0;
				}
			}
			if (num > 0.875)
			{
				num = 0.875;
				if (num2 > 0.0)
				{
					num2 = 0.0;
				}
			}
			if (num17 > 1.0)
			{
				num9 += Math.Abs(num - num18);
				num10 += (double)((Math.Abs(num - num18) <= 0.125) ? 1 : 0);
				num11 += 1.0;
			}
		}
		return new double[2]
		{
			num9 / num11,
			num10 / num11
		};
	}

	public static void RecoveredMethod45()
	{
		RecoveredType301 recoveredType = new RecoveredType301(0.055);
		recoveredType.RecoveredMethod773(0.0, 0.2);
		recoveredType.RecoveredMethod773(0.016, 0.208);
		RecoveredMethod42(Math.Abs(recoveredType.RecoveredMethod773(0.032, 0.216) - 0.5) < 1E-05, "Position history estimates actual bar velocity");
		RecoveredType303 recoveredType2 = new RecoveredType303();
		RecoveredMethod42(recoveredType2.RecoveredMethod775(0.0, 0.125, 0.02, 0.25, false), "Pinned top target holds the bar at its stop");
		RecoveredType303 recoveredType3 = new RecoveredType303();
		RecoveredMethod42(!recoveredType3.RecoveredMethod775(0.0, 0.875, 0.98, 0.25, true), "Pinned bottom target releases at its stop");
		RecoveredType303 recoveredType4 = new RecoveredType303();
		RecoveredMethod42(recoveredType4.RecoveredMethod775(0.0, 0.7, 0.4, 0.25, false), "Below fish -> raise bar");
		recoveredType4.RecoveredMethod45();
		RecoveredMethod42(!recoveredType4.RecoveredMethod775(0.0, 0.3, 0.6, 0.25, true), "Above fish -> lower bar");
		bool flag = false;
		try
		{
			new RecoveredType303().RecoveredMethod775(0.0, double.NaN, 0.5, 0.25, false);
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag, "Invalid measurements rejected");
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = 0;
		for (int i = 0; i < 5; i++)
		{
			double num6 = 0.0;
			double num7 = 0.0;
			for (int j = 5; j < 11; j++)
			{
				double[] array = RecoveredMethod852(false, i, j);
				double[] array2 = RecoveredMethod852(true, i, j);
				num += array[0];
				num2 += array2[0];
				num3 += array[1];
				num4 += array2[1];
				num6 += array[0];
				num7 += array2[0];
				num5++;
			}
			RecoveredMethod42(num7 < num6, "Improvement across target scenario " + i);
		}
		RecoveredMethod42(num2 < num * 0.65 && num4 > num3, "Tracking improves across 30 delayed/asymmetric holdout simulations");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: measured velocity; top/bottom limits; motion direction; invalid-sample rejection; all five simulated target styles improve. Holdout mean error " + (num / (double)num5).ToString("0.0000") + " -> " + (num2 / (double)num5).ToString("0.0000") + "; simulated contact " + (num3 / (double)num5).ToString("P1") + " -> " + (num4 / (double)num5).ToString("P1") + " across 30 cases. These are simulation results, not live GPO catch rates.\r\n");
	}
}
