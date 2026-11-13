using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using a;

namespace c;

internal sealed class RecoveredType169 : RecoveredType168, IDisposable
{
	private readonly IntPtr window;

	private readonly int pid;

	private IntPtr heldPoint;

	[CompilerGenerated]
	private bool _003CHeld_003Ek__BackingField;

	public bool Held
	{
		[CompilerGenerated]
		get
		{
			return _003CHeld_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CHeld_003Ek__BackingField = value;
		}
	}

	public RecoveredType169(IntPtr P_0, int P_1)
	{
		window = P_0;
		pid = P_1;
		if (!RecoveredType164.RecoveredMethod78(window, pid))
		{
			throw new Exception("No valid window belongs to this process.");
		}
	}

	private IntPtr RecoveredMethod566(double P_0, double P_1)
	{
		if (!RecoveredType164.RecoveredMethod559(window, out var recoveredType) || recoveredType.Right < 10 || recoveredType.Bottom < 10)
		{
			throw new Exception("Client area is not available.");
		}
		int num = (int)Math.Round(Math.Max(0.0, Math.Min(1.0, P_0)) * (double)(recoveredType.Right - 1));
		int num2 = (int)Math.Round(Math.Max(0.0, Math.Min(1.0, P_1)) * (double)(recoveredType.Bottom - 1));
		return new IntPtr((num2 << 16) | (num & 0xFFFF));
	}

	private void RecoveredMethod567(uint P_0, int P_1, IntPtr P_2)
	{
		if (!RecoveredType164.RecoveredMethod78(window, pid))
		{
			throw new Exception("The Roblox window closed or changed ownership.");
		}
		if (!RecoveredType164.RecoveredMethod561(window, P_0, new IntPtr(P_1), P_2))
		{
			throw new Exception("Windows rejected the window message (" + Marshal.GetLastWin32Error() + ").");
		}
	}

	public void RecoveredMethod565(bool P_0, double P_1, double P_2)
	{
		if (P_0 == Held)
		{
			return;
		}
		if (P_0)
		{
			if (RecoveredType164.RecoveredMethod558(window))
			{
				throw new Exception("Restore this Roblox window; minimized rendering cannot be verified.");
			}
			heldPoint = RecoveredMethod566(P_1, P_2);
			RecoveredMethod567(512u, 0, heldPoint);
			RecoveredMethod567(513u, 1, heldPoint);
			Held = true;
			return;
		}
		try
		{
			RecoveredMethod567(514u, 0, heldPoint);
		}
		finally
		{
			Held = false;
		}
	}

	public void RecoveredMethod377(int P_0)
	{
		uint num = RecoveredType164.RecoveredMethod562((uint)P_0, 0u);
		long num2 = (long)(1 | ((ulong)num << 16));
		RecoveredMethod567(256u, P_0, new IntPtr(num2));
		RecoveredMethod567(257u, P_0, new IntPtr((int)(num2 | 0xC0000000u)));
	}

	public void Dispose()
	{
		if (Held)
		{
			try
			{
				RecoveredMethod565(false, 0.0, 0.0);
			}
			catch
			{
				Held = false;
			}
		}
	}
}
