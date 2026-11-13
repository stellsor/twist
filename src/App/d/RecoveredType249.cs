using System;
using System.Runtime.InteropServices;
using System.Threading;
using A;
using B;
using a;
using c;

namespace d;

internal sealed class RecoveredType249 : RecoveredType117, RecoveredType244, RecoveredType247, RecoveredType246, RecoveredType243, RecoveredType248
{
	private struct RecoveredType250
	{
		public int RecoveredField1381;

		public int RecoveredField1382;
	}

	private readonly IntPtr window;

	private readonly int pid;

	public bool Focused
	{
		get
		{
			if (RecoveredType164.RecoveredMethod78(window, pid) && !RecoveredType164.RecoveredMethod558(window) && RecoveredType164.RecoveredMethod556(RecoveredMethod680(), out var num) != 0)
			{
				return num == (uint)pid;
			}
			return false;
		}
	}

	public bool LeftIsDown => (RecoveredMethod685(1) & 0x8000) != 0;

	public static int PacketSize => Marshal.SizeOf(typeof(RecoveredType291));

	[DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
	private static extern IntPtr RecoveredMethod680();

	[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
	private static extern bool RecoveredMethod557(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "ClientToScreen")]
	private static extern bool RecoveredMethod681(IntPtr P_0, ref RecoveredType250 P_1);

	[DllImport("user32.dll", EntryPoint = "ScreenToClient")]
	private static extern bool RecoveredMethod682(IntPtr P_0, ref RecoveredType250 P_1);

	[DllImport("user32.dll", EntryPoint = "GetCursorPos")]
	private static extern bool RecoveredMethod683(out RecoveredType250 P_0);

	[DllImport("user32.dll", EntryPoint = "SetCursorPos")]
	private static extern bool RecoveredMethod684(int P_0, int P_1);

	[DllImport("user32.dll", EntryPoint = "GetAsyncKeyState")]
	private static extern short RecoveredMethod685(int P_0);

	[DllImport("user32.dll", EntryPoint = "SendInput", SetLastError = true)]
	private static extern uint RecoveredMethod686(uint P_0, [In] RecoveredType291[] P_1, int P_2);

	[DllImport("user32.dll", EntryPoint = "GetKeyboardLayout")]
	private static extern IntPtr RecoveredMethod687(uint P_0);

	[DllImport("user32.dll", EntryPoint = "MapVirtualKeyEx")]
	private static extern uint RecoveredMethod688(uint P_0, uint P_1, IntPtr P_2);

	public RecoveredType249(IntPtr P_0, int P_1)
	{
		window = P_0;
		pid = P_1;
		if (!RecoveredType164.RecoveredMethod78(P_0, P_1))
		{
			throw new Exception("This Roblox window is not available. Refresh the account list.");
		}
	}

	private static void RecoveredMethod689(RecoveredType291 P_0)
	{
		if (RecoveredMethod686(1u, new RecoveredType291[1] { P_0 }, Marshal.SizeOf(typeof(RecoveredType291))) != 1)
		{
			throw new Exception("Windows did not accept the input. Error " + Marshal.GetLastWin32Error() + ".");
		}
	}

	public void RecoveredMethod348(double P_0, double P_1)
	{
		if (!Focused)
		{
			throw new Exception("Roblox is not in the foreground.");
		}
		RecoveredType127.RecoveredMethod503(window).RecoveredMethod496(P_0, P_1, out var num, out var num2);
		RecoveredType305.RecoveredMethod777(this, num, num2);
	}

	public void RecoveredMethod672(double P_0, double P_1)
	{
		if (!Focused)
		{
			throw new Exception("Roblox is not in the foreground.");
		}
		RecoveredType127.RecoveredMethod503(window).RecoveredMethod496(P_0, P_1, out var num, out var num2);
		RecoveredType377.RecoveredMethod870(this, num, num2);
	}

	private void RecoveredMethod690(int P_0, int P_1)
	{
		RecoveredMethod689(RecoveredType292.RecoveredMethod765(P_0, P_1, RecoveredType127.RecoveredMethod501()));
	}

	void RecoveredType247.RecoveredMethod679(int P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in RecoveredMethod690
		this.RecoveredMethod690(P_0, P_1);
	}

	private RecoveredType304 RecoveredMethod691()
	{
		if (!RecoveredType127.RecoveredMethod502(out var recoveredField, out var recoveredField2))
		{
			throw new Exception("Cannot read the session cursor.");
		}
		return new RecoveredType304
		{
			RecoveredField1628 = recoveredField,
			RecoveredField1629 = recoveredField2
		};
	}

	RecoveredType304 RecoveredType246.RecoveredMethod677()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RecoveredMethod691
		return this.RecoveredMethod691();
	}

