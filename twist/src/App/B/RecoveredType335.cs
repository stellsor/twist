using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using A;
using C;
using D;
using TwistApp;
using a;
using b;

namespace B;

internal static class RecoveredType335
{
	private sealed class RecoveredType336 : IDisposable
	{
		[CompilerGenerated]
		private sealed class RecoveredType337
		{
			public bool capped;

			public InventoryEntry RecoveredMethod813(InventoryEntry P_0)
			{
				return new InventoryEntry
				{
					Name = P_0.Name,
					Count = P_0.Count + ((P_0.Name == "Fish 0" && !capped) ? 1 : 0),
					Metadata = P_0.Metadata
				};
			}
		}

		private readonly object gate = new object();

		public readonly string Id = Guid.NewGuid().ToString("N");

		private bool visible = true;

		public readonly int Session;

		public volatile string Desktop = "Ready";

		public int Releases;

		public bool HangCommand;

		private readonly List<RoundRecord> rounds = new List<RoundRecord>();

		private RecoveredType174 state;

		private InventorySnapshot inventory;

		private readonly RecoveredType276 images;

		public RecoveredType392 Link;

		[CompilerGenerated]
		private string _003CKey_003Ek__BackingField;

		public string Key
		{
			[CompilerGenerated]
			get
			{
				return _003CKey_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CKey_003Ek__BackingField = value;
			}
		}

		public bool Running
		{
			get
			{
				lock (gate)
				{
					return state.Running;
				}
			}
		}

		public RecoveredType336(RecoveredType321 P_0, int P_1, string P_2)
		{
			Session = P_1;
			Key = 100 + P_1 + "-123";
			state = new RecoveredType174
			{
				Pid = 100 + P_1,
				Created = 123L,
				Account = "test" + P_1,
				UserId = P_1.ToString(),
				Attached = true,
				Status = "Idle"
			};
			inventory = new InventorySnapshot
			{
				Account = state.Account,
				UserId = state.UserId,
				Updated = DateTime.UtcNow,
				Valid = true,
				Status = "Test inventory",
				Items = (from num in Enumerable.Range(0, 81)
					select new InventoryEntry
					{
						Name = "Fish " + num,
						Count = 1,
						Metadata = new ItemMetadata
						{
							Name = "Fish " + num,
							Rarity = "Rare",
							Category = "Fish"
						}
					}).Concat(new InventoryEntry[2]
				{
					new InventoryEntry
					{
						Name = "Ope",
						Count = 1,
						Metadata = new ItemMetadata
						{
							Name = "Ope",
							Rarity = "Mythical",
							Category = "Fruit"
						}
					},
					new InventoryEntry
					{
						Name = "Fruit Bag",
						Count = 1,
						Metadata = new ItemMetadata
						{
							Name = "Fruit Bag",
							Category = "Item"
						}
					}
				}).ToArray()
			};
			images = new RecoveredType276(P_2);
			BitmapSource source = BitmapSource.Create(1, 1, 96.0, 96.0, PixelFormats.Bgra32, null, new byte[4] { 100, 200, 255, 255 }, 4);
			PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder
			{
				Frames = { BitmapFrame.Create(source) }
			};
			using (MemoryStream memoryStream = new MemoryStream())
			{
				pngBitmapEncoder.Save(memoryStream);
				foreach (InventoryEntry item in inventory.Items.Where((InventoryEntry inventoryEntry) => inventoryEntry.Name == "Fish 0" || inventoryEntry.Name == "Ope"))
				{
					File.WriteAllBytes(Path.Combine(P_2, item.Metadata.IconKey + ".png"), memoryStream.ToArray());
				}
			}
			Link = new RecoveredType392(P_0, Id, RecoveredMethod810, RecoveredMethod125, RecoveredMethod50, images, P_1, () => Desktop);
		}

		private RecoveredType311 RecoveredMethod810()
		{
			lock (gate)
			{
				RecoveredType311 recoveredType = new RecoveredType311();
				recoveredType.Activity = state.Activity;
				recoveredType.Accounts = (visible ? new RecoveredType310[1]
				{
					new RecoveredType310
					{
						Key = Key,
						State = state.RecoveredMethod509(),
						Profile = new RecoveredType170(),
						Rounds = rounds.ToArray()
					}
				} : new RecoveredType310[0]);
				RecoveredType311 recoveredType2 = recoveredType;
				if (visible)
				{
					recoveredType2.Inventories[Key] = inventory;
				}
				return recoveredType2;
			}
		}

		private Task<string> RecoveredMethod125(RecoveredType318 P_0)
		{
			if (HangCommand)
			{
				return new TaskCompletionSource<string>().Task;
			}
			lock (gate)
			{
				if (!visible || P_0.Key != Key)
				{
					throw new Exception("This Roblox client closed or changed identity.");
				}
				if (P_0.Action == "start")
				{
					if (Desktop != "Ready")
					{
						throw new Exception("Desktop unavailable");
					}
					RecoveredType322.RecoveredMethod128(P_0.Profile);
					state.Running = (state.AutoFish = (state.Held = true));
					state.Status = "Fishing";
				}
				else if (P_0.Action == "stop")
				{
					RecoveredMethod50();
				}
				else if (P_0.Action == "profile")
				{
					RecoveredType322.RecoveredMethod128(P_0.Profile);
				}
				else if (P_0.Action != "attach" && P_0.Action != "diagnose")
				{
					throw new Exception("Unsupported command");
				}
			}
			return Task.FromResult("Acknowledged");
		}

