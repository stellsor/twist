using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace A;

internal sealed class RecoveredType141
{
	public bool SpawnEnabled = true;

	public bool Enabled;

	public bool PingMythical;

	public string Url = "";

	public string PingKind = "User";

	public string PingId = "";

	public RecoveredType141 RecoveredMethod524()
	{
		return (RecoveredType141)MemberwiseClone();
	}

	public void RecoveredMethod50()
	{
		if (Enabled || Url != "")
		{
			RecoveredMethod526();
		}
		if (PingKind != "User" && PingKind != "Role" && PingKind != "Everyone")
		{
			throw new Exception("Choose User, Role or Everyone for mythical pings.");
		}
	}

	public string RecoveredMethod525()
	{
		string input = (PingId ?? "").Trim();
		Match match = Regex.Match(input, "^(?:<@!?([0-9]{16,20})>|<@&([0-9]{16,20})>|([0-9]{16,20}))$");
		if (!match.Success)
		{
			return "";
		}
		string text = (match.Groups[1].Success ? match.Groups[1].Value : (match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value));
		if (!ulong.TryParse(text, out var result) || result == 0)
		{
			return "";
		}
		return text;
	}

	public Uri RecoveredMethod526()
	{
		if (!Uri.TryCreate(Url, UriKind.Absolute, out var result) || result.Scheme != "https" || result.Port != 443 || result.UserInfo != "" || result.Fragment != "" || !new string[4] { "discord.com", "discordapp.com", "canary.discord.com", "ptb.discord.com" }.Contains(result.Host.ToLowerInvariant()) || !Regex.IsMatch(result.AbsolutePath, "^/api(?:/v[0-9]+)?/webhooks/[0-9]{15,22}/[A-Za-z0-9_-]{20,250}/?$"))
		{
			throw new Exception("Enter a valid HTTPS Discord webhook URL.");
		}
		string text = result.Query.TrimStart('?');
		string text2 = "";
		string[] array = text.Split('&');
		foreach (string text3 in array)
		{
			switch (text3)
			{
			case "":
			case "wait=true":
			case "wait=false":
				continue;
			}
			if (Regex.IsMatch(text3, "^thread_id=[0-9]{15,22}$") && text2 == "")
			{
				text2 = text3;
				continue;
			}
			throw new Exception("Only a Discord thread_id is supported in the webhook query.");
		}
		UriBuilder uriBuilder = new UriBuilder(result);
		uriBuilder.Query = "wait=true" + ((text2 == "") ? "" : ("&" + text2));
		return uriBuilder.Uri;
	}
}
