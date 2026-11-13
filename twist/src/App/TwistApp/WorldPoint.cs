using System;
using System.Globalization;
using System.Web.Script.Serialization;

namespace TwistApp;

public sealed class WorldPoint
{
	public double RecoveredField2015;

	public double RecoveredField2016;

	public double RecoveredField2017;

	[ScriptIgnore]
	public bool Valid
	{
		get
		{
			if (Finite(RecoveredField2015) && Finite(RecoveredField2016))
			{
				return Finite(RecoveredField2017);
			}
			return false;
		}
	}

	[ScriptIgnore]
	public string Label
	{
		get
		{
			if (!Valid)
			{
				return "Position unavailable";
			}
			return "X " + Math.Floor(RecoveredField2015).ToString("0", CultureInfo.InvariantCulture) + "   Y " + Math.Floor(RecoveredField2016).ToString("0", CultureInfo.InvariantCulture) + "   Z " + Math.Floor(RecoveredField2017).ToString("0", CultureInfo.InvariantCulture);
		}
	}

	[ScriptIgnore]
	public string Compact => Math.Floor(RecoveredField2015).ToString("0", CultureInfo.InvariantCulture) + ", " + Math.Floor(RecoveredField2016).ToString("0", CultureInfo.InvariantCulture) + ", " + Math.Floor(RecoveredField2017).ToString("0", CultureInfo.InvariantCulture);

	public static bool Finite(double n)
	{
		if (!double.IsNaN(n) && !double.IsInfinity(n))
		{
			return Math.Abs(n) < 10000000.0;
		}
		return false;
	}

	public double Distance(WorldPoint other)
	{
		return Math.Sqrt(Math.Pow(RecoveredField2015 - other.RecoveredField2015, 2.0) + Math.Pow(RecoveredField2016 - other.RecoveredField2016, 2.0) + Math.Pow(RecoveredField2017 - other.RecoveredField2017, 2.0));
	}
}
