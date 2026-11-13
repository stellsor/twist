using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Script.Serialization;
using A;
using a;

namespace B;

internal sealed class RecoveredType350
{
	private readonly RecoveredType86 journal;

	private readonly string file;

	private readonly string folder;

	private readonly RecoveredType349 marker;

	private readonly O<RecoveredType349> writer;

	private int failed;

	private long updated;

	public static RecoveredType350 Current;

	public Action EmergencyStop;

	public RecoveredType86 Journal => journal;

	public RecoveredType350(string P_0, string P_1, RecoveredType86 P_2)
	{
		journal = P_2;
		folder = P_0;
		Directory.CreateDirectory(P_0);
		RecoveredMethod842(P_0, P_2);
		using (Process process = Process.GetCurrentProcess())
		{
			marker = new RecoveredType349
			{
				Pid = process.Id,
				Created = process.StartTime.ToUniversalTime().Ticks,
				StartedUtc = DateTime.UtcNow.ToString("o"),
				Role = P_1,
				UpdatedUtc = DateTime.UtcNow.ToString("o")
			};
		}
		file = Path.Combine(P_0, "run-" + marker.Pid + "-" + marker.Created + ".running.json");
		writer = new O<RecoveredType349>(file, delegate
		{
		});
		RecoveredType351.RecoveredMethod82(file, new JavaScriptSerializer().Serialize(new RecoveredType349[1] { marker }));
	}

	internal static void RecoveredMethod842(string P_0, RecoveredType86 P_1)
	{
		string[] files = Directory.GetFiles(P_0, "*.running.json");
		foreach (string text in files)
		{
			try
			{
				RecoveredType349 recoveredType = new JavaScriptSerializer().Deserialize<RecoveredType349[]>(File.ReadAllText(text)).First();
				bool flag = false;
				try
				{
					using Process process = Process.GetProcessById(recoveredType.Pid);
					flag = process.StartTime.ToUniversalTime().Ticks == recoveredType.Created && !process.HasExited;
				}
				catch
				{
				}
				if (!flag)
				{
					string path = text.Replace(".running.json", ".crash.txt");
					string text2 = (File.Exists(path) ? File.ReadLines(path).FirstOrDefault() : "Unexpected exit. The process ended without a clean shutdown; the cause is unknown (for example, force-close, Windows restart, or a crash outside .NET).");
					P_1.RecoveredMethod367(new RecoveredType82
					{
						Id = "recovered-" + Path.GetFileNameWithoutExtension(text),
						Category = "Crash",
						Level = "Error",
						Source = (recoveredType.Role ?? "twist"),
						Message = RecoveredType84.RecoveredMethod364(text2 + " Last update: " + recoveredType.UpdatedUtc + ". Last state: " + string.Join(" | ", recoveredType.Sessions ?? new string[0]) + ". " + (File.Exists(path) ? ("Report: " + Path.GetFileName(path)) : ""))
					});
					P_1.Completion.GetAwaiter().GetResult();
					File.Delete(text);
				}
			}
			catch (Exception ex)
			{
				P_1.RecoveredMethod367(new RecoveredType82
				{
					Category = "Diagnostics",
					Level = "Warning",
					Message = "Could not read a previous run marker: " + RecoveredType84.RecoveredMethod364(ex.Message)
				});
			}
		}
	}

	public void RecoveredMethod843(RecoveredType174[] P_0)
	{
		long ticks = DateTime.UtcNow.Ticks;
		if (ticks - Interlocked.Read(ref updated) >= TimeSpan.FromSeconds(5.0).Ticks)
		{
			Interlocked.Exchange(ref updated, ticks);
			RecoveredType349 recoveredType = new RecoveredType349();
			recoveredType.Pid = marker.Pid;
			recoveredType.Created = marker.Created;
			recoveredType.StartedUtc = marker.StartedUtc;
			recoveredType.Role = marker.Role;
			recoveredType.UpdatedUtc = DateTime.UtcNow.ToString("o");
			recoveredType.Sessions = (from recoveredType3 in P_0.Take(32)
				select RecoveredType84.RecoveredMethod364(recoveredType3.Account + ": " + (recoveredType3.Running ? ("running · " + recoveredType3.Status) : ("stopped · " + (string.IsNullOrEmpty(recoveredType3.StopReason) ? recoveredType3.Status : recoveredType3.StopReason))), 300)).ToArray();
			RecoveredType349 recoveredType2 = recoveredType;
			writer.RecoveredMethod669(new RecoveredType349[1] { recoveredType2 });
		}
	}

	public string RecoveredMethod844(Exception P_0, string P_1)
	{
		if (Interlocked.Exchange(ref failed, 1) != 0)
		{
			return "";
		}
		string text = "twist crashed · " + P_1 + ": " + ((P_0 == null) ? "Unspecified runtime failure" : (P_0.GetType().Name + " · " + P_0.Message));
		try
		{
			if (EmergencyStop != null)
			{
				EmergencyStop();
			}
		}
		catch
		{
		}
		try
		{
			journal.RecoveredMethod367(new RecoveredType82
			{
				Category = "Crash",
				Level = "Error",
				Source = marker.Role,
				Message = RecoveredType84.RecoveredMethod364(text)
			});
			string text2 = file.Replace(".running.json", ".crash.txt");
			File.WriteAllText(text2, RecoveredType84.RecoveredMethod364(text) + Environment.NewLine + "Version: 0.7.29 · " + DateTime.UtcNow.ToString("o") + Environment.NewLine + RecoveredType84.RecoveredMethod364((P_0 == null) ? "" : P_0.ToString(), 30000) + Environment.NewLine + "Recent activity:" + Environment.NewLine + string.Join(Environment.NewLine, from recoveredType in journal.RecoveredMethod368().Take(60).Reverse()
				select recoveredType.AtUtc + " [" + recoveredType.Source + "] " + recoveredType.Account + " · " + recoveredType.Category + " · " + recoveredType.Message));
			return text2;
		}
		catch
		{
			return "";
		}
	}

	public void RecoveredMethod45()
	{
		writer.Completion.GetAwaiter().GetResult();
		journal.Completion.GetAwaiter().GetResult();
		if (Volatile.Read(ref failed) == 0 && File.Exists(file))
		{
			File.Delete(file);
		}
	}

	[CompilerGenerated]
	private static void RecoveredMethod48(string P_0)
	{
	}

	[CompilerGenerated]
	private static string RecoveredMethod97(RecoveredType174 P_0)
	{
		return RecoveredType84.RecoveredMethod364(P_0.Account + ": " + (P_0.Running ? ("running · " + P_0.Status) : ("stopped · " + (string.IsNullOrEmpty(P_0.StopReason) ? P_0.Status : P_0.StopReason))), 300);
	}

	[CompilerGenerated]
	private static string RecoveredMethod845(RecoveredType82 P_0)
	{
		return P_0.AtUtc + " [" + P_0.Source + "] " + P_0.Account + " · " + P_0.Category + " · " + P_0.Message;
	}
}
