using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace A;

internal static class RecoveredType106
{
	[CompilerGenerated]
	private sealed class RecoveredType107
	{
		public string mode;

		public bool RecoveredMethod399(KeyValuePair<string, int> P_0)
		{
			if (P_0.Value > 0 && RecoveredMethod403(P_0.Key) > 0)
			{
				if (!(mode == "best"))
				{
					return RecoveredMethod403(P_0.Key) == 1;
				}
				return true;
			}
			return false;
		}
	}

	public static int RecoveredMethod403(string P_0)
	{
		if (!Regex.IsMatch(P_0 ?? "", "^(Common|Rare|Legendary)\\s+(?:Fish\\s+)?Baits?$", RegexOptions.IgnoreCase))
		{
			return 0;
		}
		if (P_0.StartsWith("Legendary", StringComparison.OrdinalIgnoreCase))
		{
			return 3;
		}
		if (P_0.StartsWith("Rare", StringComparison.OrdinalIgnoreCase))
		{
			return 2;
		}
		if (P_0.StartsWith("Common", StringComparison.OrdinalIgnoreCase))
		{
			return 1;
		}
		return 0;
	}

	public static string RecoveredMethod404(IDictionary<string, int> P_0, string P_1)
	{
		return (from keyValuePair in (from keyValuePair in P_0
				where keyValuePair.Value > 0 && RecoveredMethod403(keyValuePair.Key) > 0 && (P_1 == "best" || RecoveredMethod403(keyValuePair.Key) == 1)
				orderby RecoveredMethod403(keyValuePair.Key) descending
				select keyValuePair).ThenBy((KeyValuePair<string, int> keyValuePair) => keyValuePair.Key, StringComparer.Ordinal)
			select keyValuePair.Key).FirstOrDefault();
	}

	public static bool RecoveredMethod405(int P_0, int P_1 = 50)
	{
		return P_0 < P_1;
	}

	public static int RecoveredMethod406(string P_0)
	{
		Match match = Regex.Match(P_0 ?? "", "(?:purchase|buy)\\s+(\\d[\\d,]*)\\s+Common\\s+(?:Fish\\s+)?Baits?\\b", RegexOptions.IgnoreCase);
		if (!match.Success || !int.TryParse(match.Groups[1].Value.Replace(",", ""), out var result))
		{
			return 0;
		}
		return result;
	}

	[CompilerGenerated]
	private static int RecoveredMethod407(KeyValuePair<string, int> P_0)
	{
		return RecoveredMethod403(P_0.Key);
	}

	[CompilerGenerated]
	private static string RecoveredMethod408(KeyValuePair<string, int> P_0)
	{
		return P_0.Key;
	}

	[CompilerGenerated]
	private static string RecoveredMethod409(KeyValuePair<string, int> P_0)
	{
		return P_0.Key;
	}
}
