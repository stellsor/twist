using System;
using A;

namespace a;

internal static class RecoveredType292
{
	public static RecoveredType291 RecoveredMethod760(uint P_0, bool P_1)
	{
		if (P_0 == 0 || P_0 > 65535)
		{
			throw new Exception("Windows could not map the requested key.");
		}
		return new RecoveredType291
		{
			Type = 1u,
			Data = new RecoveredType290
			{
				Key = new RecoveredType289
				{
					Scan = (ushort)(P_0 & 0xFF),
					Flags = ((uint)(8 | ((!P_1) ? 2 : 0)) | (((P_0 & 0xFF00) == 57344) ? 1u : 0u))
				}
			}
		};
	}

	public static RecoveredType291 RecoveredMethod761(int P_0)
	{
		if (P_0 == 0 || Math.Abs((long)P_0) > 1200)
		{
			throw new Exception("Invalid wheel step.");
		}
		return new RecoveredType291
		{
			Type = 0u,
			Data = new RecoveredType290
			{
				Mouse = new RecoveredType288
				{
					Data = (uint)P_0,
					Flags = 2048u
				}
			}
		};
	}

	public static RecoveredType291 RecoveredMethod762(bool P_0)
	{
		return new RecoveredType291
		{
			Type = 0u,
			Data = new RecoveredType290
			{
				Mouse = new RecoveredType288
				{
					Flags = (P_0 ? 2u : 4u)
				}
			}
		};
	}

	public static RecoveredType291 RecoveredMethod763(int P_0, int P_1)
	{
		if (P_0 < -32 || P_0 > 32 || P_1 < -32 || P_1 > 32)
		{
			throw new Exception("Relative mouse step is too large.");
		}
		return new RecoveredType291
		{
			Type = 0u,
			Data = new RecoveredType290
			{
				Mouse = new RecoveredType288
				{
					RecoveredField1576 = P_0,
					RecoveredField1577 = P_1,
					Flags = 1u
				}
			}
		};
	}

	public static int RecoveredMethod764(int P_0, int P_1, int P_2)
	{
		if (P_2 < 1 || P_0 < P_1 || P_0 >= (long)P_1 + (long)P_2)
		{
			throw new Exception("Mouse target is outside this session's desktop.");
		}
		return Math.Max(0, Math.Min(65535, (int)(((double)(P_0 - P_1) + 0.5) * 65536.0 / (double)P_2)));
	}

	public static RecoveredType291 RecoveredMethod765(int P_0, int P_1, RecoveredType126 P_2)
	{
		RecoveredType291 result = RecoveredMethod766(P_0, P_1, P_2);
		result.Data.Mouse.Flags |= 8192u;
		return result;
	}

	public static RecoveredType291 RecoveredMethod766(int P_0, int P_1, RecoveredType126 P_2)
	{
		return new RecoveredType291
		{
			Type = 0u,
			Data = new RecoveredType290
			{
				Mouse = new RecoveredType288
				{
					RecoveredField1576 = RecoveredMethod764(P_0, P_2.Left, P_2.Width),
					RecoveredField1577 = RecoveredMethod764(P_1, P_2.Top, P_2.Height),
					Flags = 49153u
				}
			}
		};
	}
}
