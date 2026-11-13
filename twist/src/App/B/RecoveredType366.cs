using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using c;

namespace B;

internal sealed class RecoveredType366
{
	[CompilerGenerated]
	private sealed class RecoveredType367
	{
		public Stopwatch clock;

		public long RecoveredMethod858()
		{
			return clock.ElapsedMilliseconds;
		}
	}

	private readonly RecoveredType245 input;

	private readonly Action<int, CancellationToken> wait;

	private readonly Func<long> milliseconds;

	private Func<RecoveredType365> resolve;

	private long next;

	public RecoveredType366(RecoveredType245 P_0, Action<int, CancellationToken> P_1 = null, Func<long> P_2 = null)
	{
		input = P_0;
		Stopwatch clock = Stopwatch.StartNew();
		milliseconds = P_2 ?? ((Func<long>)(() => clock.ElapsedMilliseconds));
		wait = P_1 ?? ((Action<int, CancellationToken>)delegate(int millisecondsTimeout, CancellationToken cancellationToken)
		{
			if (cancellationToken.WaitHandle.WaitOne(millisecondsTimeout))
			{
				cancellationToken.ThrowIfCancellationRequested();
			}
		});
	}

	public void RecoveredMethod853(Func<RecoveredType365> P_0)
	{
		resolve = P_0;
		next = milliseconds();
	}

	public void RecoveredMethod45()
	{
		resolve = null;
	}

	private RecoveredType365 RecoveredMethod854(bool P_0 = false)
	{
		try
		{
			return (resolve == null) ? null : resolve();
		}
		catch (Exception ex)
		{
			if (P_0)
			{
				throw new Exception("The UI target is not ready: " + ex.Message, ex);
			}
			return null;
		}
	}

	private static bool RecoveredMethod855(RecoveredType126 P_0, RecoveredType126 P_1)
	{
		if (P_0.Left == P_1.Left && P_0.Top == P_1.Top && P_0.Width == P_1.Width)
		{
			return P_0.Height == P_1.Height;
		}
		return false;
	}

	public static double[][] RecoveredMethod856(RecoveredType381 P_0, RecoveredType126 P_1)
	{
		if (!P_0.RecoveredMethod872(P_1, out var num, out var num2))
		{
			throw new Exception("The hover target is outside Roblox.");
		}
		double num3 = P_0.RecoveredField1938 + P_0.Width / 2.0;
		double num4 = P_0.RecoveredField1939 + P_0.Height / 2.0;
		double num5 = Math.Min(6.0, P_0.Width / 2.0 - 5.0);
		double num6 = Math.Min(6.0, P_0.Height / 2.0 - 5.0);
		if (num5 >= 4.0 && num3 - num5 >= 5.0 && num3 + num5 < (double)(P_1.Width - 5))
		{
			return new double[4][]
			{
				new double[2] { num, num2 },
				new double[2]
				{
					(num3 - num5) / (double)(P_1.Width - 1),
					num2
				},
				new double[2]
				{
					(num3 + num5) / (double)(P_1.Width - 1),
					num2
				},
				new double[2] { num, num2 }
			};
		}
		if (num6 >= 4.0 && num4 - num6 >= 5.0 && num4 + num6 < (double)(P_1.Height - 5))
		{
			return new double[4][]
			{
				new double[2] { num, num2 },
				new double[2]
				{
					num,
					(num4 - num6) / (double)(P_1.Height - 1)
				},
				new double[2]
				{
					num,
					(num4 + num6) / (double)(P_1.Height - 1)
				},
				new double[2] { num, num2 }
			};
		}
		return new double[1][] { new double[2] { num, num2 } };
	}

	public bool RecoveredMethod857(CancellationToken P_0, bool P_1 = false)
	{
		P_0.ThrowIfCancellationRequested();
		if (resolve == null || input.Held || (!P_1 && milliseconds() < next))
		{
			return false;
		}
		try
		{
			input.RecoveredMethod50();
		}
		catch
		{
			RecoveredMethod45();
			if (P_1)
			{
				throw;
			}
			return false;
		}
		RecoveredType365 recoveredType = RecoveredMethod854(P_1);
		if (recoveredType == null)
		{
			RecoveredMethod45();
			if (P_1)
			{
				throw new Exception("The UI target changed before the hover refresh.");
			}
			return false;
		}
		double[][] array = RecoveredMethod856(recoveredType.Rectangle, recoveredType.Client);
		foreach (double[] array2 in array)
		{
			P_0.ThrowIfCancellationRequested();
			RecoveredType365 recoveredType2 = RecoveredMethod854(P_1);
			if (recoveredType2 == null || recoveredType2.Node != recoveredType.Node || !recoveredType2.Rectangle.RecoveredMethod873(recoveredType.Rectangle) || !RecoveredMethod855(recoveredType2.Client, recoveredType.Client))
			{
				RecoveredMethod45();
				throw new Exception("The UI target moved during the hover refresh; waiting for its new position.");
			}
			input.RecoveredMethod672(array2[0], array2[1]);
			input.RecoveredMethod674(array2[0], array2[1]);
			wait(80, P_0);
			input.RecoveredMethod50();
		}
		next = milliseconds() + 2000;
		return true;
	}

	[CompilerGenerated]
	private static void RecoveredMethod393(int P_0, CancellationToken P_1)
	{
		if (P_1.WaitHandle.WaitOne(P_0))
		{
			P_1.ThrowIfCancellationRequested();
		}
	}
}
