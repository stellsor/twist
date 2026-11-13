using System;
using A;

namespace B;

internal struct RecoveredType381
{
	public double RecoveredField1938;

	public double RecoveredField1939;

	public double Width;

	public double Height;

	public static RecoveredType381 RecoveredMethod871(byte[] P_0)
	{
		if (P_0 == null || P_0.Length < 16)
		{
			throw new Exception("The UI rectangle could not be read.");
		}
		return new RecoveredType381
		{
			RecoveredField1938 = BitConverter.ToSingle(P_0, 0),
			RecoveredField1939 = BitConverter.ToSingle(P_0, 4),
			Width = BitConverter.ToSingle(P_0, 8),
			Height = BitConverter.ToSingle(P_0, 12)
		};
	}

	public bool RecoveredMethod872(RecoveredType126 P_0, out double P_1, out double P_2)
	{
		P_1 = (P_2 = 0.0);
		double num = RecoveredField1938 + Width / 2.0;
		double num2 = RecoveredField1939 + Height / 2.0;
		double[] array = new double[6] { RecoveredField1938, RecoveredField1939, Width, Height, num, num2 };
		foreach (double d in array)
		{
			if (double.IsNaN(d) || double.IsInfinity(d))
			{
				return false;
			}
		}
		if (Width < 2.0 || Height < 2.0 || P_0.Width < 10 || P_0.Height < 10 || num < 0.0 || num2 < 0.0 || num >= (double)P_0.Width || num2 >= (double)P_0.Height)
		{
			return false;
		}
		P_1 = num / (double)(P_0.Width - 1);
		P_2 = num2 / (double)(P_0.Height - 1);
		return true;
	}

	public bool RecoveredMethod873(RecoveredType381 P_0)
	{
		if (Math.Abs(RecoveredField1938 - P_0.RecoveredField1938) < 1.0 && Math.Abs(RecoveredField1939 - P_0.RecoveredField1939) < 1.0 && Math.Abs(Width - P_0.Width) < 1.0)
		{
			return Math.Abs(Height - P_0.Height) < 1.0;
		}
		return false;
	}
}
