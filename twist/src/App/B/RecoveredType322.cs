using System;
using System.Runtime.InteropServices;
using System.Text;
using a;

namespace B;

internal static class RecoveredType322
{
	[DllImport("wtsapi32.dll", EntryPoint = "WTSQuerySessionInformation", SetLastError = true)]
	private static extern bool RecoveredMethod786(IntPtr P_0, int P_1, int P_2, out IntPtr P_3, out int P_4);

	[DllImport("wtsapi32.dll", EntryPoint = "WTSFreeMemory")]
	private static extern void RecoveredMethod787(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "OpenInputDesktop", SetLastError = true)]
	private static extern IntPtr RecoveredMethod788(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", EntryPoint = "CloseDesktop")]
	private static extern bool RecoveredMethod558(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserObjectInformation")]
	private static extern bool RecoveredMethod789(IntPtr P_0, int P_1, StringBuilder P_2, int P_3, out int P_4);

	public static string RecoveredMethod357()
	{
		if (!RecoveredMethod786(IntPtr.Zero, RecoveredType309.SessionId, 8, out var intPtr, out var num))
		{
			return "Session state unavailable";
		}
		try
		{
			if (num < 4 || Marshal.ReadInt32(intPtr) != 0)
			{
				return "Session disconnected or inactive";
			}
		}
		finally
		{
			RecoveredMethod787(intPtr);
		}
		IntPtr intPtr2 = RecoveredMethod788(0u, false, 1u);
		if (intPtr2 == IntPtr.Zero)
		{
			return "Desktop locked or unavailable";
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			if (!RecoveredMethod789(intPtr2, 2, stringBuilder, 512, out var _) || !stringBuilder.ToString().Equals("Default", StringComparison.OrdinalIgnoreCase))
			{
				return "Desktop locked or unavailable";
			}
		}
		finally
		{
			RecoveredMethod558(intPtr2);
		}
		return "Ready";
	}

	public static void RecoveredMethod128(RecoveredType170 P_0)
	{
		if (P_0 == null)
		{
			throw new Exception("Missing fishing settings.");
		}
		P_0.RecoveredMethod50();
		double[] array = new double[5] { P_0.CastX, P_0.CastY, P_0.PredictionMs, P_0.DeadZone, P_0.StopAfterMinutes };
		foreach (double d in array)
		{
			if (double.IsNaN(d) || double.IsInfinity(d))
			{
				throw new Exception("Invalid fishing settings.");
			}
		}
	}
}
