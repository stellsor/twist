using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TwistApp;
using a;
using b;
using c;

namespace A;

internal sealed class RecoveredType150 : IDisposable
{
	[CompilerGenerated]
	private sealed class RecoveredType152
	{
		public DateTime at;

		public string key;

		public bool RecoveredMethod538(RecoveredType400 P_0)
		{
			if (P_0.Key == key)
			{
				return Math.Abs((at - P_0.At).TotalSeconds) <= 120.0;
			}
			return false;
		}
	}

	private readonly object gate = new object();

	private readonly string settingsFile;

	private readonly string outboxFile;

	private readonly RecoveredType89 transport;

	private readonly Action<string> log;

	private readonly Func<int, CancellationToken, Task> delay;

	private readonly CancellationTokenSource stop = new CancellationTokenSource();

	private readonly DateTime opened;

	private RecoveredType149 box;

	private readonly HashSet<string> seen;

	private RecoveredType141 config;

	private bool running;

	private bool closed;

	private string status = "Notifications are off.";

	public RecoveredType141 Settings
	{
		get
		{
			lock (gate)
			{
				return config.RecoveredMethod524();
			}
		}
	}

	public string Status
	{
		get
		{
			lock (gate)
			{
				return status + ((box.Jobs.Count > 0) ? (" · " + box.Jobs.Count + " pending") : "");
			}
		}
	}

	public RecoveredType150(string P_0, Action<string> P_1, RecoveredType89 P_2 = null, Func<int, CancellationToken, Task> P_3 = null, DateTime? P_4 = null)
	{
		Directory.CreateDirectory(P_0);
		settingsFile = Path.Combine(P_0, "discord-settings.json");
		outboxFile = Path.Combine(P_0, "fruit-alerts.json");
		log = P_1;
		transport = P_2 ?? new RecoveredType146();
		delay = P_3 ?? ((Func<int, CancellationToken, Task>)((int millisecondsDelay, CancellationToken cancellationToken) => Task.Delay(millisecondsDelay, cancellationToken)));
		opened = P_4 ?? DateTime.UtcNow;
		try
		{
			config = RecoveredType143.RecoveredMethod528(settingsFile);
		}
		catch
		{
			config = new RecoveredType141();
			status = "Saved Discord settings could not be read; enter them again.";
		}
		try
		{
			box = (File.Exists(outboxFile) ? new JavaScriptSerializer
			{
				MaxJsonLength = 8000000
			}.Deserialize<RecoveredType149>(File.ReadAllText(outboxFile)) : new RecoveredType149());
			if (box == null || box.Jobs == null || box.Seen == null)
			{
				throw new Exception();
			}
		}
		catch
		{
			box = new RecoveredType149();
			status = "Discord delivery history could not be read.";
		}
		if (box.WorldReceipts == null)
		{
			box.WorldReceipts = new List<RecoveredType400>();
		}
		seen = new HashSet<string>(box.Seen, StringComparer.Ordinal);
		foreach (RecoveredType148 job in box.Jobs)
		{
			if (job.InFlight)
			{
				job.InFlight = false;
				job.Uncertain = (job.Paused = true);
			}
		}
		if (box.Jobs.Any((RecoveredType148 recoveredType) => recoveredType.Paused))
		{
			status = "Delivery is paused; use Retry pending after checking Discord.";
		}
		else if (config.Enabled || (config.SpawnEnabled && config.Url != ""))
		{
			status = "Waiting for fruit alerts.";
		}
		RecoveredMethod51();
	}

	private void RecoveredMethod48(string P_0)
	{
		try
		{
			log(P_0);
		}
		catch
		{
		}
	}

	private bool RecoveredMethod387()
	{
		try
		{
			string text = outboxFile + ".tmp";
			File.WriteAllText(text, new JavaScriptSerializer
			{
				MaxJsonLength = 8000000
			}.Serialize(box));
			if (File.Exists(outboxFile))
			{
				File.Replace(text, outboxFile, outboxFile + ".bak");
			}
			else
			{
				File.Move(text, outboxFile);
			}
			return true;
		}
		catch
		{
			status = "Discord delivery state could not be saved.";
			return false;
		}
	}

	public void RecoveredMethod532(RecoveredType141 P_0)
	{
		P_0.RecoveredMethod50();
		RecoveredType143.RecoveredMethod527(settingsFile, P_0);
		lock (gate)
		{
			config = P_0.RecoveredMethod524();
			foreach (RecoveredType148 job in box.Jobs)
			{
				if (!job.Uncertain)
				{
					job.Paused = false;
				}
			}
			status = ((P_0.Enabled || (P_0.SpawnEnabled && P_0.Url != "")) ? "Waiting for fruit alerts." : "Notifications are off.");
		}
		RecoveredMethod51();
	}

