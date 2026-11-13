using System;
using System.Collections.Generic;
using System.Diagnostics;
using a;

namespace b;

internal sealed class RecoveredType397
{
	private readonly RecoveredType208 memory;

	private readonly RecoveredType285 reader;

	private readonly RecoveredType163 map;

	private readonly ulong model;

	private readonly List<ulong> prompts = new List<ulong>();

	private readonly Queue<ulong> scan = new Queue<ulong>();

	private readonly HashSet<ulong> seen = new HashSet<ulong>();

	private DateTime scanned = DateTime.MinValue;

	private ulong workspace;

	public RecoveredType397(RecoveredType208 P_0, RecoveredType285 P_1, RecoveredType163 P_2, ulong P_3)
	{
		memory = P_0;
		reader = P_1;
		map = P_2;
		model = P_3;
	}

	private static bool RecoveredMethod39(string P_0)
	{
		switch (P_0)
		{
		default:
			return P_0 == "CornerWedgePart";
		case "Part":
		case "MeshPart":
		case "UnionOperation":
		case "WedgePart":
		case "TrussPart":
			return true;
		}
	}

	private double[] RecoveredMethod880(ulong P_0)
	{
		byte[] array = memory.RecoveredMethod609(P_0, 12);
		if (array == null)
		{
			return null;
		}
		double[] array2 = new double[3]
		{
			BitConverter.ToSingle(array, 0),
			BitConverter.ToSingle(array, 4),
			BitConverter.ToSingle(array, 8)
		};
		double[] array3 = array2;
		foreach (double num in array3)
		{
			if (double.IsNaN(num) || double.IsInfinity(num) || Math.Abs(num) > 10000000.0)
			{
				return null;
			}
		}
		return array2;
	}

