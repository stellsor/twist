using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TwistApp;
using a;
using c;

namespace b;

internal sealed class RecoveredType410 : IDisposable
{
	private readonly Process process;

	private readonly RecoveredType282 memory;

	private readonly RecoveredType285 reader;

	private readonly RecoveredType163 map;

	private readonly ulong model;

	private readonly ulong player;

	private readonly ulong module;

	private readonly string account;

	private readonly RecoveredType197 pulseTracker = new RecoveredType197();

	private RecoveredType204 eyeReader;

	private int revision;

	public RecoveredType410(int P_0, long P_1, RecoveredType163 P_2)
	{
		map = P_2;
		process = Process.GetProcessById(P_0);
		try
		{
			if (process.StartTime.ToUniversalTime().Ticks != P_1 || process.MainModule.FileName.IndexOf(map.Core.Version, StringComparison.OrdinalIgnoreCase) < 0)
			{
				throw new Exception("World reader client changed");
			}
			module = (ulong)process.MainModule.BaseAddress.ToInt64();
			memory = new RecoveredType282(P_0);
			reader = new RecoveredType285(memory, map.Core);
			model = reader.RecoveredMethod649(module);
			if (reader.RecoveredMethod753(model + map.RecoveredMethod554("DataModel", "GameId")) != 648454481)
			{
				throw new Exception("Join GPO to read world coordinates");
			}
			player = reader.RecoveredMethod753(reader.RecoveredMethod756(model, "Players") + map.Core.LocalPlayer);
			account = reader.RecoveredMethod754(player);
			eyeReader = new RecoveredType204(memory, reader, map, RecoveredMethod617);
		}
		catch
		{
			Dispose();
			throw;
		}
	}

	private static bool RecoveredMethod39(string P_0)
	{
		switch (P_0)
		{
		default:
			return P_0 == "CornerWedgePart";
		case "Part":
		case "MeshPart":
		case "UnionOperation":
		case "WedgePart":
		case "TrussPart":
			return true;
		}
	}

	private WorldPoint RecoveredMethod617(ulong P_0)
	{
		if (!RecoveredType285.RecoveredMethod572(P_0) || !RecoveredMethod39(reader.RecoveredMethod607(P_0)))
		{
			return null;
		}
		ulong num = reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("BasePart", "Primitive"));
		if (!RecoveredType285.RecoveredMethod572(num))
		{
			return null;
		}
		byte[] array = memory.RecoveredMethod609(num + map.RecoveredMethod554("Primitive", "Position"), 12);
		if (array == null)
		{
			return null;
		}
		WorldPoint worldPoint = new WorldPoint();
		worldPoint.RecoveredField2015 = BitConverter.ToSingle(array, 0);
		worldPoint.RecoveredField2016 = BitConverter.ToSingle(array, 4);
		worldPoint.RecoveredField2017 = BitConverter.ToSingle(array, 8);
		WorldPoint worldPoint2 = worldPoint;
		if (!worldPoint2.Valid)
		{
			return null;
		}
		return worldPoint2;
	}

	private string RecoveredMethod888(ulong P_0, string P_1)
	{
		ulong num = P_0 + map.RecoveredMethod554("ProximityPrompt", P_1);
		string text = reader.RecoveredMethod475(num);
		if (!(text != ""))
		{
			return reader.RecoveredMethod475(reader.RecoveredMethod753(num));
		}
		return text;
	}

	public WorldSnapshot RecoveredMethod889()
	{
		if (process.HasExited || reader.RecoveredMethod649(module) != model)
		{
			throw new Exception("World changed; reconnecting");
		}
		ulong num = reader.RecoveredMethod756(model, "Workspace");
		ulong num2 = reader.RecoveredMethod753(player + map.RecoveredMethod554("Player", "ModelInstance"));
		ulong num3 = reader.RecoveredMethod756(player, "Backpack");
		DateTime utcNow = DateTime.UtcNow;
		WorldSnapshot worldSnapshot = new WorldSnapshot();
		worldSnapshot.Valid = RecoveredType285.RecoveredMethod572(num);
		worldSnapshot.Updated = utcNow;
		worldSnapshot.Revision = ++revision;
		worldSnapshot.Position = RecoveredMethod617(reader.RecoveredMethod756(num2, "HumanoidRootPart"));
		WorldSnapshot worldSnapshot2 = worldSnapshot;
		string input = reader.RecoveredMethod475(model + map.RecoveredMethod554("DataModel", "JobId"));
		worldSnapshot2.Server = (Guid.TryParse(input, out var result) ? result.ToString("N") : ("client-" + process.Id + "-" + process.StartTime.ToUniversalTime().Ticks));
		foreach (ulong item in reader.RecoveredMethod755(num3).Concat(reader.RecoveredMethod755(num2)))
		{
			if (!(reader.RecoveredMethod607(item) != "Tool") && RecoveredType406.RecoveredMethod39(reader.RecoveredMethod754(item)))
			{
				string text = reader.RecoveredMethod475(item + map.RecoveredMethod554("Tool", "Tooltip"));
				if (text.ToLowerInvariant().Contains("fruit"))
				{
					worldSnapshot2.HasEye = true;
					worldSnapshot2.EyeName = reader.RecoveredMethod754(item);
					worldSnapshot2.EyeDescription = text;
					break;
				}
			}
		}
		List<ulong> source = reader.RecoveredMethod755(reader.RecoveredMethod756(num, "Islands"));
		worldSnapshot2.Hub = (source.Any((ulong P_0) => reader.RecoveredMethod754(P_0).Equals("Fishing Hub", StringComparison.OrdinalIgnoreCase)) ? "Fishing Hub" : (source.Any((ulong P_0) => reader.RecoveredMethod754(P_0).IndexOf("Trade Hub", StringComparison.OrdinalIgnoreCase) >= 0) ? "Trade Hub" : "GPO"));
		worldSnapshot2.Fruits = pulseTracker.RecoveredMethod597(eyeReader.RecoveredMethod604(reader.RecoveredMethod757(model)), eyeReader.RecoveredMethod605(num), worldSnapshot2.Server, account, worldSnapshot2.HasEye, utcNow);
		worldSnapshot2.Events = pulseTracker.Events;
		worldSnapshot2.Status = ((!worldSnapshot2.Valid) ? "Waiting for Workspace" : (worldSnapshot2.HasEye ? "Watching Eye announcements and pulse targets" : "All Seeing Eye timer unavailable"));
		return worldSnapshot2;
	}

	public void Dispose()
	{
		if (memory != null)
		{
			memory.Dispose();
		}
		if (process != null)
		{
			process.Dispose();
		}
	}

	[CompilerGenerated]
	private bool RecoveredMethod473(ulong P_0)
	{
		return reader.RecoveredMethod754(P_0).Equals("Fishing Hub", StringComparison.OrdinalIgnoreCase);
	}

	[CompilerGenerated]
	private bool RecoveredMethod890(ulong P_0)
	{
		return reader.RecoveredMethod754(P_0).IndexOf("Trade Hub", StringComparison.OrdinalIgnoreCase) >= 0;
	}
}