		private void RecoveredMethod50()
		{
			lock (gate)
			{
				state.Running = (state.Held = (state.Reeling = false));
				state.Status = "Stopped";
				Interlocked.Increment(ref Releases);
			}
		}

		public void RecoveredMethod51()
		{
			lock (gate)
			{
				visible = false;
				state.Running = (state.Held = false);
			}
		}

		public void RecoveredMethod53()
		{
			lock (gate)
			{
				long num = state.Created + 1;
				state = new RecoveredType174
				{
					Pid = state.Pid,
					Created = num,
					Account = state.Account,
					UserId = state.UserId,
					Attached = true,
					Status = "Idle"
				};
				Key = state.Pid + "-" + num;
				rounds.Clear();
				inventory = new InventorySnapshot
				{
					Account = state.Account,
					UserId = state.UserId,
					Items = inventory.Items,
					Updated = DateTime.UtcNow,
					Valid = true,
					Status = "Reopened inventory"
				};
				visible = true;
			}
		}

		public void RecoveredMethod55()
		{
			lock (gate)
			{
				state.StopReason = "Controller heartbeat timed out (4 seconds).";
				state.Activity = new RecoveredType82[1]
				{
					new RecoveredType82
					{
						Id = "activity-" + Id,
						Category = "Stopped",
						Level = "Warning",
						Message = state.StopReason,
						Account = state.Account,
						UserId = state.UserId
					}
				};
			}
		}

		public void RecoveredMethod56()
		{
			lock (gate)
			{
				state.World = new WorldSnapshot
				{
					Revision = 1,
					Valid = true,
					Updated = DateTime.UtcNow,
					Position = new WorldPoint
					{
						RecoveredField2015 = 10.0,
						RecoveredField2016 = 4.0,
						RecoveredField2017 = -20.0
					},
					HasEye = true,
					EyeName = "All Seeing Shamrock",
					EyeDescription = "All Seeing Eye: 5 mins until next fruit spawn",
					Events = new WorldFruitRecord[1]
					{
						new WorldFruitRecord
						{
							Id = "world-" + Id,
							Name = "Kilo",
							Rarity = "Common",
							Server = "test-server",
							Account = state.Account,
							Hub = "Fishing Hub",
							AtUtc = DateTime.UtcNow.ToString("o"),
							Position = new WorldPoint
							{
								RecoveredField2015 = 594.0,
								RecoveredField2016 = 1.0,
								RecoveredField2017 = -1486.0
							}
						}
					}
				};
			}
		}

		public void RecoveredMethod693()
		{
			lock (gate)
			{
				state.FruitStores = new FruitStoredRecord[1]
				{
					new FruitStoredRecord
					{
						Id = "store-" + Id,
						Name = "Hie",
						Rarity = "Legendary",
						UserId = state.UserId,
						Account = state.Account,
						AtUtc = DateTime.UtcNow.ToString("o"),
						FishCaught = 147,
						Seconds = 5025.0,
						Common = 79,
						Rare = 5,
						Legendary = 0
					}
				};
			}
		}

		public void RecoveredMethod72(bool P_0 = false)
		{
			lock (gate)
			{
				rounds.Add(new RoundRecord
				{
					Id = Guid.NewGuid().ToString("N"),
					UserId = state.UserId,
					Account = state.Account,
					AtUtc = DateTime.UtcNow.ToString("o"),
					Full = true,
					Peak = 1.0
				});
				InventoryEntry[] items = inventory.Items.Select((InventoryEntry inventoryEntry) => new InventoryEntry
				{
					Name = inventoryEntry.Name,
					Count = inventoryEntry.Count + ((inventoryEntry.Name == "Fish 0" && !P_0) ? 1 : 0),
					Metadata = inventoryEntry.Metadata
				}).ToArray();
				inventory = new InventorySnapshot
				{
					Account = state.Account,
					UserId = state.UserId,
					Items = items,
					Updated = DateTime.UtcNow,
					Valid = true,
					Status = "Test inventory",
					Gains = (P_0 ? new InventoryGain[0] : new InventoryGain[1]
					{
						new InventoryGain
						{
							Name = "Fish 0",
							Count = 1,
							Fishing = true,
							AtUtc = DateTime.UtcNow.ToString("o")
						}
					})
				};
			}
		}

		public void Dispose()
		{
			Link.Dispose();
			images.Dispose();
		}

