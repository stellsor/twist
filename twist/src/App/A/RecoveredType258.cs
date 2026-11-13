using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Script.Serialization;
using A;
using B;
using TwistApp;
using c;

namespace a;

internal sealed class RecoveredType258 : IDisposable
{
	private readonly Process process;

	private readonly RecoveredType282 memory;

	private readonly RecoveredType285 reader;

	private readonly RecoveredType163 map;

	private readonly Dictionary<string, ItemMetadata> metadata = new Dictionary<string, ItemMetadata>(StringComparer.Ordinal);

	private readonly Dictionary<string, ulong> models = new Dictionary<string, ulong>(StringComparer.Ordinal);

	private readonly Dictionary<string, string> raritySignatures = new Dictionary<string, string>(StringComparer.Ordinal);

	private readonly HashSet<string> previewAttempted = new HashSet<string>(StringComparer.Ordinal);

	private readonly HashSet<string> fishMeshes = new HashSet<string>(StringComparer.Ordinal);

	private readonly HashSet<string> fishNames = new HashSet<string>(StringComparer.Ordinal);

	private ulong model;

	private ulong storage;

	private ulong player;

	private ulong gui;

	private ulong value;

	private DateTime lastFishing = DateTime.MinValue;

	private DateTime lastMeshes = DateTime.MinValue;

	public string Account;

	public string UserId;

	public bool FishingRecently => DateTime.UtcNow - lastFishing < TimeSpan.FromSeconds(8.0);

	public RecoveredType258(int P_0, long P_1, RecoveredType163 P_2)
	{
		process = Process.GetProcessById(P_0);
		map = P_2;
		try
		{
			if (process.StartTime.ToUniversalTime().Ticks != P_1 || process.MainModule.FileName.IndexOf(map.Core.Version, StringComparison.OrdinalIgnoreCase) < 0)
			{
				throw new Exception("Client version or identity changed.");
			}
			memory = new RecoveredType282(P_0);
			reader = new RecoveredType285(memory, map.Core);
			model = reader.RecoveredMethod649((ulong)process.MainModule.BaseAddress.ToInt64());
			if (reader.RecoveredMethod753(model + map.RecoveredMethod554("DataModel", "GameId")) != 648454481)
			{
				throw new Exception("Join GPO to read its inventory.");
			}
			storage = reader.RecoveredMethod756(model, "ReplicatedStorage");
			player = reader.RecoveredMethod753(reader.RecoveredMethod756(model, "Players") + map.Core.LocalPlayer);
			Account = reader.RecoveredMethod754(player);
			UserId = reader.RecoveredMethod753(player + map.RecoveredMethod554("Player", "UserId")).ToString();
			gui = reader.RecoveredMethod757(model);
			RecoveredMethod45();
			value = RecoveredMethod471(storage, "Stats" + Account, "Inventory", "Inventory");
			if (reader.RecoveredMethod607(value) != "StringValue")
			{
				throw new Exception("The replicated inventory is not ready.");
			}
			RecoveredMethod50();
		}
		catch
		{
			if (memory != null)
			{
				memory.Dispose();
			}
			process.Dispose();
			throw;
		}
	}

	private void RecoveredMethod45()
	{
		try
		{
			string path = Path.Combine(RecoveredType309.Base, "data", "item-catalog.json");
			if (!File.Exists(path))
			{
				return;
			}
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			javaScriptSerializer.MaxJsonLength = 8388608;
			ItemMetadata[] array = javaScriptSerializer.Deserialize<ItemMetadata[]>(File.ReadAllText(path));
			if (array == null)
			{
				return;
			}
			ItemMetadata[] array2 = array;
			foreach (ItemMetadata itemMetadata in array2)
			{
				if (itemMetadata != null && !string.IsNullOrEmpty(itemMetadata.Name))
				{
					metadata[itemMetadata.Name] = itemMetadata;
				}
			}
		}
		catch
		{
		}
	}

	private ulong RecoveredMethod471(ulong P_0, params string[] names)
	{
		foreach (string text in names)
		{
			if (!RecoveredType285.RecoveredMethod572(P_0))
			{
				return 0uL;
			}
			P_0 = reader.RecoveredMethod756(P_0, text);
		}
		return P_0;
	}

	private string RecoveredMethod474(ulong P_0, int P_1)
	{
		if (!RecoveredType285.RecoveredMethod572(P_0))
		{
			return "";
		}
		ulong num = reader.RecoveredMethod753(P_0 + 16);
		if (num == 0)
		{
			return "";
		}
		if (num > (ulong)P_1)
		{
			return "";
		}
		ulong num2 = ((num >= 16) ? reader.RecoveredMethod753(P_0) : P_0);
		byte[] array = new byte[(uint)num];
		for (int i = 0; i < array.Length; i += 65536)
		{
			int num3 = Math.Min(65536, array.Length - i);
			byte[] array2 = memory.RecoveredMethod609(num2 + (ulong)i, num3);
			if (array2 == null)
			{
				return "";
			}
			Buffer.BlockCopy(array2, 0, array, i, num3);
		}
		return Encoding.UTF8.GetString(array);
	}

