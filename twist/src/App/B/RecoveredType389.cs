using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace b;

internal static class RecoveredType389
{
	private sealed class RecoveredType390
	{
		public string Name;

		public string Class = "Frame";

		public string Text = "";

		public bool Visible = true;

		public List<ulong> Children = new List<ulong>();
	}

	[CompilerGenerated]
	private sealed class RecoveredType391
	{
		public Dictionary<ulong, RecoveredType390> nodes;

		public bool RecoveredMethod387()
		{
			return RecoveredType387.RecoveredMethod876(1uL, (ulong P_0) => nodes[P_0].Children, (ulong P_0) => nodes[P_0].Name, (ulong P_0) => nodes[P_0].Class, (ulong P_0) => nodes[P_0].Text, (ulong P_0) => nodes[P_0].Visible);
		}

		public List<ulong> RecoveredMethod635(ulong P_0)
		{
			return nodes[P_0].Children;
		}

		public string RecoveredMethod636(ulong P_0)
		{
			return nodes[P_0].Name;
		}

		public string RecoveredMethod475(ulong P_0)
		{
			return nodes[P_0].Class;
		}

		public string RecoveredMethod754(ulong P_0)
		{
			return nodes[P_0].Text;
		}

		public bool RecoveredMethod647(ulong P_0)
		{
			return nodes[P_0].Visible;
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Vendor prompt: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		Dictionary<ulong, RecoveredType390> nodes = new Dictionary<ulong, RecoveredType390>
		{
			{
				1uL,
				new RecoveredType390
				{
					Name = "PlayerGui",
					Children = new List<ulong> { 2uL, 3uL, 9uL }
				}
			},
			{
				2uL,
				new RecoveredType390
				{
					Name = "ProximityPrompts",
					Visible = false,
					Children = new List<ulong> { 4uL }
				}
			},
			{
				3uL,
				new RecoveredType390
				{
					Name = "ProximityPrompts",
					Children = new List<ulong> { 5uL }
				}
			},
			{
				4uL,
				new RecoveredType390
				{
					Name = "ObjectText",
					Class = "TextLabel",
					Visible = false,
					Text = "Common Fish Bait"
				}
			},
			{
				5uL,
				new RecoveredType390
				{
					Name = "Billboard",
					Children = new List<ulong> { 6uL }
				}
			},
			{
				6uL,
				new RecoveredType390
				{
					Name = "Wrapper",
					Children = new List<ulong> { 7uL }
				}
			},
			{
				7uL,
				new RecoveredType390
				{
					Name = "PromptFrame",
					Children = new List<ulong> { 8uL }
				}
			},
			{
				8uL,
				new RecoveredType390
				{
					Name = "ObjectText",
					Class = "TextLabel",
					Text = "<b>Common Fish Bait</b>\n"
				}
			},
			{
				9uL,
				new RecoveredType390
				{
					Name = "FishingBaitGui",
					Children = new List<ulong> { 10uL }
				}
			},
			{
				10uL,
				new RecoveredType390
				{
					Name = "ObjectText",
					Class = "TextLabel",
					Text = "Common Fish Bait"
				}
			}
		};
		Func<bool> func = () => RecoveredType387.RecoveredMethod876(1uL, (ulong P_0) => nodes[P_0].Children, (ulong P_0) => nodes[P_0].Name, (ulong P_0) => nodes[P_0].Class, (ulong P_0) => nodes[P_0].Text, (ulong P_0) => nodes[P_0].Visible);
		RecoveredMethod42(func(), "active second container and nested rich-text prompt detected");
		nodes[8uL].Visible = false;
		RecoveredMethod42(!func(), "hidden prompts and unrelated bait menu do not authorize E");
		nodes[8uL].Visible = true;
		nodes[8uL].Text = "Rare Fish Bait";
		RecoveredMethod42(!func(), "wrong vendor rejected");
		nodes[8uL].Text = "Common Fish Baits";
		RecoveredMethod42(func(), "plural vendor label supported");
		nodes[8uL].Text = "Common Fish Bait vendor unavailable";
		RecoveredMethod42(!func(), "partial text rejected");
		nodes[8uL].Text = "Common Fish Bait";
		nodes[8uL].Name = "ToolText";
		RecoveredMethod42(!func(), "only prompt object label can identify vendor");
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: duplicate prompt containers, nested layout, rich text/whitespace, hidden/wrong/unrelated vendor rejection. Synthetic UI tree only; no game input.\r\n");
	}
}
