using System;
using System.IO;
using TwistApp;
using a;

namespace B;

internal static class RecoveredType364
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
		RecoveredType170 recoveredType = new RecoveredType170();
		recoveredType.StopAfterRounds = 3;
		recoveredType.StopAfterMinutes = 2.0;
		RecoveredType170 recoveredType2 = recoveredType;
		recoveredType2.RecoveredMethod50();
		RecoveredMethod42(RecoveredType358.RecoveredMethod847(recoveredType2, 150.0, 0, true) == null, "Time limit waits for the current round");
		RecoveredMethod42(RecoveredType358.RecoveredMethod847(recoveredType2, 150.0, 0, false) == "Time limit reached", "Time limit stops when between rounds");
		RecoveredMethod42(RecoveredType358.RecoveredMethod847(recoveredType2, 0.0, 3, false) == "Round goal reached", "Full-round limit stops the run");
		RecoveredMethod42(RecoveredType358.RecoveredMethod847(new RecoveredType170(), 99999.0, 99999, false) == null, "Default limits leave fishing unchanged");
		bool flag = false;
		try
		{
			RecoveredType170 recoveredType3 = new RecoveredType170();
			recoveredType3.StopAfterRounds = -1;
			recoveredType3.RecoveredMethod50();
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag, "Invalid session limit rejected");
		string text = Path.Combine(Path.GetTempPath(), "twist-test-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text);
		try
		{
			RecoveredType360 recoveredType4 = new RecoveredType360(text);
			RoundRecord roundRecord = new RoundRecord();
			roundRecord.Id = "a";
			roundRecord.Account = "=1+1";
			roundRecord.UserId = "123";
			roundRecord.AtUtc = "2026-10-25T06:00:00.0000000Z";
			roundRecord.Seconds = 8.0;
			roundRecord.Contact = 0.9;
			roundRecord.Peak = 1.0;
			roundRecord.Full = true;
			RoundRecord roundRecord2 = roundRecord;
			RoundRecord roundRecord3 = new RoundRecord();
			roundRecord3.Id = "b";
			roundRecord3.Account = "other";
			roundRecord3.UserId = "456";
			roundRecord3.AtUtc = "2026-10-25T06:01:00.0000000Z";
			roundRecord3.Seconds = 10.0;
			roundRecord3.Contact = 0.5;
			roundRecord3.Peak = 0.6;
			roundRecord3.Full = false;
			RoundRecord roundRecord4 = roundRecord3;
			RecoveredMethod42(recoveredType4.RecoveredMethod724(new RoundRecord[2] { roundRecord2, roundRecord4 }), "New rounds persisted");
			RecoveredMethod42(!recoveredType4.RecoveredMethod724(new RoundRecord[1] { roundRecord2 }), "Duplicate round excluded");
			RecoveredMethod42(recoveredType4.RecoveredMethod848("123").Length == 1, "Account histories remain separate");
			recoveredType4.Completion.GetAwaiter().GetResult();
			RecoveredType360 recoveredType5 = new RecoveredType360(text);
			RecoveredMethod42(recoveredType5.RecoveredMethod848("").Length == 2, "History survives restart");
			string text2 = Path.Combine(text, "export.csv");
			recoveredType5.RecoveredMethod82(text2, "123");
			string text3 = File.ReadAllText(text2);
			RecoveredMethod42(text3.Contains("'=1+1") && !text3.Contains("other"), "CSV export filters accounts and escapes formula-like values");
		}
		finally
		{
			string[] array = new string[4] { "rounds.json", "rounds.json.bak", "rounds.json.tmp", "export.csv" };
			foreach (string path in array)
			{
				string path2 = Path.Combine(text, path);
				if (File.Exists(path2))
				{
					File.Delete(path2);
				}
			}
			Directory.Delete(text);
		}
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: optional run limits including finish-current-round behavior; default unlimited operation; durable account-filtered history; round de-duplication; CSV export; formula escaping.\r\n");
	}
}
