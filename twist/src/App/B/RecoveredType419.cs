using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using a;

namespace b;

internal static class RecoveredType419
{
	private sealed class RecoveredType420 : RecoveredType208
	{
		private readonly Dictionary<ulong, byte> bytes = new Dictionary<ulong, byte>();

		public byte[] RecoveredMethod609(ulong P_0, int P_1)
		{
			byte[] array = new byte[P_1];
			for (int i = 0; i < P_1; i++)
			{
				bytes.TryGetValue(P_0 + (ulong)i, out array[i]);
			}
			return array;
		}

		public void RecoveredMethod610(ulong P_0, byte[] P_1)
		{
			for (int i = 0; i < P_1.Length; i++)
			{
				bytes[P_0 + (ulong)i] = P_1[i];
			}
		}

		public void RecoveredMethod612(ulong P_0, ulong P_1)
		{
			RecoveredMethod610(P_0, BitConverter.GetBytes(P_1));
		}
	}

	private sealed class RecoveredType421
	{
		public readonly RecoveredType420 Mem = new RecoveredType420();

		public readonly RecoveredType163 Map;

		public readonly RecoveredType285 Reader;

		public ulong Root;

		public ulong Workspace;

		public ulong Vendor;

		public ulong Prompt;

		public ulong Part;

		public ulong Character;

		private ulong next = 1048576uL;