	private string RecoveredMethod699(ulong P_0, ulong P_1)
	{
		ulong num = reader.RecoveredMethod753(P_0 + P_1);
		ulong[] array = new ulong[4]
		{
			P_0 + P_1,
			num,
			RecoveredType285.RecoveredMethod572(num) ? (num + 8) : 0,
			RecoveredType285.RecoveredMethod572(num) ? (num + 16) : 0
		};
		foreach (ulong num2 in array)
		{
			string text = RecoveredMethod474(num2, 512);
			if (text.StartsWith("rbxassetid://", StringComparison.Ordinal) || text.StartsWith("rbxasset://", StringComparison.Ordinal) || text.StartsWith("https://", StringComparison.Ordinal))
			{
				return text;
			}
		}
		return "";
	}

	private float[] RecoveredMethod700(ulong P_0, int P_1)
	{
		byte[] array = memory.RecoveredMethod609(P_0, P_1 * 4);
		if (array == null)
		{
			return new float[0];
		}
		float[] array2 = new float[P_1];
		for (int i = 0; i < P_1; i++)
		{
			array2[i] = BitConverter.ToSingle(array, i * 4);
			if (float.IsNaN(array2[i]) || float.IsInfinity(array2[i]) || Math.Abs(array2[i]) > 1000000f)
			{
				return new float[0];
			}
		}
		return array2;
	}

	private string RecoveredMethod472(ulong P_0)
	{
		if (reader.RecoveredMethod607(P_0) != "UIGradient")
		{
			return "";
		}
		ulong num = reader.RecoveredMethod753(P_0 + 240);
		byte[] array = memory.RecoveredMethod609(P_0 + 248, 4);
		if (array == null)
		{
			return "";
		}
		int num2 = BitConverter.ToInt32(array, 0);
		if (num2 < 2 || num2 > 32)
		{
			return "";
		}
		byte[] array2 = memory.RecoveredMethod609(num, num2 * 20);
		if (array2 == null)
		{
			return "";
		}
		float num3 = -1f;
		for (int i = 0; i < num2; i++)
		{
			float num4 = BitConverter.ToSingle(array2, i * 20);
			if (float.IsNaN(num4) || num4 < num3 || num4 < 0f || num4 > 1f)
			{
				return "";
			}
			num3 = num4;
			for (int j = 1; j < 4; j++)
			{
				float num5 = BitConverter.ToSingle(array2, i * 20 + j * 4);
				if (float.IsNaN(num5) || num5 < 0f || num5 > 1f)
				{
					return "";
				}
			}
		}
		return Convert.ToBase64String(array2);
	}

	private void RecoveredMethod50()
	{
		ulong num = reader.RecoveredMethod756(storage, "Tools");
		foreach (ulong item in reader.RecoveredMethod755(num))
		{
			models[reader.RecoveredMethod754(item)] = item;
		}
		ulong num2 = RecoveredMethod471(storage, "Modules", "Client", "ItemDisplay", "Gradients");
		foreach (ulong item2 in reader.RecoveredMethod755(num2))
		{
			string text = RecoveredMethod472(item2);
			if (text != "")
			{
				raritySignatures[text] = reader.RecoveredMethod754(item2);
			}
		}
		ulong num3 = RecoveredMethod471(storage, "Fishing", "Assets", "Rewards");
		foreach (ulong item3 in reader.RecoveredMethod755(num3))
		{
			if (reader.RecoveredMethod607(item3) != "Model" || !reader.RecoveredMethod755(item3).Any((ulong P_0) => reader.RecoveredMethod607(P_0) == "AnimationController"))
			{
				continue;
			}
			fishNames.Add(reader.RecoveredMethod754(item3));
			if (!models.ContainsKey(reader.RecoveredMethod754(item3)))
			{
				models[reader.RecoveredMethod754(item3)] = item3;
			}
			List<VisualPart> list = new List<VisualPart>();
			RecoveredMethod701(item3, 0, list);
			foreach (VisualPart item4 in list)
			{
				if (item4.Mesh != "")
				{
					fishMeshes.Add(item4.Mesh);
				}
			}
		}
	}

