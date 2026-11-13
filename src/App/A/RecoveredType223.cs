using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace a;

internal static class RecoveredType223
{
	[CompilerGenerated]
	private sealed class RecoveredType224
	{
		public Dictionary<ulong, List<ulong>> children;

		public Dictionary<ulong, string> names;

		public Func<ulong, string> type;

		public HashSet<ulong> visible;

		private static Func<ulong, string> CS_0024_003C_003E9__CachedAnonymousMethodDelegate14;

		public ulong RecoveredMethod611()
		{
			return RecoveredType222.RecoveredMethod633(1uL, (ulong P_0) => children[P_0], (ulong P_0) => names[P_0], type, (ulong P_0) => "<b>Store Fruit</b>", (ulong P_0) => visible.Contains(P_0));
		}

		public List<ulong> RecoveredMethod635(ulong P_0)
		{
			return children[P_0];
		}

		public string RecoveredMethod636(ulong P_0)
		{
			return names[P_0];
		}

		private static string RecoveredMethod475(ulong P_0)
		{
			return "<b>Store Fruit</b>";
		}

		public bool RecoveredMethod606(ulong P_0)
		{
			return visible.Contains(P_0);
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Store Fruit control: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		Dictionary<ulong, List<ulong>> children = new Dictionary<ulong, List<ulong>>
		{
			{
				1uL,
				new List<ulong> { 2uL, 3uL }
			},
			{
				2uL,
				new List<ulong> { 4uL }
			},
			{
				3uL,
				new List<ulong> { 5uL }
			},
			{
				4uL,
				new List<ulong> { 6uL }
			},
			{
				5uL,
				new List<ulong> { 7uL }
			},
			{
				6uL,
				new List<ulong>()
			},
			{
				7uL,
				new List<ulong> { 8uL }
			},
			{
				8uL,
				new List<ulong>()
			}
		};
		Dictionary<ulong, string> names = new Dictionary<ulong, string>
		{
			{ 1uL, "PlayerGui" },
			{ 2uL, "StoreFruit" },
			{ 3uL, "StoreFruit" },
			{ 4uL, "Store" },
			{ 5uL, "Wrapper" },
			{ 6uL, "Text" },
			{ 7uL, "Store" },
			{ 8uL, "Caption" }
		};
		Func<ulong, string> type = delegate(ulong P_0)
		{
			switch (P_0)
			{
			default:
				return "Frame";
			case 6uL:
			case 8uL:
				return "TextLabel";
			case 4uL:
			case 7uL:
				return "ImageButton";
			}
		};
		HashSet<ulong> visible = new HashSet<ulong> { 1uL, 3uL, 5uL, 7uL, 8uL };
		Func<ulong> func = () => RecoveredType222.RecoveredMethod633(1uL, (ulong P_0) => children[P_0], (ulong P_0) => names[P_0], type, (ulong P_0) => "<b>Store Fruit</b>", (ulong P_0) => visible.Contains(P_0));
		RecoveredMethod42(func() == 7, "visible current button chosen over stale first root, including nested layout and renamed caption");
		visible.Remove(8uL);
		RecoveredMethod42(func() == 0, "hidden caption cannot authorize Store");
		RecoveredType212 recoveredType = new RecoveredType212();
		recoveredType.InventoryReady = true;
		recoveredType.StoreReady = true;
		recoveredType.Tools = new RecoveredType211[1]
		{
			new RecoveredType211
			{
				Id = 9uL,
				Fruit = true,
				Equipped = true,
				Name = "Hie"
			}
		};
		RecoveredType212 recoveredType2 = recoveredType;
		RecoveredMethod42(RecoveredType222.RecoveredMethod634(recoveredType2, 9uL) == "", "equipped unowned fruit and ready control authorize storage");
		recoveredType2.StoreReady = false;
		RecoveredMethod42(RecoveredType222.RecoveredMethod634(recoveredType2, 9uL).Contains("active Store Fruit"), "loading button gets specific waiting reason");
		recoveredType2.StoreReady = true;
		recoveredType2.BackpackOpen = true;
		RecoveredMethod42(RecoveredType222.RecoveredMethod634(recoveredType2, 9uL).Contains("backpack"), "backpack must close before storage");
		recoveredType2.BackpackOpen = false;
		recoveredType2.Stored["Hie"] = 1;
		RecoveredMethod42(RecoveredType222.RecoveredMethod634(recoveredType2, 9uL).Contains("already contains"), "ownership rechecked before storage");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: active Store Fruit duplicate-root recovery, wrapper/caption changes, hidden control rejection and precise equipment/backpack/inventory/ownership guards. Synthetic UI only; no real input.\r\n");
	}

	[CompilerGenerated]
	private static string RecoveredMethod472(ulong P_0)
	{
		switch (P_0)
		{
		default:
			return "Frame";
		case 6uL:
		case 8uL:
			return "TextLabel";
		case 4uL:
		case 7uL:
			return "ImageButton";
		}
	}
}