	private void RecoveredMethod692(int P_0, int P_1)
	{
		RecoveredMethod689(RecoveredType292.RecoveredMethod763(P_0, P_1));
	}

	void RecoveredType246.RecoveredMethod678(int P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in RecoveredMethod692
		this.RecoveredMethod692(P_0, P_1);
	}

	private void RecoveredMethod56()
	{
		if (!Focused)
		{
			throw new Exception("Roblox lost focus during mouse movement.");
		}
	}

	void RecoveredType246.RecoveredMethod50()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RecoveredMethod56
		this.RecoveredMethod56();
	}

	private void RecoveredMethod693()
	{
		Thread.Sleep(8);
	}

	void RecoveredType246.RecoveredMethod51()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RecoveredMethod693
		this.RecoveredMethod693();
	}

	public string RecoveredMethod670(double P_0, double P_1)
	{
		RecoveredType127.RecoveredMethod503(window).RecoveredMethod496(P_0, P_1, out var num, out var num2);
		if (!RecoveredType127.RecoveredMethod502(out var num3, out var num4))
		{
			return "Cannot verify the worker cursor position.";
		}
		if (Math.Abs(num - num3) > 4 || Math.Abs(num2 - num4) > 4)
		{
			return "Cursor did not reach UI target: expected " + num + "," + num2 + "; actual " + num3 + "," + num4 + ". Disable Roblox mouse/shift lock and retry.";
		}
		if (!RecoveredType127.RecoveredMethod504(pid, num3, num4))
		{
			return "Another window covers the bait control. Move the worker panel away from the game controls.";
		}
		return "";
	}

	public void RecoveredMethod377(int P_0)
	{
		if (!Focused)
		{
			throw new Exception("Roblox lost focus before scrolling.");
		}
		RecoveredMethod689(RecoveredType292.RecoveredMethod761(P_0));
	}

	public void RecoveredMethod72(bool P_0)
	{
		if (P_0 && !Focused)
		{
			throw new Exception("Roblox lost focus before mouse down.");
		}
		RecoveredMethod689(RecoveredType292.RecoveredMethod762(P_0));
	}

	public void RecoveredMethod469(int P_0, bool P_1)
	{
		if (P_1 && !Focused)
		{
			throw new Exception("Roblox lost focus before key down.");
		}
		uint num2;
		uint num = RecoveredType164.RecoveredMethod556(window, out num2);
		uint num3 = RecoveredMethod688((uint)P_0, 4u, RecoveredMethod687(num));
		RecoveredMethod689(RecoveredType292.RecoveredMethod760(num3, P_1));
	}

	public static bool RecoveredMethod694(int P_0)
	{
		IntPtr intPtr = RecoveredType164.RecoveredMethod563(P_0);
		if (!RecoveredType164.RecoveredMethod78(intPtr, P_0) || RecoveredType164.RecoveredMethod558(intPtr))
		{
			return false;
		}
		if (!RecoveredMethod557(intPtr))
		{
			RecoveredType164.RecoveredMethod556(RecoveredMethod680(), out var num);
			if (num != (uint)P_0)
			{
				return false;
			}
		}
		return new RecoveredType249(intPtr, P_0).Focused;
	}

	public static bool RecoveredMethod695(int P_0, out double P_1, out double P_2)
	{
		P_1 = (P_2 = 0.0);
		IntPtr intPtr = RecoveredType164.RecoveredMethod563(P_0);
		if (RecoveredType164.RecoveredMethod78(intPtr, P_0) && !RecoveredType164.RecoveredMethod558(intPtr))
		{
			return RecoveredType127.RecoveredMethod505(intPtr, out P_1, out P_2);
		}
		return false;
	}
}
