using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using A;
using B;
using TwistApp;
using a;
using b;
using d;

namespace c;

internal sealed class RecoveredType175 : RecoveredType131, IDisposable
{
	[CompilerGenerated]
	private sealed class RecoveredType176
	{
		public RecoveredType175 _003C_003E4__this;

		public Action<string> logger;

		public void RecoveredMethod48(string P_0)
		{
			RecoveredType174 recoveredType = _003C_003E4__this.RecoveredMethod509();
			_003C_003E4__this.activity.RecoveredMethod367(RecoveredType84.RecoveredMethod365(P_0, recoveredType.Account, recoveredType.UserId, "Session " + RecoveredType309.SessionId));
			logger(P_0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType177
	{
		public string[] info;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.Account = info[0];
			P_0.Display = info[1];
			P_0.UserId = info[2];
			P_0.Place = info[3];
			P_0.Attached = true;
			P_0.Connection = "Attached";
			P_0.Status = "Idle";
			P_0.Detail = info[4];
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType178
	{
		public Exception RecoveredField1102;

		public RecoveredType175 _003C_003E4__this;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.Attached = false;
			P_0.Connection = "Unavailable";
			P_0.Status = RecoveredField1102.Message;
			P_0.Account = "PID " + _003C_003E4__this.Pid;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType180
	{
		public CancellationToken token;

		public RecoveredType175 _003C_003E4__this;

		public RecoveredType170 profile;

		public bool autoFish;

		public void RecoveredMethod45()
		{
			_003C_003E4__this.RecoveredMethod583(profile, autoFish, token);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType181
	{
		public RecoveredType175 _003C_003E4__this;

		public bool autoFish;
	}

	[CompilerGenerated]
	private sealed class RecoveredType182
	{
		private sealed class RecoveredType183
		{
			public RecoveredType182 CS_0024_003C_003E8__locals43;

			public RecoveredType181 CS_0024_003C_003E8__locals3c;

			public string text;

			public void RecoveredMethod585(RecoveredType174 P_0)
			{
				P_0.Status = text;
			}
		}

		private sealed class RecoveredType184
		{
			public RecoveredType182 CS_0024_003C_003E8__locals43;

			public RecoveredType181 CS_0024_003C_003E8__locals3c;

			public string text;

			public void RecoveredMethod585(RecoveredType174 P_0)
			{
				P_0.Status = text;
			}
		}

		public RecoveredType181 CS_0024_003C_003E8__locals3c;

		public RecoveredType172 RecoveredField1118;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.Account = RecoveredField1118.Account;
			P_0.Display = RecoveredField1118.Display;
			P_0.UserId = RecoveredField1118.UserId.ToString();
			P_0.Place = RecoveredField1118.Place;
			P_0.Attached = true;
			P_0.Connection = "Attached";
		}

		public void RecoveredMethod48(string P_0)
		{
			RecoveredType181 recoveredType = CS_0024_003C_003E8__locals3c;
			if (P_0.StartsWith("Moving to ") || P_0.StartsWith("Clicking ") || P_0.StartsWith("Waiting for "))
			{
				CS_0024_003C_003E8__locals3c._003C_003E4__this.RecoveredMethod581(delegate(RecoveredType174 recoveredType2)
				{
					recoveredType2.Status = P_0;
				});
			}
			CS_0024_003C_003E8__locals3c._003C_003E4__this.log("@" + RecoveredField1118.Account + " fruit input · " + P_0);
		}

		public void RecoveredMethod414(string P_0)
		{
			CS_0024_003C_003E8__locals3c._003C_003E4__this.log("@" + RecoveredField1118.Account + " · " + P_0);
		}

		public void RecoveredMethod422(string P_0)
		{
			RecoveredType181 recoveredType = CS_0024_003C_003E8__locals3c;
			if (P_0.StartsWith("Moving to ") || P_0.StartsWith("Clicking "))
			{
				CS_0024_003C_003E8__locals3c._003C_003E4__this.RecoveredMethod581(delegate(RecoveredType174 recoveredType2)
				{
					recoveredType2.Status = P_0;
				});
			}
			CS_0024_003C_003E8__locals3c._003C_003E4__this.log("@" + RecoveredField1118.Account + " input · " + P_0);
		}

		public void RecoveredMethod424(string P_0)
		{
			CS_0024_003C_003E8__locals3c._003C_003E4__this.log("@" + RecoveredField1118.Account + " · " + P_0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType185
	{
		public RecoveredType245 input;
	}

	[CompilerGenerated]
	private sealed class RecoveredType186
	{
		public RecoveredType185 CS_0024_003C_003E8__locals45;

		public RecoveredType182 CS_0024_003C_003E8__locals43;

		public RecoveredType181 CS_0024_003C_003E8__locals3c;

		public Stopwatch clock;

		public double lastLoop;

		public double roundPeak;

		public RecoveredType214 fruitPort;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.Rounds++;
			if (roundPeak >= 0.999)
			{
				P_0.FullRounds++;
			}
			P_0.Reeling = false;
			P_0.Held = false;
			P_0.Progress = 0.0;
			P_0.Status = "Round ended";
		}

		public void RecoveredMethod49(string P_0, bool P_1)
		{
			CS_0024_003C_003E8__locals3c._003C_003E4__this.RecoveredMethod580(P_0, P_1, Math.Max(0.0, clock.Elapsed.TotalSeconds - lastLoop), fruitPort);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType187
	{
		public string text;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.Status = text;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType188
	{
		public string text;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.Status = text;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType189
	{
		public RecoveredType186 CS_0024_003C_003E8__locals49;

		public RecoveredType185 CS_0024_003C_003E8__locals45;

		public RecoveredType182 CS_0024_003C_003E8__locals43;

		public RecoveredType181 CS_0024_003C_003E8__locals3c;

		public double activeDelta;

		public RecoveredType171 RecoveredField1140;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.ActiveSeconds += activeDelta;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType190
	{
		public RecoveredType189 CS_0024_003C_003E8__locals53;

		public RecoveredType186 CS_0024_003C_003E8__locals49;

		public RecoveredType185 CS_0024_003C_003E8__locals45;

		public RecoveredType182 CS_0024_003C_003E8__locals43;

		public RecoveredType181 CS_0024_003C_003E8__locals3c;

		public double observedDelta;

		public bool onTarget;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.Reeling = true;
			P_0.BarHeight = CS_0024_003C_003E8__locals53.RecoveredField1140.Height;
			P_0.TrackedSeconds += observedDelta;
			if (onTarget)
			{
				P_0.OnTargetSeconds += observedDelta;
			}
			P_0.Player = CS_0024_003C_003E8__locals53.RecoveredField1140.PlayerY;
			P_0.Goal = CS_0024_003C_003E8__locals53.RecoveredField1140.GoalY;
			P_0.Progress = CS_0024_003C_003E8__locals53.RecoveredField1140.Progress;
			P_0.Held = CS_0024_003C_003E8__locals45.input != null && CS_0024_003C_003E8__locals45.input.Held;
			P_0.Status = ((!CS_0024_003C_003E8__locals3c.autoFish) ? "Observing reel" : (P_0.Held ? "Reeling · hold" : "Reeling · release"));
			P_0.Detail = "Live FishingUIBill";
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType191
	{
		public RecoveredType104 view;

		public string bait;

		public void RecoveredMethod585(RecoveredType174 P_0)
		{
			P_0.Bait = bait ?? "";
			P_0.CommonBait = view.Common;
		}
	}

	private readonly RecoveredType85 activity = new RecoveredType85();

	private string requestedStop = "";

	private RecoveredType411 world;

	private readonly object gate = new object();

	private readonly List<RoundRecord> history = new List<RoundRecord>();

	private RecoveredType174 state;

	private CancellationTokenSource cancel;

	private Task task;

	private readonly RecoveredType163 offsets;

	private readonly Action<string> log;

	[CompilerGenerated]
	private int _003CPid_003Ek__BackingField;

	[CompilerGenerated]
	private long _003CCreated_003Ek__BackingField;

	public int Pid
	{
		[CompilerGenerated]
		get
		{
			return _003CPid_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CPid_003Ek__BackingField = value;
		}
	}

	public long Created
	{
		[CompilerGenerated]
		get
		{
			return _003CCreated_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCreated_003Ek__BackingField = value;
		}
	}

	public string InputScope => "session:" + RecoveredType309.SessionId;

	public RecoveredType175(int P_0, long P_1, RecoveredType163 P_2, Action<string> P_3)
	{
		RecoveredType175 recoveredType = this;
		Pid = P_0;
		Created = P_1;
		offsets = P_2;
		Action<string> recoveredField = delegate(string text)
		{
			RecoveredType174 recoveredType2 = recoveredType.RecoveredMethod509();
			recoveredType.activity.RecoveredMethod367(RecoveredType84.RecoveredMethod365(text, recoveredType2.Account, recoveredType2.UserId, "Session " + RecoveredType309.SessionId));
			P_3(text);
		};
		log = recoveredField;
		state = new RecoveredType174
		{
			Pid = P_0,
			Created = P_1
		};
	}

	public RoundRecord[] RecoveredMethod510()
	{
		lock (gate)
		{
			return history.ToArray();
		}
	}

	private void RecoveredMethod579(double P_0, double P_1, double P_2, double P_3)
	{
		lock (gate)
		{
			history.Add(new RoundRecord
			{
				Id = Guid.NewGuid().ToString("N"),
				Account = state.Account,
				UserId = state.UserId,
				AtUtc = DateTime.UtcNow.ToString("o"),
				Seconds = P_0,
				Contact = ((P_1 > 0.0) ? (P_2 / P_1) : 0.0),
				Peak = P_3,
				Full = (P_3 >= 0.999)
			});
			while (history.Count > 200)
			{
				history.RemoveAt(0);
			}
		}
	}

	private void RecoveredMethod580(string P_0, bool P_1, double P_2, RecoveredType214 P_3)
	{
		RecoveredType212 recoveredType = null;
		if (!P_1)
		{
			try
			{
				recoveredType = P_3.RecoveredMethod622();
			}
			catch
			{
				log("Fruit stored; bait statistics could not be refreshed.");
			}
		}
		lock (gate)
		{
			state.LastFruit = P_0;
			if (P_1)
			{
				state.FruitsDropped++;
				return;
			}
			state.FruitsStored++;
			FruitStoredRecord fruitStoredRecord = new FruitStoredRecord();
			fruitStoredRecord.Id = Guid.NewGuid().ToString("N");
			fruitStoredRecord.UserId = state.UserId;
			fruitStoredRecord.Account = state.Account;
			fruitStoredRecord.Name = P_0;
			fruitStoredRecord.Rarity = RecoveredType219.RecoveredMethod52(P_0);
			fruitStoredRecord.AtUtc = DateTime.UtcNow.ToString("o");
			fruitStoredRecord.FishCaught = state.FullRounds;
			fruitStoredRecord.Seconds = state.ActiveSeconds + P_2;
			fruitStoredRecord.Common = FruitStoredRecord.RecoveredMethod637(recoveredType, 1);
			fruitStoredRecord.Rare = FruitStoredRecord.RecoveredMethod637(recoveredType, 2);
			fruitStoredRecord.Legendary = FruitStoredRecord.RecoveredMethod637(recoveredType, 3);
			FruitStoredRecord fruitStoredRecord2 = fruitStoredRecord;
			state.FruitStores = state.FruitStores.Concat(new FruitStoredRecord[1] { fruitStoredRecord2 }).Skip(Math.Max(0, state.FruitStores.Length + 1 - 100)).ToArray();
		}
	}

	public RecoveredType174 RecoveredMethod509()
	{
		lock (gate)
		{
			RecoveredType174 recoveredType = state.RecoveredMethod509();
			recoveredType.Activity = activity.RecoveredMethod368();
			if (world != null)
			{
				recoveredType.World = world.RecoveredMethod889();
			}
			return recoveredType;
		}
	}

	private void RecoveredMethod581(Action<RecoveredType174> P_0)
	{
		lock (gate)
		{
			P_0(state);
		}
	}

	public async Task RecoveredMethod511()
	{
		if (RecoveredMethod509().Running)
		{
			return;
		}
		try
		{
			string[] info = await Task.Run(delegate
			{
				using RecoveredType172 recoveredType = new RecoveredType172(Pid, Created, offsets);
				if (recoveredType.UserId == 0 || string.IsNullOrWhiteSpace(recoveredType.Account) || !RecoveredType285.RecoveredMethod572(recoveredType.Gui) || !RecoveredType164.RecoveredMethod78(recoveredType.Window, Pid))
				{
					throw new Exception("Roblox player or window is still loading.");
				}
				return new string[5]
				{
					recoveredType.Account,
					recoveredType.Display,
					recoveredType.UserId.ToString(),
					recoveredType.Place,
					"Window found"
				};
			});
			RecoveredMethod581(delegate(RecoveredType174 P_0)
			{
				P_0.Account = info[0];
				P_0.Display = info[1];
				P_0.UserId = info[2];
				P_0.Place = info[3];
				P_0.Attached = true;
				P_0.Connection = "Attached";
				P_0.Status = "Idle";
				P_0.Detail = info[4];
			});
			if (world == null)
			{
				world = new RecoveredType411(Pid, Created, offsets);
			}
			log("Attached @" + info[0] + " · PID " + Pid);
		}
		catch (Exception ex)
		{
			Exception RecoveredField1102 = ex;
			RecoveredMethod581(delegate(RecoveredType174 P_0)
			{
				P_0.Attached = false;
				P_0.Connection = "Unavailable";
				P_0.Status = RecoveredField1102.Message;
				P_0.Account = "PID " + Pid;
			});
			log("PID " + Pid + ": " + RecoveredField1102.Message);
		}
	}

	public Task RecoveredMethod512(RecoveredType170 P_0, bool P_1)
	{
		RecoveredMethod582(P_0, P_1);
		return Task.FromResult(0);
	}

	public void RecoveredMethod582(RecoveredType170 P_0, bool P_1)
	{
		P_0.RecoveredMethod50();
		lock (gate)
		{
			if (state.Running)
			{
				return;
			}
			requestedStop = "";
			state.StopReason = "";
			state.StoppedAtUtc = "";
			state.Running = true;
			state.Reeling = false;
			state.AutoFish = P_1;
			state.Status = (P_1 ? "Preparing cast" : "Observing");
			state.Input = (P_1 ? "Real mouse + keyboard" : "Observe only");
		}
		if (cancel != null)
		{
			cancel.Dispose();
		}
		cancel = new CancellationTokenSource();
		CancellationToken token = cancel.Token;
		log(P_1 ? "Fishing started." : "Observation started.");
		task = Task.Run(delegate
		{
			RecoveredMethod583(P_0, P_1, token);
		});
	}

	private void RecoveredMethod583(RecoveredType170 P_0, bool P_1, CancellationToken P_2)
	{
		string text = null;
		Exception ex = null;
		try
		{
			RecoveredType172 RecoveredField1118 = new RecoveredType172(Pid, Created, offsets);
			try
			{
				RecoveredType245 input = (P_1 ? new RecoveredType245(new RecoveredType249(RecoveredField1118.Window, Pid), Pid) : null);
				try
				{
					using RecoveredType300 recoveredType = new RecoveredType300(Pid);
					if (P_1 && RecoveredField1118.Universe != 648454481)
					{
						throw new Exception("This client is not in the GPO universe.");
					}
					if (input != null)
					{
						input.RecoveredMethod348(P_0.CastX, P_0.CastY);
					}
					long num = -1000L;
					RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
					{
						recoveredType6.Account = RecoveredField1118.Account;
						recoveredType6.Display = RecoveredField1118.Display;
						recoveredType6.UserId = RecoveredField1118.UserId.ToString();
						recoveredType6.Place = RecoveredField1118.Place;
						recoveredType6.Attached = true;
						recoveredType6.Connection = "Attached";
					});
					Stopwatch clock = Stopwatch.StartNew();
					long num2 = -100000L;
					long num3 = -100000L;
					long num4 = -1L;
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					RecoveredType303 recoveredType2 = new RecoveredType303();
					int num5 = 0;
					ulong num6 = 0uL;
					bool flag4 = false;
					long num7 = -1000L;
					long num8 = -1000L;
					double lastLoop = 0.0;
					double num9 = -1.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					double roundPeak = 0.0;
					int fullRounds = RecoveredMethod509().FullRounds;
					long num13 = -1000L;
					RecoveredType214 fruitPort = (P_1 ? RecoveredField1118.RecoveredMethod570(input, P_0, delegate(string text5)
					{
						if (text5.StartsWith("Moving to ") || text5.StartsWith("Clicking ") || text5.StartsWith("Waiting for "))
						{
							RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
							{
								recoveredType6.Status = text5;
							});
						}
						log("@" + RecoveredField1118.Account + " fruit input · " + text5);
					}) : null);
					RecoveredType215 recoveredType3 = (P_1 ? new RecoveredType215(fruitPort, delegate(string text5)
					{
						log("@" + RecoveredField1118.Account + " · " + text5);
					}, delegate(string status)
					{
						RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
						{
							recoveredType6.Status = status;
						});
					}) : null);
					long num14 = -1000L;
					RecoveredType108 recoveredType4 = (P_1 ? new RecoveredType108(RecoveredField1118.RecoveredMethod571(input, P_2, delegate(string text5)
					{
						if (text5.StartsWith("Moving to ") || text5.StartsWith("Clicking "))
						{
							RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
							{
								recoveredType6.Status = text5;
							});
						}
						log("@" + RecoveredField1118.Account + " input · " + text5);
					}, P_0), delegate(string text5)
					{
						log("@" + RecoveredField1118.Account + " · " + text5);
					}, delegate(string status)
					{
						RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
						{
							recoveredType6.Status = status;
						});
					}) : null);
					while (!P_2.IsCancellationRequested)
					{
						if (!RecoveredField1118.RecoveredMethod387())
						{
							throw new Exception("Roblox exited or restarted.");
						}
						if (input != null)
						{
							input.RecoveredMethod50();
						}
						long elapsedMilliseconds = clock.ElapsedMilliseconds;
						if (input != null && elapsedMilliseconds - num >= 100)
						{
							input.RecoveredMethod45();
							num = elapsedMilliseconds;
						}
						double totalSeconds = clock.Elapsed.TotalSeconds;
						double activeDelta = Math.Max(0.0, totalSeconds - lastLoop);
						lastLoop = totalSeconds;
						RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
						{
							recoveredType6.ActiveSeconds += activeDelta;
						});
						RecoveredType171 RecoveredField1140 = RecoveredField1118.RecoveredMethod575();
						if (RecoveredField1140 != null)
						{
							flag3 = true;
							if (!flag2 || num6 != RecoveredField1140.Gui)
							{
								flag2 = true;
								num6 = RecoveredField1140.Gui;
								recoveredType2.RecoveredMethod45();
								num10 = totalSeconds;
								num11 = (num12 = (roundPeak = 0.0));
								num9 = -1.0;
								flag = false;
								num4 = -1L;
								if (input != null && input.Held)
								{
									input.RecoveredMethod565(false, P_0.CastX, P_0.CastY);
								}
								log("@" + RecoveredField1118.Account + " · fishing meter detected");
							}
							double observedDelta = ((num9 >= 0.0) ? Math.Min(0.1, Math.Max(0.0, totalSeconds - num9)) : 0.0);
							num9 = totalSeconds;
							bool onTarget = Math.Abs(RecoveredField1140.PlayerY - RecoveredField1140.GoalY) <= RecoveredField1140.Height / 2.0;
							num11 += observedDelta;
							if (onTarget)
							{
								num12 += observedDelta;
							}
							roundPeak = Math.Max(roundPeak, RecoveredField1140.Progress);
							bool flag5 = recoveredType2.RecoveredMethod775(clock.Elapsed.TotalSeconds, RecoveredField1140.PlayerY, RecoveredField1140.GoalY, RecoveredField1140.Height, input != null && input.Held);
							if (input != null)
							{
								input.RecoveredMethod565(flag5, P_0.CastX, P_0.CastY);
							}
							recoveredType.RecoveredMethod772(clock.Elapsed.TotalSeconds, RecoveredField1140, recoveredType2, input != null && input.Held);
							if (elapsedMilliseconds - num8 >= 1000)
							{
								num8 = elapsedMilliseconds;
								log("@" + RecoveredField1118.Account + " reel · player=" + RecoveredField1140.PlayerY.ToString("0.000") + " goal=" + RecoveredField1140.GoalY.ToString("0.000") + " held=" + (input != null && input.Held) + " progress=" + RecoveredField1140.Progress.ToString("0.000"));
							}
							RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
							{
								recoveredType6.Reeling = true;
								recoveredType6.BarHeight = RecoveredField1140.Height;
								recoveredType6.TrackedSeconds += observedDelta;
								if (onTarget)
								{
									recoveredType6.OnTargetSeconds += observedDelta;
								}
								recoveredType6.Player = RecoveredField1140.PlayerY;
								recoveredType6.Goal = RecoveredField1140.GoalY;
								recoveredType6.Progress = RecoveredField1140.Progress;
								recoveredType6.Held = input != null && input.Held;
								recoveredType6.Status = ((!P_1) ? "Observing reel" : (recoveredType6.Held ? "Reeling · hold" : "Reeling · release"));
								recoveredType6.Detail = "Live FishingUIBill";
							});
						}
						else
						{
							if (flag2)
							{
								flag2 = false;
								num3 = elapsedMilliseconds;
								num2 = -100000L;
								flag = false;
								if (input != null)
								{
									input.RecoveredMethod565(false, P_0.CastX, P_0.CastY);
								}
								RecoveredMethod579(totalSeconds - num10, num11, num12, roundPeak);
								RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
								{
									recoveredType6.Rounds++;
									if (roundPeak >= 0.999)
									{
										recoveredType6.FullRounds++;
									}
									recoveredType6.Reeling = false;
									recoveredType6.Held = false;
									recoveredType6.Progress = 0.0;
									recoveredType6.Status = "Round ended";
								});
								log("@" + RecoveredField1118.Account + ((roundPeak >= 0.999) ? " · Fish caught. Minigame completed." : " · Round ended without a confirmed catch."));
							}
							if (input != null && num4 >= 0 && elapsedMilliseconds >= num4)
							{
								input.RecoveredMethod565(false, P_0.CastX, P_0.CastY);
								num4 = -1L;
								RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
								{
									recoveredType6.Held = false;
								});
							}
							if (P_1)
							{
								if (!flag && !input.Held && elapsedMilliseconds - num13 >= 1000)
								{
									recoveredType3.RecoveredMethod626(P_0, P_2, delegate(string text5, bool flag6)
									{
										RecoveredMethod580(text5, flag6, Math.Max(0.0, clock.Elapsed.TotalSeconds - lastLoop), fruitPort);
									});
									elapsedMilliseconds = clock.ElapsedMilliseconds;
									num13 = elapsedMilliseconds;
									flag4 = RecoveredField1118.RecoveredMethod573();
									num7 = elapsedMilliseconds;
								}
								string text2 = RecoveredType358.RecoveredMethod847(P_0, clock.Elapsed.TotalSeconds, RecoveredMethod509().FullRounds - fullRounds, false);
								if (text2 != null)
								{
									text = text2;
									break;
								}
								if (elapsedMilliseconds - num7 > 1000)
								{
									flag4 = RecoveredField1118.RecoveredMethod573();
									num7 = elapsedMilliseconds;
								}
								if (flag4 && !flag && !input.Held && elapsedMilliseconds - num14 >= 750)
								{
									recoveredType4.RecoveredMethod411(P_0, P_2, delegate(RecoveredType104 recoveredType6, string text5)
									{
										RecoveredMethod581(delegate(RecoveredType174 recoveredType7)
										{
											recoveredType7.Bait = text5 ?? "";
											recoveredType7.CommonBait = recoveredType6.Common;
										});
									}, !flag);
									elapsedMilliseconds = clock.ElapsedMilliseconds;
									num14 = elapsedMilliseconds;
									flag4 = RecoveredField1118.RecoveredMethod573();
								}
								if (!flag4)
								{
									if (input.Held)
									{
										input.RecoveredMethod565(false, P_0.CastX, P_0.CastY);
									}
									if (P_0.EquipSlot > 0 && elapsedMilliseconds - num2 > 5000)
									{
										input.RecoveredMethod377(48 + P_0.EquipSlot);
										num2 = elapsedMilliseconds;
									}
									if (RecoveredMethod509().Status != "Equip a fishing rod")
									{
										log("@" + RecoveredField1118.Account + " · Waiting for an equipped fishing rod.");
									}
									RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
									{
										recoveredType6.Status = "Equip a fishing rod";
									});
								}
								else if (flag)
								{
									RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
									{
										recoveredType6.Status = "Cast sent · waiting for fish";
									});
									if (elapsedMilliseconds - num2 > P_0.BiteTimeoutSeconds * 1000)
									{
										num5++;
										flag = false;
										num3 = elapsedMilliseconds;
										log("@" + RecoveredField1118.Account + " · no fishing meter after foreground cast");
										if (!flag3 || num5 >= 2)
										{
											throw new Exception("No fishing meter appeared. Check bait and the saved cast point; inputs stopped.");
										}
									}
								}
								else if (elapsedMilliseconds - num3 >= P_0.RecastDelayMs)
								{
									input.RecoveredMethod565(true, P_0.CastX, P_0.CastY);
									num2 = elapsedMilliseconds;
									num4 = elapsedMilliseconds + P_0.CastHoldMs;
									flag = true;
									RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
									{
										recoveredType6.Status = "Casting";
										recoveredType6.Held = true;
									});
									log("@" + RecoveredField1118.Account + " · cast with real foreground mouse input; waiting for game response");
								}
							}
							else
							{
								RecoveredMethod581(delegate(RecoveredType174 recoveredType6)
								{
									recoveredType6.Status = "Watching · waiting for fishing meter";
									recoveredType6.Held = false;
								});
							}
						}
						if (P_2.WaitHandle.WaitOne((RecoveredField1140 != null) ? 6 : 20))
						{
							break;
						}
					}
				}
				finally
				{
					if (input != null)
					{
						((IDisposable)input).Dispose();
					}
				}
			}
			finally
			{
				if (RecoveredField1118 != null)
				{
					((IDisposable)RecoveredField1118).Dispose();
				}
			}
		}
		catch (OperationCanceledException ex2)
		{
			if (!P_2.IsCancellationRequested)
			{
				ex = ex2;
			}
		}
		catch (Exception ex3)
		{
			ex = ex3;
		}
		finally
		{
			string text3;
			string text4;
			lock (gate)
			{
				text3 = RecoveredType83.RecoveredMethod363(P_2.IsCancellationRequested, requestedStop, ex, text);
				text4 = RecoveredType83.RecoveredMethod362(P_2.IsCancellationRequested, requestedStop, ex);
				state.Running = false;
				state.Reeling = false;
				state.Held = false;
				state.StopReason = RecoveredType84.RecoveredMethod364(text3);
				state.StoppedAtUtc = DateTime.UtcNow.ToString("o");
				state.StopLevel = text4;
				state.Status = "Stopped · " + state.StopReason;
				state.Detail = state.StopReason;
			}
			RecoveredType174 recoveredType5 = RecoveredMethod509();
			activity.RecoveredMethod367(new RecoveredType82
			{
				Account = recoveredType5.Account,
				UserId = recoveredType5.UserId,
				Source = "Session " + RecoveredType309.SessionId,
				Category = "Stopped",
				Level = text4,
				Message = RecoveredType84.RecoveredMethod364(text3)
			});
			log("@" + recoveredType5.Account + " stopped · " + RecoveredType84.RecoveredMethod364(text3));
		}
	}

	public void RecoveredMethod48(string P_0 = "Stopped by user.")
	{
		lock (gate)
		{
			if (cancel != null && state.Running && !cancel.IsCancellationRequested)
			{
				requestedStop = RecoveredType84.RecoveredMethod364(P_0);
				cancel.Cancel();
			}
		}
	}

	public async Task RecoveredMethod513(string P_0 = "Stopped by user.")
	{
		RecoveredMethod48(P_0);
		Task t;
		lock (gate)
		{
			t = task;
		}
		if (t != null)
		{
			await t;
		}
	}

	public async Task<string> RecoveredMethod514()
	{
		return await Task.Run(delegate
		{
			using RecoveredType172 recoveredType = new RecoveredType172(Pid, Created, offsets);
			return recoveredType.RecoveredMethod576();
		});
	}

	public void Dispose()
	{
		if (world != null)
		{
			world.Dispose();
		}
		RecoveredMethod48("twist closed.");
		if (task != null)
		{
			try
			{
				task.Wait(2000);
			}
			catch
			{
			}
		}
		if (cancel != null)
		{
			cancel.Dispose();
		}
	}

	[CompilerGenerated]
	private string[] RecoveredMethod584()
	{
		using RecoveredType172 recoveredType = new RecoveredType172(Pid, Created, offsets);
		if (recoveredType.UserId == 0 || string.IsNullOrWhiteSpace(recoveredType.Account) || !RecoveredType285.RecoveredMethod572(recoveredType.Gui) || !RecoveredType164.RecoveredMethod78(recoveredType.Window, Pid))
		{
			throw new Exception("Roblox player or window is still loading.");
		}
		return new string[5]
		{
			recoveredType.Account,
			recoveredType.Display,
			recoveredType.UserId.ToString(),
			recoveredType.Place,
			"Window found"
		};
	}

	[CompilerGenerated]
	private void RecoveredMethod422(string P_0)
	{
		RecoveredMethod581(delegate(RecoveredType174 recoveredType)
		{
			recoveredType.Status = P_0;
		});
	}

	[CompilerGenerated]
	private void RecoveredMethod424(string P_0)
	{
		RecoveredMethod581(delegate(RecoveredType174 recoveredType)
		{
			recoveredType.Status = P_0;
		});
	}

	[CompilerGenerated]
	private static void RecoveredMethod585(RecoveredType174 P_0)
	{
		P_0.Held = false;
	}

	[CompilerGenerated]
	private void RecoveredMethod420(RecoveredType104 P_0, string P_1)
	{
		RecoveredMethod581(delegate(RecoveredType174 recoveredType)
		{
			recoveredType.Bait = P_1 ?? "";
			recoveredType.CommonBait = P_0.Common;
		});
	}

	[CompilerGenerated]
	private static void RecoveredMethod586(RecoveredType174 P_0)
	{
		P_0.Status = "Equip a fishing rod";
	}

	[CompilerGenerated]
	private static void RecoveredMethod587(RecoveredType174 P_0)
	{
		P_0.Status = "Cast sent · waiting for fish";
	}

	[CompilerGenerated]
	private static void RecoveredMethod588(RecoveredType174 P_0)
	{
		P_0.Status = "Casting";
		P_0.Held = true;
	}

	[CompilerGenerated]
	private static void RecoveredMethod589(RecoveredType174 P_0)
	{
		P_0.Status = "Watching · waiting for fishing meter";
		P_0.Held = false;
	}

	[CompilerGenerated]
	private string RecoveredMethod590()
	{
		using RecoveredType172 recoveredType = new RecoveredType172(Pid, Created, offsets);
		return recoveredType.RecoveredMethod576();
	}
}
