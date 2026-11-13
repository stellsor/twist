using System;
using System.Runtime.InteropServices;
using a;

namespace c;

internal sealed class RecoveredType282 : RecoveredType208, IDisposable
{
	private IntPtr handle;

	[DllImport("kernel32.dll", EntryPoint = "OpenProcess", SetLastError = true)]
	private static extern IntPtr RecoveredMethod751(uint P_0, bool P_1, int P_2);

	[DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory", SetLastError = true)]
	private static extern bool RecoveredMethod752(IntPtr P_0, IntPtr P_1, [Out] byte[] P_2, UIntPtr P_3, out UIntPtr P_4);

	[DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
	private static extern bool RecoveredMethod557(IntPtr P_0);

	public RecoveredType282(int P_0)
	{
		handle = RecoveredMethod751(4112u, false, P_0);
		if (handle == IntPtr.Zero)
		{
			throw new Exception("Windows denied read access to Roblox (error " + Marshal.GetLastWin32Error() + ").");
		}
	}

	public byte[] RecoveredMethod609(ulong P_0, int P_1)
	{
		if (!RecoveredType285.RecoveredMethod572(P_0) || P_1 < 1 || P_1 > 1048576)
		{
			return null;
		}
		byte[] array = new byte[P_1];
		if (!RecoveredMethod752(handle, new IntPtr((long)P_0), array, (UIntPtr)(ulong)P_1, out var uIntPtr) || uIntPtr.ToUInt64() != (ulong)P_1)
		{
			return null;
		}
		return array;
	}

	public void Dispose()
	{
		if (handle != IntPtr.Zero)
		{
			RecoveredMethod557(handle);
			handle = IntPtr.Zero;
		}
	}
}