	private double[] RecoveredMethod881(ulong P_0)
	{
		if (!RecoveredType285.RecoveredMethod572(P_0) || !RecoveredMethod39(reader.RecoveredMethod607(P_0)))
		{
			return null;
		}
		ulong num = reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("BasePart", "Primitive"));
		if (!RecoveredType285.RecoveredMethod572(num))
		{
			return null;
		}
		return RecoveredMethod880(num + map.RecoveredMethod554("Primitive", "Position"));
	}

	private string RecoveredMethod475(ulong P_0)
	{
		ulong num = P_0 + map.RecoveredMethod554("ProximityPrompt", "ObjectText");
		string text = reader.RecoveredMethod475(num);
		if (!(text != ""))
		{
			return reader.RecoveredMethod475(reader.RecoveredMethod753(num));
		}
		return text;
	}

	private double[] RecoveredMethod479(ulong P_0)
	{
		ulong num = reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("Instance", "Parent"));
		double[] array = null;
		for (int i = 0; i < 8; i++)
		{
			if (!RecoveredType285.RecoveredMethod572(num))
			{
				break;
			}
			string text = reader.RecoveredMethod607(num);
			if (text == "Attachment")
			{
				if (array != null)
				{
					return null;
				}
				array = RecoveredMethod880(num + map.RecoveredMethod554("Attachment", "Position"));
				if (array == null)
				{
					return null;
				}
			}
			if (RecoveredMethod39(text))
			{
				double[] array2 = RecoveredMethod881(num);
				if (array2 == null || array == null)
				{
					return array2;
				}
				ulong num2 = reader.RecoveredMethod753(num + map.RecoveredMethod554("BasePart", "Primitive"));
				byte[] array3 = memory.RecoveredMethod609(num2 + map.RecoveredMethod554("Primitive", "Rotation"), 36);
				if (array3 == null)
				{
					return null;
				}
				for (int m = 0; m < 3; m++)
				{
					double num3 = 0.0;
					for (int n = 0; n < 3; n++)
					{
						double num4 = BitConverter.ToSingle(array3, (m * 3 + n) * 4);
						if (double.IsNaN(num4) || double.IsInfinity(num4) || Math.Abs(num4) > 1.01)
						{
							return null;
						}
						num3 += num4 * array[n];
					}
					array2[m] += num3;
				}
				return array2;
			}
			if (text == "Model")
			{
				ulong num5 = reader.RecoveredMethod753(num + map.RecoveredMethod554("Model", "PrimaryPart"));
				return RecoveredMethod881(num5);
			}
			num = reader.RecoveredMethod753(num + map.RecoveredMethod554("Instance", "Parent"));
		}
		return null;
	}

	private void RecoveredMethod45()
	{
		if (scan.Count == 0 && DateTime.UtcNow - scanned > TimeSpan.FromSeconds(5.0))
		{
			ulong num = reader.RecoveredMethod756(model, "Workspace");
			if (!RecoveredType285.RecoveredMethod572(num))
			{
				return;
			}
			workspace = num;
			scan.Enqueue(workspace);
			seen.Clear();
			prompts.Clear();
			scanned = DateTime.UtcNow;
		}
		Stopwatch stopwatch = Stopwatch.StartNew();
		int num2 = 0;
		while (scan.Count > 0 && num2++ < 1500 && stopwatch.ElapsedMilliseconds < 25)
		{
			ulong num3 = scan.Dequeue();
			if (!seen.Add(num3))
			{
				continue;
			}
			if (reader.RecoveredMethod607(num3) == "ProximityPrompt" && RecoveredType387.RecoveredMethod39(RecoveredMethod475(num3)))
			{
				prompts.Add(num3);
			}
			if (seen.Count >= 150000)
			{
				scan.Clear();
				break;
			}
			foreach (ulong item in reader.RecoveredMethod755(num3))
			{
				if (scan.Count < 150000)
				{
					scan.Enqueue(item);
				}
			}
		}
	}

	private bool RecoveredMethod647(ulong P_0)
	{
		for (int i = 0; i < 80; i++)
		{
			if (!RecoveredType285.RecoveredMethod572(P_0))
			{
				break;
			}
			if (P_0 == workspace)
			{
				return true;
			}
			P_0 = reader.RecoveredMethod753(P_0 + map.RecoveredMethod554("Instance", "Parent"));
		}
		return false;
	}

	public bool RecoveredMethod882(out string P_0)
	{
		try
		{
			ulong num = reader.RecoveredMethod756(model, "Players");
			ulong num2 = reader.RecoveredMethod753(num + map.Core.LocalPlayer);
			ulong num3 = reader.RecoveredMethod753(num2 + map.RecoveredMethod554("Player", "ModelInstance"));
			double[] array = RecoveredMethod881(reader.RecoveredMethod756(num3, "HumanoidRootPart"));
			if (array == null)
			{
				P_0 = "Waiting for player world position";
				return false;
			}
			RecoveredMethod45();
			double num4 = double.MaxValue;
			foreach (ulong prompt in prompts)
			{
				if (reader.RecoveredMethod607(prompt) != "ProximityPrompt" || !RecoveredType387.RecoveredMethod39(RecoveredMethod475(prompt)) || !RecoveredMethod647(prompt))
				{
					continue;
				}
				byte[] array2 = memory.RecoveredMethod609(prompt + map.RecoveredMethod554("ProximityPrompt", "Enabled"), 1);
				if (array2 == null || array2[0] != 1)
				{
					continue;
				}
				double[] array3 = RecoveredMethod479(prompt);
				if (array3 != null)
				{
					double num5 = RecoveredMethod883(array, array3);
					if (num5 < num4)
					{
						num4 = num5;
					}
				}
			}
			P_0 = ((num4 != double.MaxValue) ? ("Common bait vendor " + num4.ToString("0.0") + " studs away") : ((scan.Count > 0) ? "Scanning nearby vendors" : "No enabled Common Fish Bait vendor found"));
			return num4 <= 12.0;
		}
		catch (KeyNotFoundException)
		{
			P_0 = "World vendor offsets unavailable for this Roblox version";
			return false;
		}
		catch (Exception)
		{
			P_0 = "Waiting for readable vendor world position";
			return false;
		}
	}

	public static double RecoveredMethod883(double[] P_0, double[] P_1)
	{
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			num += (P_0[i] - P_1[i]) * (P_0[i] - P_1[i]);
		}
		return Math.Sqrt(num);
	}
}
