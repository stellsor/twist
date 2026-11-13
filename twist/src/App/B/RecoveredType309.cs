using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using TwistApp;
using a;

namespace B;

internal static class RecoveredType309
{
	public static RecoveredType308 Mode;

	public static string Folder;

	public static int SessionId
	{
		get
		{
			using Process process = Process.GetCurrentProcess();
			return process.SessionId;
		}
	}

	public static string Base => Folder ?? AppDomain.CurrentDomain.BaseDirectory;

	public static void RecoveredMethod778(RecoveredType308 P_0)
	{
		Mode = P_0;
		Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "twist-rdp", (P_0 == RecoveredType308.Worker) ? ("worker-" + SessionId) : P_0.ToString().ToLowerInvariant());
		Directory.CreateDirectory(Folder);
		string[] array = new string[5] { "profiles", "data", "assets\\icons", "assets\\icons\\raw", "logs" };
		foreach (string path in array)
		{
			Directory.CreateDirectory(Path.Combine(Folder, path));
		}
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		string[] array2 = new string[2] { "assets", "profiles" };
		foreach (string path2 in array2)
		{
			string text = Path.Combine(baseDirectory, path2);
			if (!Directory.Exists(text))
			{
				continue;
			}
			string[] files = Directory.GetFiles(text, "*", SearchOption.AllDirectories);
			foreach (string text2 in files)
			{
				string path3 = text2.Substring(text.Length + 1);
				string text3 = Path.Combine(Folder, path2, path3);
				Directory.CreateDirectory(Path.GetDirectoryName(text3));
				if (!File.Exists(text3))
				{
					File.Copy(text2, text3);
				}
			}
		}
		string text4 = Path.Combine(Folder, "data", "item-catalog.json");
		if (!File.Exists(text4) && File.Exists(Path.Combine(baseDirectory, "data", "item-catalog.json")))
		{
			File.Copy(Path.Combine(baseDirectory, "data", "item-catalog.json"), text4);
		}
		try
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			javaScriptSerializer.MaxJsonLength = 16000000;
			JavaScriptSerializer javaScriptSerializer2 = javaScriptSerializer;
			Dictionary<string, ItemMetadata> dictionary = javaScriptSerializer2.Deserialize<ItemMetadata[]>(File.ReadAllText(text4)).ToDictionary((ItemMetadata itemMetadata2) => itemMetadata2.Name, StringComparer.Ordinal);
			ItemMetadata[] array3 = javaScriptSerializer2.Deserialize<ItemMetadata[]>(File.ReadAllText(Path.Combine(baseDirectory, "data", "item-catalog.json")));
			bool flag = false;
			ItemMetadata[] array4 = array3;
			foreach (ItemMetadata itemMetadata in array4)
			{
				if (!dictionary.TryGetValue(itemMetadata.Name, out var value))
				{
					dictionary[itemMetadata.Name] = itemMetadata;
					flag = true;
				}
				else if (value.Rarity == "Unknown" && itemMetadata.Rarity != "Unknown")
				{
					value.Rarity = itemMetadata.Rarity;
					flag = true;
				}
			}
			foreach (ItemMetadata value2 in dictionary.Values)
			{
				string category = value2.Category;
				string rarity = value2.Rarity;
				RecoveredType210.RecoveredMethod619(value2);
				RecoveredType219.RecoveredMethod619(value2);
				if (category != value2.Category || rarity != value2.Rarity)
				{
					flag = true;
				}
			}
			if (flag)
			{
				File.WriteAllText(text4, javaScriptSerializer2.Serialize(dictionary.Values.ToArray()));
			}
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	private static string RecoveredMethod254(ItemMetadata P_0)
	{
		return P_0.Name;
	}
}
