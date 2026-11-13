using System;
using System.Globalization;
using System.IO;
using a;

namespace B;

internal sealed class RecoveredType300 : IDisposable
{
	private StreamWriter writer;

	public RecoveredType300(int P_0)
	{
		try
		{
			string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
			Directory.CreateDirectory(text);
			string path = Path.Combine(text, "reel-" + P_0 + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss-fff") + ".csv");
			writer = new StreamWriter(new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.Read));
			writer.WriteLine("seconds,player_y,fish_y,bar_height,progress,held,bar_velocity,fish_velocity,desired_velocity,predicted_target");
		}
		catch
		{
			writer = null;
		}
	}

	public void RecoveredMethod772(double P_0, RecoveredType171 P_1, RecoveredType303 P_2, bool P_3)
	{
		if (writer == null)
		{
			return;
		}
		try
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			writer.WriteLine(string.Join(",", P_0.ToString("0.000000", invariantCulture), P_1.PlayerY.ToString("R", invariantCulture), P_1.GoalY.ToString("R", invariantCulture), P_1.Height.ToString("R", invariantCulture), P_1.Progress.ToString("R", invariantCulture), P_3 ? "1" : "0", P_2.BarVelocity.ToString("R", invariantCulture), P_2.TargetVelocity.ToString("R", invariantCulture), P_2.DesiredVelocity.ToString("R", invariantCulture), P_2.Target.ToString("R", invariantCulture)));
		}
		catch
		{
			try
			{
				writer.Dispose();
			}
			catch
			{
			}
			writer = null;
		}
	}

	public void Dispose()
	{
		if (writer != null)
		{
			try
			{
				writer.Dispose();
			}
			catch
			{
			}
			writer = null;
		}
	}
}
