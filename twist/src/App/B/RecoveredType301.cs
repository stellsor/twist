using System.Collections.Generic;

namespace B;

internal sealed class RecoveredType301
{
	private struct RecoveredType302
	{
		public double Time;

		public double Position;
	}

	private readonly List<RecoveredType302> samples = new List<RecoveredType302>();

	private readonly double duration;

	public RecoveredType301(double P_0)
	{
		duration = P_0;
	}

	public void RecoveredMethod45()
	{
		samples.Clear();
	}

	public double RecoveredMethod773(double P_0, double P_1)
	{
		if (samples.Count > 0 && P_0 <= samples[samples.Count - 1].Time)
		{
			return 0.0;
		}
		samples.Add(new RecoveredType302
		{
			Time = P_0,
			Position = P_1
		});
		while (samples.Count > 2 && P_0 - samples[0].Time > duration)
		{
			samples.RemoveAt(0);
		}
		double num = 0.0;
		double num2 = 0.0;
		foreach (RecoveredType302 sample in samples)
		{
			num += sample.Time;
			num2 += sample.Position;
		}
		num /= (double)samples.Count;
		num2 /= (double)samples.Count;
		double num3 = 0.0;
		double num4 = 0.0;
		foreach (RecoveredType302 sample2 in samples)
		{
			num3 += (sample2.Time - num) * (sample2.Position - num2);
			num4 += (sample2.Time - num) * (sample2.Time - num);
		}
		if (!(num4 > 1E-07))
		{
			return 0.0;
		}
		return num3 / num4;
	}
}
