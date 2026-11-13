using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using A;
using TwistApp;

namespace a;

internal static class RecoveredType153
{
	private sealed class RecoveredType154 : RecoveredType89
	{
		private readonly object gate = new object();

		public List<string> Payloads = new List<string>();

		public Queue<RecoveredType145> Results = new Queue<RecoveredType145>();

		public int Count
		{
			get
			{
				lock (gate)
				{
					return Payloads.Count;
				}
			}
		}

		public RecoveredType145 RecoveredMethod378(Uri P_0, string P_1, CancellationToken P_2)
		{
			P_2.ThrowIfCancellationRequested();
			RecoveredMethod42(P_0.Query.Contains("wait=true"), "Wait for server confirmation");
			lock (gate)
			{
				Payloads.Add(P_1);
				RecoveredType145 result;
				if (Results.Count <= 0)
				{
					RecoveredType145 recoveredType = new RecoveredType145();
					recoveredType.Status = 200;
					result = recoveredType;
				}
				else
				{
					result = Results.Dequeue();
				}
				return result;
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType155
	{
		public RecoveredType154 transport;

		public List<int> delays;

		public RecoveredType154 rate;

		public RecoveredType154 uncertain;

		public RecoveredType154 crashed;

		public RecoveredType154 test;

		public Task RecoveredMethod193(int P_0, CancellationToken P_1)
		{
			lock (delays)
			{
				delays.Add(P_0);
			}
			return Task.FromResult(0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType156
	{
		public RecoveredType155 CS_0024_003C_003E8__locals4a;

		public RecoveredType150 alerts;

		public bool RecoveredMethod387()
		{
			if (alerts.Status.Contains("delivered"))
			{
				return CS_0024_003C_003E8__locals4a.transport.Count == 1;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType157
	{
		public RecoveredType155 CS_0024_003C_003E8__locals4a;

		public RecoveredType150 alerts;

		public bool RecoveredMethod387()
		{
			if (CS_0024_003C_003E8__locals4a.rate.Count == 2)
			{
				return alerts.Status.Contains("delivered");
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType158
	{
		public RecoveredType155 CS_0024_003C_003E8__locals4a;

		public RecoveredType150 alerts;

		public bool RecoveredMethod387()
		{
			return alerts.Status.Contains("uncertain");
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType159
	{
		public RecoveredType155 CS_0024_003C_003E8__locals4a;

		public RecoveredType150 alerts;

		public bool RecoveredMethod387()
		{
			if (CS_0024_003C_003E8__locals4a.uncertain.Count == 2)
			{
				return alerts.Status.Contains("delivered");
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType160
	{
		public RecoveredType155 CS_0024_003C_003E8__locals4a;

		public RecoveredType150 alerts;

		public bool RecoveredMethod387()
		{
			if (CS_0024_003C_003E8__locals4a.crashed.Count == 1)
			{
				return alerts.Status.Contains("delivered");
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType161
	{
		public RecoveredType155 CS_0024_003C_003E8__locals4a;

		public RecoveredType150 alerts;

		public bool RecoveredMethod387()
		{
			return alerts.Status.Contains("HTTP 404");
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType162
	{
		public RecoveredType155 CS_0024_003C_003E8__locals4a;

		public RecoveredType150 alerts;

		public bool RecoveredMethod387()
		{
			if (CS_0024_003C_003E8__locals4a.test.Count == 1)
			{
				return alerts.Status.Contains("delivered");
			}
			return false;
		}
	}

	private const string FakeUrl = "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890";

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Discord test: " + P_1);
		}
	}

	private static void RecoveredMethod539(Func<bool> P_0, string P_1)
	{
		DateTime dateTime = DateTime.UtcNow.AddSeconds(5.0);
		while (DateTime.UtcNow < dateTime)
		{
			if (P_0())
			{
				return;
			}
			Thread.Sleep(10);
		}
		throw new Exception("Discord test timed out: " + P_1);
	}

	private static FruitStoredRecord RecoveredMethod540(string P_0, string P_1 = "Hie", string P_2 = "Legendary")
	{
		FruitStoredRecord fruitStoredRecord = new FruitStoredRecord();
		fruitStoredRecord.Id = P_0;
		fruitStoredRecord.Name = P_1;
		fruitStoredRecord.Rarity = P_2;
		fruitStoredRecord.Account = "tester";
		fruitStoredRecord.UserId = "42";
		fruitStoredRecord.AtUtc = DateTime.UtcNow.ToString("o");
		fruitStoredRecord.FishCaught = 147;
		fruitStoredRecord.Seconds = 5025.0;
		fruitStoredRecord.Common = 79;
		fruitStoredRecord.Rare = 5;
		fruitStoredRecord.Legendary = 0;
		return fruitStoredRecord;
	}

	private static string RecoveredMethod381(string P_0)
	{
		return (string)new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(P_0)["content"];
	}

	private static RecoveredType141 RecoveredMethod524()
	{
		RecoveredType141 recoveredType = new RecoveredType141();
		recoveredType.Enabled = true;
		recoveredType.Url = "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890";
		recoveredType.PingMythical = true;
		recoveredType.PingKind = "User";
		recoveredType.PingId = "123456789012345678";
		return recoveredType;
	}

	public static void RecoveredMethod50()
	{
		RecoveredMethod42(AssetFiles.RecoveredMethod741("https://assetdelivery.roblox.com/v1/asset/?id=12783858892") == "12783858892" && AssetFiles.RecoveredMethod741("https://assetdelivery.roblox.com.evil.test/v1/asset/?id=1") == "", "Fruit preview assetdelivery URLs resolve only their numeric asset IDs");
		RecoveredMethod42(!new JavaScriptSerializer().Serialize(new RecoveredType148
		{
			Test = true,
			TestUrl = "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890"
		}).Contains("abcdefghijklmnopqrstuvwxyz"), "A one-off test URL is never serialized into the outbox");
		RecoveredType141 recoveredType = RecoveredMethod524();
		string text = RecoveredType144.RecoveredMethod529(RecoveredMethod540("hie"), recoveredType);
		RecoveredMethod42(text.Contains("Hie was stored successfully") && text.Contains("147") && text.Contains("01:23:45") && text.Contains("79") && text.Contains("84 total"), "Stored message carries account catch/time/current bait statistics");
		RecoveredMethod42(!RecoveredMethod381(text).Contains("<@") && text.Contains("\"parse\":[]"), "Non-mythical fruit never pings");
		FruitStoredRecord fruitStoredRecord = RecoveredMethod540("ope", "Ope", "Mythical");
		text = RecoveredType144.RecoveredMethod529(fruitStoredRecord, recoveredType);
		RecoveredMethod42(RecoveredMethod381(text).Contains("<@123456789012345678>") && text.Contains("\"users\":[\"123456789012345678\"]"), "Mythical user ping allows only the selected ID");
		recoveredType.PingId = "demo.username";
		text = RecoveredType144.RecoveredMethod529(fruitStoredRecord, recoveredType);
		RecoveredMethod42(RecoveredMethod381(text).Contains("@demo.username") && text.Contains("\"parse\":[]") && !text.Contains("\"users\":"), "Username target is included as text without rejecting the notification");
		recoveredType.PingId = "<@123456789012345678>";
		text = RecoveredType144.RecoveredMethod529(fruitStoredRecord, recoveredType);
		RecoveredMethod42(RecoveredMethod381(text).Contains("<@123456789012345678>") && text.Contains("\"users\":[\"123456789012345678\"]"), "Pasted mention resolves to its numeric ID");
		recoveredType.PingId = "123456789012345678";
		recoveredType.PingKind = "Role";
		text = RecoveredType144.RecoveredMethod529(fruitStoredRecord, recoveredType);
		RecoveredMethod42(RecoveredMethod381(text).Contains("<@&123456789012345678>") && text.Contains("\"roles\""), "Role mention uses an explicit allowlist");
		recoveredType.PingKind = "Everyone";
		text = RecoveredType144.RecoveredMethod529(fruitStoredRecord, recoveredType);
		RecoveredMethod42(text.Contains("@everyone") && text.Contains("\"parse\":[\"everyone\"]"), "Everyone ping requires explicit selection");
		RecoveredMethod42(!RecoveredType144.RecoveredMethod529(fruitStoredRecord, recoveredType, true).Contains("@everyone"), "Test notifications never ping");
		recoveredType.PingMythical = false;
		RecoveredMethod42(!RecoveredType144.RecoveredMethod529(fruitStoredRecord, recoveredType).Contains("@everyone"), "Disabled pings cannot mention everyone");
		FruitStoredRecord fruitStoredRecord2 = RecoveredMethod540("bad", "@everyone <@123456789012345678>", "Unknown");
		RecoveredMethod42(!RecoveredType144.RecoveredMethod529(fruitStoredRecord2, RecoveredMethod524()).Contains("@everyone"), "Fruit/account text cannot inject extra mentions");
		string[] array = new string[6]
		{
			"http://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz",
			"https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890".Replace("discord.com", "discord.com.evil.test"),
			"https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890".Replace("discord.com", "127.0.0.1"),
			"https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890?redirect=https://example.com",
			"https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890#secret",
			"https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890".Replace("https://", "https://user:pass@")
		};
		foreach (string recoveredField in array)
		{
			bool flag = false;
			try
			{
				RecoveredType141 recoveredType2 = new RecoveredType141();
				recoveredType2.Url = recoveredField;
				recoveredType2.RecoveredMethod50();
			}
			catch (Exception ex)
			{
				flag = true;
				RecoveredMethod42(!ex.Message.Contains("abcdefghijklmnopqrstuvwxyz"), "Validation errors do not expose webhook tokens");
			}
			RecoveredMethod42(flag, "Unsupported webhook endpoint rejected");
		}
		RecoveredType141 recoveredType3 = new RecoveredType141();
		recoveredType3.Url = "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890?thread_id=123456789012345678&wait=false";
		RecoveredMethod42(recoveredType3.RecoveredMethod526().Query.Contains("wait=true"), "Optional thread target preserves confirmation mode");
		string text2 = Path.Combine(Path.GetTempPath(), "twist-discord-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text2);
		try
		{
			string text3 = Path.Combine(text2, "settings.json");
			RecoveredType143.RecoveredMethod527(text3, RecoveredMethod524());
			RecoveredMethod42(!File.ReadAllText(text3).Contains("abcdefghijklmnopqrstuvwxyz") && RecoveredType143.RecoveredMethod528(text3).Url == "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890", "Webhook token is encrypted for the current Windows user");
			RecoveredType154 transport = new RecoveredType154();
			List<int> delays = new List<int>();
			string text4 = Path.Combine(text2, "one");
			RecoveredType150 alerts = new RecoveredType150(text4, delegate
			{
			}, transport, (int P_0, CancellationToken P_1) => Task.FromResult(0), DateTime.MinValue);
			try
			{
				FruitStoredRecord fruitStoredRecord3 = RecoveredMethod540("existing");
				alerts.RecoveredMethod533(new FruitStoredRecord[1] { fruitStoredRecord3 }, (FruitStoredRecord P_0) => P_0.Rarity);
				alerts.RecoveredMethod532(RecoveredMethod524());
				alerts.RecoveredMethod533(new FruitStoredRecord[1] { fruitStoredRecord3 }, (FruitStoredRecord P_0) => P_0.Rarity);
				RecoveredMethod42(transport.Count == 0, "Existing/disabled events are not replayed on enabling alerts");
				FruitStoredRecord fruitStoredRecord4 = RecoveredMethod540("new");
				alerts.RecoveredMethod533(new FruitStoredRecord[2] { fruitStoredRecord4, fruitStoredRecord4 }, (FruitStoredRecord P_0) => P_0.Rarity);
				RecoveredMethod539(() => alerts.Status.Contains("delivered") && transport.Count == 1, "Confirmed storage delivery");
				alerts.RecoveredMethod533(new FruitStoredRecord[1] { fruitStoredRecord4 }, (FruitStoredRecord P_0) => P_0.Rarity);
				RecoveredMethod42(transport.Count == 1, "Repeated worker snapshots never notify twice");
			}
			finally
			{
				if (alerts != null)
				{
					((IDisposable)alerts).Dispose();
				}
			}
			using (RecoveredType150 recoveredType4 = new RecoveredType150(text4, delegate
			{
			}, transport, (int P_0, CancellationToken P_1) => Task.FromResult(0), DateTime.MinValue))
			{
				recoveredType4.RecoveredMethod533(new FruitStoredRecord[1] { RecoveredMethod540("new") }, (FruitStoredRecord P_0) => P_0.Rarity);
				RecoveredMethod42(transport.Count == 1, "Seen event IDs persist across controller restart");
			}
			RecoveredType154 rate = new RecoveredType154();
			rate.Results.Enqueue(new RecoveredType145
			{
				Status = 429,
				RetryAfterMs = 1700
			});
			rate.Results.Enqueue(new RecoveredType145
			{
				Status = 200
			});
			RecoveredType150 alerts2 = new RecoveredType150(Path.Combine(text2, "rate"), delegate
			{
			}, rate, delegate(int P_0, CancellationToken P_1)
			{
				lock (delays)
				{
					delays.Add(P_0);
				}
				return Task.FromResult(0);
			}, DateTime.MinValue);
			try
			{
				alerts2.RecoveredMethod532(RecoveredMethod524());
				alerts2.RecoveredMethod533(new FruitStoredRecord[1] { RecoveredMethod540("limited") }, (FruitStoredRecord P_0) => P_0.Rarity);
				RecoveredMethod539(() => rate.Count == 2 && alerts2.Status.Contains("delivered"), "Retry after rate limit");
				RecoveredMethod42(delays.Contains(1700), "429 respects Discord retry_after rather than a hard-coded resend interval");
			}
			finally
			{
				if (alerts2 != null)
				{
					((IDisposable)alerts2).Dispose();
				}
			}
			RecoveredType154 uncertain = new RecoveredType154();
			uncertain.Results.Enqueue(new RecoveredType145
			{
				Status = 0
			});
			string text5 = Path.Combine(text2, "uncertain");
			RecoveredType150 alerts3 = new RecoveredType150(text5, delegate
			{
			}, uncertain, (int P_0, CancellationToken P_1) => Task.FromResult(0), DateTime.MinValue);
			try
			{
				alerts3.RecoveredMethod532(RecoveredMethod524());
				alerts3.RecoveredMethod533(new FruitStoredRecord[1] { RecoveredMethod540("uncertain") }, (FruitStoredRecord P_0) => P_0.Rarity);
				RecoveredMethod539(() => alerts3.Status.Contains("uncertain"), "Ambiguous network result pauses delivery");
				RecoveredMethod42(uncertain.Count == 1, "Uncertain delivery cannot automatically duplicate a ping");
			}
			finally
			{
				if (alerts3 != null)
				{
					((IDisposable)alerts3).Dispose();
				}
			}
			RecoveredType150 alerts4 = new RecoveredType150(text5, delegate
			{
			}, uncertain, (int P_0, CancellationToken P_1) => Task.FromResult(0), DateTime.MinValue);
			try
			{
				RecoveredMethod42(uncertain.Count == 1, "Restart retains uncertain-delivery pause");
				alerts4.RecoveredMethod50();
				RecoveredMethod539(() => uncertain.Count == 2 && alerts4.Status.Contains("delivered"), "Explicit retry recovers pending delivery");
			}
			finally
			{
				if (alerts4 != null)
				{
					((IDisposable)alerts4).Dispose();
				}
			}
			RecoveredType154 crashed = new RecoveredType154();
			string text6 = Path.Combine(text2, "crashed");
			Directory.CreateDirectory(text6);
			RecoveredType143.RecoveredMethod527(Path.Combine(text6, "discord-settings.json"), RecoveredMethod524());
			File.WriteAllText(Path.Combine(text6, "fruit-alerts.json"), new JavaScriptSerializer().Serialize(new RecoveredType149
			{
				Seen = new List<string> { "crashed" },
				Jobs = new List<RecoveredType148>
				{
					new RecoveredType148
					{
						Fruit = RecoveredMethod540("crashed"),
						InFlight = true
					}
				}
			}));
			RecoveredType150 alerts5 = new RecoveredType150(text6, delegate
			{
			}, crashed, (int P_0, CancellationToken P_1) => Task.FromResult(0), DateTime.MinValue);
			try
			{
				RecoveredMethod42(crashed.Count == 0 && alerts5.Status.Contains("paused"), "An interrupted in-flight delivery is not resent automatically on restart");
				alerts5.RecoveredMethod50();
				RecoveredMethod539(() => crashed.Count == 1 && alerts5.Status.Contains("delivered"), "Explicit retry recovers an interrupted delivery");
			}
			finally
			{
				if (alerts5 != null)
				{
					((IDisposable)alerts5).Dispose();
				}
			}
			RecoveredType154 recoveredType5 = new RecoveredType154();
			recoveredType5.Results.Enqueue(new RecoveredType145
			{
				Status = 404
			});
			RecoveredType150 alerts6 = new RecoveredType150(Path.Combine(text2, "rejected"), delegate
			{
			}, recoveredType5, (int P_0, CancellationToken P_1) => Task.FromResult(0), DateTime.MinValue);
			try
			{
				alerts6.RecoveredMethod532(RecoveredMethod524());
				alerts6.RecoveredMethod533(new FruitStoredRecord[1] { RecoveredMethod540("rejected") }, (FruitStoredRecord P_0) => P_0.Rarity);
				RecoveredMethod539(() => alerts6.Status.Contains("HTTP 404"), "Invalid webhook pauses instead of looping");
				RecoveredMethod42(recoveredType5.Count == 1, "Rejected webhook is not repeatedly sent");
			}
			finally
			{
				if (alerts6 != null)
				{
					((IDisposable)alerts6).Dispose();
				}
			}
			RecoveredType154 test = new RecoveredType154();
			RecoveredType150 alerts7 = new RecoveredType150(Path.Combine(text2, "test"), delegate
			{
			}, test, (int P_0, CancellationToken P_1) => Task.FromResult(0), DateTime.MinValue);
			try
			{
				alerts7.RecoveredMethod532(RecoveredMethod524());
				alerts7.RecoveredMethod414();
				RecoveredMethod539(() => test.Count == 1 && alerts7.Status.Contains("delivered"), "Test message delivery");
				RecoveredMethod42(!RecoveredMethod381(test.Payloads[0]).Contains("<@"), "Actual queued test has no ping");
			}
			finally
			{
				if (alerts7 != null)
				{
					((IDisposable)alerts7).Dispose();
				}
			}
		}
		finally
		{
			string[] files = Directory.GetFiles(text2, "*", SearchOption.AllDirectories);
			foreach (string path in files)
			{
				File.Delete(path);
			}
			foreach (string item in from P_0 in Directory.GetDirectories(text2, "*", SearchOption.AllDirectories)
				orderby P_0.Length descending
				select P_0)
			{
				Directory.Delete(item);
			}
			Directory.Delete(text2);
		}
		array = "Tori Mochi Ope Venom Buddha Pteranodon Ptero Dragon Soul Leopard".Split(' ');
		foreach (string text7 in array)
		{
			RecoveredMethod42(RecoveredType219.RecoveredMethod52(text7) == "Mythical", "Mythical catalog includes " + text7);
		}
		int num;
		if (RecoveredType219.RecoveredMethod52("Ope") == "Mythical" && RecoveredType219.RecoveredMethod52("Hie") == "Legendary" && RecoveredType219.RecoveredMethod52("Bomb") == "Rare")
		{
			ItemMetadata itemMetadata = new ItemMetadata();
			itemMetadata.Name = "Fruit Bag";
			if (!itemMetadata.IsFruit)
			{
				ItemMetadata itemMetadata2 = new ItemMetadata();
				itemMetadata2.Name = "Legendary Fruit Chest";
				num = ((!itemMetadata2.IsFruit) ? 1 : 0);
				goto IL_1048;
			}
		}
		num = 0;
		goto IL_1048;
		IL_1048:
		RecoveredMethod42((byte)num != 0, "Exact fruit classification excludes fruit equipment and chests");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: Discord payload/runtime statistics, mythical-only explicit user/role/everyone mentions, test/no-ping behavior, mention injection suppression, HTTPS webhook allowlist, encrypted token storage, event replay deduplication, persisted outbox, rate-limit delay, uncertain-delivery pause/retry and rejected endpoint pause. HTTP mocked; no Discord messages sent.\r\n");
	}

	[CompilerGenerated]
	private static void RecoveredMethod414(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod193(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static string RecoveredMethod189(FruitStoredRecord P_0)
	{
		return P_0.Rarity;
	}

	[CompilerGenerated]
	private static string RecoveredMethod541(FruitStoredRecord P_0)
	{
		return P_0.Rarity;
	}

	[CompilerGenerated]
	private static string RecoveredMethod542(FruitStoredRecord P_0)
	{
		return P_0.Rarity;
	}

	[CompilerGenerated]
	private static string RecoveredMethod543(FruitStoredRecord P_0)
	{
		return P_0.Rarity;
	}

	[CompilerGenerated]
	private static void RecoveredMethod422(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod313(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static string RecoveredMethod544(FruitStoredRecord P_0)
	{
		return P_0.Rarity;
	}

	[CompilerGenerated]
	private static void RecoveredMethod424(string P_0)
	{
	}

	[CompilerGenerated]
	private static string RecoveredMethod545(FruitStoredRecord P_0)
	{
		return P_0.Rarity;
	}

	[CompilerGenerated]
	private static void RecoveredMethod84(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod546(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static string RecoveredMethod547(FruitStoredRecord P_0)
	{
		return P_0.Rarity;
	}

	[CompilerGenerated]
	private static void RecoveredMethod93(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod548(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static void RecoveredMethod99(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod549(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static void RecoveredMethod428(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod550(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static string RecoveredMethod551(FruitStoredRecord P_0)
	{
		return P_0.Rarity;
	}

	[CompilerGenerated]
	private static void RecoveredMethod431(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod552(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static int RecoveredMethod553(string P_0)
	{
		return P_0.Length;
	}
}
