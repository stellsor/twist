using System.Collections.Generic;
using A;

namespace c;

internal sealed class RecoveredType251 : RecoveredType117
{
	public bool InFocus = true;

	public bool PhysicalDown;

	public bool LoseFocusOnMove;

	public List<string> Events = new List<string>();

	public List<int> Keys = new List<int>();

	public List<double[]> Positions = new List<double[]>();

	public bool Focused => InFocus;

	public bool LeftIsDown => PhysicalDown;

	public void RecoveredMethod348(double P_0, double P_1)
	{
		Events.Add("move");
		Positions.Add(new double[2] { P_0, P_1 });
		if (LoseFocusOnMove)
		{
			InFocus = false;
		}
	}

	public void RecoveredMethod72(bool P_0)
	{
		Events.Add(P_0 ? "down" : "up");
	}

	public void RecoveredMethod469(int P_0, bool P_1)
	{
		if (P_1)
		{
			Keys.Add(P_0);
		}
		Events.Add(P_1 ? "key-down" : "key-up");
	}
}
