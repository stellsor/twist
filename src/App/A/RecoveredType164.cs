using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace a;

internal static class RecoveredType164
{
	internal delegate bool RecoveredType165(IntPtr P_0, IntPtr P_1);

	internal struct RecoveredType166
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	[CompilerGenerated]
	private sealed class RecoveredType167
	{
		public IntPtr best;

		public long size;

		public int pid;

		public bool RecoveredMethod564(IntPtr P_0, IntPtr P_1)
		{
			RecoveredMethod556(P_0, out var num);
			if (num != (uint)pid)
			{
				return true;
			}
			if (!RecoveredMethod559(P_0, out var recoveredType))
			{
				return true;
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			RecoveredMethod560(P_0, stringBuilder, 256);
			long num2 = (long)recoveredType.Right * (long)recoveredType.Bottom;
			if (num2 > size && recoveredType.Right >= 200 && recoveredType.Bottom >= 150 && stringBuilder.ToString().IndexOf("Roblox", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				best = P_0;
				size = num2;
			}
			return true;
		}
	}

	[DllImport("user32.dll", EntryPoint = "EnumWindows")]
	internal static extern bool RecoveredMethod555(RecoveredType165 P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
	internal static extern uint RecoveredMethod556(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", EntryPoint = "IsWindow")]
	internal static extern bool RecoveredMethod557(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsIconic")]
	internal static extern bool RecoveredMethod558(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "GetClientRect")]
	internal static extern bool RecoveredMethod559(IntPtr P_0, out RecoveredType166 P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowText")]
	internal static extern int RecoveredMethod560(IntPtr P_0, StringBuilder P_1, int P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostMessage", SetLastError = true)]
	internal static extern bool RecoveredMethod561(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "MapVirtualKey")]
	internal static extern uint RecoveredMethod562(uint P_0, uint P_1);

	public static bool RecoveredMethod78(IntPtr P_0, int P_1)
	{
		if (P_0 != IntPtr.Zero && RecoveredMethod557(P_0) && RecoveredMethod556(P_0, out var num) != 0)
		{
			return num == (uint)P_1;
		}
		return false;
	}

	public static IntPtr RecoveredMethod563(int P_0)
	{
		IntPtr best = IntPtr.Zero;
		long size = 0L;
		RecoveredMethod555(delegate(IntPtr intPtr, IntPtr intPtr2)
		{
			RecoveredMethod556(intPtr, out var num);
			if (num != (uint)P_0)
			{
				return true;
			}
			if (!RecoveredMethod559(intPtr, out var recoveredType))
			{
				return true;
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			RecoveredMethod560(intPtr, stringBuilder, 256);
			long num2 = (long)recoveredType.Right * (long)recoveredType.Bottom;
			if (num2 > size && recoveredType.Right >= 200 && recoveredType.Bottom >= 150 && stringBuilder.ToString().IndexOf("Roblox", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				best = intPtr;
				size = num2;
			}
			return true;
		}, IntPtr.Zero);
		return best;
	}
}