	private void RecoveredMethod701(ulong P_0, int P_1, List<VisualPart> P_2)
	{
		if (P_1 > 8 || P_2.Count >= 96)
		{
			return;
		}
		string text = reader.RecoveredMethod607(P_0);
		switch (text)
		{
		case "MeshPart":
		case "Part":
		case "UnionOperation":
		case "WedgePart":
		{
			byte[] array = memory.RecoveredMethod609(P_0 + 280, 4);
			float num = ((array == null) ? 0f : BitConverter.ToSingle(array, 0));
			ulong num2 = reader.RecoveredMethod753(P_0 + 376);
			float[] array2 = RecoveredMethod700(num2 + 212, 3);
			float[] array3 = RecoveredMethod700(num2 + 176, 9);
			float[] array4 = RecoveredMethod700(num2 + 452, 3);
			if (array2.Length != 3 || array3.Length != 9 || array4.Length != 3 || !array4.All((float num3) => num3 > 0f && num3 < 10000f) || (num >= 0.98f && num <= 1f) || !(reader.RecoveredMethod754(P_0) != "HumanoidRootPart"))
			{
				break;
			}
			string mesh = ((text == "MeshPart") ? RecoveredMethod699(P_0, 760uL) : "");
			string texture = ((text == "MeshPart") ? RecoveredMethod699(P_0, 808uL) : "");
			foreach (ulong item in reader.RecoveredMethod755(P_0))
			{
				string text2 = reader.RecoveredMethod607(item);
				if (text2 == "SurfaceAppearance")
				{
					string text3 = RecoveredMethod699(item, 176uL);
					if (text3 != "")
					{
						texture = text3;
					}
				}
				if (text2 == "SpecialMesh")
				{
					mesh = RecoveredMethod699(item, 224uL);
					texture = RecoveredMethod699(item, 272uL);
				}
				if (text2 == "Decal")
				{
					string text4 = RecoveredMethod699(item, 456uL);
					if (text4 != "")
					{
						texture = text4;
					}
				}
			}
			P_2.Add(new VisualPart
			{
				Mesh = mesh,
				Texture = texture,
				Position = array2,
				Rotation = array3,
				Size = array4
			});
			break;
		}
		}
		foreach (ulong item2 in reader.RecoveredMethod755(P_0))
		{
			RecoveredMethod701(item2, P_1 + 1, P_2);
		}
	}

	private ItemMetadata RecoveredMethod702(string P_0)
	{
		if (!metadata.TryGetValue(P_0, out var itemMetadata))
		{
			ItemMetadata itemMetadata2 = new ItemMetadata();
			itemMetadata2.Name = P_0;
			itemMetadata = itemMetadata2;
		}
		if (itemMetadata.Parts.Count == 0 && previewAttempted.Add(P_0))
		{
			if (models.TryGetValue(P_0, out var num) || (P_0.EndsWith(" Eternal Pose", StringComparison.Ordinal) && models.TryGetValue("Eternal Pose", out num)))
			{
				RecoveredMethod701(num, 0, itemMetadata.Parts);
				itemMetadata.Category = ((fishNames.Contains(P_0) || itemMetadata.Parts.Any((VisualPart visualPart) => fishMeshes.Contains(visualPart.Mesh))) ? "Fish" : "Item");
			}
			else if (fishNames.Contains(P_0))
			{
				itemMetadata.Category = "Fish";
			}
		}
		RecoveredType210.RecoveredMethod619(itemMetadata);
		RecoveredType219.RecoveredMethod619(itemMetadata);
		metadata[P_0] = itemMetadata;
		return itemMetadata;
	}

	private void RecoveredMethod703(IDictionary<string, int> P_0)
	{
		ulong num = RecoveredMethod471(gui, "Inventory", "Main", "Inventory", "List");
		foreach (ulong item in reader.RecoveredMethod755(num))
		{
			string text = reader.RecoveredMethod754(item);
			if (!P_0.ContainsKey(text) || reader.RecoveredMethod607(item) != "ImageButton")
			{
				continue;
			}
			ItemMetadata itemMetadata = RecoveredMethod702(text);
			string text2 = RecoveredMethod472(RecoveredMethod471(item, "ItemName", "ItemRare"));
			if (text2 != "" && raritySignatures.TryGetValue(text2, out var rarity))
			{
				itemMetadata.Rarity = rarity;
			}
			ulong num2 = RecoveredMethod471(item, "Display");
			if (itemMetadata.Parts.Count == 0)
			{
				RecoveredMethod701(num2, 0, itemMetadata.Parts);
				if (itemMetadata.Parts.Count > 0)
				{
					itemMetadata.Category = (itemMetadata.Parts.Any((VisualPart visualPart) => fishMeshes.Contains(visualPart.Mesh)) ? "Fish" : "Item");
				}
			}
			foreach (ulong item2 in reader.RecoveredMethod755(num2))
			{
				if (!(reader.RecoveredMethod607(item2) != "ImageLabel") && !new string[3] { "FavIcon", "Border", "vanityDisplay" }.Contains(reader.RecoveredMethod754(item2)))
				{
					string text3 = RecoveredMethod699(item2, 2520uL);
					if (text3 != "")
					{
						itemMetadata.Image = text3;
					}
				}
			}
			RecoveredType210.RecoveredMethod619(itemMetadata);
		}
	}

