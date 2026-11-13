using System;
using System.IO;
using System.Web.Script.Serialization;
using B;

namespace a;

internal sealed class RecoveredType170
{
	public double UiOffsetX;

	public double UiOffsetY;

	public double CastX = 0.5;

	public double CastY = 0.42;

	public double PredictionMs = 55.0;

	public double DeadZone = 0.02;

	public int CastHoldMs = 350;

	public int BiteTimeoutSeconds = 75;

	public int RecastDelayMs = 1500;

	public int EquipSlot;

	public int StopAfterRounds;

	public double StopAfterMinutes;

	public int RestockBelow = 50;

	public int RestockBuy = 100;

	public string BaitMode = "common";

	public bool AutoRestockCommon = true;

	public bool AutoStoreFruits = true;

	public bool DropDuplicateFruits = true;

	public RecoveredType170 RecoveredMethod568()
	{
		return (RecoveredType170)MemberwiseClone();
	}

	public static RecoveredType170 RecoveredMethod569(string P_0)
	{
		if (!File.Exists(P_0))
		{
			return new RecoveredType170();
		}
		RecoveredType170 recoveredType = new JavaScriptSerializer().Deserialize<RecoveredType170>(File.ReadAllText(P_0));
		if (recoveredType == null)
		{
			throw new Exception("Empty profile.");
		}
		recoveredType.RecoveredMethod50();
		return recoveredType;
	}

	public void RecoveredMethod50()
	{
		if (RestockBelow < 0 || RestockBelow > 100000 || RestockBuy < 1 || RestockBuy > 100000)
		{
			throw new Exception("Bait restock threshold must be 0–100000 and purchase amount 1–100000.");
		}
		if (double.IsNaN(UiOffsetX) || double.IsInfinity(UiOffsetX) || double.IsNaN(UiOffsetY) || double.IsInfinity(UiOffsetY) || Math.Abs(UiOffsetX) > 512.0 || Math.Abs(UiOffsetY) > 512.0)
		{
			throw new Exception("UI alignment is outside supported bounds.");
		}
		if (BaitMode != "common" && BaitMode != "best")
		{
			throw new Exception("Choose Common or Best available bait.");
		}
		if (StopAfterRounds < 0 || StopAfterRounds > 10000 || double.IsNaN(StopAfterMinutes) || double.IsInfinity(StopAfterMinutes) || StopAfterMinutes < 0.0 || StopAfterMinutes > 1440.0)
		{
			throw new Exception("Session limits are outside their supported ranges.");
		}
		if (double.IsNaN(CastX) || double.IsNaN(CastY) || CastX < 0.0 || CastX > 1.0 || CastY < 0.0 || CastY > 1.0 || CastHoldMs < 40 || CastHoldMs > 3000 || BiteTimeoutSeconds < 10 || BiteTimeoutSeconds > 300 || RecastDelayMs < 500 || RecastDelayMs > 10000 || EquipSlot < 0 || EquipSlot > 9 || PredictionMs < 0.0 || PredictionMs > 150.0 || DeadZone < 0.002 || DeadZone > 0.1)
		{
			throw new Exception("Profile values are outside their supported ranges.");
		}
	}

	public void RecoveredMethod414(string P_0)
	{
		RecoveredMethod50();
		RecoveredType351.RecoveredMethod82(P_0, new JavaScriptSerializer().Serialize(this));
	}
}
