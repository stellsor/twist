using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace a;

internal sealed class RecoveredType163
{
	public RecoveredType280 Core;

	private readonly Dictionary<string, object> groups;

	public RecoveredType163(string P_0)
	{
		Core = RecoveredType280.RecoveredMethod750(P_0);
		groups = (Dictionary<string, object>)((Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(P_0))["Offsets"];
	}

	public ulong RecoveredMethod554(string P_0, string P_1)
	{
		Dictionary<string, object> dictionary = (Dictionary<string, object>)groups[P_0];
		string text = Convert.ToString(dictionary[P_1]);
		if (!text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
		{
			return Convert.ToUInt64(text);
		}
		return Convert.ToUInt64(text.Substring(2), 16);
	}
}
