using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using B;
using a;

namespace A;

internal static class RecoveredType87
{
	[CompilerGenerated]
	private sealed class RecoveredType88
	{
		public RecoveredType85 buffer;

		public void RecoveredMethod377(int P_0)
		{
			buffer.RecoveredMethod367(new RecoveredType82
			{
				Message = "Live " + P_0
			});
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Activity: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		string text = Path.Combine(Path.GetTempPath(), "twist-activity-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text);
		try
		{
			RecoveredType86 recoveredType = new RecoveredType86(text);
			RecoveredType82 recoveredType2 = new RecoveredType82();
			recoveredType2.Id = "one";
			recoveredType2.Account = "Demo";
			recoveredType2.UserId = "42";
			recoveredType2.Category = "Stopped";
			recoveredType2.Level = "Error";
			recoveredType2.Message = "Roblox exited or restarted.";
			RecoveredType82 recoveredType3 = recoveredType2;
			recoveredType.RecoveredMethod369(new RecoveredType82[2] { recoveredType3, recoveredType3 });
			recoveredType.Completion.GetAwaiter().GetResult();
			RecoveredMethod42(recoveredType.RecoveredMethod368().Length == 1, "deduplicate repeated telemetry");
			recoveredType3.Message = "mutated";
			RecoveredMethod42(recoveredType.RecoveredMethod368()[0].Message != "mutated", "detach source entries");
			RecoveredType86 recoveredType4 = new RecoveredType86(text);
			RecoveredMethod42(recoveredType4.RecoveredMethod368().Single().Message == "Roblox exited or restarted.", "persist reason across restart");
			recoveredType.RecoveredMethod369(from P_0 in Enumerable.Range(0, 5100)
				select new RecoveredType82
				{
					Id = "item-" + P_0,
					Message = "Event " + P_0,
					AtUtc = DateTime.UtcNow.AddSeconds(P_0).ToString("o")
				});
			recoveredType.Completion.GetAwaiter().GetResult();
			RecoveredMethod42(recoveredType.RecoveredMethod368().Length == 5000, "bounded history");
			RecoveredType85 buffer = new RecoveredType85();
			Parallel.For(0, 1000, delegate(int P_0)
			{
				buffer.RecoveredMethod367(new RecoveredType82
				{
					Message = "Live " + P_0
				});
			});
			RecoveredMethod42(buffer.RecoveredMethod368().Length == 128, "bounded concurrent session ring");
			RecoveredType85 recoveredType5 = new RecoveredType85();
			recoveredType5.RecoveredMethod367(new RecoveredType82
			{
				Level = "Warning",
				Message = "Supplies paused; retrying"
			});
			recoveredType5.RecoveredMethod367(new RecoveredType82
			{
				Level = "Warning",
				Message = "Supplies paused; retrying"
			});
			RecoveredMethod42(recoveredType5.RecoveredMethod368().Length == 1, "repeated retry coalescing");
			RecoveredMethod42(RecoveredType84.RecoveredMethod365("@Demo reel · player=0.3") == null && RecoveredType84.RecoveredMethod365("@Demo input · Moving to Yes") == null, "omit high-frequency pointer/reel diagnostics");
			string text2 = "https://discord.com/api/webhooks/123/token twist1:26744:" + new string('a', 64);
			RecoveredMethod42(!RecoveredType84.RecoveredMethod364(text2).Contains("token") && !RecoveredType84.RecoveredMethod364(text2).Contains(new string('a', 64)), "hide webhook URLs and pairing codes");
			RecoveredMethod42(RecoveredType83.RecoveredMethod363(true, "F9 stop", new OperationCanceledException(), null) == "F9 stop", "cancellation retains initiating reason");
			RecoveredMethod42(RecoveredType83.RecoveredMethod363(false, "", new Exception("Lost focus"), null) == "Lost focus", "fault retains original cause");
			RecoveredMethod42(RecoveredType83.RecoveredMethod363(false, "", null, "Round limit reached") == "Round limit reached", "session limit is distinct from failure");
			string text3 = Path.Combine(text, "diagnostics");
			RecoveredType86 recoveredType6 = new RecoveredType86(text3);
			RecoveredType350 recoveredType7 = new RecoveredType350(text3, "Worker", recoveredType6);
			recoveredType7.RecoveredMethod843(new RecoveredType174[1]
			{
				new RecoveredType174
				{
					Account = "Demo",
					Running = true,
					Status = "Storing Suke"
				}
			});
			RecoveredType350.RecoveredMethod842(text3, recoveredType6);
			RecoveredMethod42(!recoveredType6.RecoveredMethod368().Any((RecoveredType82 P_0) => P_0.Category == "Crash"), "live process marker is not a crash");
			recoveredType7.RecoveredMethod45();
			RecoveredMethod42(Directory.GetFiles(text3, "*.running.json").Length == 0, "normal shutdown removes marker");
			string path = Path.Combine(text3, "run-dead.running.json");
			File.WriteAllText(path, new JavaScriptSerializer().Serialize(new RecoveredType349[1]
			{
				new RecoveredType349
				{
					Pid = int.MaxValue,
					Created = 1L,
					Role = "Worker",
					UpdatedUtc = DateTime.UtcNow.ToString("o"),
					Sessions = new string[1] { "Demo: running · Storing Suke" }
				}
			}));
			RecoveredType350.RecoveredMethod842(text3, recoveredType6);
			RecoveredMethod42(recoveredType6.RecoveredMethod368().Any((RecoveredType82 P_0) => P_0.Category == "Crash" && P_0.Message.Contains("cause is unknown") && P_0.Message.Contains("Storing Suke")), "unclean exit reports last state without inventing cause");
			RecoveredType350 recoveredType8 = new RecoveredType350(text3, "Local", recoveredType6);
			string path2 = recoveredType8.RecoveredMethod844(new InvalidOperationException("Synthetic test exception"), "UI exception");
			RecoveredMethod42(File.Exists(path2) && File.ReadAllText(path2).Contains("InvalidOperationException") && recoveredType6.RecoveredMethod368().Any((RecoveredType82 P_0) => P_0.Message.Contains("Synthetic test exception")), "captured exception has durable local report");
			recoveredType8.RecoveredMethod45();
			recoveredType6.Completion.GetAwaiter().GetResult();
			RecoveredMethod42(Directory.GetFiles(text3, "*.running.json").Length == 1, "failed run retains recovery marker");
			Console.WriteLine("PASS: activity persistence, bounds, redaction, stop reasons, live/clean/unclean/crashed process diagnostics. No game input.");
		}
		finally
		{
			Directory.Delete(text, recursive: true);
		}
	}

	[CompilerGenerated]
	private static RecoveredType82 RecoveredMethod375(int P_0)
	{
		return new RecoveredType82
		{
			Id = "item-" + P_0,
			Message = "Event " + P_0,
			AtUtc = DateTime.UtcNow.AddSeconds(P_0).ToString("o")
		};
	}

	[CompilerGenerated]
	private static bool RecoveredMethod182(RecoveredType82 P_0)
	{
		return P_0.Category == "Crash";
	}

	[CompilerGenerated]
	private static bool RecoveredMethod342(RecoveredType82 P_0)
	{
		if (P_0.Category == "Crash" && P_0.Message.Contains("cause is unknown"))
		{
			return P_0.Message.Contains("Storing Suke");
		}
		return false;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod376(RecoveredType82 P_0)
	{
		return P_0.Message.Contains("Synthetic test exception");
	}
}
