using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using A;
using B;
using a;

namespace c;

internal sealed class RecoveredType232 : RecoveredType214
{
	private sealed class RecoveredType233 : RecoveredType99
	{
		private readonly RecoveredType232 ui;

		private readonly ulong tool;

		public RecoveredType233(RecoveredType232 P_0, ulong P_1)
		{
			ui = P_0;
			tool = P_1;
		}

		public RecoveredType98 RecoveredMethod390()
		{
			ui.input.RecoveredMethod50();
			if (ui.RecoveredMethod622().Busy)
			{
				throw new Exception("Waiting for the current game menu to close before equipping fruit/rod.");
			}
			ulong num = ui.RecoveredMethod650(tool, false);
			ulong num2 = ui.RecoveredMethod471(ui.gui, "BackpackGui", "Backpack", "Inventory");
			RecoveredType98 recoveredType = new RecoveredType98();
			recoveredType.Carried = ui.RecoveredMethod647(tool);
			recoveredType.Equipped = ui.RecoveredMethod482(tool);
			recoveredType.Open = ui.RecoveredMethod572(ui.RecoveredMethod471(ui.gui, "BackpackGui", "Backpack"));
			recoveredType.Slot = ui.RecoveredMethod651(tool);
			recoveredType.ListReady = ui.RecoveredMethod653(num2);
			recoveredType.TileVisible = ui.RecoveredMethod572(num);
			recoveredType.SearchReady = RecoveredType285.RecoveredMethod572(ui.RecoveredMethod477());
			RecoveredType98 recoveredType2 = recoveredType;
			if (recoveredType2.ListReady)
			{
				recoveredType2.Viewport = ui.RecoveredMethod652(num2);
			}
			if (recoveredType2.TileVisible)
			{
				recoveredType2.Tile = ui.RecoveredMethod652(num);
				recoveredType2.TileVisible = recoveredType2.Tile.Width >= 2.0 && recoveredType2.Tile.Height >= 2.0;
			}
			return recoveredType2;
		}

		public void RecoveredMethod391(bool P_0, CancellationToken P_1)
		{
			ui.hover.RecoveredMethod45();
			ui.RecoveredMethod391(P_0, P_1);
		}

		public void RecoveredMethod392(CancellationToken P_0)
		{
			ui.RecoveredMethod658(tool, P_0);
		}

		public void RecoveredMethod393(int P_0, CancellationToken P_1)
		{
			ui.hover.RecoveredMethod45();
			if (!ui.RecoveredMethod647(tool) || ui.RecoveredMethod482(tool) || ui.RecoveredMethod622().BackpackOpen || ui.RecoveredMethod651(tool) != P_0)
			{
				throw new Exception("The exact hotbar slot changed before equipping.");
			}
			ui.log("Equipping " + ui.reader.RecoveredMethod754(tool) + " from hotbar " + P_0);
			ui.input.RecoveredMethod675(48 + P_0, 100, P_1);
		}

		public void RecoveredMethod394(CancellationToken P_0)
		{
			try
			{
				ui.RecoveredMethod656(() => ui.RecoveredMethod650(tool, false), delegate
				{
					RecoveredType98 recoveredType = RecoveredMethod390();
					return recoveredType.Carried && !recoveredType.Equipped && recoveredType.Open && recoveredType.ListReady && recoveredType.TileVisible && RecoveredMethod657(recoveredType.Tile, recoveredType.Viewport);
				}, P_0);
			}
			finally
			{
				ui.hover.RecoveredMethod45();
			}
		}

		public void RecoveredMethod395(int P_0, CancellationToken P_1)
		{
			ui.hover.RecoveredMethod45();
			RecoveredType98 recoveredType = RecoveredMethod390();
			if (!recoveredType.Carried || !recoveredType.Open || !recoveredType.ListReady)
			{
				throw new Exception("The backpack changed before scrolling.");
			}
			if (!recoveredType.Viewport.RecoveredMethod872(RecoveredType127.RecoveredMethod503(ui.window), out var num, out var num2))
			{
				throw new Exception("The backpack list is outside Roblox.");
			}
			ui.input.RecoveredMethod672(num, num2);
			ui.input.RecoveredMethod674(num, num2);
			ui.input.RecoveredMethod673(P_0);
		}

