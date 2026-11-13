using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using a;
using c;

namespace B;

internal static class RecoveredType368
{
	private sealed class RecoveredType369 : RecoveredType117, RecoveredType244
	{
		public bool InFocus = true;

		public bool BadPoint;

		public int Keys;

		public int MousePackets;

		public readonly List<double[]> Points = new List<double[]>();

		public Action OnMove;

		public bool Focused => InFocus;

		public bool LeftIsDown => false;

		public void RecoveredMethod348(double P_0, double P_1)
		{
			Points.Add(new double[2] { P_0, P_1 });
			if (OnMove != null)
			{
				OnMove();
			}
		}

		public string RecoveredMethod670(double P_0, double P_1)
		{
			if (!BadPoint)
			{
				return "";
			}
			return "Cursor missed target";
		}

		public void RecoveredMethod72(bool P_0)
		{
			MousePackets++;
		}

		public void RecoveredMethod469(int P_0, bool P_1)
		{
			Keys++;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType370
	{
		public RecoveredType365 target;

		public long clock;

		public RecoveredType369 focus;

		public CancellationTokenSource canceled;

		public void RecoveredMethod393(int P_0, CancellationToken P_1)
		{
			P_1.ThrowIfCancellationRequested();
			clock += P_0;
		}

		public long RecoveredMethod858()
		{
			return clock;
		}

		public RecoveredType365 RecoveredMethod867()
		{
			return target;
		}

		public void RecoveredMethod51()
		{
			focus.InFocus = false;
		}

		public void RecoveredMethod395(int P_0, CancellationToken P_1)
		{
			canceled.Cancel();
			P_1.ThrowIfCancellationRequested();
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType371
	{
		public bool resize;
	}

	[CompilerGenerated]
	private sealed class RecoveredType372
	{
		public RecoveredType371 CS_0024_003C_003E8__locals2c;

		public RecoveredType370 CS_0024_003C_003E8__locals2a;

		public RecoveredType365 RecoveredField1919;

		public int reads;

		public RecoveredType365 RecoveredMethod488()
		{
			if (++reads == 3)
			{
				if (CS_0024_003C_003E8__locals2c.resize)
				{
					RecoveredField1919.Client.Width = 1280;
				}
				else
				{
					RecoveredField1919.Rectangle.RecoveredField1938 += 50.0;
				}
			}
			return new RecoveredType365
			{
				Node = RecoveredField1919.Node,
				Client = RecoveredField1919.Client,
				Rectangle = RecoveredField1919.Rectangle
			};
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("UI hover test: " + P_1);
		}
	}

	private static RecoveredType365 RecoveredMethod488()
	{
		RecoveredType365 recoveredType = new RecoveredType365();
		recoveredType.Node = 123uL;
		recoveredType.Client = new RecoveredType126
		{
			Left = -1920,
			Top = 80,
			Width = 1920,
			Height = 1080
		};
		recoveredType.Rectangle = new RecoveredType381
		{
			RecoveredField1938 = 800.0,
			RecoveredField1939 = 700.0,
			Width = 160.0,
			Height = 20.0
		};
		return recoveredType;
	}

	public static void RecoveredMethod50()
	{
		RecoveredType365 target = RecoveredMethod488();
		RecoveredType369 recoveredType = new RecoveredType369();
		long clock = 0L;
		using (RecoveredType245 recoveredType2 = new RecoveredType245(recoveredType, 8851))
		{
			RecoveredType366 recoveredType3 = new RecoveredType366(recoveredType2, delegate(int P_0, CancellationToken P_1)
			{
				P_1.ThrowIfCancellationRequested();
				clock += P_0;
			}, () => clock);
			recoveredType3.RecoveredMethod853(() => target);
			RecoveredMethod42(recoveredType3.RecoveredMethod857(CancellationToken.None, true) && recoveredType.Points.Count == 4, "Initial hover emits center, left, right and center movements");
			foreach (double[] point in recoveredType.Points)
			{
				double num = point[0] * (double)(target.Client.Width - 1);
				double num2 = point[1] * (double)(target.Client.Height - 1);
				RecoveredMethod42(num >= target.Rectangle.RecoveredField1938 + 5.0 && num <= target.Rectangle.RecoveredField1938 + target.Rectangle.Width - 5.0 && num2 >= target.Rectangle.RecoveredField1939 + 5.0 && num2 <= target.Rectangle.RecoveredField1939 + target.Rectangle.Height - 5.0, "Every nudge stays inside the button");
			}
			RecoveredMethod42(recoveredType.MousePackets == 0 && recoveredType.Keys == 0, "Hover does not click, type or buy");
			RecoveredMethod42(Math.Abs(recoveredType.Points.Last()[0] - 0.4585721730067744) < 1E-05, "Hover ends at the target center");
			int count = recoveredType.Points.Count;
			clock += 1999L;
			RecoveredMethod42(!recoveredType3.RecoveredMethod857(CancellationToken.None) && recoveredType.Points.Count == count, "No nudge before the two-second interval");
			clock++;
			RecoveredMethod42(recoveredType3.RecoveredMethod857(CancellationToken.None) && recoveredType.Points.Count == count + 4, "A waiting UI target refreshes after two seconds");
			recoveredType2.RecoveredMethod565(true, 0.5, 0.5);
			count = recoveredType.Points.Count;
			clock += 3000L;
			RecoveredMethod42(!recoveredType3.RecoveredMethod857(CancellationToken.None, true) && recoveredType.Points.Count == count, "Held mouse control prevents hover movement");
			recoveredType2.RecoveredMethod565(false, 0.0, 0.0);
			recoveredType3.RecoveredMethod853(() => (RecoveredType365)null);
			count = recoveredType.Points.Count;
			RecoveredMethod42(!recoveredType3.RecoveredMethod857(CancellationToken.None) && recoveredType.Points.Count == count, "A closed target disarms without movement");
		}
		bool[] array = new bool[2] { false, true };
		foreach (bool resize in array)
		{
			RecoveredType369 recoveredType4 = new RecoveredType369();
			RecoveredType365 RecoveredField1919 = RecoveredMethod488();
			int reads = 0;
			using RecoveredType245 recoveredType5 = new RecoveredType245(recoveredType4, 8852);
			RecoveredType366 recoveredType6 = new RecoveredType366(recoveredType5, delegate
			{
			}, () => 0L);
			recoveredType6.RecoveredMethod853(delegate
			{
				if (++reads == 3)
				{
					if (resize)
					{
						RecoveredField1919.Client.Width = 1280;
					}
					else
					{
						RecoveredField1919.Rectangle.RecoveredField1938 += 50.0;
					}
				}
				return new RecoveredType365
				{
					Node = RecoveredField1919.Node,
					Client = RecoveredField1919.Client,
					Rectangle = RecoveredField1919.Rectangle
				};
			});
			bool flag = false;
			try
			{
				recoveredType6.RecoveredMethod857(CancellationToken.None, true);
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag && recoveredType4.Points.Count == 1 && recoveredType4.MousePackets == 0, "Moving layout or resized window stops before the next nudge");
		}
		RecoveredType369 recoveredType7 = new RecoveredType369();
		using (RecoveredType245 recoveredType8 = new RecoveredType245(recoveredType7, 8856))
		{
			RecoveredType366 recoveredType9 = new RecoveredType366(recoveredType8, delegate
			{
			}, () => 0L);
			recoveredType9.RecoveredMethod853(delegate
			{
				throw new Exception("Stored inventory unavailable");
			});
			string text = "";
			try
			{
				recoveredType9.RecoveredMethod857(CancellationToken.None, true);
			}
			catch (Exception ex)
			{
				text = ex.Message;
			}
			RecoveredMethod42(text.Contains("Stored inventory unavailable") && recoveredType7.Points.Count == 0, "pre-movement validation preserves the specific blocker instead of hiding it as a changed target");
			RecoveredMethod42(!recoveredType9.RecoveredMethod857(CancellationToken.None), "passive refresh can still disarm a closed target quietly");
		}
		RecoveredType369 focus = new RecoveredType369();
		using (RecoveredType245 recoveredType10 = new RecoveredType245(focus, 8853))
		{
			RecoveredType366 recoveredType11 = new RecoveredType366(recoveredType10, delegate
			{
			}, () => 0L);
			recoveredType11.RecoveredMethod853(RecoveredMethod488);
			focus.OnMove = delegate
			{
				focus.InFocus = false;
			};
			bool flag2 = false;
			try
			{
				recoveredType11.RecoveredMethod857(CancellationToken.None, true);
			}
			catch
			{
				flag2 = true;
			}
			RecoveredMethod42(flag2 && focus.Points.Count == 1 && focus.MousePackets == 0, "Focus loss interrupts the hover immediately");
		}
		RecoveredType369 recoveredType12 = new RecoveredType369();
		recoveredType12.BadPoint = true;
		RecoveredType369 recoveredType13 = recoveredType12;
		using (RecoveredType245 recoveredType14 = new RecoveredType245(recoveredType13, 8855))
		{
			RecoveredType366 recoveredType15 = new RecoveredType366(recoveredType14, delegate
			{
			}, () => 0L);
			recoveredType15.RecoveredMethod853(RecoveredMethod488);
			bool flag3 = false;
			try
			{
				recoveredType15.RecoveredMethod857(CancellationToken.None, true);
			}
			catch
			{
				flag3 = true;
			}
			RecoveredMethod42(flag3 && recoveredType13.Points.Count == 1 && recoveredType13.MousePackets == 0, "Cursor feedback failure prevents further nudges and clicks");
		}
		CancellationTokenSource canceled = new CancellationTokenSource();
		RecoveredType369 recoveredType16 = new RecoveredType369();
		using (RecoveredType245 recoveredType17 = new RecoveredType245(recoveredType16, 8854))
		{
			RecoveredType366 recoveredType18 = new RecoveredType366(recoveredType17, delegate(int P_0, CancellationToken P_1)
			{
				canceled.Cancel();
				P_1.ThrowIfCancellationRequested();
			}, () => 0L);
			recoveredType18.RecoveredMethod853(RecoveredMethod488);
			bool flag4 = false;
			try
			{
				recoveredType18.RecoveredMethod857(canceled.Token, true);
			}
			catch (OperationCanceledException)
			{
				flag4 = true;
			}
			RecoveredMethod42(flag4 && recoveredType16.Points.Count == 1 && recoveredType16.MousePackets == 0, "Stop cancels mid-hover without a click");
		}
		RecoveredType381[] array2 = new RecoveredType381[3]
		{
			new RecoveredType381
			{
				RecoveredField1938 = 10.0,
				RecoveredField1939 = 10.0,
				Width = 8.0,
				Height = 8.0
			},
			new RecoveredType381
			{
				RecoveredField1938 = 0.0,
				RecoveredField1939 = 0.0,
				Width = 20.0,
				Height = 20.0
			},
			new RecoveredType381
			{
				RecoveredField1938 = 1910.0,
				RecoveredField1939 = 100.0,
				Width = 10.0,
				Height = 30.0
			}
		};
		foreach (RecoveredType381 recoveredType19 in array2)
		{
			double[][] array3 = RecoveredType366.RecoveredMethod856(recoveredType19, RecoveredMethod488().Client);
			double[][] array4 = array3;
			foreach (double[] array5 in array4)
			{
				RecoveredMethod42(array5[0] >= 0.0 && array5[0] <= 1.0 && array5[1] >= 0.0 && array5[1] <= 1.0, "Small and edge controls produce only in-client points");
			}
		}
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: bounded UI hover pulses before clicking and at two-second intervals; ends centered; no mouse-button/key packets; held/reeling suppression; closed/moving/resized targets, focus-loss and Stop cancellation; small/edge geometry. Input and timing mocked.\r\n");
	}

	[CompilerGenerated]
	private static RecoveredType365 RecoveredMethod859()
	{
		return null;
	}

	[CompilerGenerated]
	private static void RecoveredMethod393(int P_0, CancellationToken P_1)
	{
	}

	[CompilerGenerated]
	private static long RecoveredMethod860()
	{
		return 0L;
	}

	[CompilerGenerated]
	private static void RecoveredMethod395(int P_0, CancellationToken P_1)
	{
	}

	[CompilerGenerated]
	private static long RecoveredMethod861()
	{
		return 0L;
	}

	[CompilerGenerated]
	private static RecoveredType365 RecoveredMethod862()
	{
		throw new Exception("Stored inventory unavailable");
	}

	[CompilerGenerated]
	private static void RecoveredMethod396(int P_0, CancellationToken P_1)
	{
	}

	[CompilerGenerated]
	private static long RecoveredMethod863()
	{
		return 0L;
	}

	[CompilerGenerated]
	private static void RecoveredMethod864(int P_0, CancellationToken P_1)
	{
	}

	[CompilerGenerated]
	private static long RecoveredMethod865()
	{
		return 0L;
	}

	[CompilerGenerated]
	private static long RecoveredMethod866()
	{
		return 0L;
	}
}
