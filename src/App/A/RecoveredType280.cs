using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace a;

internal sealed class RecoveredType280
{
	[CompilerGenerated]
	private sealed class RecoveredType281
	{
		public Dictionary<string, object> groups;

		public ulong RecoveredMethod554(string P_0, string P_1)
		{
			if (groups == null || !groups.ContainsKey(P_0) || !(groups[P_0] is Dictionary<string, object> dictionary) || !dictionary.TryGetValue(P_1, out var value))
			{
				throw new Exception("Missing offset: " + P_0 + "." + P_1);
			}
			string text = Convert.ToString(value, CultureInfo.InvariantCulture);
			ulong num = (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? ulong.Parse(text.Substring(2), NumberStyles.HexNumber) : ulong.Parse(text, CultureInfo.InvariantCulture));
			if (num > 1073741824)
			{
				throw new Exception("Offset out of range: " + P_0 + "." + P_1);
			}
			return num;
		}
	}

	public string Version;

	public ulong FakePointer;

	public ulong RealDataModel;

	public ulong NameContainer;

	public ulong Name;

	public ulong Children;

	public ulong ChildrenEnd;

	public ulong ClassDescriptor;

	public ulong ClassName;

	public ulong StringLength;

	public ulong LocalPlayer;

	public ulong Visible;

	public ulong Enabled;

	public static RecoveredType280 RecoveredMethod750(string P_0)
	{
		if (!(new JavaScriptSerializer().DeserializeObject(P_0) is Dictionary<string, object> dictionary) || !dictionary.ContainsKey("Roblox Version") || !dictionary.ContainsKey("Offsets"))
		{
			throw new Exception("Expected the versioned Theo offsets JSON.");
		}
		Dictionary<string, object> groups = dictionary["Offsets"] as Dictionary<string, object>;
		Func<string, string, ulong> func = delegate(string text, string text2)
		{
			if (groups == null || !groups.ContainsKey(text) || !(groups[text] is Dictionary<string, object> dictionary2) || !dictionary2.TryGetValue(text2, out var value))
			{
				throw new Exception("Missing offset: " + text + "." + text2);
			}
			string text3 = Convert.ToString(value, CultureInfo.InvariantCulture);
			ulong num = (text3.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? ulong.Parse(text3.Substring(2), NumberStyles.HexNumber) : ulong.Parse(text3, CultureInfo.InvariantCulture));
			if (num > 1073741824)
			{
				throw new Exception("Offset out of range: " + text + "." + text2);
			}
			return num;
		};
		RecoveredType280 recoveredType = new RecoveredType280();
		recoveredType.Version = Convert.ToString(dictionary["Roblox Version"]);
		if (!Regex.IsMatch(recoveredType.Version, "^version-[a-fA-F0-9]{16,}$"))
		{
			throw new Exception("Invalid version label.");
		}
		recoveredType.FakePointer = func("FakeDataModel", "Pointer");
		recoveredType.RealDataModel = func("FakeDataModel", "RealDataModel");
		recoveredType.NameContainer = func("Instance", "NameContainer");
		recoveredType.Name = func("Instance", "Name");
		recoveredType.Children = func("Instance", "ChildrenStart");
		recoveredType.ChildrenEnd = func("Instance", "ChildrenEnd");
		recoveredType.ClassDescriptor = func("Instance", "ClassDescriptor");
		recoveredType.ClassName = func("Instance", "ClassName");
		recoveredType.StringLength = func("Misc", "StringLength");
		recoveredType.LocalPlayer = func("Player", "LocalPlayer");
		recoveredType.Visible = func("GuiObject", "Visible");
		recoveredType.Enabled = func("GuiObject", "ScreenGui_Enabled");
		if (recoveredType.FakePointer == 0 || recoveredType.RealDataModel == 0 || recoveredType.NameContainer == 0 || recoveredType.Children == 0 || recoveredType.ChildrenEnd == 0 || recoveredType.StringLength == 0)
		{
			throw new Exception("Required offsets must be nonzero.");
		}
		return recoveredType;
	}
}
