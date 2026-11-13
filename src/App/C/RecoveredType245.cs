using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using a;

namespace c;

internal sealed class RecoveredType245 : RecoveredType168, IDisposable
{
	private static int owner;

	private readonly RecoveredType117 device;

	private readonly int pid;

	private bool disposed;

	private bool uiPositioned;

	private double anchorX = 0.5;

	private double anchorY = 0.42;

	[CompilerGenerated]
	private bool _003CHeld_003Ek__BackingField;

	public bool Held
	{
		[CompilerGenerated]
		get
		{
			return _003CHeld_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CHeld_003Ek__BackingField = value;
		}
	}

	public void RecoveredMethod348(double P_0, double P_1)
	{
		anchorX = P_0;
		anchorY = P_1;
		RecoveredMethod45();
	}

	public void RecoveredMethod671(double P_0, double P_1)
	{
		RecoveredMethod50();
		uiPositioned = false;
		device.RecoveredMethod348(P_0, P_1);
		RecoveredMethod50();
	}

	public void RecoveredMethod672(double P_0, double P_1)
	{
		RecoveredMethod50();
		if (!(device is RecoveredType248 recoveredType))
		{
			device.RecoveredMethod348(P_0, P_1);
		}
		else
		{
			recoveredType.RecoveredMethod672(P_0, P_1);
		}
		RecoveredMethod50();
		uiPositioned = true;
	}

	public void RecoveredMethod45()
	{
		RecoveredMethod671(anchorX, anchorY);
	}

	public void RecoveredMethod673(int P_0)
	{
		RecoveredMethod50();
		if (!(device is RecoveredType243 recoveredType))
		{
			throw new Exception("Mouse wheel input is unavailable.");
		}
		recoveredType.RecoveredMethod377(P_0);
		RecoveredMethod50();
	}

	public void RecoveredMethod674(double P_0, double P_1)
	{
		RecoveredMethod50();
		if (device is RecoveredType244 recoveredType)
		{
			string text = recoveredType.RecoveredMethod670(P_0, P_1);
			if (text != "")
			{
				throw new Exception(text);
			}
		}
	}

	public void RecoveredMethod675(int P_0, int P_1, CancellationToken P_2)
	{
		P_2.ThrowIfCancellationRequested();
		RecoveredMethod50();
		try
		{
			device.RecoveredMethod469(P_0, true);
			int num = P_1;
			while (num > 0)
			{
				int num2 = Math.Min(40, num);
				if (P_2.WaitHandle.WaitOne(num2))
				{
					P_2.ThrowIfCancellationRequested();
				}
				RecoveredMethod50();
				num -= num2;
			}
		}
		finally
		{
			device.RecoveredMethod469(P_0, false);
		}
	}

	public RecoveredType245(RecoveredType117 P_0, int P_1)
	{
		device = P_0;
		pid = P_1;
		if (Interlocked.CompareExchange(ref owner, pid, 0) != 0)
		{
			throw new Exception("Another session already owns the real mouse and keyboard.");
		}
	}

	public void RecoveredMethod50()
	{
		if (disposed)
		{
			throw new ObjectDisposedException("ForegroundInput");
		}
		if (!device.Focused)
		{
			throw new Exception("Roblox lost focus. Fishing stopped and held input was released.");
		}
	}

	public void RecoveredMethod565(bool P_0, double P_1, double P_2)
	{
		if (P_0)
		{
			RecoveredMethod50();
			if (!Held)
			{
				if (device.LeftIsDown)
				{
					throw new Exception("Release the physical left mouse button before starting fishing.");
				}
				RecoveredType248 recoveredType = device as RecoveredType248;
				if (uiPositioned && recoveredType != null)
				{
					recoveredType.RecoveredMethod672(P_1, P_2);
				}
				else
				{
					device.RecoveredMethod348(P_1, P_2);
				}
				RecoveredMethod50();
				device.RecoveredMethod72(true);
				Held = true;
			}
		}
		else if (Held)
		{
			try
			{
				device.RecoveredMethod72(false);
			}
			finally
			{
				Held = false;
			}
		}
	}

	public void RecoveredMethod377(int P_0)
	{
		RecoveredMethod50();
		try
		{
			device.RecoveredMethod469(P_0, true);
			Thread.Sleep(35);
		}
		finally
		{
			device.RecoveredMethod469(P_0, false);
		}
	}

	private void RecoveredMethod392(CancellationToken P_0)
	{
		P_0.ThrowIfCancellationRequested();
		RecoveredMethod50();
		try
		{
			device.RecoveredMethod469(17, true);
			device.RecoveredMethod469(65, true);
			RecoveredMethod395(120, P_0);
		}
		finally
		{
			try
			{
				device.RecoveredMethod469(65, false);
			}
			finally
			{
				device.RecoveredMethod469(17, false);
			}
		}
		RecoveredMethod395(150, P_0);
	}

	public void RecoveredMethod394(CancellationToken P_0)
	{
		RecoveredMethod392(P_0);
		RecoveredMethod675(46, 100, P_0);
		RecoveredMethod395(200, P_0);
	}

	public void RecoveredMethod676(CancellationToken P_0)
	{
		RecoveredMethod392(P_0);
		RecoveredMethod675(8, 100, P_0);
		RecoveredMethod395(200, P_0);
	}

	public void RecoveredMethod393(int P_0, CancellationToken P_1 = default(CancellationToken))
	{
		if (P_0 < 0 || P_0 > 100000)
		{
			throw new Exception("Quantity is outside supported bounds.");
		}
		RecoveredMethod392(P_1);
		string text = P_0.ToString(CultureInfo.InvariantCulture);
		foreach (char c in text)
		{
			P_1.ThrowIfCancellationRequested();
			RecoveredMethod50();
			RecoveredMethod675(48 + (c - 48), 100, P_1);
			RecoveredMethod395(120, P_1);
		}
	}

	private void RecoveredMethod395(int P_0, CancellationToken P_1)
	{
		if (P_1.WaitHandle.WaitOne(P_0))
		{
			P_1.ThrowIfCancellationRequested();
		}
		RecoveredMethod50();
	}

	public void Dispose()
	{
		if (disposed)
		{
			return;
		}
		try
		{
			RecoveredMethod565(false, 0.0, 0.0);
		}
		finally
		{
			disposed = true;
			Interlocked.CompareExchange(ref owner, 0, pid);
		}
	}
}