        public void ReportBackpackClickFailure(string reason)
        {
            string details;
            try
            {
                var client = RecoveredType127.RecoveredMethod503(ui.window);
                var node = ui.RecoveredMethod650(tool, false);
                var raw = RecoveredType381.RecoveredMethod871(ui.memory.RecoveredMethod609(node + 244, 16));
                details = ui.reader.RecoveredMethod754(tool)
                    + " · tile=" + raw.RecoveredField1938 + "," + raw.RecoveredField1939 + "," + raw.Width + "," + raw.Height
                    + " · client=" + client.Width + "x" + client.Height
                    + " · saved alignment=" + ui.profile.UiOffsetX + "," + ui.profile.UiOffsetY
                    + " · alignment bypassed=" + ui.ignoreBackpackAlignment;
            }
            catch (Exception error)
            {
                details = "Target details unavailable: " + error.Message;
            }
            ui.log("Backpack click failed · " + reason + " · " + details
                + " · Open Activity, choose Export TXT, save the log and attach it to github.com/stellsor/twist/issues/1.");
        }

        public void RecoverBackpackClick(CancellationToken cancellationToken)
        {
            ui.hover.RecoveredMethod45();
            ui.ignoreBackpackAlignment = true;
            ui.log("Backpack click recovery · reopening inventory and resolving the exact tool again with saved alignment bypassed for this equip attempt.");
            ui.RecoveredMethod391(false, cancellationToken);
            ui.RecoveredMethod395(250, cancellationToken);
            ui.RecoveredMethod391(true, cancellationToken);
            ui.RecoveredMethod395(450, cancellationToken);
        }

		public void RecoveredMethod396(int P_0, CancellationToken P_1)
		{
			ui.RecoveredMethod395(P_0, P_1);
		}

		[CompilerGenerated]
		private ulong RecoveredMethod665()
		{
			return ui.RecoveredMethod650(tool, false);
		}

