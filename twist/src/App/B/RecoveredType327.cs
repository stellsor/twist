using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using A;
using D;
using TwistApp;
using a;

namespace B;

internal sealed class RecoveredType327
{
	private sealed class RecoveredType328
	{
		public string Version;

		public RecoveredType316 First;

		public InventoryEntry[][] Chunks;

		public DateTime At = DateTime.UtcNow;
	}

	[CompilerGenerated]
	private sealed class RecoveredType330
	{
		public RecoveredType317 packet;

		public bool RecoveredMethod290(RecoveredType325 P_0)
		{
			return P_0.Inventory.RecoveredMethod515().Items.Any((InventoryEntry inventoryEntry) => inventoryEntry.Metadata.IconKey == packet.Key);
		}

		public bool RecoveredMethod1(InventoryEntry P_0)
		{
			return P_0.Metadata.IconKey == packet.Key;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType331
	{
		public HashSet<string> keys;

		public bool RecoveredMethod39(string P_0)
		{
			return !keys.Contains(P_0);
		}
	}

	private static readonly object iconGate = new object();

	public string Failure = "";

	private readonly object gate = new object();

	private readonly Dictionary<string, RecoveredType325> accounts = new Dictionary<string, RecoveredType325>();

	private readonly Dictionary<string, RecoveredType328> partial = new Dictionary<string, RecoveredType328>();

	private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> pending = new ConcurrentDictionary<string, TaskCompletionSource<string>>();

	private RecoveredType82[] activity = new RecoveredType82[0];

	private readonly RecoveredType341 wire;

	private readonly string icons;

	private readonly Action changed;

	private readonly Action<RecoveredType325> retired;

	private int disconnected;

	private long seen = DateTime.UtcNow.Ticks;

	public readonly string Id;

	public readonly string Name;

	public readonly string User;

	public readonly int SessionId;

	public string Desktop = "Connecting";

	public bool Connected => Volatile.Read(ref disconnected) == 0;

	public DateTime LastSeen => new DateTime(Interlocked.Read(ref seen), DateTimeKind.Utc);

	public RecoveredType82[] RecoveredMethod368()
	{
		lock (gate)
		{
			return activity.Select((RecoveredType82 P_0) => P_0.RecoveredMethod361()).ToArray();
		}
	}

	public RecoveredType327(RecoveredType312 P_0, RecoveredType341 P_1, string P_2, Action P_3, Action<RecoveredType325> P_4 = null)
	{
		retired = P_4 ?? ((Action<RecoveredType325>)delegate
		{
		});
		Id = P_0.WorkerId;
		Name = P_0.Name;
		User = P_0.User;
		SessionId = P_0.SessionId;
		wire = P_1;
		icons = P_2;
		changed = P_3;
	}

	public RecoveredType325[] RecoveredMethod795()
	{
		lock (gate)
		{
			return accounts.Values.ToArray();
		}
	}

	public async Task<string> RecoveredMethod125(RecoveredType318 P_0)
	{
		if (!Connected)
		{
			throw new Exception("Worker is offline.");
		}
		TaskCompletionSource<string> completion = new TaskCompletionSource<string>();
		if (!pending.TryAdd(P_0.Id, completion))
		{
			throw new Exception("Duplicate command.");
		}
		try
		{
			wire.RecoveredMethod807(P_0);
			if (await Task.WhenAny(completion.Task, Task.Delay(3500)) != completion.Task)
			{
				RecoveredMethod55();
				throw new Exception("Worker did not acknowledge the command. Fishing is stopping on its connection watchdog.");
			}
			return await completion.Task;
		}
		finally
		{
			pending.TryRemove(P_0.Id, out var _);
		}
	}

	public void RecoveredMethod51()
	{
		if (DateTime.UtcNow - LastSeen > TimeSpan.FromSeconds(4.0))
		{
			RecoveredMethod55();
			return;
		}
		try
		{
			wire.RecoveredMethod807(new RecoveredType320());
		}
		catch
		{
			RecoveredMethod55();
		}
	}

	private void RecoveredMethod796(RecoveredType316 P_0)
	{
		if (P_0 == null || P_0.Key == null || P_0.Version == null || P_0.Total < 1 || P_0.Total > 250 || P_0.Index < 0 || P_0.Index >= P_0.Total || P_0.Items == null || P_0.Items.Length > 40 || (P_0.Gains != null && P_0.Gains.Length > 500))
		{
			throw new Exception("Invalid inventory packet.");
		}
		lock (gate)
		{
			if (!accounts.TryGetValue(P_0.Key, out var value))
			{
				return;
			}
			if (!partial.TryGetValue(P_0.Key, out var value2) || value2.Version != P_0.Version || DateTime.UtcNow - value2.At > TimeSpan.FromSeconds(10.0))
			{
				RecoveredType328 recoveredType = new RecoveredType328();
				recoveredType.Version = P_0.Version;
				recoveredType.First = P_0;
				recoveredType.Chunks = new InventoryEntry[P_0.Total][];
				value2 = recoveredType;
				partial[P_0.Key] = value2;
			}
			if (value2.Chunks.Length != P_0.Total)
			{
				throw new Exception("Inventory chunk count changed.");
			}
			value2.Chunks[P_0.Index] = P_0.Items;
			if (value2.Chunks.Any((InventoryEntry[] array2) => array2 == null))
			{
				return;
			}
			InventoryEntry[] array = value2.Chunks.SelectMany((InventoryEntry[] result) => result).ToArray();
			if (array.Length > 10000 || array.Any((InventoryEntry inventoryEntry) => inventoryEntry == null || string.IsNullOrEmpty(inventoryEntry.Name) || inventoryEntry.Name.Length > 250 || inventoryEntry.Count < 0 || inventoryEntry.Metadata == null || inventoryEntry.Metadata.Parts == null || inventoryEntry.Metadata.Parts.Count > 96) || array.Select((InventoryEntry inventoryEntry) => inventoryEntry.Name).Distinct(StringComparer.Ordinal).Count() != array.Length)
			{
				throw new Exception("Invalid inventory entries.");
			}
			RecoveredType316 first = value2.First;
			if (first.UserId != value.RecoveredMethod509().UserId)
			{
				throw new Exception("Inventory account identity mismatch.");
			}
			value.Inventory.RecoveredMethod791(new InventorySnapshot
			{
				Account = first.Account,
				UserId = first.UserId,
				Status = first.Status,
				Valid = first.Valid,
				Updated = first.Updated,
				Items = array,
				Gains = (first.Gains ?? new InventoryGain[0])
			});
			partial.Remove(P_0.Key);
		}
		changed();
	}

	private void RecoveredMethod797(RecoveredType317 P_0)
	{
		if (P_0 == null || !Regex.IsMatch(P_0.Key ?? "", "^[0-9a-f]{24}$") || P_0.Png == null || P_0.Png.Length > 350000)
		{
			throw new Exception("Invalid preview packet.");
		}
		if (!RecoveredMethod795().Any((RecoveredType325 recoveredType) => recoveredType.Inventory.RecoveredMethod515().Items.Any((InventoryEntry inventoryEntry) => inventoryEntry.Metadata.IconKey == P_0.Key)))
		{
			return;
		}
		byte[] array = Convert.FromBase64String(P_0.Png);
		if (array.Length < 24 || array.Length > 256000 || array[0] != 137 || array[1] != 80 || array[2] != 78 || array[3] != 71)
		{
			throw new Exception("Invalid PNG preview.");
		}
		int num = (array[16] << 24) | (array[17] << 16) | (array[18] << 8) | array[19];
		int num2 = (array[20] << 24) | (array[21] << 16) | (array[22] << 8) | array[23];
		if (num < 1 || num2 < 1 || num > 512 || num2 > 512)
		{
			throw new Exception("Preview dimensions exceed the limit.");
		}
		lock (iconGate)
		{
			Directory.CreateDirectory(icons);
			string text = Path.Combine(icons, P_0.Key + ".png");
			string text2 = text + "." + Guid.NewGuid().ToString("N") + ".tmp";
			File.WriteAllBytes(text2, array);
			try
			{
				if (File.Exists(text))
				{
					File.Replace(text2, text, null);
				}
				else
				{
					File.Move(text2, text);
				}
			}
			finally
			{
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
			}
		}
		RecoveredType323.RecoveredMethod48(P_0.Key);
		changed();
	}

	internal void RecoveredMethod798(RecoveredType315 P_0)
	{
		if (P_0 == null || P_0.Accounts == null || P_0.Accounts.Length > 32)
		{
			throw new Exception("Invalid account list.");
		}
		if (P_0.Activity != null && (P_0.Activity.Length > 128 || P_0.Activity.Any((RecoveredType82 recoveredType4) => !RecoveredType84.RecoveredMethod182(recoveredType4))))
		{
			throw new Exception("Invalid activity packet.");
		}
		List<RecoveredType325> list = new List<RecoveredType325>();
		lock (gate)
		{
			if (P_0.Activity != null)
			{
				activity = P_0.Activity.Select(delegate(RecoveredType82 recoveredType5)
				{
					RecoveredType82 recoveredType4 = RecoveredType84.RecoveredMethod366(recoveredType5);
					recoveredType4.Source = "Worker S" + SessionId;
					return recoveredType4;
				}).ToArray();
			}
			Desktop = P_0.Desktop ?? "Unknown";
			HashSet<string> keys = new HashSet<string>();
			RecoveredType310[] array = P_0.Accounts;
			foreach (RecoveredType310 recoveredType in array)
			{
				if (recoveredType == null || string.IsNullOrEmpty(recoveredType.Key) || recoveredType.Key.Length > 160 || recoveredType.State == null || recoveredType.State.Pid < 1 || recoveredType.State.Created < 1 || !keys.Add(recoveredType.Key))
				{
					throw new Exception("Invalid account identity.");
				}
				if (recoveredType.State.Activity != null && (recoveredType.State.Activity.Length > 128 || recoveredType.State.Activity.Any((RecoveredType82 recoveredType4) => !RecoveredType84.RecoveredMethod182(recoveredType4))))
				{
					throw new Exception("Invalid session activity.");
				}
				if (accounts.TryGetValue(recoveredType.Key, out var value))
				{
					RecoveredType174 recoveredType2 = value.RecoveredMethod509();
					if (recoveredType2.Pid != recoveredType.State.Pid || recoveredType2.Created != recoveredType.State.Created)
					{
						throw new Exception("Client identity changed.");
					}
					value.RecoveredMethod792(recoveredType);
				}
				else
				{
					accounts[recoveredType.Key] = new RecoveredType325(this, recoveredType);
				}
			}
			string[] array2 = accounts.Keys.Where((string item) => !keys.Contains(item)).ToArray();
			foreach (string key in array2)
			{
				RecoveredType325 recoveredType3 = accounts[key];
				recoveredType3.Inventory.RecoveredMethod50();
				list.Add(recoveredType3);
				accounts.Remove(key);
				partial.Remove(key);
			}
		}
		foreach (RecoveredType325 item in list)
		{
			retired(item);
		}
		changed();
	}

	public void RecoveredMethod53()
	{
		try
		{
			while (Connected)
			{
				string text = wire.RecoveredMethod470();
				string text2 = RecoveredType341.RecoveredMethod381(text);
				Interlocked.Exchange(ref seen, DateTime.UtcNow.Ticks);
				switch (text2)
				{
				case "state":
					RecoveredMethod798(RecoveredType341.RecoveredMethod833<RecoveredType315>(text));
					break;
				case "inventory":
					RecoveredMethod796(RecoveredType341.RecoveredMethod833<RecoveredType316>(text));
					break;
				case "icon":
					RecoveredMethod797(RecoveredType341.RecoveredMethod833<RecoveredType317>(text));
					break;
				case "ack":
				{
					RecoveredType319 recoveredType = RecoveredType341.RecoveredMethod833<RecoveredType319>(text);
					if (recoveredType.Id != null && pending.TryRemove(recoveredType.Id, out var value))
					{
						if (string.IsNullOrEmpty(recoveredType.Error))
						{
							value.TrySetResult(recoveredType.Result ?? "");
						}
						else
						{
							value.TrySetException(new Exception(recoveredType.Error));
						}
					}
					break;
				}
				default:
					throw new Exception("Unexpected worker message.");
				}
			}
		}
		catch (Exception ex)
		{
			Failure = ex.Message;
		}
		finally
		{
			RecoveredMethod55();
		}
	}

	public void RecoveredMethod55()
	{
		if (Interlocked.Exchange(ref disconnected, 1) != 0)
		{
			return;
		}
		wire.Dispose();
		RecoveredType325[] array = RecoveredMethod795();
		foreach (RecoveredType325 recoveredType in array)
		{
			recoveredType.Inventory.RecoveredMethod50();
		}
		foreach (TaskCompletionSource<string> value in pending.Values)
		{
			value.TrySetException(new Exception("Worker disconnected; its fishing loop is stopping."));
		}
		pending.Clear();
		changed();
	}

	[CompilerGenerated]
	private static RecoveredType82 RecoveredMethod799(RecoveredType82 P_0)
	{
		return P_0.RecoveredMethod361();
	}

	[CompilerGenerated]
	private static void RecoveredMethod347(RecoveredType325 P_0)
	{
	}

	[CompilerGenerated]
	private static bool RecoveredMethod800(InventoryEntry[] P_0)
	{
		return P_0 == null;
	}

	[CompilerGenerated]
	private static IEnumerable<InventoryEntry> RecoveredMethod801(InventoryEntry[] P_0)
	{
		return P_0;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod1(InventoryEntry P_0)
	{
		if (P_0 != null && !string.IsNullOrEmpty(P_0.Name) && P_0.Name.Length <= 250 && P_0.Count >= 0 && P_0.Metadata != null && P_0.Metadata.Parts != null)
		{
			return P_0.Metadata.Parts.Count > 96;
		}
		return true;
	}

	[CompilerGenerated]
	private static string RecoveredMethod20(InventoryEntry P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod342(RecoveredType82 P_0)
	{
		return !RecoveredType84.RecoveredMethod182(P_0);
	}

	[CompilerGenerated]
	private RecoveredType82 RecoveredMethod372(RecoveredType82 P_0)
	{
		RecoveredType82 recoveredType = RecoveredType84.RecoveredMethod366(P_0);
		recoveredType.Source = "Worker S" + SessionId;
		return recoveredType;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod802(RecoveredType82 P_0)
	{
		return !RecoveredType84.RecoveredMethod182(P_0);
	}
}
