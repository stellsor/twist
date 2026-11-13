using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace A;

internal static class RecoveredType84
{
	public static string RecoveredMethod364(string P_0, int P_1 = 1200)
	{
		P_0 = Regex.Replace(P_0 ?? "", "https?://(?:(?:canary|ptb)\\.)?(?:discord(?:app)?\\.com)/api/webhooks/[^\\s]+", "[webhook hidden]", RegexOptions.IgnoreCase);
		P_0 = Regex.Replace(P_0, "twist1:\\d+:[a-fA-F0-9]{64}", "[pairing code hidden]");
		P_0 = P_0.Replace('\r', ' ').Replace('\n', ' ');
		if (P_0.Length > P_1)
		{
			return P_0.Substring(0, P_1) + "…";
		}
		return P_0;
	}

	public static RecoveredType82 RecoveredMethod365(string P_0, string P_1 = "", string P_2 = "", string P_3 = "")
	{
		if (string.IsNullOrWhiteSpace(P_0) || P_0.Contains(" stopped · ") || P_0.Contains(" reel · ") || (P_0.Contains(" input · ") && P_0.IndexOf("Backpack click", StringComparison.Ordinal) < 0) || (P_0.Contains(" fruit input · ") && P_0.IndexOf("Backpack click", StringComparison.Ordinal) < 0))
		{
			return null;
		}
		string category = "General";
		string level = "Info";
		string text = P_0.ToLowerInvariant();
		if (text.Contains("retry") || text.Contains("paused") || text.Contains("not ready") || text.Contains("not acknowledged"))
		{
			level = "Warning";
		}
		if (text.Contains("failed") || text.Contains("could not") || text.Contains("error"))
		{
			level = "Error";
		}
		if (text.Contains("bait") || text.Contains("purchase") || text.Contains("vendor"))
		{
			category = "Supplies";
		}
		else if (text.Contains("fruit") || text.Contains("storing") || text.Contains("backpack"))
		{
			category = "Fruits";
		}
		else if (text.Contains("connect") || text.Contains("attach") || text.Contains("client") || text.Contains("worker") || text.Contains("controller"))
		{
			category = "Connection";
		}
		else if (text.Contains("cast") || text.Contains("round") || text.Contains("fish") || text.Contains("rod"))
		{
			category = "Fishing";
		}
		if (text.Contains("cast with real"))
		{
			P_0 = "Cast sent. Waiting for a bite.";
		}
		else if (text.Contains("fishing meter detected"))
		{
			P_0 = "Fish hooked. Tracking the minigame.";
		}
		RecoveredType82 recoveredType = new RecoveredType82();
		recoveredType.Account = P_1 ?? "";
		recoveredType.UserId = P_2 ?? "";
		recoveredType.Source = P_3 ?? "";
		recoveredType.Category = category;
		recoveredType.Level = level;
		recoveredType.Message = RecoveredMethod364(P_0);
		return recoveredType;
	}

	public static bool RecoveredMethod182(RecoveredType82 P_0)
	{
		DateTime result;
		if (P_0 != null && !string.IsNullOrEmpty(P_0.Id) && P_0.Id.Length <= 100 && P_0.Message != null && P_0.Message.Length <= 2400 && P_0.Account != null && P_0.Account.Length <= 120 && P_0.UserId != null && P_0.UserId.Length <= 40 && P_0.Source != null && P_0.Source.Length <= 120 && P_0.Category != null && P_0.Category.Length <= 40 && new string[3] { "Info", "Warning", "Error" }.Contains(P_0.Level))
		{
			return DateTime.TryParse(P_0.AtUtc, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out result);
		}
		return false;
	}

	public static RecoveredType82 RecoveredMethod366(RecoveredType82 P_0)
	{
		RecoveredType82 recoveredType = P_0.RecoveredMethod361();
		recoveredType.Message = RecoveredMethod364(recoveredType.Message);
		recoveredType.Account = RecoveredMethod364(recoveredType.Account, 100);
		recoveredType.Source = RecoveredMethod364(recoveredType.Source, 100);
		return recoveredType;
	}
}