		[CompilerGenerated]
		private bool RecoveredMethod666()
		{
			RecoveredType98 recoveredType = RecoveredMethod390();
			if (recoveredType.Carried && !recoveredType.Equipped && recoveredType.Open && recoveredType.ListReady && recoveredType.TileVisible)
			{
				return RecoveredMethod657(recoveredType.Tile, recoveredType.Viewport);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType235
	{
		public RecoveredType232 _003C_003E4__this;

		public ulong tool;

		public bool RecoveredMethod572(ulong P_0)
		{
			return _003C_003E4__this.RecoveredMethod649(P_0) == tool;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType236
	{
		public ulong character;

		public Dictionary<ulong, int> slots;

		public RecoveredType232 _003C_003E4__this;

		public RecoveredType211 RecoveredMethod620(ulong P_0)
		{
			return new RecoveredType211
			{
				Id = P_0,
				Name = _003C_003E4__this.reader.RecoveredMethod754(P_0),
				Fruit = _003C_003E4__this.RecoveredMethod606(P_0),
				Rod = RecoveredMethod39(_003C_003E4__this.reader.RecoveredMethod754(P_0)),
				Equipped = (_003C_003E4__this.reader.RecoveredMethod753(P_0 + _003C_003E4__this.map.RecoveredMethod554("Instance", "Parent")) == character),
				Slot = (slots.ContainsKey(P_0) ? slots[P_0] : (-1))
			};
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType237
	{
		public ulong header;

		public RecoveredType232 _003C_003E4__this;

		public bool RecoveredMethod387()
		{
			if (_003C_003E4__this.RecoveredMethod622().BackpackOpen)
			{
				return _003C_003E4__this.RecoveredMethod653(header);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType238
	{
		public ulong node;

		public RecoveredType232 _003C_003E4__this;

		public Func<ulong> resolve;

		public Func<bool> valid;

		public RecoveredType365 RecoveredMethod488()
		{
			if (!valid() || resolve() != node || !_003C_003E4__this.RecoveredMethod653(node))
			{
				return null;
			}
			return new RecoveredType365
			{
				Node = node,
				Rectangle = _003C_003E4__this.RecoveredMethod652(node),
				Client = RecoveredType127.RecoveredMethod503(_003C_003E4__this.window)
			};
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType239
	{
		public ulong search;

		public RecoveredType232 _003C_003E4__this;

		public ulong tool;

		public bool RecoveredMethod387()
		{
			if (_003C_003E4__this.RecoveredMethod647(tool) && _003C_003E4__this.RecoveredMethod622().BackpackOpen)
			{
				return _003C_003E4__this.RecoveredMethod477() == search;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType240
	{
		public RecoveredType239 CS_0024_003C_003E8__locals24;

		public ulong header;

		public bool RecoveredMethod387()
		{
			if (CS_0024_003C_003E8__locals24._003C_003E4__this.RecoveredMethod647(CS_0024_003C_003E8__locals24.tool) && CS_0024_003C_003E8__locals24._003C_003E4__this.RecoveredMethod622().BackpackOpen)
			{
				return CS_0024_003C_003E8__locals24._003C_003E4__this.RecoveredMethod653(header);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType241
	{
		public RecoveredType232 _003C_003E4__this;

		public ulong tool;

		public bool RecoveredMethod387()
		{
			return _003C_003E4__this.RecoveredMethod659(tool);
		}
	}

	private bool ignoreBackpackAlignment;

	private readonly RecoveredType384 uiText;

	private readonly RecoveredType366 hover;

	private readonly RecoveredType282 memory;

	private readonly RecoveredType285 reader;

	private readonly RecoveredType163 map;

	private readonly ulong model;

	private readonly ulong module;

	private readonly ulong player;

	private readonly ulong gui;

	private readonly string account;

	private readonly IntPtr window;

	private readonly RecoveredType245 input;

	private readonly RecoveredType170 profile;

	private readonly Action<string> log;

	private static readonly string[] Classes = new string[9] { "Frame", "CanvasGroup", "ScrollingFrame", "TextLabel", "TextButton", "TextBox", "ImageLabel", "ImageButton", "ViewportFrame" };

	private ulong Character => reader.RecoveredMethod753(player + map.RecoveredMethod554("Player", "ModelInstance"));

	public RecoveredType232(RecoveredType282 P_0, RecoveredType285 P_1, RecoveredType163 P_2, ulong P_3, ulong P_4, ulong P_5, ulong P_6, string P_7, IntPtr P_8, RecoveredType245 P_9, RecoveredType170 P_10, Action<string> P_11)
	{
		uiText = new RecoveredType384(P_0, P_1, P_2.Core.Version);
		hover = new RecoveredType366(P_9);
		memory = P_0;
		reader = P_1;
		map = P_2;
		model = P_3;
		module = P_4;
		player = P_5;
		gui = P_6;
		account = P_7;
		window = P_8;
		input = P_9;
		profile = P_10;
		log = P_11;
	}

	private ulong RecoveredMethod471(ulong P_0, params string[] names)
	{
		foreach (string text in names)
		{
			P_0 = reader.RecoveredMethod756(P_0, text);
			if (!RecoveredType285.RecoveredMethod572(P_0))
			{
				return 0uL;
			}
		}
		return P_0;
	}

	private bool RecoveredMethod572(ulong P_0)
	{
		HashSet<ulong> hashSet = new HashSet<ulong>();
		for (int i = 0; i < 40; i++)
		{
			if (!RecoveredType285.RecoveredMethod572(P_0))
			{
				break;
			}
			if (!hashSet.Add(P_0))
			{
				break;
			}
			string text = reader.RecoveredMethod607(P_0);
			ulong num = ((text == "ScreenGui") ? map.Core.Enabled : (Classes.Contains(text) ? map.Core.Visible : 0));
			if (num != 0)
			{
				byte[] array = memory.RecoveredMethod609(P_0 + num, 1);
				if (array == null || array[0] != 1)
				{
					return false;
				}
			}
			if (P_0 == gui)
			{
				return true;
			}
			P_0 = reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("Instance", "Parent"));
		}
		return false;
	}

	private string RecoveredMethod636(ulong P_0)
	{
		return uiText.RecoveredMethod636(P_0);
	}

	private string RecoveredMethod475(ulong P_0)
	{
		ulong num = reader.RecoveredMethod753(P_0 + 176);
		if (num < 2 || num > 2097152)
		{
			throw new Exception("Stored inventory is not ready.");
		}
		ulong num2 = ((num >= 16) ? reader.RecoveredMethod753(P_0 + 160) : (P_0 + 160));
		byte[] array = new byte[(uint)num];
		for (int i = 0; i < array.Length; i += 65536)
		{
			byte[] array2 = memory.RecoveredMethod609(num2 + (ulong)i, Math.Min(65536, array.Length - i));
			if (array2 == null)
			{
				throw new Exception("Stored inventory read failed.");
			}
			Buffer.BlockCopy(array2, 0, array, i, array2.Length);
		}
		return Encoding.UTF8.GetString(array);
	}

	private static bool RecoveredMethod39(string P_0)
	{
		if (P_0.IndexOf("Fishing Rod", StringComparison.OrdinalIgnoreCase) < 0)
		{
			return P_0.EndsWith(" Rod", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private bool RecoveredMethod606(ulong P_0)
	{
		if (reader.RecoveredMethod607(P_0) == "Tool" && reader.RecoveredMethod607(reader.RecoveredMethod756(P_0, "FruitEater")) == "Script")
		{
			return reader.RecoveredMethod607(reader.RecoveredMethod756(P_0, "FruitModel")) == "Model";
		}
		return false;
	}

	private bool RecoveredMethod647(ulong P_0)
	{
		ulong num = reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("Instance", "Parent"));
		if (RecoveredType285.RecoveredMethod572(num) && reader.RecoveredMethod607(P_0) == "Tool")
		{
			if (num != Character)
			{
				return num == RecoveredMethod471(player, "Backpack");
			}
			return true;
		}
		return false;
	}

	private bool RecoveredMethod482(ulong P_0)
	{
		if (RecoveredType285.RecoveredMethod572(Character) && RecoveredMethod647(P_0))
		{
			return reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("Instance", "Parent")) == Character;
		}
		return false;
	}

	private IEnumerable<ulong> RecoveredMethod648(ulong P_0, int P_1)
	{
		if (P_1 > 3)
		{
			yield break;
		}
		foreach (ulong child in reader.RecoveredMethod755(P_0))
		{
			if (reader.RecoveredMethod607(child) == "ImageButton" && reader.RecoveredMethod607(RecoveredMethod471(child, "ToolObject")) == "ObjectValue")
			{
				yield return child;
			}
			else
			{
				if (!(reader.RecoveredMethod607(child) == "Frame") && !(reader.RecoveredMethod607(child) == "ScrollingFrame"))
				{
					continue;
				}
				foreach (ulong item in RecoveredMethod648(child, P_1 + 1))
				{
					yield return item;
				}
			}
		}
	}

	private ulong RecoveredMethod649(ulong P_0)
	{
		return reader.RecoveredMethod753(RecoveredMethod471(P_0, "ToolObject") + 160);
	}

	private ulong RecoveredMethod650(ulong P_0, bool P_1)
	{
		return RecoveredMethod648(RecoveredMethod471(gui, "BackpackGui", P_1 ? "Hotbar" : "Backpack"), 0).FirstOrDefault((ulong num) => RecoveredMethod649(num) == P_0);
	}

	private int RecoveredMethod651(ulong P_0)
	{
		ulong num = RecoveredMethod650(P_0, true);
		if (!RecoveredType285.RecoveredMethod572(num))
		{
			return -1;
		}
		ulong num2 = reader.RecoveredMethod753(num + map.RecoveredMethod554("Instance", "Parent"));
		if (!int.TryParse(RecoveredMethod636(RecoveredMethod471(num2, "Number")), out var result) || result < 0 || result > 9)
		{
			return -1;
		}
		return result;
	}

	private RecoveredType381 RecoveredMethod652(ulong P_0)
	{
		var rectangle = RecoveredType381.RecoveredMethod871(memory.RecoveredMethod609(P_0 + 244, 16));
        return ignoreBackpackAlignment ? rectangle : RecoveredType382.RecoveredMethod874(rectangle, profile);
	}

	private bool RecoveredMethod653(ulong P_0)
	{
		if (!RecoveredMethod572(P_0))
		{
			return false;
		}
		try
		{
			double num;
			double num2;
			return RecoveredMethod652(P_0).RecoveredMethod872(RecoveredType127.RecoveredMethod503(window), out num, out num2);
		}
		catch
		{
			return false;
		}
	}

	private ulong RecoveredMethod654()
	{
		return RecoveredType222.RecoveredMethod633(gui, reader.RecoveredMethod755, reader.RecoveredMethod754, reader.RecoveredMethod607, RecoveredMethod636, RecoveredMethod653);
	}

	private bool RecoveredMethod655()
	{
		return RecoveredType285.RecoveredMethod572(RecoveredMethod654());
	}

	public RecoveredType212 RecoveredMethod622()
	{
		if (reader.RecoveredMethod649(module) != model)
		{
			throw new Exception("Game changed while handling fruit.");
		}
		RecoveredType212 recoveredType = new RecoveredType212();
		ulong num = RecoveredMethod471(player, "Backpack");
		ulong character = Character;
		Dictionary<ulong, int> slots = new Dictionary<ulong, int>();
		foreach (ulong item in RecoveredMethod648(RecoveredMethod471(gui, "BackpackGui", "Hotbar"), 0))
		{
			ulong num2 = reader.RecoveredMethod753(item + map.RecoveredMethod554("Instance", "Parent"));
			if (int.TryParse(RecoveredMethod636(RecoveredMethod471(num2, "Number")), out var result) && result >= 0 && result <= 9)
			{
				slots[RecoveredMethod649(item)] = result;
			}
		}
		recoveredType.Tools = (from P_0 in (from P_0 in reader.RecoveredMethod755(num).Concat(reader.RecoveredMethod755(character))
				where reader.RecoveredMethod607(P_0) == "Tool"
				select P_0).Distinct()
			select new RecoveredType211
			{
				Id = P_0,
				Name = reader.RecoveredMethod754(P_0),
				Fruit = RecoveredMethod606(P_0),
				Rod = RecoveredMethod39(reader.RecoveredMethod754(P_0)),
				Equipped = (reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("Instance", "Parent")) == character),
				Slot = (slots.ContainsKey(P_0) ? slots[P_0] : (-1))
			}).ToArray();
		try
		{
			ulong num3 = RecoveredMethod471(RecoveredMethod471(model, "ReplicatedStorage"), "Stats" + account, "Inventory", "Inventory");
			if (reader.RecoveredMethod607(num3) == "StringValue")
			{
				recoveredType.Stored = RecoveredType259.RecoveredMethod712(RecoveredMethod475(num3));
				recoveredType.InventoryReady = true;
			}
		}
		catch
		{
			recoveredType.InventoryReady = false;
		}
		recoveredType.BackpackOpen = RecoveredMethod572(RecoveredMethod471(gui, "BackpackGui", "Backpack"));
		recoveredType.StoreReady = RecoveredMethod655();
		recoveredType.Busy = RecoveredMethod572(RecoveredMethod471(gui, "NPCCHAT")) || RecoveredMethod572(RecoveredMethod471(gui, "Shop", "Frame", "count")) || RecoveredMethod572(RecoveredMethod471(gui, "Inventory", "Main")) || RecoveredMethod572(RecoveredMethod471(gui, "FishingUIBill", "Frame", "Player"));
		return recoveredType;
	}

	public void RecoveredMethod393(int P_0, CancellationToken P_1)
	{
		if (P_1.WaitHandle.WaitOne(P_0))
		{
			P_1.ThrowIfCancellationRequested();
		}
		hover.RecoveredMethod857(P_1);
	}

	private void RecoveredMethod395(int P_0, CancellationToken P_1)
	{
		RecoveredMethod393(P_0, P_1);
		input.RecoveredMethod50();
	}

	private void RecoveredMethod391(bool P_0, CancellationToken P_1)
	{
		if (RecoveredMethod622().BackpackOpen == P_0)
		{
			return;
		}
		hover.RecoveredMethod45();
		if (!P_0)
		{
			ulong header = RecoveredMethod471(gui, "BackpackGui", "Backpack", "Header", "HeaderText");
			if (!RecoveredMethod653(header))
			{
				throw new Exception("Waiting for the backpack header before closing its search field.");
			}
			try
			{
				RecoveredMethod656(() => RecoveredMethod471(gui, "BackpackGui", "Backpack", "Header", "HeaderText"), () => RecoveredMethod622().BackpackOpen && RecoveredMethod653(header), P_1);
			}
			finally
			{
				hover.RecoveredMethod45();
			}
		}
		input.RecoveredMethod675(192, 100, P_1);
		for (int num = 0; num < 25; num++)
		{
			RecoveredMethod395(100, P_1);
			if (RecoveredMethod622().BackpackOpen == P_0)
			{
				return;
			}
		}
		throw new Exception("Waiting for the backpack to " + (P_0 ? "open" : "close") + ".");
	}

	private void RecoveredMethod656(Func<ulong> P_0, Func<bool> P_1, CancellationToken P_2, Action P_3 = null, string P_4 = "fruit control")
	{
		RecoveredType381 recoveredType = default(RecoveredType381);
		RecoveredType381 recoveredType2 = default(RecoveredType381);
		ulong node = 0uL;
		ulong num = 0uL;
		int num2 = 0;
		for (int i = 0; i < 40; i++)
		{
			P_2.ThrowIfCancellationRequested();
			input.RecoveredMethod50();
			if (!P_1())
			{
				throw new Exception("The fruit control changed before clicking.");
			}
			node = P_0();
			if (RecoveredMethod653(node))
			{
				recoveredType2 = RecoveredMethod652(node);
				num2 = ((node == num && recoveredType2.RecoveredMethod873(recoveredType)) ? (num2 + 1) : 0);
				recoveredType = recoveredType2;
				num = node;
				if (num2 >= 3)
				{
					break;
				}
			}
			else
			{
				num2 = 0;
				num = 0uL;
			}
			RecoveredMethod395(100, P_2);
		}
		if (num2 < 3)
		{
			throw new Exception("Waiting for the fruit control to settle.");
		}
		if (!recoveredType2.RecoveredMethod872(RecoveredType127.RecoveredMethod503(window), out var num3, out var num4))
		{
			throw new Exception("The fruit control is outside Roblox.");
		}
		input.RecoveredMethod565(false, 0.0, 0.0);
		log("Moving to " + P_4);
		hover.RecoveredMethod853(() => (!P_1() || P_0() != node || !RecoveredMethod653(node)) ? null : new RecoveredType365
		{
			Node = node,
			Rectangle = RecoveredMethod652(node),
			Client = RecoveredType127.RecoveredMethod503(window)
		});
		try
		{
			hover.RecoveredMethod857(P_2, true);
			RecoveredMethod395(150, P_2);
			input.RecoveredMethod674(num3, num4);
			if (!P_1() || P_0() != node || !RecoveredMethod653(node) || !RecoveredMethod652(node).RecoveredMethod873(recoveredType2))
			{
				throw new Exception("The fruit control moved before the click.");
			}
			log("Clicking " + P_4);
			P_3?.Invoke();
			input.RecoveredMethod565(true, num3, num4);
			RecoveredMethod395(120, P_2);
		}
		finally
		{
			input.RecoveredMethod565(false, 0.0, 0.0);
		}
		RecoveredMethod395(250, P_2);
	}

	public static bool RecoveredMethod657(RecoveredType381 P_0, RecoveredType381 P_1)
	{
		if (P_0.RecoveredField1938 >= P_1.RecoveredField1938 + 1.0 && P_0.RecoveredField1939 >= P_1.RecoveredField1939 + 1.0 && P_0.RecoveredField1938 + P_0.Width <= P_1.RecoveredField1938 + P_1.Width - 1.0)
		{
			return P_0.RecoveredField1939 + P_0.Height <= P_1.RecoveredField1939 + P_1.Height - 1.0;
		}
		return false;
	}

	private ulong RecoveredMethod477()
	{
		return new ulong[2]
		{
			RecoveredMethod471(gui, "BackpackGui", "Backpack", "Search"),
			RecoveredMethod471(gui, "BackpackGui", "Backpack", "SearchButton", "HeaderText")
		}.FirstOrDefault((ulong P_0) => reader.RecoveredMethod607(P_0) == "TextBox" && RecoveredMethod653(P_0));
	}

	private void RecoveredMethod658(ulong P_0, CancellationToken P_1)
	{
		ulong search = RecoveredMethod477();
		if (!RecoveredType285.RecoveredMethod572(search))
		{
			return;
		}
		log("Recovering backpack filter for " + reader.RecoveredMethod754(P_0));
		try
		{
			RecoveredMethod656(() => RecoveredMethod477(), () => RecoveredMethod647(P_0) && RecoveredMethod622().BackpackOpen && RecoveredMethod477() == search, P_1);
			hover.RecoveredMethod45();
			if (!RecoveredMethod652(search).RecoveredMethod872(RecoveredType127.RecoveredMethod503(window), out var num, out var num2))
			{
				throw new Exception("The backpack search is outside Roblox.");
			}
			input.RecoveredMethod674(num, num2);
			if (!RecoveredMethod647(P_0) || !RecoveredMethod622().BackpackOpen || RecoveredMethod477() != search)
			{
				throw new Exception("The backpack search changed before clearing.");
			}
			input.RecoveredMethod394(P_1);
			RecoveredMethod395(300, P_1);
			ulong header = RecoveredMethod471(gui, "BackpackGui", "Backpack", "Header", "HeaderText");
			RecoveredMethod656(() => RecoveredMethod471(gui, "BackpackGui", "Backpack", "Header", "HeaderText"), () => RecoveredMethod647(P_0) && RecoveredMethod622().BackpackOpen && RecoveredMethod653(header), P_1);
		}
		finally
		{
			hover.RecoveredMethod45();
		}
	}

	public void RecoveredMethod623(ulong P_0, CancellationToken P_1)
	{
		P_1.ThrowIfCancellationRequested();
		hover.RecoveredMethod45();
		try
		{
			RecoveredType100.RecoveredMethod397(new RecoveredType233(this, P_0), P_1);
            if (ignoreBackpackAlignment) log("Backpack click recovered · exact fruit/rod equipped and backpack closed.");
		}
		finally
		{
            ignoreBackpackAlignment = false;
            hover.RecoveredMethod45();
		}
	}

	private bool RecoveredMethod659(ulong P_0)
	{
		string text = RecoveredType222.RecoveredMethod634(RecoveredMethod622(), P_0);
		if (text != "")
		{
			throw new Exception(text);
		}
		return true;
	}

	public void RecoveredMethod624(ulong P_0, Action P_1, CancellationToken P_2)
	{
		hover.RecoveredMethod45();
		string text = "";
		string text2 = "";
		for (int i = 0; i < 60; i++)
		{
			P_2.ThrowIfCancellationRequested();
			input.RecoveredMethod50();
			text = RecoveredType222.RecoveredMethod634(RecoveredMethod622(), P_0);
			if (text == "")
			{
				break;
			}
			if (text != text2)
			{
				log(text);
				text2 = text;
			}
			RecoveredMethod395(100, P_2);
		}
		if (text != "")
		{
			throw new Exception(text);
		}
		ulong num = RecoveredMethod654();
		RecoveredType381 recoveredType = RecoveredMethod652(num);
		log("Store Fruit target rect=" + recoveredType.RecoveredField1938.ToString("0.0") + "," + recoveredType.RecoveredField1939.ToString("0.0") + "," + recoveredType.Width.ToString("0.0") + "," + recoveredType.Height.ToString("0.0"));
		RecoveredMethod656(RecoveredMethod654, () => RecoveredMethod659(P_0), P_2, P_1, "Store Fruit");
	}

	public void RecoveredMethod625(ulong P_0, Action P_1, CancellationToken P_2)
	{
		P_2.ThrowIfCancellationRequested();
		input.RecoveredMethod50();
		RecoveredType212 recoveredType = RecoveredMethod622();
		RecoveredType211 recoveredType2 = recoveredType.RecoveredMethod620(P_0);
		if (recoveredType2 == null || !recoveredType2.Fruit || !recoveredType2.Equipped || recoveredType.BackpackOpen || recoveredType.Busy || !recoveredType.InventoryReady || recoveredType.RecoveredMethod403(recoveredType2.Name) <= 0)
		{
			throw new Exception("Duplicate ownership/equipped tool changed; no Backspace sent.");
		}
		string name = recoveredType2.Name;
		RecoveredMethod395(450, P_2);
		recoveredType = RecoveredMethod622();
		recoveredType2 = recoveredType.RecoveredMethod620(P_0);
		if (recoveredType2 == null || recoveredType2.Name != name || !recoveredType2.Fruit || !recoveredType2.Equipped || recoveredType.BackpackOpen || recoveredType.Busy || !recoveredType.InventoryReady || recoveredType.RecoveredMethod403(name) <= 0)
		{
			throw new Exception("Duplicate ownership changed while settling; no Backspace sent.");
		}
		input.RecoveredMethod45();
		P_1?.Invoke();
		input.RecoveredMethod675(8, 150, P_2);
	}

	public void RecoveredMethod50()
	{
		input.RecoveredMethod45();
	}

	[CompilerGenerated]
	private bool RecoveredMethod660(ulong P_0)
	{
		return reader.RecoveredMethod607(P_0) == "Tool";
	}

	[CompilerGenerated]
	private ulong RecoveredMethod661()
	{
		return RecoveredMethod471(gui, "BackpackGui", "Backpack", "Header", "HeaderText");
	}

	[CompilerGenerated]
	private bool RecoveredMethod662(ulong P_0)
	{
		if (reader.RecoveredMethod607(P_0) == "TextBox")
		{
			return RecoveredMethod653(P_0);
		}
		return false;
	}

	[CompilerGenerated]
	private ulong RecoveredMethod663()
	{
		return RecoveredMethod477();
	}

	[CompilerGenerated]
	private ulong RecoveredMethod664()
	{
		return RecoveredMethod471(gui, "BackpackGui", "Backpack", "Header", "HeaderText");
	}
}
