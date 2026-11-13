using System;
using System.Runtime.InteropServices;

namespace A;

internal sealed class RecoveredType125 : IDisposable
{
	private readonly IntPtr previous;

	[DllImport("user32.dll", EntryPoint = "SetThreadDpiAwarenessContext", SetLastError = true)]
	private static extern IntPtr RecoveredMethod494(IntPtr P_0);

	public RecoveredType125()
	{
		previous = RecoveredMethod494(new IntPtr(-4));
		if (previous == IntPtr.Zero)
		{
			previous = RecoveredMethod494(new IntPtr(-3));
		}
		if (previous == IntPtr.Zero)
		{
			throw new Exception("Windows could not provide physical client coordinates.");
		}
	}

	public void Dispose()
	{
		if (previous != IntPtr.Zero)
		{
			RecoveredMethod494(previous);
		}
	}
}
