using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using A;
using B;
using a;
using b;
using c;

namespace C;

internal sealed class RecoveredType118 : RecoveredType105
{
	[CompilerGenerated]
	private sealed class RecoveredType119
	{
		public RecoveredType118 _003C_003E4__this;

		public int depth;

		public string RecoveredMethod472(ulong P_0)
		{
			return _003C_003E4__this.RecoveredMethod474(P_0, depth + 1);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType120
	{
		public ulong node;

		public RecoveredType118 _003C_003E4__this;

		public RecoveredType103 target;

		public string bait;

		public RecoveredType365 RecoveredMethod488()
		{
			if (_003C_003E4__this.RecoveredMethod483(target, bait) != node || !_003C_003E4__this.RecoveredMethod482(node) || !_003C_003E4__this.RecoveredMethod485(target, bait, node))
			{
				return null;
			}
			return new RecoveredType365
			{
				Node = node,
				Rectangle = _003C_003E4__this.RecoveredMethod480(node),
				Client = RecoveredType127.RecoveredMethod503(_003C_003E4__this.window)
			};
		}
	}

	private readonly RecoveredType384 uiText;

	private readonly RecoveredType366 hover;

	private readonly RecoveredType397 worldVendor;

	private string vendorStatus = "";

	private RecoveredType296 quantityText;

	private ulong verifiedQuantityBox;

	private string expectedQuantity = "";

	private readonly RecoveredType170 profile;

	private readonly Action<string> log;

	private readonly RecoveredType282 memory;

	private readonly RecoveredType285 reader;

	private readonly RecoveredType163 map;

	private readonly ulong model;

	private readonly ulong module;

	private readonly ulong gui;

	private readonly string account;

	private readonly IntPtr window;

	private readonly RecoveredType245 input;

	private readonly CancellationToken stop;

	private static readonly string[] UiClasses = new string[9] { "Frame", "CanvasGroup", "ScrollingFrame", "TextLabel", "TextButton", "TextBox", "ImageLabel", "ImageButton", "ViewportFrame" };

	public RecoveredType118(RecoveredType282 P_0, RecoveredType285 P_1, RecoveredType163 P_2, ulong P_3, ulong P_4, ulong P_5, string P_6, IntPtr P_7, RecoveredType245 P_8, CancellationToken P_9, Action<string> P_10 = null, RecoveredType170 P_11 = null)
	{
		uiText = new RecoveredType384(P_0, P_1, P_2.Core.Version);
		hover = new RecoveredType366(P_8);
		worldVendor = new RecoveredType397(P_0, P_1, P_2, P_3);
		profile = P_11 ?? new RecoveredType170();
		log = P_10 ?? ((Action<string>)delegate
		{
		});
		stop = P_9;
		memory = P_0;
		reader = P_1;
		map = P_2;
		model = P_3;
		module = P_4;
		gui = P_5;
		account = P_6;
		window = P_7;
		input = P_8;
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

	private string RecoveredMethod472(ulong P_0)
	{
		return uiText.RecoveredMethod636(P_0);
	}

	private bool RecoveredMethod473(ulong P_0)
	{
		if (!RecoveredType285.RecoveredMethod572(P_0))
		{
			return false;
		}
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
			ulong num = ((text == "ScreenGui") ? map.Core.Enabled : (UiClasses.Contains(text) ? map.Core.Visible : 0));
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

	private string RecoveredMethod474(ulong P_0, int P_1)
	{
		if (P_1 > 10)
		{
			return "";
		}
		string text = reader.RecoveredMethod607(P_0);
		string text2 = (text.StartsWith("Text", StringComparison.Ordinal) ? RecoveredMethod472(P_0) : "");
		if (text2 != "")
		{
			return text2;
		}
		return string.Join(" ", from num in reader.RecoveredMethod755(P_0)
			select RecoveredMethod474(num, P_1 + 1));
	}

	private string RecoveredMethod475(ulong P_0)
	{
		ulong num = reader.RecoveredMethod753(P_0 + 16);
		if (num < 2 || num > 2097152)
		{
			throw new Exception("Inventory quantity data is not ready.");
		}
		ulong num2 = ((num >= 16) ? reader.RecoveredMethod753(P_0) : P_0);
		byte[] array = new byte[(uint)num];
		for (int i = 0; i < array.Length; i += 65536)
		{
			int num3 = Math.Min(65536, array.Length - i);
			byte[] array2 = memory.RecoveredMethod609(num2 + (ulong)i, num3);
			if (array2 == null)
			{
				throw new Exception("Inventory quantity read failed.");
			}
			Buffer.BlockCopy(array2, 0, array, i, num3);
		}
		return Encoding.UTF8.GetString(array);
	}

	private ulong RecoveredMethod476()
	{
		return reader.RecoveredMethod755(gui).FirstOrDefault((ulong P_0) => reader.RecoveredMethod754(P_0) == "NPCCHAT" && RecoveredMethod473(P_0));
	}

	private ulong RecoveredMethod477()
	{
		return reader.RecoveredMethod755(gui).FirstOrDefault((ulong P_0) => reader.RecoveredMethod754(P_0) == "Shop" && RecoveredMethod473(P_0) && reader.RecoveredMethod607(RecoveredMethod471(P_0, "Frame", "count")) == "TextBox" && RecoveredMethod473(RecoveredMethod471(P_0, "Frame", "count")) && RecoveredMethod482(RecoveredMethod471(P_0, "Frame", "count")));
	}

	private bool RecoveredMethod478()
	{
		return worldVendor.RecoveredMethod882(out vendorStatus);
	}

	public RecoveredType104 RecoveredMethod401()
	{
		if (reader.RecoveredMethod649(module) != model)
		{
			throw new Exception("Game changed; fishing stopped.");
		}
		ulong num = reader.RecoveredMethod756(model, "ReplicatedStorage");
		ulong num2 = RecoveredMethod471(num, "Stats" + account, "Inventory", "Inventory");
		if (reader.RecoveredMethod607(num2) != "StringValue")
		{
			throw new Exception("Inventory quantities are not ready.");
		}
		RecoveredType104 recoveredType = new RecoveredType104();
		recoveredType.Counts = RecoveredType259.RecoveredMethod712(RecoveredMethod475(num2 + 160));
		RecoveredType104 recoveredType2 = recoveredType;
		ulong num3 = RecoveredMethod471(gui, "FishingBaitGui", "Main", "List");
		recoveredType2.BaitMenu = RecoveredMethod473(num3) && RecoveredMethod484(num3);
		if (recoveredType2.BaitMenu)
		{
			foreach (ulong item in reader.RecoveredMethod755(num3))
			{
				if (!(reader.RecoveredMethod607(item) != "ImageButton") && RecoveredMethod473(item))
				{
					ulong num4 = reader.RecoveredMethod756(item, "backGroundSelect");
					if (RecoveredMethod473(num4))
					{
						recoveredType2.Selected = reader.RecoveredMethod754(item);
					}
				}
			}
		}
		ulong num5 = RecoveredMethod476();
		recoveredType2.Dialog = RecoveredMethod473(num5);
		if (recoveredType2.Dialog)
		{
			string text = RecoveredMethod474(RecoveredMethod471(num5, "Frame", "ImageLabel", "desc"), 0);
			recoveredType2.DialogText = Regex.Replace(text, "\\s+", " ").Trim();
			recoveredType2.CommonDialog = Regex.IsMatch(recoveredType2.DialogText, "Common\\s+Fish\\s+Baits?", RegexOptions.IgnoreCase);
			recoveredType2.ConfirmationAmount = RecoveredType106.RecoveredMethod406(recoveredType2.DialogText);
			recoveredType2.Done = RecoveredMethod473(RecoveredMethod471(num5, "Frame", "endChat")) && RecoveredMethod484(RecoveredMethod471(num5, "Frame", "endChat"));
		}
		ulong num6 = RecoveredMethod477();
		recoveredType2.Quantity = RecoveredType285.RecoveredMethod572(num6);
		if (recoveredType2.Quantity)
		{
			ulong num7 = RecoveredMethod471(num6, "Frame", "count");
			recoveredType2.QuantityText = ((quantityText != null && quantityText.Node == num7) ? quantityText.RecoveredMethod470() : ((verifiedQuantityBox == num7 && uiText.ExactTextBoxLayout) ? uiText.RecoveredMethod636(num7) : ""));
		}
		recoveredType2.CommonVendor = RecoveredMethod478();
		recoveredType2.Debug = "menu=" + recoveredType2.BaitMenu + " selected=" + recoveredType2.Selected + " vendor=" + recoveredType2.CommonVendor + " vendorWorld=" + vendorStatus + " dialog=" + recoveredType2.Dialog + " commonDialog=" + recoveredType2.CommonDialog + " done=" + recoveredType2.Done + " confirmationAmount=" + recoveredType2.ConfirmationAmount + " commonStock=" + recoveredType2.Common + " quantity=" + recoveredType2.Quantity + " quantityText=" + recoveredType2.QuantityText + " text=" + ((recoveredType2.DialogText.Length > 240) ? recoveredType2.DialogText.Substring(0, 240) : recoveredType2.DialogText);
		return recoveredType2;
	}

	private double[] RecoveredMethod479(ulong P_0)
	{
		for (int i = 0; i < 40; i++)
		{
			if (!RecoveredType285.RecoveredMethod572(P_0))
			{
				break;
			}
			if (reader.RecoveredMethod607(P_0) == "ScreenGui")
			{
				byte[] array = memory.RecoveredMethod609(P_0 + 244, 16);
				if (array == null)
				{
					break;
				}
				return new double[2]
				{
					(double)BitConverter.ToSingle(array, 0) + (double)BitConverter.ToSingle(array, 8),
					(double)BitConverter.ToSingle(array, 4) + (double)BitConverter.ToSingle(array, 12)
				};
			}
			P_0 = reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("Instance", "Parent"));
		}
		throw new Exception("The bait control viewport is unavailable.");
	}

	private RecoveredType381 RecoveredMethod480(ulong P_0)
	{
		return RecoveredType382.RecoveredMethod874(RecoveredType381.RecoveredMethod871(memory.RecoveredMethod609(P_0 + 244, 16)), profile);
	}

	public RecoveredType381 RecoveredMethod481(string P_0)
	{
		ulong num = RecoveredMethod471(gui, "FishingBaitGui", "Main", "List", P_0);
		if (!RecoveredMethod473(num) || !RecoveredMethod484(num))
		{
			throw new Exception("Equip the rod and leave the bait list visible.");
		}
		return RecoveredType381.RecoveredMethod871(memory.RecoveredMethod609(num + 244, 16));
	}

	private bool RecoveredMethod482(ulong P_0)
	{
		if (!RecoveredMethod473(P_0) || !RecoveredMethod484(P_0))
		{
			return false;
		}
		try
		{
			double num;
			double num2;
			return RecoveredMethod480(P_0).RecoveredMethod872(RecoveredType127.RecoveredMethod503(window), out num, out num2);
		}
		catch
		{
			return false;
		}
	}

	private ulong RecoveredMethod483(RecoveredType103 P_0, string P_1)
	{
		return P_0 switch
		{
			RecoveredType103.Bait => RecoveredMethod471(gui, "FishingBaitGui", "Main", "List", P_1), 
			RecoveredType103.Yes => RecoveredMethod471(RecoveredMethod476(), "Frame", "go"), 
			RecoveredType103.Done => RecoveredMethod471(RecoveredMethod476(), "Frame", "endChat"), 
			_ => RecoveredMethod471(RecoveredMethod477(), "Frame", (P_0 == RecoveredType103.Buy) ? "buy" : "count"), 
		};
	}

	private bool RecoveredMethod484(ulong P_0)
	{
		byte[] array = memory.RecoveredMethod609(P_0 + 244, 16);
		if (array != null && BitConverter.ToSingle(array, 8) >= 2f)
		{
			return BitConverter.ToSingle(array, 12) >= 2f;
		}
		return false;
	}

	public void RecoveredMethod402(RecoveredType103 P_0, string P_1, Action P_2 = null)
	{
		stop.ThrowIfCancellationRequested();
		input.RecoveredMethod50();
		RecoveredType104 recoveredType = RecoveredMethod401();
		ulong node = 0uL;
		if (P_0 == RecoveredType103.Yes && P_1 == "initial-retry")
		{
			if (recoveredType.Quantity)
			{
				return;
			}
			if (!recoveredType.Dialog || !recoveredType.CommonDialog || recoveredType.Done || recoveredType.ConfirmationAmount > 1)
			{
				throw new Exception("The first Common-bait confirmation changed before retrying.");
			}
			input.RecoveredMethod565(false, 0.0, 0.0);
			input.RecoveredMethod45();
			RecoveredMethod393(450, stop);
			recoveredType = RecoveredMethod401();
			if (recoveredType.Quantity)
			{
				return;
			}
			log("Re-arming the pointer before retrying the first Yes control");
		}
		if (P_0 == RecoveredType103.Bait)
		{
			node = RecoveredMethod471(gui, "FishingBaitGui", "Main", "List", P_1);
			if (!recoveredType.BaitMenu || RecoveredType106.RecoveredMethod403(P_1) == 0 || !recoveredType.Counts.ContainsKey(P_1) || recoveredType.Counts[P_1] <= 0)
			{
				throw new Exception("The chosen bait is not available.");
			}
		}
		else if (P_0 == RecoveredType103.Yes)
		{
			if (!recoveredType.Dialog || !recoveredType.CommonDialog || recoveredType.Done || ((P_1 == "initial" || P_1 == "initial-retry") && recoveredType.ConfirmationAmount > 1))
			{
				throw new Exception("The Common bait confirmation changed.");
			}
			node = RecoveredMethod471(RecoveredMethod476(), "Frame", "go");
		}
		else if (P_0 == RecoveredType103.Quantity)
		{
			node = RecoveredMethod471(RecoveredMethod477(), "Frame", "count");
		}
		else if (P_0 == RecoveredType103.Buy)
		{
			if (!recoveredType.Quantity || expectedQuantity == "" || recoveredType.QuantityText.Trim() != expectedQuantity)
			{
				throw new Exception("The quantity changed before purchase.");
			}
			node = RecoveredMethod471(RecoveredMethod477(), "Frame", "buy");
		}
		else if (P_0 == RecoveredType103.Done)
		{
			if (!recoveredType.Dialog || !recoveredType.Done)
			{
				throw new Exception("The completion prompt changed.");
			}
			node = RecoveredMethod471(RecoveredMethod476(), "Frame", "endChat");
		}
		RecoveredType381 recoveredType2 = default(RecoveredType381);
		RecoveredType381 recoveredType3 = default(RecoveredType381);
		int num = 0;
		ulong num2 = 0uL;
		for (int i = 0; i < 40; i++)
		{
			stop.ThrowIfCancellationRequested();
			input.RecoveredMethod50();
			node = RecoveredMethod483(P_0, P_1);
			if (RecoveredMethod482(node))
			{
				recoveredType2 = RecoveredMethod480(node);
				num = ((node == num2 && recoveredType2.RecoveredMethod873(recoveredType3)) ? (num + 1) : 0);
				recoveredType3 = recoveredType2;
				num2 = node;
				if (num >= 3)
				{
					break;
				}
			}
			else
			{
				num = 0;
				num2 = 0uL;
			}
			RecoveredMethod393(100, stop);
		}
		if (num < 3)
		{
			throw new Exception("The expected bait control did not settle on screen.");
		}
		RecoveredType126 recoveredType4 = RecoveredType127.RecoveredMethod503(window);
		if (!recoveredType2.RecoveredMethod872(recoveredType4, out var num3, out var num4))
		{
			throw new Exception("The bait control is outside the current Roblox client area.");
		}
		log(string.Concat("UI ", P_0, " ", P_1, " rect=", recoveredType2.RecoveredField1938.ToString("0.0"), ",", recoveredType2.RecoveredField1939.ToString("0.0"), ",", recoveredType2.Width.ToString("0.0"), ",", recoveredType2.Height.ToString("0.0"), " client=", recoveredType4.Width, "x", recoveredType4.Height, " target=", (num3 * 100.0).ToString("0.0"), "%/", (num4 * 100.0).ToString("0.0"), "%"));
		input.RecoveredMethod565(false, 0.0, 0.0);
		log("Moving to " + ((P_0 == RecoveredType103.Bait) ? P_1 : P_0.ToString()));
		hover.RecoveredMethod853(() => (RecoveredMethod483(P_0, P_1) != node || !RecoveredMethod482(node) || !RecoveredMethod485(P_0, P_1, node)) ? null : new RecoveredType365
		{
			Node = node,
			Rectangle = RecoveredMethod480(node),
			Client = RecoveredType127.RecoveredMethod503(window)
		});
		try
		{
			hover.RecoveredMethod857(stop, true);
			RecoveredMethod393(200, stop);
			input.RecoveredMethod674(num3, num4);
			if (!RecoveredMethod485(P_0, P_1, node))
			{
				return;
			}
			if (!RecoveredMethod482(node) || !RecoveredMethod480(node).RecoveredMethod873(recoveredType2))
			{
				throw new Exception("The bait control moved before the click; waiting for its new position.");
			}
			log("Clicking " + ((P_0 == RecoveredType103.Bait) ? P_1 : P_0.ToString()));
			P_2?.Invoke();
			input.RecoveredMethod565(true, num3, num4);
			RecoveredMethod393(200, stop);
		}
		finally
		{
			input.RecoveredMethod565(false, 0.0, 0.0);
		}
		RecoveredMethod393(200, stop);
	}

	private bool RecoveredMethod485(RecoveredType103 P_0, string P_1, ulong P_2)
	{
		RecoveredType104 recoveredType = RecoveredMethod401();
		if (P_0 == RecoveredType103.Yes && P_1 == "initial-retry" && recoveredType.Quantity)
		{
			return false;
		}
		if (RecoveredMethod483(P_0, P_1) != P_2)
		{
			throw new Exception("The UI control changed before the click.");
		}
		if (P_0 == RecoveredType103.Yes && (!recoveredType.Dialog || !recoveredType.CommonDialog || recoveredType.Done || recoveredType.Quantity || ((P_1 == "initial" || P_1 == "initial-retry") && recoveredType.ConfirmationAmount > 1)))
		{
			throw new Exception("The Common bait confirmation changed before clicking Yes.");
		}
		if (P_0 == RecoveredType103.Buy && (!recoveredType.Quantity || expectedQuantity == "" || recoveredType.QuantityText.Trim() != expectedQuantity))
		{
			throw new Exception("The quantity changed before clicking Buy.");
		}
		if (P_0 == RecoveredType103.Done && (!recoveredType.Dialog || !recoveredType.Done))
		{
			throw new Exception("The completion prompt changed before dismissal.");
		}
		if (P_0 == RecoveredType103.Quantity && !recoveredType.Quantity)
		{
			throw new Exception("The quantity screen closed before focusing the field.");
		}
		if (P_0 == RecoveredType103.Bait && (!recoveredType.BaitMenu || !recoveredType.Counts.ContainsKey(P_1) || recoveredType.Counts[P_1] <= 0))
		{
			throw new Exception("The selected bait is no longer available.");
		}
		return true;
	}

	public void RecoveredMethod51()
	{
		stop.ThrowIfCancellationRequested();
		input.RecoveredMethod45();
	}

	public void RecoveredMethod377(int P_0)
	{
		if (P_0 < 1 || P_0 > 100000)
		{
			throw new Exception("Choose a bait purchase amount from 1 to 100000.");
		}
		stop.ThrowIfCancellationRequested();
		ulong num = RecoveredMethod471(RecoveredMethod477(), "Frame", "count");
		if (reader.RecoveredMethod607(num) != "TextBox")
		{
			throw new Exception("The quantity editor changed before typing. · " + RecoveredMethod401().Debug);
		}
		quantityText = null;
		verifiedQuantityBox = 0uL;
		expectedQuantity = P_0.ToString(CultureInfo.InvariantCulture);
		if (uiText.ExactTextBoxLayout)
		{
			input.RecoveredMethod393(P_0, stop);
			for (int i = 0; i < 25; i++)
			{
				RecoveredMethod393(120, stop);
				if (RecoveredMethod471(RecoveredMethod477(), "Frame", "count") != num)
				{
					throw new Exception("The quantity editor changed while verifying the purchase amount.");
				}
				if (uiText.RecoveredMethod636(num) == expectedQuantity)
				{
					verifiedQuantityBox = num;
					log("Quantity " + expectedQuantity + " verified from the active TextBox");
					return;
				}
			}
			throw new Exception("The quantity field did not acknowledge " + expectedQuantity + "; refocusing and retrying. No purchase confirmed.");
		}
		RecoveredType296 recoveredType = new RecoveredType296(memory, num);
		int num2 = ((P_0 == 37) ? 36 : ((P_0 >= 37) ? 37 : ((P_0 != 1) ? 1 : 2)));
		string text = num2.ToString(CultureInfo.InvariantCulture);
		input.RecoveredMethod393(num2, stop);
		RecoveredMethod393(600, stop);
		Dictionary<string, string> dictionary = recoveredType.RecoveredMethod768();
		if (!dictionary.Values.Contains(text))
		{
			throw new Exception("The quantity field did not acknowledge typing; refocusing and retrying. · " + RecoveredMethod401().Debug);
		}
		if (RecoveredMethod471(RecoveredMethod477(), "Frame", "count") != num)
		{
			throw new Exception("The quantity editor changed while entering the test value.");
		}
		input.RecoveredMethod393(P_0, stop);
		for (int j = 0; j < 25; j++)
		{
			RecoveredMethod393(120, stop);
			if (RecoveredMethod471(RecoveredMethod477(), "Frame", "count") != num)
			{
				throw new Exception("The quantity editor changed while verifying the purchase amount.");
			}
			if (recoveredType.RecoveredMethod769(dictionary, recoveredType.RecoveredMethod768(), text, expectedQuantity) && recoveredType.RecoveredMethod470() == expectedQuantity)
			{
				quantityText = recoveredType;
				log("Quantity " + expectedQuantity + " verified from active edit · " + recoveredType.Description);
				return;
			}
		}
		throw new Exception("Could not verify the quantity TextBox changing to " + expectedQuantity + "; refocusing and retrying. No purchase confirmed.");
	}

	public void RecoveredMethod50()
	{
		stop.ThrowIfCancellationRequested();
		if (!RecoveredMethod478())
		{
			throw new Exception("Waiting for the Common Fish Bait vendor within 12 studs. · " + vendorStatus);
		}
		input.RecoveredMethod45();
		log("E scan-code down · " + RecoveredMethod401().Debug);
		input.RecoveredMethod675(69, 650, stop);
		log("E scan-code released · " + RecoveredMethod401().Debug);
	}

	public void RecoveredMethod395(int P_0, CancellationToken P_1)
	{
		if (P_1.WaitHandle.WaitOne(P_0))
		{
			P_1.ThrowIfCancellationRequested();
		}
	}

	public void RecoveredMethod393(int P_0, CancellationToken P_1)
	{
		if (P_1.WaitHandle.WaitOne(P_0))
		{
			P_1.ThrowIfCancellationRequested();
		}
		input.RecoveredMethod50();
		hover.RecoveredMethod857(P_1);
	}

	[CompilerGenerated]
	private static void RecoveredMethod414(string P_0)
	{
	}

	[CompilerGenerated]
	private bool RecoveredMethod486(ulong P_0)
	{
		if (reader.RecoveredMethod754(P_0) == "NPCCHAT")
		{
			return RecoveredMethod473(P_0);
		}
		return false;
	}

	[CompilerGenerated]
	private bool RecoveredMethod487(ulong P_0)
	{
		if (reader.RecoveredMethod754(P_0) == "Shop" && RecoveredMethod473(P_0) && reader.RecoveredMethod607(RecoveredMethod471(P_0, "Frame", "count")) == "TextBox" && RecoveredMethod473(RecoveredMethod471(P_0, "Frame", "count")))
		{
			return RecoveredMethod482(RecoveredMethod471(P_0, "Frame", "count"));
		}
		return false;
	}
}
