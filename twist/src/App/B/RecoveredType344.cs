using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using A;
using a;

namespace B;

internal sealed class RecoveredType344 : IDisposable
{
	private delegate IntPtr RecoveredType345(int P_0, IntPtr P_1, IntPtr P_2);

	private struct RecoveredType346
	{
		public int RecoveredField1828;

		public int RecoveredField1829;
	}

	private struct RecoveredType347
	{
		public RecoveredType346 Position;

		public uint MouseData;

		public uint Flags;

		public uint Time;

		public UIntPtr Extra;
	}

	private readonly int pid;

	private readonly long created;

	private readonly Action<double, double> picked;

	private readonly RecoveredType345 callback;

	private IntPtr handle;

	private bool accepted;

	private bool disposed;

	[DllImport("user32.dll", EntryPoint = "SetWindowsHookEx", SetLastError = true)]
	private static extern IntPtr RecoveredMethod836(int P_0, RecoveredType345 P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool RecoveredMethod557(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "CallNextHookEx")]
	private static extern IntPtr RecoveredMethod837(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	private static extern IntPtr RecoveredMethod838(string P_0);

	[DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
	private static extern IntPtr RecoveredMethod839(RecoveredType346 P_0);

	[DllImport("user32.dll", EntryPoint = "ScreenToClient")]
	private static extern bool RecoveredMethod840(IntPtr P_0, ref RecoveredType346 P_1);

	public RecoveredType344(int P_0, long P_1, Action<double, double> P_2)
	{
		pid = P_0;
		created = P_1;
		picked = P_2;
		callback = RecoveredMethod841;
		handle = RecoveredMethod836(14, callback, RecoveredMethod838(null), 0u);
		if (handle == IntPtr.Zero)
		{
			throw new Win32Exception(Marshal.GetLastWin32Error(), "Could not listen for a right-click.");
		}
	}

	private IntPtr RecoveredMethod841(int P_0, IntPtr P_1, IntPtr P_2)
	{
		try
		{
			if (!disposed && !accepted && P_0 >= 0 && P_1.ToInt32() == 516)
			{
				RecoveredType347 recoveredType = (RecoveredType347)Marshal.PtrToStructure(P_2, typeof(RecoveredType347));
				if (RecoveredType127.RecoveredMethod504(pid, recoveredType.Position.RecoveredField1828, recoveredType.Position.RecoveredField1829))
				{
					using (Process process = Process.GetProcessById(pid))
					{
						if (process.StartTime.ToUniversalTime().Ticks != created)
						{
							return RecoveredMethod837(handle, P_0, P_1, P_2);
						}
					}
					IntPtr intPtr = RecoveredType164.RecoveredMethod563(pid);
					if (RecoveredType164.RecoveredMethod78(intPtr, pid) && !RecoveredType164.RecoveredMethod558(intPtr) && RecoveredType127.RecoveredMethod503(intPtr).RecoveredMethod495(recoveredType.Position.RecoveredField1828, recoveredType.Position.RecoveredField1829, out var arg, out var arg2))
					{
						accepted = true;
						picked(arg, arg2);
					}
				}
			}
		}
		catch
		{
		}
		return RecoveredMethod837(handle, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		if (!disposed)
		{
			disposed = true;
			if (handle != IntPtr.Zero)
			{
				RecoveredMethod557(handle);
				handle = IntPtr.Zero;
			}
		}
	}
}