		public RecoveredType421()
		{
			Dictionary<string, object> dictionary = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "offsets.json")));
			Dictionary<string, object> dictionary2 = (Dictionary<string, object>)dictionary["Offsets"];
			dictionary2["BasePart"] = new Dictionary<string, object> { { "Primitive", 376 } };
			dictionary2["Primitive"] = new Dictionary<string, object>
			{
				{ "Position", 212 },
				{ "Rotation", 176 }
			};
			dictionary2["ProximityPrompt"] = new Dictionary<string, object>
			{
				{ "ObjectText", 184 },
				{ "Enabled", 286 }
			};
			dictionary2["Attachment"] = new Dictionary<string, object> { { "Position", 172 } };
			dictionary2["Model"] = new Dictionary<string, object> { { "PrimaryPart", 576 } };
			Map = new RecoveredType163(new JavaScriptSerializer().Serialize(dictionary));
			Reader = new RecoveredType285(Mem, Map.Core);
			Root = RecoveredMethod554("Game", "DataModel");
			Workspace = RecoveredMethod554("Workspace", "Workspace");
			ulong num = RecoveredMethod554("Players", "Players");
			ulong num2 = RecoveredMethod554("Player", "Player");
			Character = RecoveredMethod554("Character", "Model");
			Part = RecoveredMethod554("HumanoidRootPart", "Part");
			Vendor = RecoveredMethod554("Bait stand", "Part");
			Prompt = RecoveredMethod554("Purchase", "ProximityPrompt");
			RecoveredMethod615(Root, Workspace, num);
			RecoveredMethod615(num, num2);
			RecoveredMethod615(Character, Part);
			RecoveredMethod615(Workspace, Character, Vendor);
			RecoveredMethod615(Vendor, Prompt);
			Mem.RecoveredMethod612(num + Map.Core.LocalPlayer, num2);
			Mem.RecoveredMethod612(num2 + Map.RecoveredMethod554("Player", "ModelInstance"), Character);
			RecoveredMethod905(Part, 0f, 0f, 0f);
			RecoveredMethod905(Vendor, 12f, 0f, 0f);
			RecoveredMethod48("Common Fish Bait");
			Mem.RecoveredMethod610(Prompt + 286, new byte[1] { 1 });
		}

		public ulong RecoveredMethod554(string P_0, string P_1)
		{
			ulong num = next;
			next += 16384uL;
			Mem.RecoveredMethod612(num + Map.Core.NameContainer, num + 2048);
			RecoveredMethod613(num + 2048 + Map.Core.Name, P_0);
			Mem.RecoveredMethod612(num + Map.Core.ClassDescriptor, num + 4096);
			Mem.RecoveredMethod612(num + 4096 + Map.Core.ClassName, num + 4352);
			RecoveredMethod613(num + 4352, P_1);
			return num;
		}

		private void RecoveredMethod613(ulong P_0, string P_1)
		{
			ulong num = next;
			next += 256uL;
			byte[] bytes = Encoding.UTF8.GetBytes(P_1);
			Mem.RecoveredMethod612(P_0 + Map.Core.StringLength, (ulong)bytes.Length);
			if (bytes.Length >= 16)
			{
				Mem.RecoveredMethod612(P_0, num);
				Mem.RecoveredMethod610(num, bytes);
			}
			else
			{
				Mem.RecoveredMethod610(P_0, bytes);
			}
		}

		public void RecoveredMethod615(ulong P_0, params ulong[] values)
		{
			Mem.RecoveredMethod612(P_0 + Map.Core.Children, P_0 + 6656);
			Mem.RecoveredMethod612(P_0 + 6656, P_0 + 6912);
			Mem.RecoveredMethod612(P_0 + 6656 + Map.Core.ChildrenEnd, P_0 + 6912 + (ulong)((long)values.Length * 16L));
			for (int i = 0; i < values.Length; i++)
			{
				Mem.RecoveredMethod612(P_0 + 6912 + (ulong)((long)i * 16L), values[i]);
				Mem.RecoveredMethod612(values[i] + Map.RecoveredMethod554("Instance", "Parent"), P_0);
			}
		}

		public void RecoveredMethod905(ulong P_0, float P_1, float P_2, float P_3)
		{
			Mem.RecoveredMethod612(P_0 + 376, P_0 + 8192);
			Mem.RecoveredMethod610(P_0 + 8192 + 212, new float[3] { P_1, P_2, P_3 }.SelectMany(BitConverter.GetBytes).ToArray());
			Mem.RecoveredMethod610(P_0 + 8192 + 176, new float[9] { 1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f }.SelectMany(BitConverter.GetBytes).ToArray());
		}

		public void RecoveredMethod48(string P_0)
		{
			RecoveredMethod613(Prompt + 184, P_0);
		}

		public RecoveredType397 RecoveredMethod906()
		{
			return new RecoveredType397(Mem, Reader, Map, Root);
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("World vendor: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		RecoveredType421 recoveredType = new RecoveredType421();
		RecoveredType397 recoveredType2 = recoveredType.RecoveredMethod906();
		RecoveredMethod42(recoveredType2.RecoveredMethod882(out var text), "inclusive 12-stud radius");
		recoveredType.RecoveredMethod905(recoveredType.Vendor, 12.1f, 0f, 0f);
		RecoveredMethod42(!recoveredType2.RecoveredMethod882(out text), "outside radius rejected using fresh position");
		recoveredType.RecoveredMethod905(recoveredType.Vendor, 0f, 6f, 8f);
		RecoveredMethod42(recoveredType2.RecoveredMethod882(out text), "3D distance includes height");
		RecoveredType420 recoveredField = recoveredType.Mem;
		ulong num = recoveredType.Prompt + 286;
		byte[] array = new byte[1];
		recoveredField.RecoveredMethod610(num, array);
		RecoveredMethod42(!recoveredType2.RecoveredMethod882(out text), "disabled vendor rejected");
		recoveredType.Mem.RecoveredMethod610(recoveredType.Prompt + 286, new byte[1] { 1 });
		recoveredType.RecoveredMethod48("Rare Fish Bait");
		RecoveredMethod42(!recoveredType2.RecoveredMethod882(out text), "wrong vendor rejected");
		recoveredType.RecoveredMethod48("Common Fish Bait");
		recoveredType.Mem.RecoveredMethod612(recoveredType.Prompt + recoveredType.Map.RecoveredMethod554("Instance", "Parent"), 0uL);
		RecoveredMethod42(!recoveredType2.RecoveredMethod882(out text), "removed cached vendor rejected");
		recoveredType = new RecoveredType421();
		ulong num2 = recoveredType.RecoveredMethod554("PromptAttachment", "Attachment");
		recoveredType.RecoveredMethod615(recoveredType.Vendor, num2);
		recoveredType.RecoveredMethod615(num2, recoveredType.Prompt);
		recoveredType.RecoveredMethod905(recoveredType.Vendor, 11f, 0f, 0f);
		recoveredType.Mem.RecoveredMethod610(num2 + 172, new float[3] { 2f, 0f, 0f }.SelectMany(BitConverter.GetBytes).ToArray());
		RecoveredMethod42(!recoveredType.RecoveredMethod906().RecoveredMethod882(out text), "attachment world offset puts prompt outside radius");
		recoveredType.Mem.RecoveredMethod610(num2 + 172, new float[3] { -2f, 0f, 0f }.SelectMany(BitConverter.GetBytes).ToArray());
		RecoveredMethod42(recoveredType.RecoveredMethod906().RecoveredMethod882(out text), "attachment prompt inside radius accepted");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: world Common bait vendor radius 12, live 3D positions, wrong/disabled/removed prompt rejection, attachment world transforms. Synthetic memory only; no real input.\r\n");
	}
}
