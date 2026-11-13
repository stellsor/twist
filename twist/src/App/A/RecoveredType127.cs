using System;
using System.Runtime.InteropServices;
using a;

namespace A;

internal static class RecoveredType127
{
	private struct RecoveredType128
	{
		public int RecoveredField852;

		public int RecoveredField853;
	}

	[DllImport("user32.dll", EntryPoint = "ClientToScreen")]
	private static extern bool RecoveredMethod497(IntPtr P_0, ref RecoveredType128 P_1);

	[DllImport("user32.dll", EntryPoint = "GetPhysicalCursorPos")]
	private static extern bool RecoveredMethod498(out RecoveredType128 P_0);

	[DllImport("user32.dll", EntryPoint = "SetPhysicalCursorPos")]
	private static extern bool RecoveredMethod405(int P_0, int P_1);

	[DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
	private static extern IntPtr RecoveredMethod499(RecoveredType128 P_0);

	[DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
	private static extern int RecoveredMethod500(int P_0);

	public static RecoveredType126 RecoveredMethod501()
	{
		using (new RecoveredType125())
		{
			return new RecoveredType126
			{
				Left = RecoveredMethod500(76),
				Top = RecoveredMethod500(77),
				Width = RecoveredMethod500(78),
				Height = RecoveredMethod500(79)
			};
		}
	}

	public static bool RecoveredMethod502(out int P_0, out int P_1)
	{
		RecoveredType128 recoveredType;
		bool result = RecoveredMethod498(out recoveredType);
		P_0 = recoveredType.RecoveredField852;
		P_1 = recoveredType.RecoveredField853;
		return result;
	}

	public static RecoveredType126 RecoveredMethod503(IntPtr P_0)
	{
		using (new RecoveredType125())
		{
			RecoveredType128 recoveredType = default(RecoveredType128);
			if (!RecoveredType164.RecoveredMethod559(P_0, out var recoveredType2) || recoveredType2.Right < 10 || recoveredType2.Bottom < 10 || !RecoveredMethod497(P_0, ref recoveredType))
			{
				throw new Exception("Roblox's physical client area is unavailable.");
			}
			return new RecoveredType126
			{
				Left = recoveredType.RecoveredField852,
				Top = recoveredType.RecoveredField853,
				Width = recoveredType2.Right,
				Height = recoveredType2.Bottom
			};
		}
	}

	public static bool RecoveredMethod504(int P_0, int P_1, int P_2)
	{
		using (new RecoveredType125())
		{
			uint num;
			return RecoveredType164.RecoveredMethod556(RecoveredMethod499(new RecoveredType128
			{
				RecoveredField852 = P_1,
				RecoveredField853 = P_2
			}), out num) != 0 && num == (uint)P_0;
		}
	}

	public static bool RecoveredMethod505(IntPtr P_0, out double P_1, out double P_2)
	{
		P_1 = (P_2 = 0.0);
		if (!RecoveredMethod498(out var recoveredType))
		{
			return false;
		}
		return RecoveredMethod503(P_0).RecoveredMethod495(recoveredType.RecoveredField852, recoveredType.RecoveredField853, out P_1, out P_2);
	}

	public static void RecoveredMethod506(IntPtr P_0, double P_1, double P_2)
	{
		RecoveredMethod503(P_0).RecoveredMethod496(P_1, P_2, out var num, out var num2);
		if (!RecoveredMethod405(num, num2))
		{
			throw new Exception("Could not move the cursor to the saved physical client point.");
		}
	}
}
