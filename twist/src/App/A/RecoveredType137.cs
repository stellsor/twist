using System;
using System.Collections.Generic;
using System.ComponentModel;
using D;
using TwistApp;
using a;

namespace A;

internal sealed class RecoveredType137 : INotifyPropertyChanged
{
	public readonly bool IsTotal;

	public RecoveredType163 Offsets;

	public RecoveredType131 Session;

	public RecoveredType133 Inventory;

	public DateTime InventoryUpdated;

	public DateTime NextAttachUtc;

	public bool Attaching;

	public bool InventoryValid;

	public string RemoteProfileVersion = "";

	private RecoveredType174 data;

	public readonly List<ChartPoint> Points = new List<ChartPoint>();

	public string Account => data.Account;

	public string Label
	{
		get
		{
			if (IsTotal)
			{
				return "Total · all accounts";
			}
			RecoveredType325 recoveredType = Session as RecoveredType325;
			return data.Account + ((recoveredType == null) ? "" : (" · S" + recoveredType.Peer.SessionId));
		}
	}

	public string PidLabel
	{
		get
		{
			if (IsTotal)
			{
				return "Combined inventory, catches and controls";
			}
			return "PID " + data.Pid + " · " + data.UserId;
		}
	}

	public RecoveredType174 State => data;

	public event PropertyChangedEventHandler PropertyChanged;

	public RecoveredType137(bool P_0)
	{
		IsTotal = P_0;
		data = new RecoveredType174
		{
			Account = "Total"
		};
	}

	public RecoveredType137(RecoveredType131 P_0)
	{
		Session = P_0;
		data = P_0.RecoveredMethod509();
	}

	public void RecoveredMethod519(double P_0)
	{
		RecoveredType174 recoveredType = data;
		data = Session.RecoveredMethod509();
		if (data.Reeling && (Points.Count == 0 || P_0 - Points[Points.Count - 1].Time >= 0.05))
		{
			Points.Add(new ChartPoint
			{
				Time = P_0,
				Player = data.Player,
				Fish = data.Goal
			});
			while (Points.Count > 0 && P_0 - Points[0].Time > 31.0)
			{
				Points.RemoveAt(0);
			}
		}
		if (this.PropertyChanged != null && (recoveredType.Account != data.Account || recoveredType.UserId != data.UserId || recoveredType.Pid != data.Pid))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(null));
		}
	}
}