		[CompilerGenerated]
		private static InventoryEntry RecoveredMethod811(int P_0)
		{
			return new InventoryEntry
			{
				Name = "Fish " + P_0,
				Count = 1,
				Metadata = new ItemMetadata
				{
					Name = "Fish " + P_0,
					Rarity = "Rare",
					Category = "Fish"
				}
			};
		}

		[CompilerGenerated]
		private static bool RecoveredMethod1(InventoryEntry P_0)
		{
			if (!(P_0.Name == "Fish 0"))
			{
				return P_0.Name == "Ope";
			}
			return true;
		}

		[CompilerGenerated]
		private string RecoveredMethod812()
		{
			return Desktop;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType338
	{
		public int recovered;

		public void RecoveredMethod45()
		{
			recovered++;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType339
	{
		public RecoveredType332 hub;

		public RecoveredType336 first;

		public RecoveredType336 second;

		private static Func<RecoveredType327, bool> CS_0024_003C_003E9__CachedAnonymousMethodDelegate6b;

		private static Func<RecoveredType327, bool> CS_0024_003C_003E9__CachedAnonymousMethodDelegate6c;

		private static Func<RecoveredType327, bool> CS_0024_003C_003E9__CachedAnonymousMethodDelegate6d;

		private static Func<RecoveredType327, bool> CS_0024_003C_003E9__CachedAnonymousMethodDelegate6e;

		public void RecoveredMethod807(object P_0)
		{
			hub?.RecoveredMethod45();
		}

		public bool RecoveredMethod387()
		{
			if (hub.RecoveredMethod803().Count((RecoveredType327 P_0) => P_0.Connected) == 2)
			{
				return hub.RecoveredMethod803().All((RecoveredType327 P_0) => P_0.RecoveredMethod795().Length == 1);
			}
			return false;
		}

		public bool RecoveredMethod281(RecoveredType327 P_0)
		{
			return P_0.Id == first.Id;
		}

		public bool RecoveredMethod814(RecoveredType327 P_0)
		{
			return P_0.Id == second.Id;
		}

		public bool RecoveredMethod573()
		{
			return hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()
				.Length == 0;
		}

		public bool RecoveredMethod666()
		{
			return hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()
				.Length == 1;
		}

		public bool RecoveredMethod284(RecoveredType327 P_0)
		{
			return P_0.Id == first.Id;
		}

		public bool RecoveredMethod655()
		{
			return !second.Running;
		}

		public bool RecoveredMethod815()
		{
			if (!second.Running)
			{
				return !first.Running;
			}
			return false;
		}

		public bool RecoveredMethod478()
		{
			return hub.RecoveredMethod803().Count((RecoveredType327 P_0) => P_0.Connected) == 2;
		}

		public bool RecoveredMethod816(RecoveredType327 P_0)
		{
			return P_0.Id == first.Id;
		}

		public bool RecoveredMethod817()
		{
			return hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()
				.Length == 1;
		}

		public bool RecoveredMethod286(RecoveredType327 P_0)
		{
			return P_0.Id == first.Id;
		}

		public bool RecoveredMethod818()
		{
			return !first.Running;
		}

		public bool RecoveredMethod819()
		{
			return hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == second.Id).RecoveredMethod795()
				.Length == 1;
		}

		public bool RecoveredMethod820(RecoveredType327 P_0)
		{
			return P_0.Id == second.Id;
		}

		public bool RecoveredMethod821()
		{
			return !second.Running;
		}

		public bool RecoveredMethod822()
		{
			return !hub.RecoveredMethod803().Any((RecoveredType327 P_0) => P_0.Connected);
		}

		private static bool RecoveredMethod823(RecoveredType327 P_0)
		{
			return P_0.Connected;
		}

		private static bool RecoveredMethod289(RecoveredType327 P_0)
		{
			return P_0.RecoveredMethod795().Length == 1;
		}

		public bool RecoveredMethod824(RecoveredType327 P_0)
		{
			return P_0.Id == first.Id;
		}

		public bool RecoveredMethod825(RecoveredType327 P_0)
		{
			return P_0.Id == first.Id;
		}

		private static bool RecoveredMethod826(RecoveredType327 P_0)
		{
			return P_0.Connected;
		}

		public bool RecoveredMethod827(RecoveredType327 P_0)
		{
			return P_0.Id == first.Id;
		}

		public bool RecoveredMethod828(RecoveredType327 P_0)
		{
			return P_0.Id == second.Id;
		}

		private static bool RecoveredMethod829(RecoveredType327 P_0)
		{
			return P_0.Connected;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType340
	{
		public RecoveredType339 CS_0024_003C_003E8__locals63;

		public string controller;

		public RecoveredType325 RecoveredField1811;

		public RecoveredType325 RecoveredField1812;

		public string icon;

		public string fruitIcon;

		public RecoveredType90 delivery;

		public bool RecoveredMethod387()
		{
			if (RecoveredField1811.Inventory.RecoveredMethod515().Items.Length == 82)
			{
				return RecoveredField1812.Inventory.RecoveredMethod515().Items.Length == 82;
			}
			return false;
		}

		public bool RecoveredMethod573()
		{
			return File.Exists(Path.Combine(controller, icon));
		}

		public bool RecoveredMethod666()
		{
			return File.Exists(Path.Combine(controller, fruitIcon));
		}

		public bool RecoveredMethod655()
		{
			return RecoveredField1811.RecoveredMethod509().FruitStores.Length == 1;
		}

		public bool RecoveredMethod815()
		{
			return delivery.Calls == 1;
		}

		public bool RecoveredMethod478()
		{
			if (RecoveredField1811.RecoveredMethod509().Activity.Length == 1)
			{
				return RecoveredField1811.Peer.RecoveredMethod368().Length == 1;
			}
			return false;
		}

		public bool RecoveredMethod817()
		{
			return RecoveredField1811.RecoveredMethod509().World.Valid;
		}

		public bool RecoveredMethod818()
		{
			return delivery.Calls == 2;
		}

		public bool RecoveredMethod819()
		{
			return RecoveredField1811.Inventory.RecoveredMethod515().Items[0].Count == 2;
		}

		public bool RecoveredMethod821()
		{
			return RecoveredField1811.RecoveredMethod510().Length == 1;
		}

		public bool RecoveredMethod822()
		{
			return RecoveredField1811.RecoveredMethod510().Length == 2;
		}

		public bool RecoveredMethod830()
		{
			return RecoveredField1811.Inventory.RecoveredMethod515().Items.Length == 82;
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Remote test: " + P_1);
		}
	}

	private static void RecoveredMethod808(Func<bool> P_0, string P_1, int P_2 = 7000)
	{
		DateTime dateTime = DateTime.UtcNow.AddMilliseconds(P_2);
		while (DateTime.UtcNow < dateTime)
		{
			if (P_0())
			{
				return;
			}
			Thread.Sleep(25);
		}
		throw new Exception("Remote test timed out: " + P_1);
	}

	private static string RecoveredMethod357()
	{
		string text = Path.Combine(Path.GetTempPath(), "twist-remote-test-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text);
		return text;
	}

	private static void RecoveredMethod48(string P_0)
	{
		string[] files = Directory.GetFiles(P_0, "*", SearchOption.AllDirectories);
		foreach (string path in files)
		{
			File.Delete(path);
		}
		foreach (string item in from text in Directory.GetDirectories(P_0, "*", SearchOption.AllDirectories)
			orderby text.Length descending
			select text)
		{
			Directory.Delete(item);
		}
		Directory.Delete(P_0);
	}

	public static void RecoveredMethod50()
	{
		RecoveredType321 recoveredType = RecoveredType321.RecoveredMethod780("twist1:26744:" + new string('a', 64));
		RecoveredMethod42(RecoveredType321.RecoveredMethod780(recoveredType.Code).Secret == recoveredType.Secret, "Pairing roundtrip");
		bool flag = false;
		try
		{
			RecoveredType321.RecoveredMethod780("twist1:80:hello");
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag, "Invalid pairing rejected");
		RecoveredMethod51();
		string text = RecoveredType321.RecoveredMethod783(recoveredType.Secret, "worker|nonce|id");
		RecoveredMethod42(RecoveredType321.RecoveredMethod784(text, RecoveredType321.RecoveredMethod783(recoveredType.Secret, "worker|nonce|id")) && !RecoveredType321.RecoveredMethod784(text, RecoveredType321.RecoveredMethod783(recoveredType.Secret, "controller|nonce|id")) && !RecoveredType321.RecoveredMethod784(text, text + "x"), "Challenge roles and length differ");
		flag = false;
		try
		{
			RecoveredType170 recoveredType2 = new RecoveredType170();
			recoveredType2.PredictionMs = double.NaN;
			RecoveredType322.RecoveredMethod128(recoveredType2);
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod42(flag, "Non-finite remote settings rejected");
		RecoveredType311 recoveredType3 = new RecoveredType311();
		recoveredType3.RecoveredMethod779("starting", new InventorySnapshot
		{
			Status = "Connecting"
		});
		RecoveredMethod42(recoveredType3.Inventories.Count == 0, "Unidentified connecting inventory is withheld until ready");
		RecoveredType310 recoveredType4 = new RecoveredType310();
		recoveredType4.Key = "123-456";
		recoveredType4.State = new RecoveredType174
		{
			Pid = 123,
			Created = 456L,
			Account = "test",
			UserId = "42",
			Attached = true,
			FruitsStored = 3,
			FruitsDropped = 2,
			LastFruit = "Ope",
			FruitStores = new FruitStoredRecord[1]
			{
				new FruitStoredRecord
				{
					Id = "stored-ope",
					Name = "Ope",
					Rarity = "Mythical",
					FishCaught = 147,
					Seconds = 5025.0,
					Common = 79,
					Rare = 5,
					Legendary = 0,
					AtUtc = DateTime.UtcNow.ToString("o")
				}
			}
		};
		recoveredType4.Profile = new RecoveredType170
		{
			AutoStoreFruits = false,
			DropDuplicateFruits = false,
			RestockBelow = 80,
			RestockBuy = 250
		};
		recoveredType4.Rounds = new RoundRecord[1]
		{
			new RoundRecord
			{
				Id = "r",
				Full = true
			}
		};
		RecoveredType310 recoveredType5 = recoveredType4;
		RecoveredType315 recoveredType6 = RecoveredType341.RecoveredMethod833<RecoveredType315>(RecoveredType341.RecoveredMethod831().Serialize(new RecoveredType315
		{
			Accounts = new RecoveredType310[1] { recoveredType5 },
			Desktop = "Ready"
		}));
		RecoveredMethod42(recoveredType6.Accounts[0].State.UserId == "42" && recoveredType6.Accounts[0].Rounds[0].Full, "Account and round protocol roundtrip");
		RecoveredMethod42(recoveredType6.Accounts[0].Profile.RestockBelow == 80 && recoveredType6.Accounts[0].Profile.RestockBuy == 250, "Custom restock threshold and amount survive the worker protocol");
		RecoveredMethod42(!recoveredType6.Accounts[0].Profile.AutoStoreFruits && !recoveredType6.Accounts[0].Profile.DropDuplicateFruits && recoveredType6.Accounts[0].State.FruitsStored == 3 && recoveredType6.Accounts[0].State.FruitsDropped == 2 && recoveredType6.Accounts[0].State.LastFruit == "Ope", "Fruit preferences and counters survive the worker protocol");
		RecoveredMethod42(recoveredType6.Accounts[0].State.FruitStores.Length == 1 && recoveredType6.Accounts[0].State.FruitStores[0].FishCaught == 147 && recoveredType6.Accounts[0].State.FruitStores[0].Common == 79, "Confirmed storage and its runtime statistics survive the RDP protocol");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: pairing validation, role-specific HMAC, non-finite command rejection, protocol account/profile/round roundtrip.\r\n");
	}

	private static void RecoveredMethod51()
	{
		string text = RecoveredMethod357();
		try
		{
			string text2 = Path.Combine(text, "controller-pairing.txt");
			int recovered = 0;
			Action action = delegate
			{
				recovered++;
			};
			RecoveredType321 recoveredType = RecoveredType321.RecoveredMethod781(text2, action);
			RecoveredMethod42(recoveredType.Secret.Length == 64 && recovered == 0 && File.ReadAllText(text2) == recoveredType.Code, "Missing controller pairing is generated");
			RecoveredType321 recoveredType2 = RecoveredType321.RecoveredMethod780("twist1:28901:" + new string('b', 64));
			RecoveredType321.RecoveredMethod782(text2, recoveredType2);
			DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(text2);
			RecoveredMethod42(RecoveredType321.RecoveredMethod781(text2, action).Code == recoveredType2.Code && File.GetLastWriteTimeUtc(text2) == lastWriteTimeUtc && recovered == 0, "Valid controller pairing and custom port are preserved");
			string[] array = new string[4]
			{
				new string('\0', 77),
				"",
				"twist1:26744:truncated",
				"twist1:80:" + new string('c', 64)
			};
			foreach (string text3 in array)
			{
				File.WriteAllText(text2, text3);
				string[] files = Directory.GetFiles(text, "*.invalid-*");
				RecoveredType321 recoveredType3 = RecoveredType321.RecoveredMethod781(text2, action);
				string path = Directory.GetFiles(text, "*.invalid-*").Except(files).Single();
				RecoveredMethod42(File.ReadAllText(path) == text3 && RecoveredType321.RecoveredMethod780(File.ReadAllText(text2)).Code == recoveredType3.Code, "Corrupt controller pairing is backed up and replaced with valid pairing");
				RecoveredMethod42(RecoveredType321.RecoveredMethod781(text2, action).Code == recoveredType3.Code, "Recovery secret remains stable across restart");
			}
			RecoveredMethod42(recovered == 4 && !Directory.GetFiles(text, "*.tmp-*").Any(), "Only corrupt files trigger recovery; no temporary pairing files remain");
			string text4 = File.ReadAllText(text2);
			bool flag = false;
			try
			{
				RecoveredType321.RecoveredMethod782(text2, new RecoveredType321
				{
					Secret = "invalid"
				});
			}
			catch (FormatException)
			{
				flag = true;
			}
			RecoveredMethod42(flag && File.ReadAllText(text2) == text4, "Invalid writes cannot replace valid pairing");
		}
		finally
		{
			RecoveredMethod48(text);
		}
	}

	public static void RecoveredMethod53()
	{
		string text = RecoveredMethod357();
		RecoveredType332 hub = null;
		RecoveredType336 first = null;
		RecoveredType336 second = null;
		Timer timer = null;
		try
		{
			TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 0);
			tcpListener.Start();
			int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
			tcpListener.Stop();
			RecoveredType321 recoveredType = new RecoveredType321();
			recoveredType.Port = port;
			recoveredType.Secret = RecoveredType321.RecoveredMethod357();
			RecoveredType321 recoveredType2 = recoveredType;
			string controller = Path.Combine(text, "controller");
			string text2 = Path.Combine(text, "one");
			string text3 = Path.Combine(text, "two");
			Directory.CreateDirectory(controller);
			Directory.CreateDirectory(text2);
			Directory.CreateDirectory(text3);
			hub = new RecoveredType332(recoveredType2, controller, delegate
			{
			});
			timer = new Timer(delegate
			{
				hub?.RecoveredMethod45();
			}, null, 0, 200);
			first = new RecoveredType336(recoveredType2, 1001, text2);
			second = new RecoveredType336(recoveredType2, 1002, text3);
			RecoveredMethod808(() => hub.RecoveredMethod803().Count((RecoveredType327 P_0) => P_0.Connected) == 2 && hub.RecoveredMethod803().All((RecoveredType327 P_0) => P_0.RecoveredMethod795().Length == 1), "Two authenticated workers");
			RecoveredType325 RecoveredField1811 = hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()[0];
			RecoveredType325 RecoveredField1812 = hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == second.Id).RecoveredMethod795()[0];
			RecoveredMethod808(() => RecoveredField1811.Inventory.RecoveredMethod515().Items.Length == 82 && RecoveredField1812.Inventory.RecoveredMethod515().Items.Length == 82, "Multi-chunk inventories");
			RecoveredMethod42(RecoveredField1811.Inventory.RecoveredMethod515().Items.Single((InventoryEntry P_0) => P_0.Name == "Ope").Metadata.IsFruit && !RecoveredField1811.Inventory.RecoveredMethod515().Items.Any((InventoryEntry P_0) => P_0.Name == "Fruit Bag"), "Stored fruits cross RDP without sending ordinary equipment");
			RecoveredMethod42(RecoveredField1811.Inventory.RecoveredMethod515().Valid && RecoveredField1811.InputScope != RecoveredField1812.InputScope, "Separate input scopes and atomic inventory publish");
			string icon = RecoveredField1811.Inventory.RecoveredMethod515().Items[0].Metadata.IconKey + ".png";
			RecoveredMethod808(() => File.Exists(Path.Combine(controller, icon)), "Worker PNG preview transfer");
			string fruitIcon = RecoveredField1811.Inventory.RecoveredMethod515().Items.Single((InventoryEntry P_0) => P_0.Name == "Ope").Metadata.IconKey + ".png";
			RecoveredMethod808(() => File.Exists(Path.Combine(controller, fruitIcon)), "Fruit preview transfer");
			RecoveredField1811.RecoveredMethod512(new RecoveredType170(), true).GetAwaiter().GetResult();
			RecoveredField1812.RecoveredMethod512(new RecoveredType170(), true).GetAwaiter().GetResult();
			RecoveredMethod42(first.Running && second.Running, "Concurrent starts remain independent");
			RecoveredField1811.RecoveredMethod513().GetAwaiter().GetResult();
			RecoveredMethod42(!first.Running && second.Running, "Stopping one leaves another running");
			RecoveredType90 delivery = new RecoveredType90();
			using (RecoveredType150 recoveredType3 = new RecoveredType150(Path.Combine(text, "remote-alerts"), delegate
			{
			}, delivery, (int P_0, CancellationToken P_1) => Task.FromResult(0)))
			{
				recoveredType3.RecoveredMethod532(new RecoveredType141
				{
					Enabled = true,
					Url = "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890"
				});
				first.RecoveredMethod693();
				RecoveredMethod808(() => RecoveredField1811.RecoveredMethod509().FruitStores.Length == 1, "Storage event transfer");
				RecoveredMethod42(RecoveredField1811.RecoveredMethod509().FruitStores[0].Common == 79 && RecoveredField1811.RecoveredMethod509().FruitStores[0].FishCaught == 147, "Storage event statistics survive live RDP transport");
				recoveredType3.RecoveredMethod533(RecoveredField1811.RecoveredMethod509().FruitStores, (FruitStoredRecord P_0) => P_0.Rarity);
				RecoveredMethod808(() => delivery.Calls == 1, "Controller delivers remote fruit alert");
				recoveredType3.RecoveredMethod533(RecoveredField1811.RecoveredMethod509().FruitStores, (FruitStoredRecord P_0) => P_0.Rarity);
				Thread.Sleep(200);
				RecoveredMethod42(delivery.Calls == 1, "Remote fruit alert sent once across delta state packets");
				RecoveredMethod42(RecoveredField1811.RecoveredMethod509().FruitStores.Length == 1 && RecoveredField1811.Profile.RestockBelow == 50, "Unchanged state deltas preserve receipts and saved profile");
				first.RecoveredMethod55();
				RecoveredMethod808(() => RecoveredField1811.RecoveredMethod509().Activity.Length == 1 && RecoveredField1811.Peer.RecoveredMethod368().Length == 1, "Worker activity and stop reason transfer");
				Thread.Sleep(250);
				RecoveredMethod42(RecoveredField1811.RecoveredMethod509().Activity[0].Category == "Stopped" && RecoveredField1811.RecoveredMethod509().StopReason.Contains("heartbeat") && RecoveredField1811.Peer.RecoveredMethod368()[0].Source == "Worker S1001", "Activity delta packets retain stop reasons and worker identity");
				first.RecoveredMethod56();
				RecoveredMethod808(() => RecoveredField1811.RecoveredMethod509().World.Valid, "World telemetry crosses RDP");
				recoveredType3.RecoveredMethod536(RecoveredField1811.RecoveredMethod509().World.Events);
				RecoveredMethod808(() => delivery.Calls == 2, "Controller delivers remote spawn coordinates");
				Thread.Sleep(200);
				RecoveredMethod42(RecoveredField1811.RecoveredMethod509().World.Position.RecoveredField2017 == -20.0 && RecoveredField1811.RecoveredMethod509().World.EyeDescription.Contains("5 mins") && RecoveredField1811.RecoveredMethod509().World.Events.Length == 1, "World delta packets preserve player position, timer and spawn events");
			}
			RecoveredType266 recoveredType4 = new RecoveredType266(Path.Combine(text, "ledger"));
			RecoveredMethod42(!recoveredType4.RecoveredMethod725(RecoveredField1811.Inventory.RecoveredMethod515()), "Remote starting stock skipped");
			first.RecoveredMethod72();
			RecoveredMethod808(() => RecoveredField1811.Inventory.RecoveredMethod515().Items[0].Count == 2, "Live inventory change");
			RecoveredMethod808(() => RecoveredField1811.RecoveredMethod510().Length == 1, "Completed round telemetry");
			recoveredType4.RecoveredMethod725(RecoveredField1811.Inventory.RecoveredMethod515());
			RecoveredMethod42(recoveredType4.RecoveredMethod724(RecoveredField1811.RecoveredMethod510()) && recoveredType4.RecoveredMethod727("1001").Sum((CatchRecord P_0) => P_0.Count) == 1, "Remote completed minigame ledger");
			RecoveredMethod42(!recoveredType4.RecoveredMethod725(RecoveredField1811.Inventory.RecoveredMethod515()) && !recoveredType4.RecoveredMethod724(RecoveredField1811.RecoveredMethod510()), "Remote catch deduplication");
			first.RecoveredMethod72(true);
			RecoveredMethod808(() => RecoveredField1811.RecoveredMethod510().Length == 2, "Capped round telemetry");
			RecoveredMethod42(recoveredType4.RecoveredMethod724(RecoveredField1811.RecoveredMethod510()) && recoveredType4.RecoveredMethod727("1001").Sum((CatchRecord P_0) => P_0.Count) == 2, "Remote completed minigame counts even when inventory cannot grow");
			recoveredType4.Completion.GetAwaiter().GetResult();
			RecoveredType325 recoveredType5 = RecoveredField1811;
			string recoveredField = RecoveredField1811.Key;
			first.RecoveredMethod51();
			RecoveredMethod808(() => hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()
				.Length == 0, "Closed Roblox removed from authoritative account list");
			RecoveredType325[] source = hub.RecoveredMethod804();
			RecoveredMethod42(source.Contains(recoveredType5) && recoveredType5.RecoveredMethod510().Length == 2, "Final retired client history remains available for persistence");
			first.RecoveredMethod53();
			RecoveredMethod808(() => hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()
				.Length == 1, "Reopened Roblox discovered without worker restart");
			RecoveredField1811 = hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()[0];
			RecoveredMethod808(() => RecoveredField1811.Inventory.RecoveredMethod515().Items.Length == 82, "Replacement inventory monitor publication");
			RecoveredMethod42(RecoveredField1811.Key != recoveredField && RecoveredField1811.Pid == recoveredType5.Pid && RecoveredField1811.Created != recoveredType5.Created && !RecoveredField1811.RecoveredMethod509().Running, "Reused PID is a fresh stopped client with restored inventory");
			bool flag = false;
			try
			{
				RecoveredField1811.Peer.RecoveredMethod125(new RecoveredType318
				{
					Key = recoveredField,
					Action = "start",
					Profile = new RecoveredType170(),
					AutoFish = true
				}).GetAwaiter().GetResult();
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag && !first.Running && RecoveredField1811.Peer.Connected, "Stale closed-client commands cannot control the replacement");
			bool flag2 = false;
			try
			{
				RecoveredField1811.Peer.RecoveredMethod125(new RecoveredType318
				{
					Key = RecoveredField1811.Key,
					Action = "profile",
					Profile = new RecoveredType170
					{
						CastX = 2.0
					}
				}).GetAwaiter().GetResult();
			}
			catch
			{
				flag2 = true;
			}
			RecoveredMethod42(flag2 && RecoveredField1811.Peer.Connected, "Bad command acknowledged as error");
			using (TcpClient tcpClient = new TcpClient())
			{
				tcpClient.Connect(IPAddress.Loopback, port);
				using RecoveredType341 recoveredType6 = new RecoveredType341(tcpClient);
				RecoveredType313 recoveredType7 = RecoveredType341.RecoveredMethod833<RecoveredType313>(recoveredType6.RecoveredMethod470());
				recoveredType6.RecoveredMethod807(new RecoveredType312
				{
					WorkerId = Guid.NewGuid().ToString("N"),
					Name = "test",
					User = "test",
					SessionId = 1003,
					Proof = RecoveredType321.RecoveredMethod783(new string('b', 64), recoveredType7.Nonce)
				});
				bool flag3 = false;
				try
				{
					recoveredType6.RecoveredMethod470();
				}
				catch
				{
					flag3 = true;
				}
				RecoveredMethod42(flag3, "Incorrect pairing rejected");
			}
			second.Desktop = "Desktop locked";
			RecoveredMethod808(() => !second.Running, "Locked session releases input");
			second.Desktop = "Ready";
			RecoveredField1812.RecoveredMethod512(new RecoveredType170(), true).GetAwaiter().GetResult();
			hub.Dispose();
			hub = null;
			RecoveredMethod808(() => !second.Running && !first.Running, "Controller close stops workers");
			hub = new RecoveredType332(recoveredType2, controller, delegate
			{
			});
			RecoveredMethod808(() => hub.RecoveredMethod803().Count((RecoveredType327 P_0) => P_0.Connected) == 2, "Workers reconnect");
			RecoveredMethod42(!first.Running && !second.Running, "Reconnect never resumes fishing");
			hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795();
			RecoveredMethod808(() => hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()
				.Length == 1, "Reconnected account");
			RecoveredField1811 = hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == first.Id).RecoveredMethod795()[0];
			RecoveredField1811.RecoveredMethod512(new RecoveredType170(), true).GetAwaiter().GetResult();
			first.HangCommand = true;
			bool flag4 = false;
			try
			{
				RecoveredField1811.RecoveredMethod513().GetAwaiter().GetResult();
			}
			catch
			{
				flag4 = true;
			}
			RecoveredMethod42(flag4, "Unacknowledged command times out");
			RecoveredMethod808(() => !first.Running, "Timeout disconnect releases worker");
			RecoveredMethod42(!RecoveredField1811.RecoveredMethod509().Attached && !RecoveredField1811.Inventory.RecoveredMethod515().Valid, "Offline state disables start and marks inventory stale");
			first.HangCommand = false;
			RecoveredMethod808(() => hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == second.Id).RecoveredMethod795()
				.Length == 1, "Second account after reconnect");
			RecoveredField1812 = hub.RecoveredMethod803().First((RecoveredType327 P_0) => P_0.Id == second.Id).RecoveredMethod795()[0];
			RecoveredField1812.RecoveredMethod512(new RecoveredType170(), true).GetAwaiter().GetResult();
			timer.Dispose();
			timer = null;
			RecoveredMethod808(() => !second.Running, "Controller UI heartbeat expiry");
			first.Dispose();
			second.Dispose();
			RecoveredMethod808(() => !hub.RecoveredMethod803().Any((RecoveredType327 P_0) => P_0.Connected), "Disposed workers disconnect");
			hub.RecoveredMethod805(DateTime.UtcNow.AddSeconds(31.0));
			RecoveredMethod42(hub.RecoveredMethod803().Length == 0, "Dead worker sessions expire from the controller hub");
			File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: real loopback transport with two simulated session workers; mutual pairing, independent starts/stops, 81-item chunk assembly, PNG previews, live inventory/catch updates, deduplication, invalid command rejection, desktop-lock release, controller-close release, reconnect without auto-start, command timeout release, stale/offline state, controller UI lease expiry. No real game input was sent.\r\n");
			Console.WriteLine("PASS: controller + two simulated workers; inventory, preview, command, reconnect, and watchdog integration checks. No game input.");
		}
		finally
		{
			timer?.Dispose();
			if (first != null)
			{
				first.Dispose();
			}
			if (second != null)
			{
				second.Dispose();
			}
			if (hub != null)
			{
				hub.Dispose();
			}
			Thread.Sleep(250);
			RecoveredMethod48(text);
		}
	}

	[CompilerGenerated]
	private static int RecoveredMethod406(string P_0)
	{
		return P_0.Length;
	}

	[CompilerGenerated]
	private static void RecoveredMethod55()
	{
	}

	[CompilerGenerated]
	private static bool RecoveredMethod1(InventoryEntry P_0)
	{
		return P_0.Name == "Ope";
	}

	[CompilerGenerated]
	private static bool RecoveredMethod244(InventoryEntry P_0)
	{
		return P_0.Name == "Fruit Bag";
	}

	[CompilerGenerated]
	private static bool RecoveredMethod809(InventoryEntry P_0)
	{
		return P_0.Name == "Ope";
	}

	[CompilerGenerated]
	private static void RecoveredMethod422(string P_0)
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
	private static int RecoveredMethod353(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static int RecoveredMethod253(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static void RecoveredMethod56()
	{
	}
}
