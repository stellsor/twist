using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using C;
using c;

namespace a;

internal sealed class RecoveredType172 : IDisposable
{
	private readonly Process process;

	private readonly RecoveredType282 memory;

	private readonly RecoveredType285 reader;

	private readonly RecoveredType163 offsets;

	public readonly int Pid;

	public readonly long Created;

	public ulong Model;

	public ulong Player;

	public ulong Gui;

	public string Account;

	public string Display;

	public string Place;

	public ulong UserId;

	public ulong Universe;

	public IntPtr Window;

	private ulong position;

	private ulong size;

	private ulong parent;

	private RecoveredType171 cached;

	public RecoveredType172(int P_0, long P_1, RecoveredType163 P_2)
	{
		Pid = P_0;
		Created = P_1;
		offsets = P_2;
		process = Process.GetProcessById(P_0);
		try
		{
			if (process.StartTime.ToUniversalTime().Ticks != P_1)
			{
				throw new Exception("This process ID was reused. Refresh the client list.");
			}
			ProcessModule mainModule = process.MainModule;
			if (mainModule.FileName.IndexOf(P_2.Core.Version, StringComparison.OrdinalIgnoreCase) < 0)
			{
				throw new Exception("Offsets do not match this Roblox version.");
			}
			memory = new RecoveredType282(P_0);
			reader = new RecoveredType285(memory, P_2.Core);
			Model = reader.RecoveredMethod649((ulong)mainModule.BaseAddress.ToInt64());
			ulong num = reader.RecoveredMethod756(Model, "Players");
			Player = reader.RecoveredMethod753(num + P_2.Core.LocalPlayer);
			if (!RecoveredType285.RecoveredMethod572(Player))
			{
				throw new Exception("LocalPlayer is not ready.");
			}
			Account = reader.RecoveredMethod754(Player);
			Display = reader.RecoveredMethod475(reader.RecoveredMethod753(Player + P_2.RecoveredMethod554("Player", "DisplayName")));
			UserId = reader.RecoveredMethod753(Player + P_2.RecoveredMethod554("Player", "UserId"));
			Gui = reader.RecoveredMethod757(Model);
			Place = reader.RecoveredMethod753(Model + P_2.RecoveredMethod554("DataModel", "PlaceId")).ToString();
			Universe = reader.RecoveredMethod753(Model + P_2.RecoveredMethod554("DataModel", "GameId"));
			Window = RecoveredType164.RecoveredMethod563(P_0);
			position = P_2.RecoveredMethod554("GuiObject", "Position");
			size = P_2.RecoveredMethod554("GuiObject", "Size");
			parent = P_2.RecoveredMethod554("Instance", "Parent");
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

	public RecoveredType214 RecoveredMethod570(RecoveredType245 P_0, RecoveredType170 P_1, Action<string> P_2)
	{
		return new RecoveredType232(memory, reader, offsets, Model, (ulong)process.MainModule.BaseAddress.ToInt64(), Player, Gui, Account, Window, P_0, P_1, P_2);
	}

	public RecoveredType105 RecoveredMethod571(RecoveredType245 P_0, CancellationToken P_1 = default(CancellationToken), Action<string> P_2 = null, RecoveredType170 P_3 = null)
	{
		return new RecoveredType118(memory, reader, offsets, Model, (ulong)process.MainModule.BaseAddress.ToInt64(), Gui, Account, Window, P_0, P_1, P_2, P_3);
	}

	public bool RecoveredMethod387()
	{
		try
		{
			return !process.HasExited && process.StartTime.ToUniversalTime().Ticks == Created;
		}
		catch
		{
			return false;
		}
	}

	private bool RecoveredMethod572(ulong P_0)
	{
		byte[] array = memory.RecoveredMethod609(P_0 + offsets.Core.Visible, 1);
		if (array != null)
		{
			return array[0] == 1;
		}
		return false;
	}

	public bool RecoveredMethod573()
	{
		ulong num = reader.RecoveredMethod753(Player + offsets.RecoveredMethod554("Player", "ModelInstance"));
		if (!RecoveredType285.RecoveredMethod572(num))
		{
			return false;
		}
		return reader.RecoveredMethod755(num).Any((ulong P_0) => reader.RecoveredMethod607(P_0) == "Tool" && (reader.RecoveredMethod754(P_0).IndexOf("Fishing Rod", StringComparison.OrdinalIgnoreCase) >= 0 || reader.RecoveredMethod754(P_0).EndsWith(" Rod", StringComparison.OrdinalIgnoreCase)));
	}

	private bool RecoveredMethod574(ulong P_0, ulong P_1, out double P_2)
	{
		P_2 = 0.0;
		byte[] array = memory.RecoveredMethod609(P_0 + P_1 + 8, 8);
		if (array == null)
		{
			return false;
		}
		P_2 = BitConverter.ToSingle(array, 0);
		if (BitConverter.ToInt32(array, 4) == 0 && !double.IsNaN(P_2) && !double.IsInfinity(P_2) && P_2 >= 0.0)
		{
			return P_2 <= 1.1;
		}
		return false;
	}

	public RecoveredType171 RecoveredMethod575()
	{
		RecoveredType171 recoveredType = cached;
		if (recoveredType == null || reader.RecoveredMethod753(recoveredType.Gui + parent) != Gui || reader.RecoveredMethod754(recoveredType.Gui) != "FishingUIBill")
		{
			ulong num = reader.RecoveredMethod756(Gui, "FishingUIBill");
			if (!RecoveredType285.RecoveredMethod572(num))
			{
				cached = null;
				return null;
			}
			ulong num2 = reader.RecoveredMethod756(num, "Frame");
			ulong num3 = reader.RecoveredMethod756(num2, "Player");
			ulong num4 = reader.RecoveredMethod756(num2, "Goal");
			ulong num5 = reader.RecoveredMethod756(num2, "Time");
			ulong fill = reader.RecoveredMethod756(num5, "Fill");
			if (!RecoveredType285.RecoveredMethod572(num3) || !RecoveredType285.RecoveredMethod572(num4))
			{
				cached = null;
				return null;
			}
			RecoveredType171 recoveredType2 = new RecoveredType171();
			recoveredType2.Gui = num;
			recoveredType2.Frame = num2;
			recoveredType2.Player = num3;
			recoveredType2.Goal = num4;
			recoveredType2.Fill = fill;
			recoveredType = (cached = recoveredType2);
		}
		if (reader.RecoveredMethod753(recoveredType.Player + parent) != recoveredType.Frame || reader.RecoveredMethod753(recoveredType.Goal + parent) != recoveredType.Frame || !RecoveredMethod572(recoveredType.Frame) || !RecoveredMethod572(recoveredType.Player) || !RecoveredMethod572(recoveredType.Goal))
		{
			cached = null;
			return null;
		}
		if (!RecoveredMethod574(recoveredType.Player, position, out var playerY) || !RecoveredMethod574(recoveredType.Goal, position, out var goalY) || !RecoveredMethod574(recoveredType.Player, size, out var num6) || num6 <= 0.0)
		{
			cached = null;
			return null;
		}
		double progress = 0.0;
		if (RecoveredType285.RecoveredMethod572(recoveredType.Fill))
		{
			RecoveredMethod574(recoveredType.Fill, size, out progress);
		}
		recoveredType.PlayerY = playerY;
		recoveredType.GoalY = goalY;
		recoveredType.Height = num6;
		recoveredType.Progress = progress;
		return recoveredType;
	}

	public string RecoveredMethod576()
	{
		RecoveredType284 recoveredType = reader.RecoveredMethod759(Gui, "PlayerGui", new string[3] { "FishingUIBill", "FishingBaitGui", "Fishing Rod" }, CancellationToken.None);
		return "Account: " + Account + "\r\nPID: " + Pid + "\r\nPlace: " + Place + "\r\nWindow: 0x" + Window.ToInt64().ToString("X") + "\r\nRod equipped: " + RecoveredMethod573() + "\r\n" + string.Join("\r\n", recoveredType.Hits.Select((RecoveredType283 P_0) => P_0.Path + " | " + P_0.Class)) + "\r\nUnreadable reads: " + recoveredType.Failures;
	}

	public void Dispose()
	{
		memory.Dispose();
		process.Dispose();
	}

	[CompilerGenerated]
	private bool RecoveredMethod473(ulong P_0)
	{
		if (reader.RecoveredMethod607(P_0) == "Tool")
		{
			if (reader.RecoveredMethod754(P_0).IndexOf("Fishing Rod", StringComparison.OrdinalIgnoreCase) < 0)
			{
				return reader.RecoveredMethod754(P_0).EndsWith(" Rod", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
		return false;
	}

	[CompilerGenerated]
	private static string RecoveredMethod577(RecoveredType283 P_0)
	{
		return P_0.Path + " | " + P_0.Class;
	}
}
