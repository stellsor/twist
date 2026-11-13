using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace a;

internal static class RecoveredType196
{
	public static RecoveredType194 RecoveredMethod591(string P_0, string P_1)
	{
		string text = WebUtility.HtmlDecode(Regex.Replace(P_1 ?? "", "<[^>]*>", "")).Trim();
		Match match = Regex.Match(text, "^An?\\s+(.+?)\\s+has spawned\\s+(?:at|in)\\s+((?:FISHING|TRADE)\\s+HUB)[.!]?$", RegexOptions.IgnoreCase);
		if (!match.Success || !RecoveredType219.RecoveredMethod39(match.Groups[1].Value))
		{
			return null;
		}
		RecoveredType194 recoveredType = new RecoveredType194();
		recoveredType.Key = P_0;
		recoveredType.Text = text;
		recoveredType.Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(match.Groups[1].Value.ToLowerInvariant());
		recoveredType.Hub = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(match.Groups[2].Value.ToLowerInvariant());
		return recoveredType;
	}

	public static string RecoveredMethod592(IEnumerable<KeyValuePair<string, string>> P_0)
	{
		return string.Concat(from keyValuePair in P_0.Where((KeyValuePair<string, string> keyValuePair) => Regex.IsMatch(keyValuePair.Key ?? "", "^Group[0-9]+$")).OrderBy((KeyValuePair<string, string> keyValuePair) => keyValuePair.Key, StringComparer.Ordinal)
			select keyValuePair.Value);
	}

	[CompilerGenerated]
	private static bool RecoveredMethod593(KeyValuePair<string, string> P_0)
	{
		return Regex.IsMatch(P_0.Key ?? "", "^Group[0-9]+$");
	}

	[CompilerGenerated]
	private static string RecoveredMethod594(KeyValuePair<string, string> P_0)
	{
		return P_0.Key;
	}

	[CompilerGenerated]
	private static string RecoveredMethod595(KeyValuePair<string, string> P_0)
	{
		return P_0.Value;
	}
}
