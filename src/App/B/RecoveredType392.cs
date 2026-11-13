using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using A;
using B;
using TwistApp;
using a;

namespace b;

internal sealed class RecoveredType392 : IDisposable
{
	[CompilerGenerated]
	private sealed class RecoveredType393
	{
		public RecoveredType341 activeWire;

		public RecoveredType392 _003C_003E4__this;

		public Task RecoveredMethod879()
		{
			return _003C_003E4__this.RecoveredMethod877(activeWire);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType394
	{
		public RecoveredType393 CS_0024_003C_003E8__locals11;

		public RecoveredType311 snapshot;

		public bool RecoveredMethod39(string P_0)
		{
			return !snapshot.Inventories.ContainsKey(P_0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType395
	{
		public RecoveredType394 CS_0024_003C_003E8__locals13;

		public RecoveredType393 CS_0024_003C_003E8__locals11;

		public ItemMetadata item;

		public RecoveredType341 iconWire;

		public void RecoveredMethod349(BitmapSource P_0, string P_1)
		{
			if (P_0 == null || CS_0024_003C_003E8__locals11._003C_003E4__this.stop.IsCancellationRequested || !CS_0024_003C_003E8__locals11._003C_003E4__this.Connected)
			{
				return;
			}
			try
			{
				using MemoryStream memoryStream = new MemoryStream();
				PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
				pngBitmapEncoder.Frames.Add(BitmapFrame.Create(P_0));
				pngBitmapEncoder.Save(memoryStream);
				if (memoryStream.Length <= 256000)
				{
					iconWire.RecoveredMethod807(new RecoveredType317
					{
						Key = item.IconKey,
						Png = Convert.ToBase64String(memoryStream.ToArray())
					});
				}
			}
			catch
			{
			}
		}
	}

	private readonly RecoveredType321 pairing;

	private readonly string id;

	private readonly int reportSession;

	private readonly Func<string> desktopStatus;

	private readonly Func<RecoveredType311> publication;

	private readonly Func<RecoveredType318, Task<string>> command;

	private readonly Action emergencyStop;

	private readonly Action<string> stopReason;

	private readonly RecoveredType276 previews;

	private readonly CancellationTokenSource stop = new CancellationTokenSource();

	private readonly Timer watchdog;

	private readonly object gate = new object();

	private RecoveredType341 connection;

	private long received;

	private int connected;

	public volatile string Status = "Connecting";

	public volatile string Desktop = "Checking session";

	public bool Connected => Volatile.Read(ref connected) == 1;

	public RecoveredType392(RecoveredType321 P_0, string P_1, Func<RecoveredType311> P_2, Func<RecoveredType318, Task<string>> P_3, Action P_4, RecoveredType276 P_5, int P_6 = 0, Func<string> P_7 = null, Action<string> P_8 = null)
	{
		stopReason = P_8;
		reportSession = ((P_6 == 0) ? RecoveredType309.SessionId : P_6);
		desktopStatus = P_7 ?? new Func<string>(RecoveredType322.RecoveredMethod357);
		pairing = P_0;
		id = P_1;
		publication = P_2;
		command = P_3;
		emergencyStop = P_4;
		previews = P_5;
		watchdog = new Timer(delegate
		{
			RecoveredMethod45();
		}, null, 0, 500);
		Task.Run((Action)RecoveredMethod50);
	}

	private void RecoveredMethod48(string P_0)
	{
		if (stopReason != null)
		{
			stopReason(P_0);
		}
		else
		{
			emergencyStop();
		}
	}

	private void RecoveredMethod45()
	{
		if (stop.IsCancellationRequested)
		{
			return;
		}
		try
		{
			Desktop = desktopStatus();
			if (Desktop != "Ready")
			{
				RecoveredMethod48(Desktop);
			}
			else
			{
				if (!Connected || !(DateTime.UtcNow - new DateTime(Interlocked.Read(ref received), DateTimeKind.Utc) > TimeSpan.FromSeconds(4.0)))
				{
					return;
				}
				RecoveredMethod48("Controller heartbeat timed out (4 seconds).");
				lock (gate)
				{
					if (connection != null)
					{
						connection.Dispose();
					}
					return;
				}
			}
		}
		catch
		{
			RecoveredMethod48("Worker desktop safety check failed.");
		}
	}

	private void RecoveredMethod50()
	{
		while (!stop.IsCancellationRequested)
		{
			RecoveredType341 recoveredType = null;
			try
			{
				Status = "Connecting to controller";
				TcpClient tcpClient = new TcpClient();
				Task task = tcpClient.ConnectAsync(IPAddress.Loopback, pairing.Port);
				if (!task.Wait(2000))
				{
					tcpClient.Close();
					throw new Exception("Controller connection timed out.");
				}
				recoveredType = new RecoveredType341(tcpClient);
				RecoveredType313 recoveredType2 = RecoveredType341.RecoveredMethod833<RecoveredType313>(recoveredType.RecoveredMethod470());
				if (recoveredType2 == null || recoveredType2.Type != "challenge" || recoveredType2.Protocol != 1 || recoveredType2.Nonce == null || recoveredType2.Nonce.Length != 64)
				{
					throw new Exception("Invalid controller handshake.");
				}
				RecoveredType312 recoveredType3 = new RecoveredType312();
				recoveredType3.WorkerId = id;
				recoveredType3.Name = Environment.MachineName;
				recoveredType3.User = Environment.UserName;
				recoveredType3.SessionId = reportSession;
				RecoveredType312 recoveredType4 = recoveredType3;
				recoveredType4.Proof = RecoveredType321.RecoveredMethod783(pairing.Secret, "worker|" + recoveredType2.Nonce + "|" + RecoveredType321.RecoveredMethod785(recoveredType4));
				recoveredType.RecoveredMethod807(recoveredType4);
				RecoveredType314 recoveredType5 = RecoveredType341.RecoveredMethod833<RecoveredType314>(recoveredType.RecoveredMethod470());
				if (recoveredType5 != null && recoveredType5.Type == "reject")
				{
					throw new Exception(recoveredType5.Error ?? "Worker connection rejected.");
				}
				if (recoveredType5 == null || recoveredType5.Type != "welcome" || !RecoveredType321.RecoveredMethod784(recoveredType5.Proof, RecoveredType321.RecoveredMethod783(pairing.Secret, "controller|" + recoveredType2.Nonce + "|" + RecoveredType321.RecoveredMethod785(recoveredType4))))
				{
					throw new Exception("Controller pairing failed.");
				}
				lock (gate)
				{
					connection = recoveredType;
				}
				Interlocked.Exchange(ref received, DateTime.UtcNow.Ticks);
				Volatile.Write(ref connected, 1);
				Status = "Connected · session " + reportSession;
				string text = "";
				RecoveredType341 activeWire = recoveredType;
				Task task2 = Task.Run(() => RecoveredMethod877(activeWire));
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				HashSet<string> hashSet = new HashSet<string>();
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
				Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
				Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
				Dictionary<string, int> dictionary5 = new Dictionary<string, int>();
				Dictionary<string, string> dictionary6 = new Dictionary<string, string>();
				while (!stop.IsCancellationRequested && !task2.IsCompleted && Connected)
				{
					RecoveredType311 snapshot = publication();
					RecoveredType310[] accounts = snapshot.Accounts;
					foreach (RecoveredType310 recoveredType6 in accounts)
					{
						RecoveredType82[] array = recoveredType6.State.Activity ?? new RecoveredType82[0];
						string text2 = array.Length + "|" + ((array.Length == 0) ? "" : array[array.Length - 1].Id);
						if (dictionary6.TryGetValue(recoveredType6.Key, out var value) && value == text2)
						{
							recoveredType6.State.Activity = null;
						}
						else
						{
							dictionary6[recoveredType6.Key] = text2;
						}
						WorldSnapshot world = recoveredType6.State.World;
						if (world != null)
						{
							if (dictionary5.TryGetValue(recoveredType6.Key, out var value2) && value2 == world.Revision)
							{
								recoveredType6.State.World = null;
							}
							else
							{
								dictionary5[recoveredType6.Key] = world.Revision;
							}
						}
						FruitStoredRecord[] array2 = recoveredType6.State.FruitStores ?? new FruitStoredRecord[0];
						string text3 = array2.Length + "|" + ((array2.Length == 0) ? "" : array2[array2.Length - 1].Id);
						if (dictionary4.TryGetValue(recoveredType6.Key, out value) && value == text3)
						{
							recoveredType6.State.FruitStores = null;
						}
						else
						{
							dictionary4[recoveredType6.Key] = text3;
						}
						string text4 = recoveredType6.Rounds.Length + "|" + ((recoveredType6.Rounds.Length == 0) ? "" : recoveredType6.Rounds[recoveredType6.Rounds.Length - 1].Id);
						if (dictionary2.TryGetValue(recoveredType6.Key, out value) && value == text4)
						{
							recoveredType6.Rounds = null;
						}
						else
						{
							dictionary2[recoveredType6.Key] = text4;
						}
						string text5 = RecoveredType341.RecoveredMethod831().Serialize(recoveredType6.Profile);
						if (dictionary3.TryGetValue(recoveredType6.Key, out value) && value == text5)
						{
							recoveredType6.Profile = null;
						}
						else
						{
							dictionary3[recoveredType6.Key] = text5;
						}
					}
					RecoveredType82[] array3 = snapshot.Activity ?? new RecoveredType82[0];
					string text6 = array3.Length + "|" + ((array3.Length == 0) ? "" : array3[array3.Length - 1].Id);
					recoveredType.RecoveredMethod807(new RecoveredType315
					{
						Desktop = Desktop,
						Accounts = snapshot.Accounts,
						Activity = ((text6 == text) ? null : array3)
					});
					text = text6;
					string[] array4 = dictionary.Keys.Where((string P_0) => !snapshot.Inventories.ContainsKey(P_0)).ToArray();
					foreach (string key in array4)
					{
						dictionary.Remove(key);
					}
					foreach (KeyValuePair<string, InventorySnapshot> inventory in snapshot.Inventories)
					{
						InventorySnapshot value3 = inventory.Value;
						InventorySnapshot inventorySnapshot = new InventorySnapshot();
						inventorySnapshot.Account = value3.Account;
						inventorySnapshot.UserId = value3.UserId;
						inventorySnapshot.Status = value3.Status;
						inventorySnapshot.Valid = value3.Valid;
						inventorySnapshot.Updated = value3.Updated;
						inventorySnapshot.Gains = value3.Gains;
						inventorySnapshot.Items = value3.Items.Where((InventoryEntry P_0) => P_0.Metadata != null && (P_0.Metadata.IsFish || P_0.Metadata.IsFruit || RecoveredType106.RecoveredMethod403(P_0.Name) > 0)).ToArray();
						InventorySnapshot inventorySnapshot2 = inventorySnapshot;
						string text7 = inventorySnapshot2.Updated.Ticks + "|" + inventorySnapshot2.Valid + "|" + inventorySnapshot2.Status;
						if (dictionary.TryGetValue(inventory.Key, out var value4) && value4 == text7)
						{
							continue;
						}
						RecoveredMethod878(recoveredType, inventory.Key, text7, inventorySnapshot2);
						dictionary[inventory.Key] = text7;
						foreach (InventoryEntry item2 in inventorySnapshot2.Items.Where((InventoryEntry P_0) => P_0.Metadata != null && (P_0.Metadata.IsFish || P_0.Metadata.IsFruit)))
						{
							ItemMetadata item = item2.Metadata;
							if (item == null || !hashSet.Add(item.IconKey))
							{
								continue;
							}
							RecoveredType341 iconWire = recoveredType;
							previews.RecoveredMethod747(item, delegate(BitmapSource P_0, string P_1)
							{
								if (P_0 == null || stop.IsCancellationRequested || !Connected)
								{
									return;
								}
								try
								{
									using MemoryStream memoryStream = new MemoryStream();
									PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
									pngBitmapEncoder.Frames.Add(BitmapFrame.Create(P_0));
									pngBitmapEncoder.Save(memoryStream);
									if (memoryStream.Length <= 256000)
									{
										iconWire.RecoveredMethod807(new RecoveredType317
										{
											Key = item.IconKey,
											Png = Convert.ToBase64String(memoryStream.ToArray())
										});
									}
								}
								catch
								{
								}
							});
						}
					}
					if (stop.Token.WaitHandle.WaitOne(100))
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				if (!stop.IsCancellationRequested)
				{
					Status = "Disconnected · " + RecoveredMethod52(ex.Message);
				}
			}
			finally
			{
				Volatile.Write(ref connected, 0);
				RecoveredMethod48(Status);
				lock (gate)
				{
					if (connection == recoveredType)
					{
						connection = null;
					}
				}
				recoveredType?.Dispose();
			}
			if (stop.Token.WaitHandle.WaitOne(2000))
			{
				break;
			}
		}
	}

	private static string RecoveredMethod52(string P_0)
	{
		if (P_0.Length <= 130)
		{
			return P_0;
		}
		return P_0.Substring(0, 130);
	}

	private async Task RecoveredMethod877(RecoveredType341 P_0)
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
				while (!stop.IsCancellationRequested)
				{
					string json = P_0.RecoveredMethod470();
					string type = RecoveredType341.RecoveredMethod381(json);
					Interlocked.Exchange(ref received, DateTime.UtcNow.Ticks);
					if (type == "ping")
					{
						continue;
					}
					if (type != "command")
					{
						throw new Exception("Unexpected controller message.");
					}
					RecoveredType318 request = RecoveredType341.RecoveredMethod833<RecoveredType318>(json);
					RecoveredType319 ack = new RecoveredType319
					{
						Id = request.Id
					};
					try
					{
						if (string.IsNullOrEmpty(request.Id) || request.Id.Length > 100 || request.Key == null || request.Key.Length > 160)
						{
							throw new Exception("Invalid command identity.");
						}
						ack.Result = await command(request);
					}
					catch (Exception ex)
					{
						ack.Error = RecoveredMethod52(ex.Message);
					}
					P_0.RecoveredMethod807(ack);
				}
			}
			catch (Exception ex2)
			{
				if (!stop.IsCancellationRequested)
				{
					Status = "Disconnected · " + RecoveredMethod52(ex2.Message);
				}
			}
		}
		finally
		{
			Volatile.Write(ref connected, 0);
			RecoveredMethod48(Status);
			P_0.Dispose();
		}
	}

	internal static void RecoveredMethod878(RecoveredType341 P_0, string P_1, string P_2, InventorySnapshot P_3)
	{
		InventoryEntry[] array = P_3.Items ?? new InventoryEntry[0];
		int num = Math.Max(1, (array.Length + 39) / 40);
		if (num > 250)
		{
			throw new Exception("Inventory exceeds 10,000 item types.");
		}
		for (int i = 0; i < num; i++)
		{
			P_0.RecoveredMethod807(new RecoveredType316
			{
				Key = P_1,
				Version = P_2,
				Account = P_3.Account,
				UserId = P_3.UserId,
				Status = P_3.Status,
				Valid = P_3.Valid,
				Updated = P_3.Updated,
				Index = i,
				Total = num,
				Items = array.Skip(i * 40).Take(40).ToArray(),
				Gains = ((i == 0) ? P_3.Gains : null)
			});
		}
	}

	public void Dispose()
	{
		if (stop.IsCancellationRequested)
		{
			return;
		}
		stop.Cancel();
		watchdog.Dispose();
		Volatile.Write(ref connected, 0);
		RecoveredMethod48("Worker disconnected from controller.");
		lock (gate)
		{
			if (connection != null)
			{
				connection.Dispose();
			}
		}
		Status = "Disconnected";
	}

	[CompilerGenerated]
	private void RecoveredMethod807(object P_0)
	{
		RecoveredMethod45();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod1(InventoryEntry P_0)
	{
		if (P_0.Metadata != null)
		{
			if (!P_0.Metadata.IsFish && !P_0.Metadata.IsFruit)
			{
				return RecoveredType106.RecoveredMethod403(P_0.Name) > 0;
			}
			return true;
		}
		return false;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod244(InventoryEntry P_0)
	{
		if (P_0.Metadata != null)
		{
			if (!P_0.Metadata.IsFish)
			{
				return P_0.Metadata.IsFruit;
			}
			return true;
		}
		return false;
	}
}
