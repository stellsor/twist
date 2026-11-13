using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace A;

internal static class RecoveredType21
{
	[STAThread]
	private static int Main(string[] P_0)
	{
		try
		{
			if (P_0.Length == 2 && P_0[0] == "--apply-update")
			{
				RecoveredType26.RecoveredMethod73(P_0[1]);
				return 0;
			}
			if (P_0.Contains("--self-test"))
			{
				return RecoveredType22.RecoveredMethod58();
			}
			if (P_0.Contains("--update-check"))
			{
				RecoveredType2 recoveredType = RecoveredType3.RecoveredMethod4();
				Console.WriteLine(string.Concat("Latest stable twist: ", recoveredType.Version, "; installed: ", RecoveredType3.Installed, "; verified release digest available."));
				return 0;
			}
			RecoveredType26.RecoveredMethod76(AppDomain.CurrentDomain.BaseDirectory);
			Application application = new Application();
			application.ShutdownMode = ShutdownMode.OnMainWindowClose;
			Application application2 = application;
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "twist-rdp", "launcher-role.txt");
			RecoveredType13 recoveredType2 = new RecoveredType13(AppDomain.CurrentDomain.BaseDirectory, text, delegate(ProcessStartInfo startInfo)
			{
				if (Process.Start(startInfo) == null)
				{
					throw new Exception("Windows did not start twist.");
				}
			});
			if (P_0.Length == 2 && P_0[0] == "--preview")
			{
				recoveredType2.RecoveredMethod39(P_0[1]);
				return 0;
			}
			if (P_0.Length == 2 && P_0[0] == "--preview-update")
			{
				recoveredType2.RecoveredMethod2(new RecoveredType2
				{
					Version = "99.1.2",
					Bytes = 1L,
					Sha256 = new string('a', 64),
					DownloadUrl = "https://github.com/Stellsor/twist/releases/download/v99.1.2/twist-99.1.2-public.zip"
				});
				recoveredType2.RecoveredMethod39(P_0[1]);
				return 0;
			}
			application2.Run(recoveredType2.Window);
			return 0;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "twist launcher");
			return 1;
		}
	}

	[CompilerGenerated]
	private static void RecoveredMethod57(ProcessStartInfo P_0)
	{
		if (Process.Start(P_0) == null)
		{
			throw new Exception("Windows did not start twist.");
		}
	}
}