	public void RecoveredMethod533(IEnumerable<FruitStoredRecord> P_0, Func<FruitStoredRecord, string> P_1)
	{
		bool flag = false;
		lock (gate)
		{
			foreach (FruitStoredRecord item in P_0)
			{
				if (item == null || string.IsNullOrEmpty(item.Id) || item.Id.Length > 100 || string.IsNullOrWhiteSpace(item.Name) || item.Name.Length > 120 || item.FishCaught < 0 || double.IsNaN(item.Seconds) || double.IsInfinity(item.Seconds) || item.Seconds < 0.0 || !DateTime.TryParse(item.AtUtc, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result) || seen.Contains(item.Id))
				{
					continue;
				}
				if (config.Enabled && result.ToUniversalTime() >= opened && box.Jobs.Count >= 200)
				{
					status = "Discord queue is full; waiting to queue the next storage event.";
					continue;
				}
				seen.Add(item.Id);
				box.Seen.Add(item.Id);
				flag = true;
				if (config.Enabled && !(result.ToUniversalTime() < opened) && box.Jobs.Count < 200)
				{
					string rarity = P_1(item);
					FruitStoredRecord fruitStoredRecord = new FruitStoredRecord();
					fruitStoredRecord.Id = item.Id;
					fruitStoredRecord.Name = item.Name;
					fruitStoredRecord.UserId = item.UserId;
					fruitStoredRecord.Account = item.Account;
					fruitStoredRecord.Rarity = rarity;
					fruitStoredRecord.AtUtc = item.AtUtc;
					fruitStoredRecord.FishCaught = item.FishCaught;
					fruitStoredRecord.Seconds = item.Seconds;
					fruitStoredRecord.Common = item.Common;
					fruitStoredRecord.Rare = item.Rare;
					fruitStoredRecord.Legendary = item.Legendary;
					FruitStoredRecord fruit = fruitStoredRecord;
					box.Jobs.Add(new RecoveredType148
					{
						Fruit = fruit
					});
					status = "Fruit notification queued.";
				}
			}
			if (flag)
			{
				while (box.Seen.Count > 5000)
				{
					seen.Remove(box.Seen[0]);
					box.Seen.RemoveAt(0);
				}
				RecoveredMethod387();
			}
		}
		RecoveredMethod51();
	}

	public void RecoveredMethod414(string P_0 = null)
	{
		RecoveredType141 recoveredType2;
		if (P_0 != null)
		{
			RecoveredType141 recoveredType = new RecoveredType141();
			recoveredType.Url = P_0.Trim();
			recoveredType2 = recoveredType;
		}
		else
		{
			recoveredType2 = Settings;
		}
		RecoveredType141 recoveredType3 = recoveredType2;
		recoveredType3.RecoveredMethod526();
		lock (gate)
		{
			if (box.Jobs.Count >= 200)
			{
				throw new Exception("Clear pending notifications before testing.");
			}
			box.Jobs.Add(new RecoveredType148
			{
				Test = true,
				TestUrl = recoveredType3.Url,
				Fruit = new FruitStoredRecord
				{
					Id = Guid.NewGuid().ToString("N"),
					Account = "twist test",
					UserId = "test",
					Name = "test",
					Rarity = "Test",
					AtUtc = DateTime.UtcNow.ToString("o"),
					FishCaught = 0,
					Seconds = 0.0,
					Common = 0,
					Rare = 0,
					Legendary = 0
				}
			});
			status = "Sending webhook test without pings.";
			RecoveredMethod387();
		}
		RecoveredMethod51();
	}

	public void RecoveredMethod50()
	{
		lock (gate)
		{
			if (running)
			{
				throw new Exception("Wait for the current Discord delivery before retrying.");
			}
			foreach (RecoveredType148 job in box.Jobs)
			{
				job.Paused = (job.Uncertain = (job.InFlight = false));
			}
			RecoveredMethod387();
			status = "Retrying pending notifications.";
		}
		RecoveredMethod51();
	}

	private bool RecoveredMethod534(RecoveredType148 P_0)
	{
		if (!P_0.Paused)
		{
			if (!P_0.Test)
			{
				if (P_0.Spawn == null)
				{
					if (config.Enabled)
					{
						return config.Url != "";
					}
					return false;
				}
				if (config.SpawnEnabled)
				{
					return config.Url != "";
				}
				return false;
			}
			if (string.IsNullOrEmpty(P_0.TestUrl))
			{
				return config.Url != "";
			}
			return true;
		}
		return false;
	}

	private void RecoveredMethod51()
	{
		lock (gate)
		{
			if (!closed && !running && box.Jobs.Any(RecoveredMethod534))
			{
				running = true;
				Task.Run((Func<Task>)RecoveredMethod535);
			}
		}
	}

