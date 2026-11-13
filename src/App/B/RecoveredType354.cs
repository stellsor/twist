using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using A;
using a;
using c;

namespace B;

internal static class RecoveredType354
{
	[CompilerGenerated]
	private sealed class RecoveredType355
	{
		public int closedCount;

		public DispatcherFrame frame;

		public void RecoveredMethod133(object P_0, EventArgs P_1)
		{
			closedCount++;
		}

		public void RecoveredMethod45()
		{
			frame.Continue = false;
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception(P_1);
		}
	}

	private static void RecoveredMethod45()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		while (stopwatch.ElapsedMilliseconds < 70)
		{
			System.Windows.Forms.Application.DoEvents();
			Thread.Sleep(1);
		}
	}

	public static void RecoveredMethod50()
	{
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		RecoveredMethod42(RecoveredType173.RecoveredMethod578(0.8, 0.3, 0.0, 0.0, 0.055, 0.02, false), "Hold raises a bar that is below the target");
		RecoveredMethod42(!RecoveredType173.RecoveredMethod578(0.2, 0.7, 0.0, 0.0, 0.055, 0.02, true), "Release lowers a bar that is above the target");
		RecoveredMethod42(RecoveredType173.RecoveredMethod578(0.5, 0.5, 0.0, 0.0, 0.055, 0.02, true), "Hysteresis preserves hold");
		RecoveredMethod42(!RecoveredType173.RecoveredMethod578(0.5, 0.5, 0.0, 0.0, 0.055, 0.02, false), "Hysteresis preserves release");
		double num = 0.5;
		double num2 = 0.0;
		double num3 = 0.0;
		bool flag = false;
		int num4 = 0;
		for (int i = 0; i < 3000; i++)
		{
			double num5 = (double)i * 0.02;
			double num6 = 0.5 + 0.25 * Math.Sin(num5 * 0.6);
			double num7 = 0.15 * Math.Cos(num5 * 0.6);
			flag = RecoveredType173.RecoveredMethod578(num, num6, num2, num7, 0.055, 0.02, flag);
			num2 += (double)(flag ? (-3) : 3) * 0.02;
			num2 *= 0.89;
			num = Math.Max(0.03, Math.Min(0.97, num + num2 * 0.02));
			if (i > 100)
			{
				num3 += Math.Abs(num - num6);
				num4++;
			}
		}
		RecoveredMethod42(num3 / (double)num4 < 0.08, "Controller follows a moving target in a 60-second physics simulation");
		bool flag2 = false;
		try
		{
			RecoveredType170 recoveredType = new RecoveredType170();
			recoveredType.CastX = 2.0;
			recoveredType.RecoveredMethod50();
		}
		catch
		{
			flag2 = true;
		}
		RecoveredMethod42(flag2, "Invalid cast coordinates rejected");
		using (RecoveredType353 recoveredType2 = new RecoveredType353("Harbor routing test A"))
		{
			using RecoveredType353 recoveredType3 = new RecoveredType353("Harbor routing test B");
			int id = Process.GetCurrentProcess().Id;
			using RecoveredType169 recoveredType4 = new RecoveredType169(recoveredType2.Handle, id);
			using RecoveredType169 recoveredType5 = new RecoveredType169(recoveredType3.Handle, id);
			recoveredType4.RecoveredMethod565(true, 0.25, 0.75);
			RecoveredMethod45();
			RecoveredMethod42(recoveredType2.Downs == 1 && recoveredType3.Downs == 0, "Mouse hold routes only to receiver A");
			recoveredType4.RecoveredMethod565(true, 0.25, 0.75);
			RecoveredMethod45();
			RecoveredMethod42(recoveredType2.Downs == 1, "Repeated hold does not spam presses");
			recoveredType5.RecoveredMethod565(true, 0.8, 0.2);
			recoveredType5.RecoveredMethod377(49);
			RecoveredMethod45();
			RecoveredMethod42(recoveredType3.Downs == 1 && recoveredType2.Downs == 1 && recoveredType3.Keys == 1 && recoveredType2.Keys == 0, "Concurrent target and keyboard isolation");
			recoveredType4.RecoveredMethod565(false, 0.0, 0.0);
			RecoveredMethod45();
			RecoveredMethod42(recoveredType2.Ups == 1 && recoveredType3.Ups == 0, "Release is isolated per window");
			recoveredType5.Dispose();
			RecoveredMethod45();
			RecoveredMethod42(recoveredType3.Ups == 1, "Disposal releases an outstanding hold");
			bool flag3 = false;
			try
			{
				new RecoveredType169(recoveredType2.Handle, id + 999999);
			}
			catch
			{
				flag3 = true;
			}
			RecoveredMethod42(flag3, "Wrong process ownership rejected");
		}
		RecoveredType16 obj3 = new RecoveredType16();
		Window window = (Window)typeof(RecoveredType16).GetField("window", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj3);
		int closedCount = 0;
		window.Closed += delegate
		{
			closedCount++;
		};
		window.Close();
		DispatcherFrame frame = new DispatcherFrame();
		Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.ContextIdle, (Action)delegate
		{
			frame.Continue = false;
		});
		Dispatcher.PushFrame(frame);
		RecoveredMethod42(closedCount == 1, "Dashboard closes with idle sessions without recursive Closing exception");
		RecoveredType163 recoveredType6 = new RecoveredType163(File.ReadAllText(Path.Combine(baseDirectory, "offsets.json")));
		RecoveredMethod42(recoveredType6.RecoveredMethod554("GuiObject", "Position") == 1272, "Supplied geometry offset parsed");
		RecoveredType174 recoveredType7 = new RecoveredType174();
		recoveredType7.Pid = 10;
		recoveredType7.Account = "A";
		recoveredType7.Held = true;
		RecoveredType174 recoveredType8 = recoveredType7;
		RecoveredType174 recoveredType9 = new RecoveredType174();
		recoveredType9.Pid = 11;
		recoveredType9.Account = "B";
		recoveredType9.Held = false;
		RecoveredType174 recoveredType10 = recoveredType9;
		RecoveredType174 recoveredType11 = recoveredType8.RecoveredMethod509();
		recoveredType11.Held = false;
		RecoveredMethod42(recoveredType8.Held && !recoveredType10.Held, "Snapshots and per-client state remain independent");
		File.WriteAllText(Path.Combine(baseDirectory, "test-results.txt"), "PASS: 60-second moving-target simulation (mean error " + (num3 / (double)num4).ToString("0.0000") + "); hold/release direction; hysteresis; profile bounds; real window-message routing between two hidden test windows; concurrent mouse/keyboard isolation; release on dispose; process ownership validation; offsets parsing; independent snapshots; real hidden-dashboard close regression.\r\nNo messages were sent to Roblox in these tests. GPO background input acceptance and multiple live Roblox clients remain unverified.\r\n");
	}
}
