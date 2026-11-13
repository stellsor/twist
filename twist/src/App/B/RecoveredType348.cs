using System;
using System.IO;

namespace B;

internal static class RecoveredType348
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Pick test: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredMethod42(RecoveredType343.RecoveredMethod835(959, 539, 1920, 1080, out var num, out var num2) && Math.Abs(num - 0.5) < 0.001 && Math.Abs(num2 - 0.5) < 0.001, "Right-click coordinates map to client ratios");
		RecoveredMethod42(!RecoveredType343.RecoveredMethod835(-1, 20, 1920, 1080, out num, out num2), "Outside left is rejected");
		RecoveredMethod42(!RecoveredType343.RecoveredMethod835(1920, 20, 1920, 1080, out num, out num2), "Outside right is rejected");
		RecoveredMethod42(!RecoveredType343.RecoveredMethod835(5, 5, 0, 0, out num, out num2), "Unavailable client is rejected");
		RecoveredMethod42(RecoveredType343.RecoveredMethod835(1919, 1079, 1920, 1080, out num, out num2) && num == 1.0 && num2 == 1.0, "Client edge is preserved");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: right-click client coordinate bounds, ratios and edges. No mouse hook installed and no game input sent by this test.\r\n");
	}
}