	private async Task RecoveredMethod535()
	{
		int num = default(int);
		_ = num;
		_ = 0;
		try
		{
			_ = num;
			_ = 0;
			try
			{
				while (true)
				{
					RecoveredType148 job;
					RecoveredType141 settings;
					lock (gate)
					{
						job = box.Jobs.FirstOrDefault(RecoveredMethod534);
						if (closed || job == null)
						{
							break;
						}
						settings = (job.Test ? new RecoveredType141
						{
							Url = (job.TestUrl ?? config.Url)
						} : config.RecoveredMethod524());
						job.InFlight = true;
						if (!RecoveredMethod387())
						{
							job.InFlight = false;
							job.Paused = true;
							break;
						}
					}
					RecoveredType145 result;
					try
					{
						result = transport.RecoveredMethod378(settings.RecoveredMethod526(), (job.Spawn != null) ? RecoveredType401.RecoveredMethod884(job.Spawn) : RecoveredType144.RecoveredMethod529(job.Fruit, settings, job.Test), stop.Token);
					}
					catch (OperationCanceledException)
					{
						break;
					}
					catch
					{
						result = new RecoveredType145
						{
							Status = 0
						};
					}
					int wait = 0;
					lock (gate)
					{
						job.InFlight = false;
						if (result.Status >= 200 && result.Status < 300)
						{
							box.Jobs.Remove(job);
							status = (job.Test ? "Webhook test delivered." : (((job.Spawn != null) ? (job.Spawn.Name + " spawn") : job.Fruit.Name) + " notification delivered."));
							RecoveredMethod48("Discord notification delivered.");
						}
						else if (result.Status == 429)
						{
							wait = Math.Max(500, result.RetryAfterMs);
							status = "Discord rate limit; retrying after its delay.";
						}
						else
						{
							job.Paused = true;
							job.Uncertain = result.Status == 0 || result.Status >= 500;
							status = (job.Uncertain ? ("Delivery uncertain" + (string.IsNullOrEmpty(result.Error) ? "" : (" (" + result.Error + ")")) + "; check Discord before Retry pending.") : ("Discord rejected delivery (HTTP " + result.Status + "); check settings and save."));
							RecoveredMethod48(status);
						}
						RecoveredMethod387();
					}
					if (wait > 0)
					{
						await delay(wait, stop.Token);
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
		}
		finally
		{
			lock (gate)
			{
				running = false;
			}
			RecoveredMethod51();
		}
	}

	public void Dispose()
	{
		lock (gate)
		{
			closed = true;
		}
		stop.Cancel();
	}

	public void RecoveredMethod536(IEnumerable<WorldFruitRecord> P_0)
	{
		bool flag = false;
		lock (gate)
		{
			foreach (WorldFruitRecord item in P_0)
			{
				if (item == null || string.IsNullOrEmpty(item.Id) || item.Id.Length > 100 || !RecoveredType219.RecoveredMethod39(item.Name) || (item.Position != null && !item.Position.Valid) || string.IsNullOrEmpty(item.Server) || item.Server.Length > 160 || !DateTime.TryParse(item.AtUtc, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var at) || seen.Contains("world:" + item.Id))
				{
					continue;
				}
				at = at.ToUniversalTime();
				if (config.SpawnEnabled && config.Url != "" && at >= opened && box.Jobs.Count >= 200)
				{
					status = "Discord queue is full; waiting to queue the next spawn.";
					continue;
				}
				string key = (string.IsNullOrEmpty(item.Announcement) ? item.Fingerprint() : (item.Server + "|" + item.Announcement));
				bool flag2 = box.WorldReceipts.Any((RecoveredType400 recoveredType) => recoveredType.Key == key && Math.Abs((at - recoveredType.At).TotalSeconds) <= 120.0);
				seen.Add("world:" + item.Id);
				box.Seen.Add("world:" + item.Id);
				flag = true;
				if (config.SpawnEnabled && !(config.Url == "") && !(at < opened) && !flag2)
				{
					box.WorldReceipts.Add(new RecoveredType400
					{
						Key = key,
						At = at
					});
					box.Jobs.Add(new RecoveredType148
					{
						Spawn = item
					});
					status = "Fruit spawn notification queued.";
				}
			}
			if (flag)
			{
				while (box.Seen.Count > 5000)
				{
					seen.Remove(box.Seen[0]);
					box.Seen.RemoveAt(0);
				}
				while (box.WorldReceipts.Count > 2000)
				{
					box.WorldReceipts.RemoveAt(0);
				}
				RecoveredMethod387();
			}
		}
		RecoveredMethod51();
	}

	[CompilerGenerated]
	private static Task RecoveredMethod193(int P_0, CancellationToken P_1)
	{
		return Task.Delay(P_0, P_1);
	}

	[CompilerGenerated]
	private static bool RecoveredMethod537(RecoveredType148 P_0)
	{
		return P_0.Paused;
	}
}
