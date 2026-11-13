using System;
using System.Globalization;
using System.Web.Script.Serialization;

namespace TwistApp;

public sealed class RoundRecord
{
	public string Id;

	public string Account;

	public string UserId;

	public string AtUtc;

	public double Seconds;

	public double Contact;

	public double Peak;

	public bool Full { get; set; }

	[ScriptIgnore]
	public string TimeLabel
	{
		get
		{
			if (!DateTime.TryParse(AtUtc, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result))
			{
				return "—";
			}
			return result.ToLocalTime().ToString("HH:mm");
		}
	}

	[ScriptIgnore]
	public string DurationLabel => Seconds.ToString("0.0", CultureInfo.InvariantCulture) + "s";

	[ScriptIgnore]
	public string ContactLabel => Contact.ToString("P0", CultureInfo.InvariantCulture);

	[ScriptIgnore]
	public string ResultLabel
	{
		get
		{
			if (!Full)
			{
				return "Ended early";
			}
			return "Full progress";
		}
	}
}
