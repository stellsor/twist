using A;
using TwistApp;

namespace a;

internal sealed class RecoveredType174
{
	public RecoveredType82[] Activity = new RecoveredType82[0];

	public string StopReason = "";

	public string StoppedAtUtc = "";

	public string StopLevel = "Info";

	public WorldSnapshot World = new WorldSnapshot();

	public string Account = "Reading…";

	public string Display = "";

	public string UserId = "";

	public string Place = "";

	public string Connection = "Detached";

	public string Status = "Ready to attach";

	public string Input = "Unverified";

	public string Detail = "";

	public string Bait = "";

	public int CommonBait = -1;

	public int FruitsStored;

	public int FruitsDropped;

	public string LastFruit = "";

	public FruitStoredRecord[] FruitStores = new FruitStoredRecord[0];

	public int Pid;

	public int Rounds;

	public int FullRounds;

	public double ActiveSeconds;

	public double TrackedSeconds;

	public double OnTargetSeconds;

	public double BarHeight = 0.25;

	public bool Reeling;

	public long Created;

	public bool Running;

	public bool Attached;

	public bool Held;

	public bool AutoFish;

	public double Player;

	public double Goal;

	public double Progress;

	public RecoveredType174 RecoveredMethod509()
	{
		return (RecoveredType174)MemberwiseClone();
	}
}
