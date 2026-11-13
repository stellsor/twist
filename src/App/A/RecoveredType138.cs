using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using B;
using a;
using b;

namespace A;

internal static class RecoveredType138
{
	[CompilerGenerated]
	private sealed class RecoveredType139
	{
		public RecoveredType308 mode;
	}

	[CompilerGenerated]
	private sealed class RecoveredType140
	{
		public RecoveredType139 CS_0024_003C_003E8__locals7;

		public RecoveredType86 journal;

		public RecoveredType350 diagnostics;

		public void RecoveredMethod521(object P_0, UnhandledExceptionEventArgs P_1)
		{
			diagnostics.RecoveredMethod844(P_1.ExceptionObject as Exception, "Unhandled runtime exception");
		}

		public void RecoveredMethod522(object P_0, UnobservedTaskExceptionEventArgs P_1)
		{
			journal.RecoveredMethod367(new RecoveredType82
			{
				Category = "Diagnostics",
				Level = "Warning",
				Source = CS_0024_003C_003E8__locals7.mode.ToString(),
				Message = "Background task reported an unobserved exception (not a confirmed crash): " + RecoveredType84.RecoveredMethod364(P_1.Exception.GetBaseException().Message)
			});
		}

		public void RecoveredMethod523(object P_0, DispatcherUnhandledExceptionEventArgs P_1)
		{
			diagnostics.RecoveredMethod844(P_1.Exception, "UI exception");
		}
	}

	[STAThread]
	private static int Main(string[] P_0)
	{
		try
		{
			if (P_0.Contains("--self-test"))
			{
				RecoveredType354.RecoveredMethod50();
				RecoveredType87.RecoveredMethod45();
				RecoveredType418.RecoveredMethod45();
				RecoveredType205.RecoveredMethod45();
				RecoveredType209.RecoveredMethod45();
				RecoveredType413.RecoveredMethod45();
				RecoveredType374.RecoveredMethod50();
				RecoveredType252.RecoveredMethod45();
				RecoveredType363.RecoveredMethod45();
				RecoveredType364.RecoveredMethod45();
				RecoveredType262.RecoveredMethod45();
				RecoveredType335.RecoveredMethod50();
				RecoveredType112.RecoveredMethod45();
				RecoveredType348.RecoveredMethod45();
				RecoveredType130.RecoveredMethod45();
				RecoveredType293.RecoveredMethod45();
				RecoveredType383.RecoveredMethod45();
				RecoveredType306.RecoveredMethod45();
				RecoveredType298.RecoveredMethod45();
				RecoveredType12.RecoveredMethod45();
				RecoveredType227.RecoveredMethod45();
				RecoveredType368.RecoveredMethod50();
				RecoveredType153.RecoveredMethod50();
				RecoveredType221.RecoveredMethod45();
				RecoveredType423.RecoveredMethod48(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "offsets.json")));
				return 0;
			}
			if (P_0.Length == 2 && P_0[0] == "--totals-preview")
			{
				RecoveredType16.RecoveredMethod169(P_0[1]);
				return 0;
			}
			if (P_0.Contains("--ui-self-test"))
			{
				RecoveredType16.RecoveredMethod169();
				return 0;
			}
			if (P_0.Contains("--offsets-check"))
			{
				Console.WriteLine(RecoveredType422.RecoveredMethod910(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "offsets.json"))));
				return 0;
			}
			if (P_0.Contains("--network-test"))
			{
				RecoveredType335.RecoveredMethod53();
				RecoveredType112.RecoveredMethod50();
				return 0;
			}
			if (P_0.Contains("--admin"))
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(Process.GetCurrentProcess().MainModule.FileName);
				processStartInfo.UseShellExecute = true;
				processStartInfo.Verb = "runas";
				processStartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
				Process.Start(processStartInfo);
				return 0;
			}
			RecoveredType308 mode = (P_0.Contains("--worker") ? RecoveredType308.Worker : (P_0.Contains("--local") ? RecoveredType308.Local : RecoveredType308.Controller));
			bool createdNew;
			using (new Mutex(initiallyOwned: true, "Local\\twist-" + ((mode == RecoveredType308.Controller) ? "controller" : "session-worker"), out createdNew))
			{
				if (!createdNew)
				{
					MessageBox.Show("twist is already open in this Windows session.", "twist");
					return 0;
				}
				RecoveredType309.RecoveredMethod778(mode);
				RecoveredType86 journal = new RecoveredType86(Path.Combine(RecoveredType309.Base, "logs"));
				RecoveredType350 diagnostics = new RecoveredType350(Path.Combine(RecoveredType309.Base, "logs"), mode.ToString(), journal);
				RecoveredType350.Current = diagnostics;
				AppDomain.CurrentDomain.UnhandledException += delegate(object obj2, UnhandledExceptionEventArgs e)
				{
					diagnostics.RecoveredMethod844(e.ExceptionObject as Exception, "Unhandled runtime exception");
				};
				TaskScheduler.UnobservedTaskException += delegate(object obj2, UnobservedTaskExceptionEventArgs e)
				{
					journal.RecoveredMethod367(new RecoveredType82
					{
						Category = "Diagnostics",
						Level = "Warning",
						Source = mode.ToString(),
						Message = "Background task reported an unobserved exception (not a confirmed crash): " + RecoveredType84.RecoveredMethod364(e.Exception.GetBaseException().Message)
					});
				};
				if (!P_0.Contains("--offsets-checked"))
				{
					RecoveredType422.RecoveredMethod910(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "offsets.json")));
				}
				else
				{
					RecoveredType422.LastStatus = "Startup offset check completed by launcher; selecting matching cached offsets.";
				}
				Application application = new Application();
				application.DispatcherUnhandledException += delegate(object obj2, DispatcherUnhandledExceptionEventArgs e)
				{
					diagnostics.RecoveredMethod844(e.Exception, "UI exception");
				};
				new RecoveredType16(mode).RecoveredMethod92();
				application.Run();
				journal.RecoveredMethod367(new RecoveredType82
				{
					Category = "Shutdown",
					Source = mode.ToString(),
					Message = "twist closed normally."
				});
				diagnostics.RecoveredMethod45();
				return 0;
			}
		}
		catch (Exception ex)
		{
			if (RecoveredType350.Current != null)
			{
				RecoveredType350.Current.RecoveredMethod844(ex, "Application failure");
			}
			else
			{
				try
				{
					File.WriteAllText(Path.Combine(RecoveredType309.Base, "startup-error.txt"), RecoveredType84.RecoveredMethod364(ex.ToString(), 30000));
				}
				catch
				{
				}
			}
			if (!P_0.Contains("--self-test") && !P_0.Contains("--network-test") && !P_0.Contains("--ui-self-test") && !P_0.Contains("--offsets-check") && !P_0.Contains("--totals-preview"))
			{
				MessageBox.Show(ex.Message, "twist");
			}
			return 1;
		}
	}
}
