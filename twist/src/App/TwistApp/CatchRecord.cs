using System;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Windows.Media;

namespace TwistApp;

public sealed class CatchRecord
{
	public string EvidenceId { get; set; }

	public string Id { get; set; }

	public string UserId { get; set; }

	public string Account { get; set; }

	public string Name { get; set; }

	public string Rarity { get; set; }

	public string AtUtc { get; set; }

	public int Count { get; set; }

	[ScriptIgnore]
	public string TimeLabel
	{
		get
		{
			if (!DateTime.TryParse(AtUtc, null, DateTimeStyles.RoundtripKind, out var result))
			{
				return "—";
			}
			return result.ToLocalTime().ToString("MMM d · HH:mm");
		}
	}

	[ScriptIgnore]
	public string QuantityLabel => "+" + Count;

	[ScriptIgnore]
	public Brush RarityBrush => RarityStyle.Brush(Rarity);
}
