using System;
using System.IO;
using System.Threading;
using c;
using d;

namespace a;

internal static class RecoveredType252
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception(P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredMethod42(RecoveredType249.PacketSize == 40, "Correct 64-bit Windows input packet");
		RecoveredType251 recoveredType = new RecoveredType251();
		using (RecoveredType245 recoveredType2 = new RecoveredType245(recoveredType, 111))
		{
			recoveredType2.RecoveredMethod565(true, 0.5, 0.4);
			recoveredType2.RecoveredMethod565(true, 0.5, 0.4);
			RecoveredMethod42(recoveredType.Events.Count == 2 && recoveredType2.Held, "Held input is not repeated");
			bool flag = false;
			try
			{
				using (new RecoveredType245(new RecoveredType251(), 222))
				{
				}
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag, "Only one foreground controller may own input");
			recoveredType.InFocus = false;
			bool flag2 = false;
			try
			{
				recoveredType2.RecoveredMethod50();
			}
			catch
			{
				flag2 = true;
			}
			RecoveredMethod42(flag2, "Loss of focus stops control");
		}
		RecoveredMethod42(recoveredType.Events[recoveredType.Events.Count - 1] == "up", "Dispose releases a held mouse even after focus loss");
		RecoveredType251 recoveredType3 = new RecoveredType251();
		recoveredType3.LoseFocusOnMove = true;
		RecoveredType251 recoveredType4 = recoveredType3;
		using (RecoveredType245 recoveredType5 = new RecoveredType245(recoveredType4, 333))
		{
			try
			{
				recoveredType5.RecoveredMethod565(true, 0.5, 0.4);
			}
			catch
			{
			}
			RecoveredMethod42(!recoveredType4.Events.Contains("down"), "Focus change during cursor move prevents mouse down");
		}
		RecoveredType251 recoveredType6 = new RecoveredType251();
		recoveredType6.PhysicalDown = true;
		RecoveredType251 recoveredType7 = recoveredType6;
		using (RecoveredType245 recoveredType8 = new RecoveredType245(recoveredType7, 444))
		{
			try
			{
				recoveredType8.RecoveredMethod565(true, 0.5, 0.4);
			}
			catch
			{
			}
			RecoveredMethod42(recoveredType7.Events.Count == 0, "Physical mouse hold prevents starting automation");
		}
		RecoveredType251 recoveredType9 = new RecoveredType251();
		using (RecoveredType245 recoveredType10 = new RecoveredType245(recoveredType9, 555))
		{
			recoveredType10.RecoveredMethod394(CancellationToken.None);
		}
		RecoveredMethod42(recoveredType9.Keys.Contains(46) && !recoveredType9.Keys.Contains(8), "Backpack search recovery uses Delete instead of the fruit-drop Backspace key");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: foreground exclusivity; focus-loss stop and release; no repeated downs; cursor/focus race; physical-hold guard; 64-bit input packet layout. Input calls were mocked; no real mouse or keyboard input was sent by these tests.\r\n");
	}
}
