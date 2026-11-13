using System;
using System.Threading;
using c;

namespace A;

internal static class RecoveredType100
{
	public static void RecoveredMethod397(RecoveredType99 P_0, CancellationToken P_1)
	{
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int failedClicks = 0;
		string text = "Waiting for the backpack tool.";
		for (int i = 0; i < 100; i++)
		{
			P_1.ThrowIfCancellationRequested();
			RecoveredType98 recoveredType = P_0.RecoveredMethod390();
			if (!recoveredType.Carried)
			{
				throw new Exception("The requested fruit/rod is no longer carried.");
			}
			if (recoveredType.Equipped)
			{
				P_0.RecoveredMethod391(false, P_1);
				return;
			}
			if (recoveredType.Slot >= 0)
			{
				P_0.RecoveredMethod391(false, P_1);
				recoveredType = P_0.RecoveredMethod390();
				if (recoveredType.Equipped)
				{
					return;
				}
				if (!recoveredType.Carried)
				{
					throw new Exception("The requested fruit/rod is no longer carried.");
				}
				if (recoveredType.Slot >= 0)
				{
					P_0.RecoveredMethod393(recoveredType.Slot, P_1);
					RecoveredMethod398(P_0, P_1);
				}
				continue;
			}
			if (!recoveredType.Open)
			{
				P_0.RecoveredMethod391(true, P_1);
				flag = false;
				num = 0;
				P_0.RecoveredMethod396(350, P_1);
				continue;
			}
			if (!recoveredType.ListReady)
			{
				text = "Waiting for the backpack inventory panel to settle.";
				num++;
			}
			else
			{
				if (recoveredType.TileVisible)
				{
					num = 0;
					if (RecoveredType232.RecoveredMethod657(recoveredType.Tile, recoveredType.Viewport))
					{
						try
						{
							P_0.RecoveredMethod394(P_1);
							RecoveredMethod398(P_0, P_1);
						}
						catch (OperationCanceledException)
						{
							throw;
						}
						catch (Exception error)
						{
							P_1.ThrowIfCancellationRequested();
							failedClicks++;
							P_0.ReportBackpackClickFailure("attempt " + failedClicks + "/2: " + error.Message);
							if (failedClicks >= 2)
							{
								throw new BackpackEquipmentException("Backpack click failed twice; fishing stopped to preserve the carried fruit. Open Activity, choose Export TXT, save the log and attach it when reporting a problem at github.com/stellsor/twist/issues/new.");
							}
							try
							{
								P_0.RecoverBackpackClick(P_1);
							}
							catch (OperationCanceledException)
							{
								throw;
							}
							catch (Exception recoveryError)
							{
								throw new BackpackEquipmentException("Backpack click recovery failed; fishing stopped. " + recoveryError.Message + " Open Activity, choose Export TXT, save the log and attach it when reporting a problem at github.com/stellsor/twist/issues/new.");
							}
						}
					}
					else
					{
						text = "Waiting to scroll the exact fruit/rod into view.";
						P_0.RecoveredMethod395((recoveredType.Tile.RecoveredField1939 < recoveredType.Viewport.RecoveredField1939) ? 120 : (-120), P_1);
						P_0.RecoveredMethod396(220, P_1);
					}
					continue;
				}
				text = "Waiting for the exact fruit/rod tile to appear in the backpack.";
				num++;
				if (num >= 5 && !flag && recoveredType.SearchReady)
				{
					P_0.RecoveredMethod392(P_1);
					flag = true;
					num = 0;
					P_0.RecoveredMethod396(450, P_1);
					continue;
				}
			}
			if (num >= 20 && !flag2)
			{
				P_0.RecoveredMethod391(false, P_1);
				P_0.RecoveredMethod396(250, P_1);
				P_0.RecoveredMethod391(true, P_1);
				P_0.RecoveredMethod396(450, P_1);
				flag2 = true;
				flag = false;
				num = 0;
			}
			else
			{
				P_0.RecoveredMethod396(100, P_1);
			}
		}
		if (failedClicks > 0)
		{
			throw new BackpackEquipmentException("Backpack click recovery failed; fishing stopped. " + text + " Open Activity, choose Export TXT, save the log and attach it when reporting a problem at github.com/stellsor/twist/issues/new.");
		}
		throw new Exception(text + " Retrying backpack recovery.");
	}

	private static void RecoveredMethod398(RecoveredType99 P_0, CancellationToken P_1)
	{
		for (int i = 0; i < 30; i++)
		{
			P_0.RecoveredMethod396(100, P_1);
			RecoveredType98 recoveredType = P_0.RecoveredMethod390();
			if (!recoveredType.Carried)
			{
				throw new Exception("The requested fruit/rod changed while equipping.");
			}
			if (recoveredType.Equipped)
			{
				P_0.RecoveredMethod391(false, P_1);
				return;
			}
		}
		throw new Exception("Equipping the exact fruit/rod was not acknowledged; retrying.");
	}
}