	public InventorySnapshot RecoveredMethod704()
	{
		if (process.HasExited)
		{
			throw new Exception("Roblox closed.");
		}
		if (reader.RecoveredMethod649((ulong)process.MainModule.BaseAddress.ToInt64()) != model)
		{
			throw new Exception("Game changed; reconnecting inventory.");
		}
		if (reader.RecoveredMethod753(value + map.RecoveredMethod554("Instance", "Parent")) == 0)
		{
			throw new Exception("Inventory source changed; reconnecting.");
		}
		string text = RecoveredMethod474(value + 160, 2097152);
		if (text == "")
		{
			text = RecoveredMethod474(reader.RecoveredMethod753(value + 160), 2097152);
		}
		Dictionary<string, int> dictionary = RecoveredType259.RecoveredMethod712(text);
		RecoveredMethod703(dictionary);
		ulong num = reader.RecoveredMethod756(gui, "FishingUIBill");
		ulong num2 = RecoveredMethod471(num, "Frame");
		ulong num3 = RecoveredMethod471(num2, "Player");
		ulong num4 = RecoveredMethod471(num2, "Goal");
		byte[] array = memory.RecoveredMethod609(num2 + map.Core.Visible, 1);
		byte[] array2 = memory.RecoveredMethod609(num3 + map.Core.Visible, 1);
		byte[] array3 = memory.RecoveredMethod609(num4 + map.Core.Visible, 1);
		if (RecoveredType285.RecoveredMethod572(num2) && RecoveredType285.RecoveredMethod572(num3) && RecoveredType285.RecoveredMethod572(num4) && array != null && array[0] == 1 && array2 != null && array2[0] == 1 && array3 != null && array3[0] == 1)
		{
			lastFishing = DateTime.UtcNow;
		}
		InventoryEntry[] array4 = dictionary.Select((KeyValuePair<string, int> P_0) => new InventoryEntry
		{
			Name = P_0.Key,
			Count = P_0.Value,
			Metadata = RecoveredMethod702(P_0.Key)
		}).OrderBy((InventoryEntry P_0) => P_0.Name, StringComparer.OrdinalIgnoreCase).ToArray();
		if (DateTime.UtcNow - lastMeshes > TimeSpan.FromSeconds(15.0))
		{
			lastMeshes = DateTime.UtcNow;
			try
			{
				RecoveredType135.RecoveredMethod518(memory, reader, model, array4.SelectMany((InventoryEntry P_0) => P_0.Metadata.Parts.Select((VisualPart visualPart) => visualPart.Mesh)), Path.Combine(RecoveredType309.Base, "assets", "icons", "raw"));
			}
			catch
			{
			}
		}
		InventorySnapshot inventorySnapshot = new InventorySnapshot();
		inventorySnapshot.Account = Account;
		inventorySnapshot.UserId = UserId;
		inventorySnapshot.Items = array4;
		inventorySnapshot.Valid = true;
		inventorySnapshot.Updated = DateTime.UtcNow;
		inventorySnapshot.Status = "Live · ReplicatedStorage";
		return inventorySnapshot;
	}

	public void Dispose()
	{
		memory.Dispose();
		process.Dispose();
	}

	[CompilerGenerated]
	private bool RecoveredMethod473(ulong P_0)
	{
		return reader.RecoveredMethod607(P_0) == "AnimationController";
	}

	[CompilerGenerated]
	private static bool RecoveredMethod705(float P_0)
	{
		if (P_0 > 0f)
		{
			return P_0 < 10000f;
		}
		return false;
	}

	[CompilerGenerated]
	private bool RecoveredMethod706(VisualPart P_0)
	{
		return fishMeshes.Contains(P_0.Mesh);
	}

	[CompilerGenerated]
	private bool RecoveredMethod707(VisualPart P_0)
	{
		return fishMeshes.Contains(P_0.Mesh);
	}

	[CompilerGenerated]
	private InventoryEntry RecoveredMethod708(KeyValuePair<string, int> P_0)
	{
		return new InventoryEntry
		{
			Name = P_0.Key,
			Count = P_0.Value,
			Metadata = RecoveredMethod702(P_0.Key)
		};
	}

	[CompilerGenerated]
	private static string RecoveredMethod709(InventoryEntry P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static IEnumerable<string> RecoveredMethod710(InventoryEntry P_0)
	{
		return P_0.Metadata.Parts.Select((VisualPart visualPart) => visualPart.Mesh);
	}

	[CompilerGenerated]
	private static string RecoveredMethod711(VisualPart P_0)
	{
		return P_0.Mesh;
	}
}
