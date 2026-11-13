using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace A;

internal static class RecoveredType22
{
	[CompilerGenerated]
	private sealed class RecoveredType23
	{
		public ProcessStartInfo captured;

		public bool attempted;

		public void RecoveredMethod57(ProcessStartInfo P_0)
		{
			captured = P_0;
		}

		public void RecoveredMethod59(ProcessStartInfo P_0)
		{
			attempted = true;
		}
	}

	private static void RecoveredMethod12(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Launcher test: " + P_1);
		}
	}

	public static int RecoveredMethod58()
	{
		RecoveredType6.RecoveredMethod11();
		string text = Path.Combine(Path.GetTempPath(), "twist launcher test " + Guid.NewGuid().ToString("N"));
		string text2 = Path.Combine(text, "app");
		string text3 = Path.Combine(text, "preferences", "role.txt");
		try
		{
			Directory.CreateDirectory(text2);
			File.WriteAllText(Path.Combine(text2, "twist.exe"), "Test placeholder; never executed.");
			foreach (RecoveredType11 value2 in Enum.GetValues(typeof(RecoveredType11)))
			{
				ProcessStartInfo processStartInfo = RecoveredType12.RecoveredMethod32(text, value2, true, false);
				RecoveredMethod12(processStartInfo.FileName == Path.Combine(text2, "twist.exe") && processStartInfo.WorkingDirectory == text2, "absolute runtime path and correct working directory with spaces");
				RecoveredMethod12(processStartInfo.Arguments == value2 switch
				{
					RecoveredType11.Local => "--local ", 
					RecoveredType11.Worker => "--worker ", 
					_ => "", 
				} + "--offsets-checked", "exact role arguments");
				RecoveredMethod12(processStartInfo.UseShellExecute && processStartInfo.Verb == ((value2 == RecoveredType11.Controller) ? "runas" : ""), "elevation only for requested controller");
				RecoveredMethod12(RecoveredType12.RecoveredMethod32(text, value2, false, false).Verb == "", "ordinary launch");
				RecoveredMethod12(RecoveredType12.RecoveredMethod32(text, value2, true, true).Verb == "", "already-elevated launch avoids another prompt");
			}
			RecoveredMethod12(RecoveredType12.RecoveredMethod33(text3) == RecoveredType11.Worker, "first launch defaults to worker");
			ProcessStartInfo captured = null;
			RecoveredMethod12(RecoveredType12.RecoveredMethod34(text, RecoveredType11.Local, false, false, text3, delegate(ProcessStartInfo P_0)
			{
				captured = P_0;
			}, out var text4) && captured.Arguments == "--local --offsets-checked" && RecoveredType12.RecoveredMethod33(text3) == RecoveredType11.Local, "successful choice is remembered per user");
			RecoveredMethod12(!RecoveredType12.RecoveredMethod34(text, RecoveredType11.Controller, true, false, text3, delegate
			{
				throw new Win32Exception(1223);
			}, out text4) && text4.Contains("cancelled") && RecoveredType12.RecoveredMethod33(text3) == RecoveredType11.Local, "cancelled elevation preserves last working choice");
			bool attempted = false;
			RecoveredMethod12(!RecoveredType12.RecoveredMethod34(Path.Combine(text, "missing"), RecoveredType11.Worker, false, false, text3, delegate
			{
				attempted = true;
			}, out text4) && !attempted && text4.Contains("missing"), "missing runtime reports error without launching");
			Application application = new Application();
			application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			Application application2 = application;
			RecoveredType13 recoveredType2 = new RecoveredType13(text, text3, delegate
			{
				throw new Win32Exception(1223);
			});
			RecoveredMethod12(recoveredType2.Selected == RecoveredType11.Local, "UI loads remembered selection");
			recoveredType2.RecoveredMethod36(RecoveredType11.Controller);
			RecoveredMethod12(((CheckBox)recoveredType2.Window.FindName("AdminChoice")).Visibility == Visibility.Visible && ((Button)recoveredType2.Window.FindName("LaunchButton")).Content.ToString() == "Open controller", "controller option shows elevation and correct button");
			((Button)recoveredType2.Window.FindName("LaunchButton")).RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
			RecoveredMethod12(((TextBlock)recoveredType2.Window.FindName("Status")).Visibility == Visibility.Visible && ((Button)recoveredType2.Window.FindName("LaunchButton")).IsEnabled, "cancelled start keeps the launcher usable");
			recoveredType2.RecoveredMethod36(RecoveredType11.Worker);
			RecoveredMethod12(((CheckBox)recoveredType2.Window.FindName("AdminChoice")).Visibility == Visibility.Collapsed, "worker hides controller-only controls");
			recoveredType2.RecoveredMethod2(RecoveredType3.RecoveredMethod1("{\"tag_name\":\"v99.1.2\",\"draft\":false,\"prerelease\":false,\"assets\":[{\"name\":\"twist-99.1.2-public.zip\",\"size\":4,\"digest\":\"sha256:aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"browser_download_url\":\"https://github.com/Stellsor/twist/releases/download/v99.1.2/twist-99.1.2-public.zip\"}]}"));
			RecoveredMethod12(((Button)recoveredType2.Window.FindName("DownloadUpdate")).Visibility == Visibility.Visible && ((TextBlock)recoveredType2.Window.FindName("AppUpdateStatus")).Text.Contains("99.1.2"), "bottom update prompt is available for a newer release");
			recoveredType2.prepareUpdate = delegate
			{
				throw new IOException("Simulated update failure");
			};
			recoveredType2.RecoveredMethod42().GetAwaiter().GetResult();
			RecoveredMethod12(((Button)recoveredType2.Window.FindName("LaunchButton")).IsEnabled && ((TextBlock)recoveredType2.Window.FindName("AppUpdateStatus")).Text.Contains("Simulated update failure"), "update failure leaves the ordinary launcher usable");
			RecoveredMethod12(!recoveredType2.Window.IsVisible, "test never shows a window");
			recoveredType2.Window.Close();
			application2.Shutdown();
			Console.WriteLine("PASS: all three launch modes, correct app directory and arguments, elevation choices, per-user selection, cancelled/missing-runtime recovery and hidden WPF wiring. No runtime or game processes were started.");
			return 0;
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			return 1;
		}
		finally
		{
			string path = Path.Combine(text2, "twist.exe");
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			if (File.Exists(text3))
			{
				File.Delete(text3);
			}
			string directoryName = Path.GetDirectoryName(text3);
			if (Directory.Exists(directoryName))
			{
				Directory.Delete(directoryName);
			}
			if (Directory.Exists(text2))
			{
				Directory.Delete(text2);
			}
			if (Directory.Exists(text))
			{
				Directory.Delete(text);
			}
		}
	}

	[CompilerGenerated]
	private static void RecoveredMethod57(ProcessStartInfo P_0)
	{
		throw new Win32Exception(1223);
	}

	[CompilerGenerated]
	private static void RecoveredMethod59(ProcessStartInfo P_0)
	{
		throw new Win32Exception(1223);
	}

	[CompilerGenerated]
	private static Task<string> RecoveredMethod49(RecoveredType2 P_0, Action<int> P_1, CancellationToken P_2)
	{
		throw new IOException("Simulated update failure");
	}
}
