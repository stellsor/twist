using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using B;
using C;
using D;
using Microsoft.Win32;
using TwistApp;
using a;
using b;
using c;
using d;

namespace A;

internal sealed class RecoveredType16
{
	[CompilerGenerated]
	private sealed class RecoveredType17
	{
		public string query;

		public int filter;

		public RecoveredType137 account;

		public bool RecoveredMethod182(RecoveredType82 P_0)
		{
			if (account != null && (!string.IsNullOrEmpty(P_0.UserId) || !string.IsNullOrEmpty(P_0.Account)) && (string.IsNullOrEmpty(account.State.UserId) || !(P_0.UserId == account.State.UserId)))
			{
				return P_0.Account == account.Account;
			}
			return true;
		}

		public bool RecoveredMethod342(RecoveredType82 P_0)
		{
			if ((filter != 1 || P_0.Level != "Info") && (filter != 2 || P_0.Category == "Stopped" || P_0.Category == "Crash"))
			{
				if (!(query == ""))
				{
					return (P_0.Account + " " + P_0.Source + " " + P_0.Category + " " + P_0.Message).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType18
	{
		public RecoveredType16 _003C_003E4__this;

		public int pid;

		public long created;

		public RecoveredType163 RecoveredMethod343()
		{
			using Process process = Process.GetProcessById(pid);
			if (process.StartTime.ToUniversalTime().Ticks != created)
			{
				throw new Exception("Roblox restarted while being discovered.");
			}
			return new RecoveredType163(RecoveredType422.RecoveredMethod912(process.MainModule.FileName, _003C_003E4__this.bundledOffsets));
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType21
	{
		public RecoveredType137 row;

		public bool RecoveredMethod344(KeyValuePair<int, long> P_0)
		{
			if (P_0.Key == row.Session.Pid)
			{
				return P_0.Value == row.Session.Created;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType22
	{
		public KeyValuePair<int, long> process;

		public bool RecoveredMethod345(RecoveredType137 P_0)
		{
			int pid = P_0.Session.Pid;
			KeyValuePair<int, long> keyValuePair = process;
			if (pid == keyValuePair.Key)
			{
				long created = P_0.Session.Created;
				KeyValuePair<int, long> keyValuePair2 = process;
				return created == keyValuePair2.Value;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType24
	{
		public RecoveredType132 previous;

		public RecoveredType134 previousInventory;

		public RecoveredType132 replacement;

		public int created;

		public Func<RecoveredType137, Task> attach;

		public RecoveredType132 loading;

		public RecoveredType132 ready;

		public Task<RecoveredType137> RecoveredMethod62(int P_0, long P_1)
		{
			RecoveredMethod42(previous.Disposed && previousInventory.Disposed, "Closed client is retired before a replacement is created");
			created++;
			if (P_0 == 802)
			{
				throw new Exception("Simulated loading process");
			}
			return Task.FromResult(new RecoveredType137(replacement));
		}

		public Task<RecoveredType137> RecoveredMethod346(int P_0, long P_1)
		{
			return Task.FromResult(new RecoveredType137((P_0 == 803) ? loading : ready));
		}

		public Task RecoveredMethod63(RecoveredType137 P_0)
		{
			if (P_0.Session == loading && loading.Attaches++ == 0)
			{
				throw new Exception("Simulated attach failure");
			}
			return attach(P_0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType25
	{
		public List<RecoveredType325> retired;

		public void RecoveredMethod347(RecoveredType325 P_0)
		{
			retired.Add(P_0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType26
	{
		public RecoveredType137 row;
	}

	[CompilerGenerated]
	private sealed class RecoveredType27
	{
		private sealed class RecoveredType28
		{
			public RecoveredType27 CS_0024_003C_003E8__locals74;

			public RecoveredType26 CS_0024_003C_003E8__locals72;

			public double RecoveredField333;

			public double RecoveredField334;

			public void RecoveredMethod45()
			{
				CS_0024_003C_003E8__locals74._003C_003E4__this.RecoveredMethod76(CS_0024_003C_003E8__locals72.row, RecoveredField333, RecoveredField334, CS_0024_003C_003E8__locals74.token);
			}
		}

		public RecoveredType26 CS_0024_003C_003E8__locals72;

		public int token;

		public RecoveredType16 _003C_003E4__this;

		public void RecoveredMethod348(double P_0, double P_1)
		{
			RecoveredType26 recoveredType = CS_0024_003C_003E8__locals72;
			if (!_003C_003E4__this.window.Dispatcher.HasShutdownStarted)
			{
				_003C_003E4__this.window.Dispatcher.BeginInvoke((Action)delegate
				{
					_003C_003E4__this.RecoveredMethod76(recoveredType.row, P_0, P_1, token);
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType29
	{
		public RecoveredType137 row;
	}

	[CompilerGenerated]
	private sealed class RecoveredType30
	{
		private sealed class RecoveredType31
		{
			public RecoveredType30 CS_0024_003C_003E8__locals7a;

			public RecoveredType29 CS_0024_003C_003E8__locals78;

			public double RecoveredField342;

			public double RecoveredField343;

			public void RecoveredMethod45()
			{
				CS_0024_003C_003E8__locals7a._003C_003E4__this.RecoveredMethod75(CS_0024_003C_003E8__locals78.row, CS_0024_003C_003E8__locals7a.bait, RecoveredField342, RecoveredField343, CS_0024_003C_003E8__locals7a.token);
			}
		}

		public RecoveredType29 CS_0024_003C_003E8__locals78;

		public string bait;

		public int token;

		public RecoveredType16 _003C_003E4__this;

		public void RecoveredMethod348(double P_0, double P_1)
		{
			RecoveredType29 recoveredType = CS_0024_003C_003E8__locals78;
			if (!_003C_003E4__this.window.Dispatcher.HasShutdownStarted)
			{
				_003C_003E4__this.window.Dispatcher.BeginInvoke((Action)delegate
				{
					_003C_003E4__this.RecoveredMethod75(recoveredType.row, bait, P_0, P_1, token);
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType36
	{
		public Action action;

		public void RecoveredMethod199(object P_0, RoutedEventArgs P_1)
		{
			action();
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType48
	{
		public RecoveredType16 _003C_003E4__this;

		public Window target;

		public void RecoveredMethod133(object P_0, EventArgs P_1)
		{
			_003C_003E4__this.hwnd = new WindowInteropHelper(target).Handle;
			_003C_003E4__this.source = HwndSource.FromHwnd(_003C_003E4__this.hwnd);
			_003C_003E4__this.source.AddHook(_003C_003E4__this.RecoveredMethod86);
			if (!RecoveredMethod77(_003C_003E4__this.hwnd, 911, 16384u, 119u))
			{
				_003C_003E4__this.RecoveredMethod93("F8 is in use by another app. Close the older fishing app.");
			}
			if (!RecoveredMethod77(_003C_003E4__this.hwnd, 912, 16384u, 118u))
			{
				_003C_003E4__this.RecoveredMethod93("F7 is in use by another app.");
			}
			if (!RecoveredMethod77(_003C_003E4__this.hwnd, 910, 16384u, 120u))
			{
				_003C_003E4__this.RecoveredMethod93("F9 is in use by another app. The Stop all button is available.");
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType50
	{
		public RecoveredType137 row;

		public bool RecoveredMethod345(RecoveredType137 P_0)
		{
			if (P_0.Session.InputScope == row.Session.InputScope && P_0.Session.RecoveredMethod509().Running)
			{
				return P_0.Session.RecoveredMethod509().AutoFish;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType52
	{
		public string reason;

		public Task RecoveredMethod63(RecoveredType137 P_0)
		{
			return P_0.Session.RecoveredMethod513(reason);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType54
	{
		private sealed class RecoveredType55
		{
			public RecoveredType54 CS_0024_003C_003E8__locals11a;

			public BitmapSource image;

			public string error;

			public void RecoveredMethod45()
			{
				CS_0024_003C_003E8__locals11a.card.SetIcon(image, error);
			}
		}

		public RecoveredType16 _003C_003E4__this;

		public ItemCard card;

		public void RecoveredMethod349(BitmapSource P_0, string P_1)
		{
			if (!_003C_003E4__this.window.Dispatcher.HasShutdownStarted)
			{
				_003C_003E4__this.window.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
				{
					card.SetIcon(P_0, P_1);
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType56
	{
		public string key;

		public bool RecoveredMethod350(ItemCard P_0)
		{
			if (P_0.Key == key)
			{
				return P_0.Icon == null;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType57
	{
		public bool fruit;

		public bool RecoveredMethod39(string P_0)
		{
			if (P_0 != "Collectable" && P_0 != "Unknown")
			{
				if (!fruit)
				{
					return P_0 != "Mythical";
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType58
	{
		public string since;

		public bool RecoveredMethod351(CatchRecord P_0)
		{
			return string.CompareOrdinal(P_0.AtUtc, since) >= 0;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType59
	{
		public string search;

		public string rarity;

		public RecoveredType16 _003C_003E4__this;

		public bool RecoveredMethod1(InventoryEntry P_0)
		{
			if (_003C_003E4__this.RecoveredMethod1(P_0) && P_0.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				if (rarity != null && !(rarity == "All rarities"))
				{
					return P_0.Metadata.Rarity == rarity;
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType60
	{
		private sealed class RecoveredType61
		{
			public RecoveredType60 CS_0024_003C_003E8__locals152;

			public RecoveredType59 CS_0024_003C_003E8__locals14f;

			public string name;

			public bool RecoveredMethod351(CatchRecord P_0)
			{
				return P_0.Rarity == name;
			}
		}

		public RecoveredType59 CS_0024_003C_003E8__locals14f;

		public CatchRecord[] history;

		private static Func<CatchRecord, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate153;

		public RarityTotal RecoveredMethod352(string P_0)
		{
			RecoveredType59 recoveredType = CS_0024_003C_003E8__locals14f;
			return new RarityTotal
			{
				Name = P_0,
				Count = history.Where((CatchRecord catchRecord) => catchRecord.Rarity == P_0).Sum((CatchRecord catchRecord) => catchRecord.Count)
			};
		}

		private static int RecoveredMethod353(CatchRecord P_0)
		{
			return P_0.Count;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType62
	{
		public RecoveredType59 CS_0024_003C_003E8__locals14f;

		public Dictionary<string, ItemCard> reuse;

		public ItemCard RecoveredMethod354(InventoryEntry P_0)
		{
			if (!reuse.TryGetValue(P_0.Metadata.IconKey, out var value))
			{
				value = new ItemCard
				{
					Name = P_0.Name,
					Count = P_0.Count,
					Rarity = P_0.Metadata.Rarity,
					Category = P_0.Metadata.Category,
					Key = P_0.Metadata.IconKey
				};
			}
			value.SetCount(P_0.Count);
			return value;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType63
	{
		public string code;

		public RecoveredType16 _003C_003E4__this;

		public void RecoveredMethod45()
		{
			if (_003C_003E4__this.workerLink == null || !_003C_003E4__this.workerLink.Connected || !(_003C_003E4__this.activePairCode == code))
			{
				_003C_003E4__this.RecoveredMethod79<TextBox>("WorkerPairing").Text = code;
				_003C_003E4__this.RecoveredMethod122();
				_003C_003E4__this.RecoveredMethod93("Controller discovered through Windows authentication.");
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType64
	{
		public RecoveredType318 request;

		public RecoveredType16 _003C_003E4__this;

		public Task<string> RecoveredMethod355()
		{
			return _003C_003E4__this.RecoveredMethod125(request);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType65
	{
		public RecoveredType137 row;

		public RecoveredType318 request;

		public bool RecoveredMethod345(RecoveredType137 P_0)
		{
			if (RecoveredMethod124(P_0.Session) == request.Key)
			{
				return !(P_0.Session is RecoveredType325);
			}
			return false;
		}

		public bool RecoveredMethod356(RecoveredType137 P_0)
		{
			return P_0.Session.InputScope == row.Session.InputScope;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType67
	{
		public RecoveredType325 old;

		public bool RecoveredMethod290(RecoveredType325 P_0)
		{
			if (P_0.Peer.Id == old.Peer.Id)
			{
				return P_0.Key == old.Key;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType68
	{
		public RecoveredType325 session;

		public bool RecoveredMethod345(RecoveredType137 P_0)
		{
			if (P_0.Session is RecoveredType325 recoveredType && recoveredType.Peer.Id == session.Peer.Id)
			{
				return recoveredType.Key == session.Key;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType69
	{
		public string code;

		public int[] connected;

		public string RecoveredMethod357()
		{
			return RecoveredType97.RecoveredMethod389(code, connected);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType72
	{
		public KeyValuePair<string, RecoveredType170> item;

		public bool RecoveredMethod345(RecoveredType137 P_0)
		{
			string userId = P_0.State.UserId;
			KeyValuePair<string, RecoveredType170> keyValuePair = item;
			if (userId == keyValuePair.Key && P_0.Session is RecoveredType325)
			{
				return ((RecoveredType325)P_0.Session).Peer.Connected;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType74
	{
		public string firstId;

		public string secondId;

		public int sends;

		public Dictionary<string, RecoveredType170> applied;

		public bool RecoveredMethod345(RecoveredType137 P_0)
		{
			return P_0.State.UserId == firstId;
		}

		public bool RecoveredMethod356(RecoveredType137 P_0)
		{
			return P_0.State.UserId == secondId;
		}

		public Task RecoveredMethod211(RecoveredType325 P_0, RecoveredType170 P_1)
		{
			sends++;
			RecoveredType170 recoveredType = RecoveredType129.RecoveredMethod507(P_1, P_0.Profile);
			applied[P_0.RecoveredMethod509().UserId] = recoveredType;
			P_0.RecoveredMethod792(new RecoveredType310
			{
				Key = P_0.Key,
				State = P_0.RecoveredMethod509(),
				Profile = recoveredType,
				Rounds = P_0.RecoveredMethod510()
			});
			return Task.FromResult(0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType78
	{
		public RecoveredType356 session;

		public RoundRecord RecoveredMethod358(int P_0)
		{
			return new RoundRecord
			{
				Id = session.State.UserId + "-" + P_0,
				UserId = session.State.UserId,
				Account = session.State.Account,
				AtUtc = DateTime.UtcNow.ToString("o"),
				Full = true
			};
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType79
	{
		public DispatcherFrame frame;

		public void RecoveredMethod45()
		{
			frame.Continue = false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType81
	{
		public RecoveredType174 state;

		public WorldSnapshot world;

		public J<WorldFruitRecord, WorldSnapshot, string> RecoveredMethod359(WorldFruitRecord P_0)
		{
			return new J<WorldFruitRecord, WorldSnapshot, string>(P_0, world, state.Account);
		}

		public J<WorldFruitRecord, WorldSnapshot, string> RecoveredMethod360(WorldFruitRecord P_0)
		{
			return new J<WorldFruitRecord, WorldSnapshot, string>(P_0, world, state.Account);
		}
	}

	private RecoveredType86 activityLog;

	private readonly ConcurrentQueue<string> notices = new ConcurrentQueue<string>();

	private int activityRevision = -1;

	private string activityScope = "";

	private string activityQuery = "";

	private int activityFilter = -1;

	private string activityError = "";

	private RecoveredType150 alerts;

	private string alertsUiError = "";

	private Window miniWindow;

	private bool miniSelection;

	private RecoveredType344 pointPicker;

	private RecoveredType137 pickRow;

	private int pickToken;

	private string pickBait = "";

	private readonly Window window;

	private readonly string folder;

	private readonly string bundle;

	private readonly string bundledOffsets;

	private readonly RecoveredType308 mode;

	private readonly RecoveredType163 offsets;

	private readonly RecoveredType360 ledger;

	private readonly ObservableCollection<RecoveredType137> rows = new ObservableCollection<RecoveredType137>();

	private readonly Dictionary<string, RecoveredType170> profiles = new Dictionary<string, RecoveredType170>();

	private readonly DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);

	private readonly Stopwatch clock = Stopwatch.StartNew();

	private readonly TrackingChart chart = new TrackingChart();

	private readonly ReelGauge gauge = new ReelGauge();

	private bool refreshing;

	private bool closing;

	private bool stopping;

	private bool switching;

	private IntPtr hwnd;

	private HwndSource source;

	private string historyKey = "";

	private int historyCount = -1;

	private bool showFruitInventory;

	private readonly Dictionary<string, ItemMetadata> displayedPreviewMetadata = new Dictionary<string, ItemMetadata>();

	private RecoveredType266 catches;

	private RecoveredType276 previewQueue;

	private bool inventoryDirty = true;

	private int itemLimit = 200;

	private string catchError = "";

	private string cardsSignature = "";

	private string catchSignature = "";

	private readonly DateTime openedUtc = DateTime.UtcNow;

	private readonly Dictionary<string, ItemMetadata> catalog = new Dictionary<string, ItemMetadata>(StringComparer.Ordinal);

	private readonly Dictionary<string, string> catalogStamps = new Dictionary<string, string>();

	private RecoveredType121 catalogWriter;

	private RecoveredType332 hub;

	private RecoveredType392 workerLink;

	private RecoveredType321 pairing;

	private string workerId;

	private string networkStatus = "";

	private string lastPeers = "";

	private bool networkDisposed;

	private int previewEpoch;

	private RecoveredType95 discovery;

	private bool discovering;

	private DateTime discoveryAt = DateTime.MinValue;

	private volatile string activePairCode = "";

	private int publishedActivityRevision = -1;

	private RecoveredType82[] publishedActivity = new RecoveredType82[0];

	private RecoveredType131[] workerSessions = new RecoveredType131[0];

	private RecoveredType342 uiPreferences;

	private readonly DispatcherTimer settingsTimer = new DispatcherTimer();

	private readonly Dictionary<string, RecoveredType170> pendingProfiles = new Dictionary<string, RecoveredType170>(StringComparer.Ordinal);

	private RecoveredType137 settingsRow;

	private bool loadingSettings;

	private bool profileDirty;

	private bool alertsDirty;

	private bool preferencesDirty;

	private bool autosaveReady;

	private Task settingsSend = Task.FromResult(0);

	private DateTime profileEditAt;

	private DateTime alertsEditAt;

	private DateTime preferencesEditAt;

	private Func<RecoveredType325, RecoveredType170, Task> settingsWriter = (RecoveredType325 recoveredType, RecoveredType170 recoveredType2) => recoveredType.RecoveredMethod793(recoveredType2);

	private string lastProfileError = "";

	private string lastSendError = "";

	private readonly RecoveredType137 totalChoice = new RecoveredType137(true);

	private readonly ObservableCollection<RecoveredType137> accountChoices = new ObservableCollection<RecoveredType137>();

	private string totalCards = "";

	private string currentPage = "Session";

	private bool uiTickRunning;

	private long maintenanceAt = -1000L;

	private long clientsAt = -6000L;

	private readonly Dictionary<string, int> launchCounts = new Dictionary<string, int>();

	private int launchRevision = -1;

	private RecoveredType266 launchLedger;

	private readonly DispatcherTimer liveTimer = new DispatcherTimer(DispatcherPriority.Render);

	private double progressTarget = double.NaN;

	private readonly Dictionary<string, FrameworkElement> controls = new Dictionary<string, FrameworkElement>();

	private RecoveredType416 worldHistory;

	private int worldHistoryRevision = -1;

	private string worldHistoryScope = "";

	private string worldHistoryError = "";

	private string worldWorkersSignature = "";

	private string worldFruitsSignature = "";

	private RecoveredType137 Selected
	{
		get
		{
			if (!(RecoveredMethod79<ComboBox>("Clients").SelectedItem is RecoveredType137 { IsTotal: false } recoveredType))
			{
				return null;
			}
			return recoveredType;
		}
	}

	private string PendingProfilesFile => System.IO.Path.Combine(folder, "pending-profiles.json");

	private bool IsTotalSelected
	{
		get
		{
			if (RecoveredMethod79<ComboBox>("Clients").SelectedItem is RecoveredType137 recoveredType)
			{
				return recoveredType.IsTotal;
			}
			return false;
		}
	}

	private bool PresentationHidden
	{
		get
		{
			Window window = miniWindow ?? this.window;
			if (window.WindowState != WindowState.Minimized)
			{
				return !window.IsVisible;
			}
			return true;
		}
	}

	private void RecoveredMethod45()
	{
		activityLog = ((RecoveredType350.Current == null) ? new RecoveredType86(System.IO.Path.Combine(folder, "logs")) : RecoveredType350.Current.Journal);
		RecoveredMethod83("NavActivity", delegate
		{
			RecoveredMethod84("ActivityLog");
		});
		RecoveredMethod83("QuickActivity", delegate
		{
			RecoveredMethod84("ActivityLog");
		});
		RecoveredMethod79<ComboBox>("ActivityFilter").ItemsSource = new string[3] { "All activity", "Warnings & errors", "Stops & crashes" };
		RecoveredMethod79<ComboBox>("ActivityFilter").SelectedIndex = 0;
		RecoveredMethod79<ComboBox>("ActivityFilter").SelectionChanged += delegate
		{
			RecoveredMethod51();
		};
		RecoveredMethod79<TextBox>("ActivitySearch").TextChanged += delegate
		{
			RecoveredMethod51();
		};
		RecoveredMethod83("OpenDiagnostics", delegate
		{
			Process.Start("explorer.exe", System.IO.Path.Combine(folder, "logs"));
		});
        RecoveredMethod83("ExportActivity", delegate
        {
            try
            {
                RecoveredMethod50();
                var dialog = new Microsoft.Win32.SaveFileDialog
                {
                    Title = "Export activity log",
                    Filter = "Text files (*.txt)|*.txt",
                    DefaultExt = ".txt",
                    AddExtension = true,
                    FileName = "twist-activity-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt"
                };
                if (dialog.ShowDialog(window) == true)
                {
                    System.IO.File.WriteAllText(dialog.FileName, ActivityTextExport.Format(activityLog.RecoveredMethod368()), new System.Text.UTF8Encoding(true));
                    RecoveredMethod93("Activity log exported. Attach the TXT file to github.com/stellsor/twist/issues/1.");
                }
            }
            catch (Exception error)
            {
                RecoveredMethod93("Activity export failed: " + error.Message);
            }
        });
		RecoveredMethod83("CopyActivity", delegate
		{
			if (RecoveredMethod79<ListBox>("ActivityList").SelectedItem is ActivityCard activityCard)
			{
				try
				{
					Clipboard.SetText(activityCard.Full);
				}
				catch (Exception ex)
				{
					RecoveredMethod93("Copy failed: " + ex.Message);
				}
			}
		});
	}

	private void RecoveredMethod48(string P_0)
	{
		RecoveredMethod49(P_0, false);
	}

	private void RecoveredMethod49(string P_0, bool P_1)
	{
		RecoveredType82 recoveredType = RecoveredType84.RecoveredMethod365(P_0, "", "", mode.ToString());
		if (recoveredType != null)
		{
			if (P_1 && activityLog != null)
			{
				activityLog.RecoveredMethod367(recoveredType);
			}
			notices.Enqueue(recoveredType.Message);
			while (notices.Count > 100)
			{
				notices.TryDequeue(out var _);
			}
		}
	}

	private void RecoveredMethod50()
	{
		if (activityLog == null)
		{
			return;
		}
		foreach (RecoveredType137 row in rows)
		{
			activityLog.RecoveredMethod369(row.Session.RecoveredMethod509().Activity ?? new RecoveredType82[0]);
		}
		if (RecoveredType350.Current != null)
		{
			RecoveredType350.Current.RecoveredMethod843(rows.Select((RecoveredType137 P_0) => P_0.Session.RecoveredMethod509()).ToArray());
		}
		string text = null;
		string result;
		while (notices.TryDequeue(out result))
		{
			text = result;
		}
		if (text != null)
		{
			RecoveredMethod82("Notice", text);
		}
		if (activityLog.Error != "" && activityLog.Error != activityError)
		{
			activityError = activityLog.Error;
			RecoveredMethod82("Notice", "Activity could not be saved: " + activityError);
		}
	}

	private void RecoveredMethod51()
	{
		if (currentPage != "ActivityLog" || activityLog == null)
		{
			return;
		}
		string text = ((Selected == null) ? "" : (Selected.State.UserId + "|" + Selected.Account));
		string query = RecoveredMethod79<TextBox>("ActivitySearch").Text.Trim();
		int filter = RecoveredMethod79<ComboBox>("ActivityFilter").SelectedIndex;
		if (activityRevision != activityLog.Revision || !(activityScope == text) || !(activityQuery == query) || activityFilter != filter)
		{
			activityRevision = activityLog.Revision;
			activityScope = text;
			activityQuery = query;
			activityFilter = filter;
			RecoveredType137 account = Selected;
			RecoveredType82[] array = (from P_0 in activityLog.RecoveredMethod368()
				where account == null || (string.IsNullOrEmpty(P_0.UserId) && string.IsNullOrEmpty(P_0.Account)) || (!string.IsNullOrEmpty(account.State.UserId) && P_0.UserId == account.State.UserId) || P_0.Account == account.Account
				select P_0).ToArray();
			RecoveredType82 recoveredType = array.FirstOrDefault((RecoveredType82 P_0) => P_0.Category == "Stopped" || P_0.Category == "Crash");
			RecoveredMethod82("LastStop", (recoveredType == null) ? "No stop or crash recorded yet." : ("Last stop / exit · " + ((recoveredType.Account == "") ? recoveredType.Source : ("@" + recoveredType.Account)) + " · " + RecoveredMethod52(recoveredType.AtUtc) + Environment.NewLine + recoveredType.Message));
			RecoveredType82[] array2 = array.Where((RecoveredType82 P_0) => (filter != 1 || P_0.Level != "Info") && (filter != 2 || P_0.Category == "Stopped" || P_0.Category == "Crash") && (query == "" || (P_0.Account + " " + P_0.Source + " " + P_0.Category + " " + P_0.Message).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)).ToArray();
			RecoveredMethod79<ListBox>("ActivityList").ItemsSource = (from P_0 in array2.Take(300)
				select new ActivityCard
				{
					Time = RecoveredMethod52(P_0.AtUtc),
					Scope = ((P_0.Account == "") ? "twist" : ("@" + P_0.Account)) + ((P_0.Source == "") ? "" : (" · " + P_0.Source)),
					Kind = P_0.Category + " · " + P_0.Level,
					Message = P_0.Message,
					Color = ((P_0.Level == "Error") ? "#E6A3A3" : ((P_0.Level == "Warning") ? "#E5C27C" : "#BCA7ED"))
				}).ToArray();
			RecoveredMethod82("ActivityCount", array2.Length + " matching events · newest 300 shown · 5,000 saved locally");
			RecoveredMethod79<TextBlock>("ActivityEmpty").Visibility = ((array2.Length != 0) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	private static string RecoveredMethod52(string P_0)
	{
		if (!DateTime.TryParse(P_0, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result))
		{
			return P_0;
		}
		return result.ToLocalTime().ToString("MMM d · HH:mm:ss");
	}

	private void RecoveredMethod53()
	{
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = ((mode == RecoveredType308.Controller) ? totalChoice : null);
		RecoveredType82 recoveredType = new RecoveredType82();
		recoveredType.Account = "ActivityDemo";
		recoveredType.UserId = "activity-demo";
		recoveredType.Category = "Stopped";
		recoveredType.Level = "Error";
		recoveredType.Message = "Roblox lost focus; input stopped.";
		RecoveredType82 recoveredType2 = recoveredType;
		activityLog.RecoveredMethod367(recoveredType2);
		RecoveredMethod84("ActivityLog");
		if (RecoveredMethod79<FrameworkElement>("ActivityLogView").Visibility != Visibility.Visible || RecoveredMethod79<FrameworkElement>("SettingsHubView").Visibility != Visibility.Visible)
		{
			throw new Exception("Activity settings navigation failed.");
		}
        string exportedActivity = ActivityTextExport.Format(activityLog.RecoveredMethod368());
        if (!exportedActivity.Contains("Roblox lost focus") || RecoveredMethod79<Button>("ExportActivity").Content.ToString() != "Export TXT")
            throw new Exception("Activity TXT export did not include the saved event or export control.");
		RecoveredMethod79<TextBox>("ActivitySearch").Text = "lost focus";
		RecoveredMethod51();
		if (RecoveredMethod79<ListBox>("ActivityList").Items.Count != 1 || !RecoveredMethod79<TextBlock>("LastStop").Text.Contains("lost focus"))
		{
			throw new Exception("Stop explanation did not reach Activity.");
		}
		RecoveredMethod79<ComboBox>("ActivityFilter").SelectedIndex = 2;
		RecoveredMethod51();
		if (RecoveredMethod79<ListBox>("ActivityList").Items.Count != 1)
		{
			throw new Exception("Stops filter failed.");
		}
		RecoveredMethod79<TextBox>("ActivitySearch").Text = "";
		RecoveredMethod84("Session");
		Console.WriteLine("PASS: Activity navigation, stop explanation, search and filter. No windows shown.");
	}

	private void RecoveredMethod54(Exception P_0)
	{
		alertsUiError = P_0.Message;
		RecoveredMethod82("AlertsStatus", alertsUiError);
		RecoveredMethod93("Discord settings: " + alertsUiError);
	}

	private void RecoveredMethod55()
	{
		RecoveredMethod79<ComboBox>("MythPingKind").ItemsSource = new string[3] { "User", "Role", "Everyone" };
		RecoveredMethod79<ComboBox>("MythPingKind").SelectedIndex = 0;
		RecoveredMethod79<ComboBox>("MythPingKind").SelectionChanged += delegate
		{
			RecoveredMethod56();
		};
		RecoveredMethod79<TextBox>("MythPingId").TextChanged += delegate
		{
			RecoveredMethod56();
		};
		RecoveredMethod56();
		if (mode == RecoveredType308.Worker)
		{
			RecoveredMethod79<FrameworkElement>("AlertsForm").IsEnabled = false;
			RecoveredMethod82("AlertsStatus", "Configure Discord alerts on your controller; workers send storage events to it.");
			return;
		}
		alerts = new RecoveredType150(folder, RecoveredMethod93);
		RecoveredType141 settings = alerts.Settings;
		RecoveredMethod79<CheckBox>("DiscordEnabled").IsChecked = settings.Enabled;
		RecoveredMethod79<CheckBox>("WorldSpawnEnabled").IsChecked = settings.SpawnEnabled;
		RecoveredMethod79<PasswordBox>("DiscordUrl").Password = settings.Url;
		RecoveredMethod79<CheckBox>("MythPingEnabled").IsChecked = settings.PingMythical;
		RecoveredMethod79<ComboBox>("MythPingKind").SelectedItem = settings.PingKind;
		RecoveredMethod79<TextBox>("MythPingId").Text = settings.PingId;
		RecoveredMethod82("AlertsStatus", alerts.Status);
		RecoveredMethod83("SaveAlerts", delegate
		{
			alertsDirty = true;
			RecoveredMethod146();
		});
		RecoveredMethod83("TestAlerts", delegate
		{
			try
			{
				alerts.RecoveredMethod414(RecoveredMethod79<PasswordBox>("DiscordUrl").Password.Trim());
				alertsUiError = "";
				RecoveredMethod82("AlertsStatus", "Sending test without pings.");
			}
			catch (Exception ex)
			{
				RecoveredMethod54(ex);
			}
		});
		RecoveredMethod83("RetryAlerts", delegate
		{
			try
			{
				alerts.RecoveredMethod50();
				alertsUiError = "";
				RecoveredMethod82("AlertsStatus", alerts.Status);
			}
			catch (Exception ex)
			{
				RecoveredMethod54(ex);
			}
		});
	}

	private void RecoveredMethod56()
	{
		string text = (RecoveredMethod79<ComboBox>("MythPingKind").SelectedItem as string) ?? "User";
		bool flag = text == "Everyone";
		RecoveredMethod82("MythPingLabel", flag ? "Everyone ping" : ((text == "Role") ? "Discord Role ID" : "Discord User ID"));
		RecoveredMethod79<TextBox>("MythPingId").IsEnabled = !flag;
		RecoveredMethod79<TextBox>("MythPingId").ToolTip = ((text == "Role") ? "Enable Developer Mode in Discord, right-click the role and choose Copy Role ID." : "Enable Developer Mode in Discord, right-click your profile and choose Copy User ID.");
		RecoveredMethod82("MythPingHint", flag ? "Everyone pings the channel. Discord permissions still apply. Other fruits and test messages never ping." : ("Use the numeric Discord " + text + " ID, not a username. Enable Developer Mode in Discord, then right-click the " + ((text == "Role") ? "role → Copy Role ID." : "profile → Copy User ID.") + " Text is still included in the alert, but cannot create a Discord ping."));
	}

	private RecoveredType141 RecoveredMethod57()
	{
		RecoveredType141 recoveredType = new RecoveredType141();
		recoveredType.SpawnEnabled = RecoveredMethod79<CheckBox>("WorldSpawnEnabled").IsChecked == true;
		recoveredType.Enabled = RecoveredMethod79<CheckBox>("DiscordEnabled").IsChecked == true;
		recoveredType.Url = RecoveredMethod79<PasswordBox>("DiscordUrl").Password.Trim();
		recoveredType.PingMythical = RecoveredMethod79<CheckBox>("MythPingEnabled").IsChecked == true;
		recoveredType.PingKind = ((string)RecoveredMethod79<ComboBox>("MythPingKind").SelectedItem) ?? "User";
		recoveredType.PingId = RecoveredMethod79<TextBox>("MythPingId").Text.Trim();
		return recoveredType;
	}

	private RecoveredType141 RecoveredMethod58()
	{
		RecoveredType141 recoveredType = RecoveredMethod57();
		recoveredType.RecoveredMethod50();
		return recoveredType;
	}

	private void RecoveredMethod59(IEnumerable<FruitStoredRecord> P_0)
	{
		if (alerts == null)
		{
			return;
		}
		alerts.RecoveredMethod533(P_0, delegate(FruitStoredRecord fruitStoredRecord)
		{
			if (catalog.TryGetValue(fruitStoredRecord.Name, out var value) && value.IsFruit && value.Rarity != "Unknown")
			{
				return value.Rarity;
			}
			return (!string.IsNullOrEmpty(fruitStoredRecord.Rarity) && !(fruitStoredRecord.Rarity == "Unknown")) ? fruitStoredRecord.Rarity : RecoveredType219.RecoveredMethod52(fruitStoredRecord.Name);
		});
	}

	private void RecoveredMethod60()
	{
		if (alerts != null)
		{
			alerts.RecoveredMethod536(rows.SelectMany((RecoveredType137 P_0) => (P_0.Session.RecoveredMethod509().World != null) ? P_0.Session.RecoveredMethod509().World.Events : new WorldFruitRecord[0]));
			RecoveredMethod59(rows.SelectMany((RecoveredType137 P_0) => P_0.Session.RecoveredMethod509().FruitStores ?? new FruitStoredRecord[0]));
			RecoveredMethod82("AlertsStatus", (alertsUiError != "") ? alertsUiError : alerts.Status);
		}
	}

	private void RecoveredMethod61()
	{
		alerts.Dispose();
		RecoveredType90 recoveredType = new RecoveredType90();
		string text = System.IO.Path.Combine(folder, "alert-ui-test");
		alerts = new RecoveredType150(text, delegate
		{
		}, recoveredType, (int P_0, CancellationToken P_1) => Task.FromResult(0));
		RecoveredMethod79<PasswordBox>("DiscordUrl").Password = "invalid";
		RecoveredMethod79<Button>("TestAlerts").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		string text2 = RecoveredMethod79<TextBlock>("AlertsStatus").Text;
		RecoveredMethod60();
		if (!text2.Contains("webhook URL") || RecoveredMethod79<TextBlock>("AlertsStatus").Text != text2 || recoveredType.Calls != 0)
		{
			throw new Exception("Webhook validation error did not remain visible through polling.");
		}
		RecoveredMethod79<PasswordBox>("DiscordUrl").Password = "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890";
		RecoveredMethod79<CheckBox>("DiscordEnabled").IsChecked = false;
		RecoveredMethod79<CheckBox>("MythPingEnabled").IsChecked = true;
		RecoveredMethod79<TextBox>("MythPingId").Text = "";
		RecoveredMethod79<Button>("SaveAlerts").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		text2 = RecoveredMethod79<TextBlock>("AlertsStatus").Text;
		RecoveredMethod60();
		if (alerts.Settings.Enabled || !alerts.Settings.PingMythical || !RecoveredMethod79<TextBlock>("MythPingLabel").Text.Contains("User ID"))
		{
			throw new Exception("Empty optional ping blocked saving or unclear User ID label.");
		}
		string text3 = File.ReadAllText(System.IO.Path.Combine(text, "discord-settings.json"));
		RecoveredMethod79<Button>("TestAlerts").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		DateTime dateTime = DateTime.UtcNow.AddSeconds(5.0);
		while (DateTime.UtcNow < dateTime && !alerts.Status.Contains("delivered"))
		{
			Thread.Sleep(10);
		}
		RecoveredMethod60();
		if (recoveredType.Calls != 1 || !RecoveredMethod79<TextBlock>("AlertsStatus").Text.Contains("delivered"))
		{
			throw new Exception("Test requires valid notification/ping settings instead of just a valid webhook.");
		}
		if (File.ReadAllText(System.IO.Path.Combine(text, "discord-settings.json")) != text3)
		{
			throw new Exception("Test unexpectedly changed notification preferences.");
		}
		string text4 = File.ReadAllText(System.IO.Path.Combine(text, "fruit-alerts.json"));
		if (text4.Contains("abcdefghijklmnopqrstuvwxyz"))
		{
			throw new Exception("Test URL was persisted in the outbox.");
		}
		RecoveredMethod79<PasswordBox>("DiscordUrl").Password = "";
		RecoveredMethod79<CheckBox>("MythPingEnabled").IsChecked = false;
		Console.WriteLine("PASS: actual Alerts button handlers, persistent validation errors, independent no-ping test, no preference overwrite or URL persistence. HTTP mocked.");
	}

	private async Task<RecoveredType137> RecoveredMethod62(int P_0, long P_1)
	{
		RecoveredType163 clientOffsets = await Task.Run(delegate
		{
			using Process process = Process.GetProcessById(P_0);
			if (process.StartTime.ToUniversalTime().Ticks != P_1)
			{
				throw new Exception("Roblox restarted while being discovered.");
			}
			return new RecoveredType163(RecoveredType422.RecoveredMethod912(process.MainModule.FileName, bundledOffsets));
		});
		return new RecoveredType137(new RecoveredType175(P_0, P_1, clientOffsets, RecoveredMethod48))
		{
			Offsets = clientOffsets
		};
	}

	private async Task RecoveredMethod63(RecoveredType137 P_0)
	{
		await P_0.Session.RecoveredMethod511();
		if (P_0.Session.RecoveredMethod509().Attached && P_0.Inventory == null)
		{
			P_0.Inventory = new RecoveredType260(P_0.Session.Pid, P_0.Session.Created, P_0.Offsets ?? offsets);
		}
	}

	private void RecoveredMethod64(RecoveredType131 P_0, RecoveredType133 P_1)
	{
		if (activityLog != null)
		{
			activityLog.RecoveredMethod369(P_0.RecoveredMethod509().Activity ?? new RecoveredType82[0]);
		}
		RoundRecord[] array = P_0.RecoveredMethod510();
		if (ledger.RecoveredMethod724(array))
		{
			historyCount = -1;
		}
		if (catches != null)
		{
			if (P_1 != null)
			{
				InventorySnapshot inventorySnapshot = P_1.RecoveredMethod515();
				if (inventorySnapshot.Valid)
				{
					catches.RecoveredMethod725(inventorySnapshot);
				}
			}
			if (catches.RecoveredMethod724(array))
			{
				inventoryDirty = true;
			}
		}
		if (worldHistory != null && P_0.RecoveredMethod509().World != null)
		{
			worldHistory.RecoveredMethod898(P_0.RecoveredMethod509().World.Events);
		}
		if (alerts != null && P_0.RecoveredMethod509().World != null)
		{
			alerts.RecoveredMethod536(P_0.RecoveredMethod509().World.Events);
		}
		RecoveredMethod59(P_0.RecoveredMethod509().FruitStores ?? new FruitStoredRecord[0]);
	}

	private void RecoveredMethod65(RecoveredType137 P_0)
	{
		if (pickRow == P_0)
		{
			RecoveredMethod74();
		}
		RecoveredMethod64(P_0.Session, P_0.Inventory);
		P_0.Session.Dispose();
		if (P_0.Inventory != null)
		{
			P_0.Inventory.Dispose();
		}
		rows.Remove(P_0);
		historyCount = -1;
		inventoryDirty = true;
		cardsSignature = "";
		totalCards = "";
	}

	private async Task RecoveredMethod66(KeyValuePair<int, long>[] P_0, Func<int, long, Task<RecoveredType137>> P_1, Func<RecoveredType137, Task> P_2, DateTime P_3)
	{
		RecoveredType137[] array = rows.Where((RecoveredType137 recoveredType3) => !(recoveredType3.Session is RecoveredType325)).ToArray();
		foreach (RecoveredType137 retiredRow in array)
		{
			if (!P_0.Any((KeyValuePair<int, long> keyValuePair4) => keyValuePair4.Key == retiredRow.Session.Pid && keyValuePair4.Value == retiredRow.Session.Created))
			{
				retiredRow.Session.RecoveredMethod48("Roblox closed or restarted.");
				try
				{
					await retiredRow.Session.RecoveredMethod513("Roblox closed or restarted.");
				}
				catch (Exception ex)
				{
					RecoveredMethod93("Closed client cleanup: " + ex.Message);
				}
				RecoveredMethod65(retiredRow);
				RecoveredMethod93("Closed Roblox client removed. Waiting for a new client in this Windows session.");
			}
		}
		RecoveredMethod118();
		int num2 = default(int);
		KeyValuePair<int, long>[] array2 = default(KeyValuePair<int, long>[]);
		int num3 = default(int);
		RecoveredType137 row = default(RecoveredType137);
		RecoveredType22 recoveredType = default(RecoveredType22);
		switch (num2)
		{
		default:
			array2 = P_0;
			num3 = 0;
			goto IL_059c;
		case 1:
		case 2:
			{
				try
				{
					if (row == null)
					{
						KeyValuePair<int, long> keyValuePair = recoveredType.process;
						int key = keyValuePair.Key;
						KeyValuePair<int, long> keyValuePair2 = recoveredType.process;
						row = await P_1(key, keyValuePair2.Value);
						if (closing || stopping)
						{
							row.Session.Dispose();
							break;
						}
						rows.Add(row);
						RecoveredMethod118();
					}
					if (!row.Attaching && !row.Session.RecoveredMethod509().Running && (!row.Session.RecoveredMethod509().Attached || row.Inventory == null) && !(P_3 < row.NextAttachUtc))
					{
						row.Attaching = true;
						row.NextAttachUtc = P_3.AddSeconds(6.0);
						try
						{
							await P_2(row);
							row.RecoveredMethod519(clock.Elapsed.TotalSeconds);
							if (row.State.Attached)
							{
								profiles.Remove(RecoveredMethod80(row));
								if (Selected == row)
								{
									RecoveredMethod101();
								}
							}
						}
						finally
						{
							row.Attaching = false;
						}
					}
				}
				catch (Exception ex2)
				{
					RecoveredType16 recoveredType2 = this;
					object[] array3 = new object[4] { "PID ", null, null, null };
					KeyValuePair<int, long> keyValuePair3 = recoveredType.process;
					array3[1] = keyValuePair3.Key;
					array3[2] = " not ready; will retry: ";
					array3[3] = ex2.Message;
					recoveredType2.RecoveredMethod93(string.Concat(array3));
				}
				num3++;
				goto IL_059c;
			}
			IL_059c:
			if (num3 >= array2.Length)
			{
				break;
			}
			recoveredType = new RecoveredType22();
			recoveredType.process = array2[num3];
			if (closing || stopping)
			{
				break;
			}
			row = rows.FirstOrDefault(recoveredType.RecoveredMethod345);
			goto case 1;
		}
		RecoveredMethod118();
		if (Selected == null && rows.Count > 0)
		{
			RecoveredMethod79<ComboBox>("Clients").SelectedIndex = 0;
		}
		RecoveredMethod98();
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Client lifecycle: " + P_1);
		}
	}

	private static KeyValuePair<int, long> RecoveredMethod67(int P_0, long P_1)
	{
		return new KeyValuePair<int, long>(P_0, P_1);
	}

	private void RecoveredMethod68()
	{
		DateTime utcNow = DateTime.UtcNow;
		string text = "lifecycle-" + Guid.NewGuid().ToString("N");
		RecoveredType132 previous = new RecoveredType132
		{
			Ready = true,
			User = text,
			State = new RecoveredType174
			{
				Pid = 801,
				Created = 1L,
				Account = "Lifecycle",
				UserId = text,
				Attached = true,
				Running = true
			},
			Rounds = new RoundRecord[1]
			{
				new RoundRecord
				{
					Id = "final-" + text,
					UserId = text,
					Account = "Lifecycle",
					Full = true,
					AtUtc = utcNow.ToString("o")
				}
			}
		};
		RecoveredType134 previousInventory = new RecoveredType134();
		RecoveredType137 recoveredType = new RecoveredType137(previous);
		recoveredType.Inventory = previousInventory;
		RecoveredType137 recoveredType2 = recoveredType;
		rows.Add(recoveredType2);
		RecoveredMethod118();
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = recoveredType2;
		RecoveredType170 recoveredType3 = new RecoveredType170();
		recoveredType3.CastX = 0.37;
		recoveredType3.CastY = 0.61;
		recoveredType3.BaitMode = "best";
		recoveredType3.RecoveredMethod414(RecoveredMethod81(recoveredType2));
		RecoveredType132 replacement = new RecoveredType132
		{
			User = text,
			State = new RecoveredType174
			{
				Pid = 801,
				Created = 2L
			}
		};
		int created = 0;
		Func<int, long, Task<RecoveredType137>> func = delegate(int P_0, long P_1)
		{
			RecoveredMethod42(previous.Disposed && previousInventory.Disposed, "Closed client is retired before a replacement is created");
			created++;
			if (P_0 == 802)
			{
				throw new Exception("Simulated loading process");
			}
			return Task.FromResult(new RecoveredType137(replacement));
		};
		Func<RecoveredType137, Task> attach = delegate(RecoveredType137 P_0)
		{
			RecoveredType132 recoveredType4 = (RecoveredType132)P_0.Session;
			recoveredType4.RecoveredMethod511().GetAwaiter().GetResult();
			if (recoveredType4.State.Attached && P_0.Inventory == null)
			{
				P_0.Inventory = new RecoveredType134();
			}
			return Task.FromResult(0);
		};
		RecoveredMethod66(new KeyValuePair<int, long>[2]
		{
			RecoveredMethod67(801, 2L),
			RecoveredMethod67(802, 3L)
		}, func, attach, utcNow).GetAwaiter().GetResult();
		RecoveredMethod42(rows.Count == 1 && rows[0].Session == replacement && previous.Stops == 1, "Reused PID creates a fresh row; a failing process cannot block pruning");
		RecoveredMethod42(workerSessions.Length == 1 && workerSessions[0] == replacement && replacement.Attaches == 1 && !replacement.State.Attached, "Published sessions contain only the replacement, while loading remains retryable");
		RecoveredMethod42(RecoveredMethod113(text) == 1 && ledger.RecoveredMethod848(text).Length == 1, "Final catch history survives removal");
		replacement.Ready = true;
		RecoveredMethod66(new KeyValuePair<int, long>[1] { RecoveredMethod67(801, 2L) }, func, attach, utcNow.AddSeconds(3.0)).GetAwaiter().GetResult();
		RecoveredMethod42(replacement.Attaches == 1, "Loading retries respect their delay");
		RecoveredMethod66(new KeyValuePair<int, long>[1] { RecoveredMethod67(801, 2L) }, func, attach, utcNow.AddSeconds(6.0)).GetAwaiter().GetResult();
		RecoveredMethod42(replacement.Attaches == 2 && rows[0].Inventory != null && replacement.State.Attached, "Loading player attaches on a later scan and inventory monitoring is restored");
		RecoveredMethod42(Math.Abs(RecoveredType170.RecoveredMethod569(RecoveredMethod81(rows[0])).CastX - 0.37) < 0.0001 && RecoveredMethod79<TextBox>("CastX").Text == "37" && profiles[RecoveredMethod80(rows[0])].BaitMode == "best", "Replacement restores account settings and worker point");
		RecoveredType133 inventory = rows[0].Inventory;
		RecoveredMethod66(new KeyValuePair<int, long>[1] { RecoveredMethod67(801, 2L) }, func, attach, utcNow.AddSeconds(20.0)).GetAwaiter().GetResult();
		RecoveredMethod42(replacement.Attaches == 2 && object.ReferenceEquals(inventory, rows[0].Inventory) && replacement.Starts == 0, "Attached client is not duplicated or restarted automatically");
		RecoveredMethod66(new KeyValuePair<int, long>[0], func, attach, utcNow.AddSeconds(25.0)).GetAwaiter().GetResult();
		RecoveredMethod42(rows.Count == 0 && workerSessions.Length == 0 && replacement.Disposed && ((RecoveredType134)inventory).Disposed && RecoveredMethod70<TextBlock>("MiniPoint").Text == "Open Roblox to connect", "Closed replacement and stale compact UI are cleared");
		RecoveredMethod42(RecoveredMethod113(text) == 1 && File.Exists(System.IO.Path.Combine(folder, "profiles", "account-" + text + ".json")), "History and saved settings remain after all clients close");
		RecoveredType132 loading = new RecoveredType132
		{
			User = text,
			State = new RecoveredType174
			{
				Pid = 803,
				Created = 4L
			}
		};
		RecoveredType132 ready = new RecoveredType132
		{
			User = text + "-other",
			Ready = true,
			State = new RecoveredType174
			{
				Pid = 804,
				Created = 5L
			}
		};
		Func<int, long, Task<RecoveredType137>> func2 = (int P_0, long P_1) => Task.FromResult(new RecoveredType137((P_0 == 803) ? loading : ready));
		Func<RecoveredType137, Task> func3 = delegate(RecoveredType137 P_0)
		{
			if (P_0.Session == loading && loading.Attaches++ == 0)
			{
				throw new Exception("Simulated attach failure");
			}
			return attach(P_0);
		};
		RecoveredMethod66(new KeyValuePair<int, long>[2]
		{
			RecoveredMethod67(803, 4L),
			RecoveredMethod67(804, 5L)
		}, func2, func3, utcNow.AddSeconds(30.0)).GetAwaiter().GetResult();
		RecoveredMethod42(rows.Count == 2 && ready.State.Attached, "An attachment exception does not prevent other clients from attaching");
		loading.Ready = true;
		RecoveredMethod66(new KeyValuePair<int, long>[2]
		{
			RecoveredMethod67(803, 4L),
			RecoveredMethod67(804, 5L)
		}, func2, attach, utcNow.AddSeconds(36.0)).GetAwaiter().GetResult();
		RecoveredMethod42(loading.State.Attached && rows.All((RecoveredType137 P_0) => P_0.Inventory != null), "Exception during first attach remains retryable");
		RecoveredMethod66(new KeyValuePair<int, long>[0], func2, attach, utcNow.AddSeconds(45.0)).GetAwaiter().GetResult();
		Console.WriteLine("PASS: worker close/reopen, reused PID, loading and exception retries, per-client failure isolation, publication cleanup, saved-point restoration, final catch preservation and compact UI reset. No real processes or input.");
	}

	private void RecoveredMethod69()
	{
		RecoveredType312 recoveredType = new RecoveredType312();
		recoveredType.WorkerId = Guid.NewGuid().ToString("N");
		recoveredType.SessionId = 9991;
		recoveredType.Name = "Lifecycle";
		recoveredType.User = "Test";
		RecoveredType312 recoveredType2 = recoveredType;
		List<RecoveredType325> retired = new List<RecoveredType325>();
		RecoveredType327 recoveredType3 = new RecoveredType327(recoveredType2, null, folder, delegate
		{
		}, delegate(RecoveredType325 P_0)
		{
			retired.Add(P_0);
		});
		string text = "remote-lifecycle-" + Guid.NewGuid().ToString("N");
		RecoveredType310 recoveredType4 = new RecoveredType310();
		recoveredType4.Key = "901-1";
		recoveredType4.State = new RecoveredType174
		{
			Pid = 901,
			Created = 1L,
			UserId = text,
			Account = "Lifecycle",
			Attached = true
		};
		recoveredType4.Rounds = new RoundRecord[1]
		{
			new RoundRecord
			{
				Id = "remote-final-" + text,
				UserId = text,
				Account = "Lifecycle",
				Full = true,
				AtUtc = DateTime.UtcNow.ToString("o")
			}
		};
		recoveredType4.Profile = new RecoveredType170
		{
			CastX = 0.63
		};
		RecoveredType310 recoveredType5 = recoveredType4;
		recoveredType3.RecoveredMethod798(new RecoveredType315
		{
			Desktop = "Ready",
			Accounts = new RecoveredType310[1] { recoveredType5 }
		});
		RecoveredMethod127(recoveredType3.RecoveredMethod795());
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = rows.Single();
		RecoveredMethod42(rows.Count == 1, "Controller accepts a live worker client");
		recoveredType3.RecoveredMethod798(new RecoveredType315
		{
			Desktop = "Ready",
			Accounts = new RecoveredType310[0]
		});
		RecoveredMethod42(recoveredType3.RecoveredMethod795().Length == 0 && retired.Count == 1, "Worker's authoritative empty account list removes the remote session");
		foreach (RecoveredType325 item in retired)
		{
			RecoveredMethod64(item, item.Inventory);
		}
		RecoveredMethod127(recoveredType3.RecoveredMethod795());
		RecoveredMethod42(rows.Count == 0 && accountChoices.Count == 1 && IsTotalSelected && RecoveredMethod113(text) == 1, "Dead remote client is cleared from selector with final history preserved");
		recoveredType5.Key = "901-2";
		recoveredType5.State = new RecoveredType174
		{
			Pid = 901,
			Created = 2L,
			UserId = text,
			Account = "Lifecycle",
			Attached = true
		};
		recoveredType5.Rounds = new RoundRecord[0];
		recoveredType3.RecoveredMethod798(new RecoveredType315
		{
			Desktop = "Ready",
			Accounts = new RecoveredType310[1] { recoveredType5 }
		});
		RecoveredMethod127(recoveredType3.RecoveredMethod795());
		RecoveredMethod42(rows.Count == 1 && rows[0].Session.Created == 2 && !rows[0].State.Running, "Controller adopts a reopened client once, in stopped state");
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = rows[0];
		RecoveredMethod127(new RecoveredType325[0]);
		RecoveredMethod42(rows.Count == 0 && IsTotalSelected && RecoveredMethod113(text) == 1, "Disconnected worker rows leave the controller and saved history remains");
		Console.WriteLine("PASS: controller authoritative session pruning, replacement adoption, disconnected-row cleanup and selection/history preservation. No real input.");
	}

	private A RecoveredMethod70<A>(string P_0) where A : FrameworkElement
	{
		return (A)miniWindow.FindName(P_0);
	}

	private void RecoveredMethod71()
	{
		RecoveredMethod72(true);
	}

	private void RecoveredMethod72(bool P_0)
	{
		using (FileStream stream = File.OpenRead(System.IO.Path.Combine(bundle, "Worker.xaml")))
		{
			miniWindow = (Window)XamlReader.Load((Stream)stream);
		}
		miniWindow.Icon = window.Icon;
		Application.Current.MainWindow = miniWindow;
		RecoveredMethod70<ComboBox>("MiniAccounts").ItemsSource = rows;
		RecoveredMethod70<ComboBox>("MiniAccounts").SelectionChanged += delegate
		{
			if (!miniSelection)
			{
				object selectedItem = RecoveredMethod70<ComboBox>("MiniAccounts").SelectedItem;
				RecoveredMethod74();
				RecoveredMethod79<ComboBox>("Clients").SelectedItem = selectedItem;
			}
		};
		RecoveredMethod70<Button>("MiniMinimize").Click += delegate
		{
			miniWindow.WindowState = WindowState.Minimized;
		};
		RecoveredMethod70<Button>("MiniClose").Click += delegate
		{
			miniWindow.Close();
		};
		RecoveredMethod70<Grid>("MiniTitle").MouseLeftButtonDown += delegate(object obj, MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed)
			{
				miniWindow.DragMove();
			}
		};
		RecoveredMethod70<Button>("MiniStop").Click += async delegate
		{
			await RecoveredMethod106();
		};
		RecoveredMethod70<Button>("MiniCapture").Click += async delegate
		{
			if (pointPicker != null)
			{
				RecoveredMethod74();
			}
			else
			{
				await RecoveredMethod106();
				RecoveredType137 row = Selected;
				if (row != null)
				{
					try
					{
						pickRow = row;
						int token = ++pickToken;
						pointPicker = new RecoveredType344(row.Session.Pid, row.Session.Created, delegate(double num, double num2)
						{
							if (!window.Dispatcher.HasShutdownStarted)
							{
								window.Dispatcher.BeginInvoke((Action)delegate
								{
									RecoveredMethod76(row, num, num2, token);
								});
							}
						});
						RecoveredMethod73();
					}
					catch (Exception ex)
					{
						RecoveredMethod74();
						RecoveredMethod93(ex.Message);
					}
				}
			}
		};
		RecoveredMethod70<Button>("MiniAlign").Click += async delegate
		{
			if (pointPicker != null)
			{
				RecoveredMethod74();
			}
			else
			{
				await RecoveredMethod106();
				RecoveredType137 row = Selected;
				if (row != null)
				{
					try
					{
						string bait;
						using (RecoveredType172 recoveredType = new RecoveredType172(row.Session.Pid, row.Session.Created, row.Offsets ?? offsets))
						{
							RecoveredType104 recoveredType2 = recoveredType.RecoveredMethod571(null).RecoveredMethod401();
							bait = RecoveredType106.RecoveredMethod404(recoveredType2.Counts, "best");
							if (bait == null)
							{
								throw new Exception("No bait is available to align.");
							}
							((RecoveredType118)recoveredType.RecoveredMethod571(null)).RecoveredMethod481(bait);
						}
						pickRow = row;
						pickBait = bait;
						int token = ++pickToken;
						pointPicker = new RecoveredType344(row.Session.Pid, row.Session.Created, delegate(double num, double num2)
						{
							if (!window.Dispatcher.HasShutdownStarted)
							{
								window.Dispatcher.BeginInvoke((Action)delegate
								{
									RecoveredMethod75(row, bait, num, num2, token);
								});
							}
						});
						RecoveredMethod73();
					}
					catch (Exception ex)
					{
						RecoveredMethod74();
						RecoveredMethod93(ex.Message);
					}
				}
			}
		};
		RecoveredMethod70<Button>("MiniResetAlign").Click += delegate
		{
			RecoveredMethod74();
			RecoveredType137 selected = Selected;
			if (selected == null)
			{
				return;
			}
			try
			{
				RecoveredType170 recoveredType = RecoveredType170.RecoveredMethod569(RecoveredMethod81(selected));
				recoveredType.UiOffsetX = (recoveredType.UiOffsetY = 0.0);
				recoveredType.RecoveredMethod414(RecoveredMethod81(selected));
				profiles[RecoveredMethod80(selected)] = recoveredType;
				RecoveredMethod93("Worker UI alignment reset.");
				RecoveredMethod73();
			}
			catch (Exception ex)
			{
				RecoveredMethod93(ex.Message);
			}
		};
		RecoveredMethod70<Button>("MiniConnect").Click += delegate
		{
			RecoveredMethod79<TextBox>("WorkerPairing").Text = RecoveredMethod70<TextBox>("MiniCode").Text;
			RecoveredMethod122();
		};
		RecoveredMethod70<TextBox>("MiniCode").Text = RecoveredMethod79<TextBox>("WorkerPairing").Text;
		miniWindow.StateChanged += delegate
		{
			RecoveredMethod165();
		};
		miniWindow.IsVisibleChanged += delegate
		{
			RecoveredMethod165();
		};
		miniWindow.Closing += delegate(object obj, CancelEventArgs e)
		{
			if (!closing)
			{
				e.Cancel = true;
				if (!stopping)
				{
					stopping = true;
					window.Dispatcher.BeginInvoke(new Action(RecoveredMethod90));
				}
			}
		};
		RecoveredMethod91(miniWindow);
		RecoveredMethod73();
		miniWindow.Loaded += async delegate
		{
			await RecoveredMethod94();
		};
		if (P_0)
		{
			miniWindow.Show();
		}
	}

	private void RecoveredMethod73()
	{
		if (miniWindow != null)
		{
			miniSelection = true;
			RecoveredMethod70<ComboBox>("MiniAccounts").SelectedItem = Selected;
			miniSelection = false;
			bool flag = workerLink != null && workerLink.Connected;
			string text = ((workerLink == null) ? "Waiting for controller" : workerLink.Status);
			RecoveredMethod70<TextBlock>("MiniStatus").Text = ((!flag) ? text : ((workerLink.Desktop == "Ready") ? ("Connected · S" + RecoveredType309.SessionId) : ("Connected · " + workerLink.Desktop)));
			RecoveredMethod70<TextBlock>("MiniStatus").ToolTip = text + ((workerLink == null) ? "" : (" · " + workerLink.Desktop));
			RecoveredMethod70<Ellipse>("MiniDot").Fill = (flag ? RecoveredType122.Connected : RecoveredType122.Disconnected);
			RecoveredType137 selected = Selected;
			if (selected == null)
			{
				RecoveredMethod70<TextBlock>("MiniPoint").Text = "Open Roblox to connect";
				RecoveredMethod70<TextBlock>("MiniAlignValue").Text = "Waiting for a Roblox client";
			}
			if (selected != null && profiles.TryGetValue(RecoveredMethod80(selected), out var value))
			{
				RecoveredMethod70<TextBlock>("MiniPoint").Text = (value.CastX * 100.0).ToString("0.#") + "% / " + (value.CastY * 100.0).ToString("0.#") + "%";
			}
			if (selected != null && profiles.TryGetValue(RecoveredMethod80(selected), out var value2))
			{
				RecoveredMethod70<TextBlock>("MiniAlignValue").Text = "UI offset: " + value2.UiOffsetX.ToString("0.0") + ", " + value2.UiOffsetY.ToString("0.0") + " px";
			}
			if (pointPicker != null)
			{
				RecoveredMethod70<TextBlock>("MiniStatus").Text = ((pickBait == "") ? "Right-click Roblox to choose" : ("Right-click center of " + pickBait));
				RecoveredMethod70<TextBlock>("MiniStatus").ToolTip = ((pickBait == "") ? "Right-click inside the selected Roblox client. Click Cancel selection or press F9 to cancel." : ("Right-click the CENTER of the visible " + pickBait + " row. This aligns all bait and purchase controls; the cast point stays saved."));
				RecoveredMethod70<TextBlock>("MiniAlignValue").Text = ((pickBait == "") ? "Choosing cast point" : ("Right-click CENTER: " + pickBait));
			}
			RecoveredMethod70<Button>("MiniCapture").Content = ((pointPicker == null) ? "Select cursor point" : "Cancel selection");
			RecoveredMethod70<Button>("MiniCapture").ToolTip = "Click here, then right-click the desired point inside Roblox.";
			RecoveredMethod70<Button>("MiniCapture").IsEnabled = selected != null;
			RecoveredMethod70<Button>("MiniAlign").IsEnabled = selected != null;
			RecoveredMethod70<Button>("MiniStop").IsEnabled = selected?.Session.RecoveredMethod509().Running ?? false;
			RecoveredMethod70<TextBlock>("MiniPoint").ToolTip = ((selected == null) ? "" : selected.Session.RecoveredMethod509().StopReason);
		}
	}

	private void RecoveredMethod74()
	{
		pickToken++;
		if (pointPicker != null)
		{
			pointPicker.Dispose();
			pointPicker = null;
		}
		pickRow = null;
		pickBait = "";
		if (miniWindow != null)
		{
			RecoveredMethod73();
		}
	}

	private void RecoveredMethod75(RecoveredType137 P_0, string P_1, double P_2, double P_3, int P_4)
	{
		if (pointPicker == null || pickRow != P_0 || P_4 != pickToken)
		{
			return;
		}
		RecoveredMethod74();
		try
		{
			RecoveredType381 recoveredType2;
			RecoveredType126 recoveredType3;
			using (RecoveredType172 recoveredType = new RecoveredType172(P_0.Session.Pid, P_0.Session.Created, P_0.Offsets ?? offsets))
			{
				recoveredType2 = ((RecoveredType118)recoveredType.RecoveredMethod571(null)).RecoveredMethod481(P_1);
				recoveredType3 = RecoveredType127.RecoveredMethod503(recoveredType.Window);
			}
			RecoveredType170 recoveredType4 = RecoveredType382.RecoveredMethod875(RecoveredType170.RecoveredMethod569(RecoveredMethod81(P_0)), recoveredType2, recoveredType3, P_2, P_3);
			recoveredType4.RecoveredMethod414(RecoveredMethod81(P_0));
			profiles[RecoveredMethod80(P_0)] = recoveredType4;
			if (Selected == P_0)
			{
				RecoveredMethod101();
			}
			RecoveredMethod93("UI alignment saved from " + P_1 + " · delta " + recoveredType4.UiOffsetX.ToString("0.0") + "," + recoveredType4.UiOffsetY.ToString("0.0") + " px. Cast point unchanged.");
			RecoveredMethod73();
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	private void RecoveredMethod76(RecoveredType137 P_0, double P_1, double P_2, int P_3)
	{
		if (pointPicker == null || pickRow != P_0 || P_3 != pickToken)
		{
			return;
		}
		RecoveredMethod74();
		try
		{
			RecoveredType170 recoveredType = RecoveredType170.RecoveredMethod569(RecoveredMethod81(P_0));
			recoveredType.CastX = P_1;
			recoveredType.CastY = P_2;
			recoveredType.RecoveredMethod414(RecoveredMethod81(P_0));
			profiles[RecoveredMethod80(P_0)] = recoveredType;
			if (Selected == P_0)
			{
				RecoveredMethod101();
			}
			RecoveredMethod93("Worker S" + RecoveredType309.SessionId + " cast point saved · " + (P_1 * 100.0).ToString("0.0") + "% / " + (P_2 * 100.0).ToString("0.0") + "%");
			RecoveredMethod73();
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterHotKey")]
	private static extern bool RecoveredMethod77(IntPtr P_0, int P_1, uint P_2, uint P_3);

	[DllImport("user32.dll", EntryPoint = "UnregisterHotKey")]
	private static extern bool RecoveredMethod78(IntPtr P_0, int P_1);

	private A RecoveredMethod79<A>(string P_0) where A : FrameworkElement
	{
		if (!controls.TryGetValue(P_0, out var value))
		{
			value = (FrameworkElement)window.FindName(P_0);
			controls[P_0] = value;
		}
		return (A)value;
	}

	private string RecoveredMethod80(RecoveredType137 P_0)
	{
		if (!string.IsNullOrEmpty(P_0.State.UserId))
		{
			return "account-" + P_0.State.UserId;
		}
		return "pid-" + P_0.Session.Pid;
	}

	private string RecoveredMethod81(RecoveredType137 P_0)
	{
		return System.IO.Path.Combine(folder, "profiles", RecoveredMethod80(P_0) + ".json");
	}

	private void RecoveredMethod82(string P_0, string P_1)
	{
		TextBlock textBlock = RecoveredMethod79<TextBlock>(P_0);
		if (textBlock.Text != P_1)
		{
			textBlock.Text = P_1;
		}
	}

	private void RecoveredMethod83(string P_0, Action P_1)
	{
		RecoveredMethod79<Button>(P_0).Click += delegate
		{
			P_1();
		};
	}

	public RecoveredType16(RecoveredType308 P_0 = RecoveredType308.Local)
	{
		mode = P_0;
		bundle = AppDomain.CurrentDomain.BaseDirectory;
		folder = RecoveredType309.Base;
		Directory.CreateDirectory(System.IO.Path.Combine(folder, "profiles"));
		Directory.CreateDirectory(System.IO.Path.Combine(folder, "logs"));
		bundledOffsets = File.ReadAllText(System.IO.Path.Combine(bundle, "offsets.json"));
		offsets = new RecoveredType163(bundledOffsets);
		ledger = new RecoveredType360(System.IO.Path.Combine(folder, "data"));
		using (FileStream stream = File.OpenRead(System.IO.Path.Combine(bundle, "Dashboard.xaml")))
		{
			window = (Window)XamlReader.Load((Stream)stream);
		}
		window.Icon = BitmapFrame.Create(new Uri(System.IO.Path.Combine(bundle, "twist.ico")));
		window.Width = Math.Min(window.Width, SystemParameters.WorkArea.Width - 30.0);
		window.Height = Math.Min(window.Height, SystemParameters.WorkArea.Height - 30.0);
		RecoveredMethod45();
		RecoveredMethod79<Grid>("ChartHost").Children.Add(chart);
		RecoveredMethod79<Grid>("GaugeHost").Children.Add(gauge);
		RecoveredMethod79<ComboBox>("Clients").SelectionChanged += delegate
		{
			RecoveredMethod101();
			inventoryDirty = true;
			historyCount = -1;
			RecoveredMethod98();
		};
		RecoveredMethod112();
		RecoveredMethod170();
		RecoveredMethod55();
		RecoveredMethod79<ComboBox>("BaitMode").ItemsSource = new string[2] { "Common bait", "Best available · Legendary → Rare → Common" };
		RecoveredMethod79<ComboBox>("BaitMode").SelectedIndex = 0;
		RecoveredMethod83("InventoryFishTab", delegate
		{
			RecoveredMethod84("Inventory");
		});
		RecoveredMethod83("SettingsGeneralTab", delegate
		{
			RecoveredMethod84("Settings");
		});
		RecoveredMethod83("NavWorld", delegate
		{
			RecoveredMethod84("World");
		});
		RecoveredMethod83("NavConnections", delegate
		{
			RecoveredMethod84("Connections");
		});
		RecoveredMethod83("NavInventory", delegate
		{
			RecoveredMethod84("Inventory");
		});
		RecoveredMethod83("NavFruits", delegate
		{
			RecoveredMethod84("Fruits");
		});
		RecoveredMethod83("NavAlerts", delegate
		{
			RecoveredMethod84("Alerts");
		});
		RecoveredMethod83("NavSession", delegate
		{
			RecoveredMethod84("Session");
		});
		RecoveredMethod83("NavTracker", delegate
		{
			RecoveredMethod84("Tracker");
		});
		RecoveredMethod83("NavSettings", delegate
		{
			RecoveredMethod84("Settings");
		});
		RecoveredMethod84((mode == RecoveredType308.Local) ? "Session" : "Connections");
		RecoveredMethod120();
		RecoveredMethod154();
		if (RecoveredType350.Current != null)
		{
			RecoveredType350.Current.EmergencyStop = delegate
			{
				RecoveredMethod119("twist encountered a fatal error.");
			};
		}
		RecoveredMethod83("Minimize", delegate
		{
			window.WindowState = WindowState.Minimized;
		});
		RecoveredMethod83("CloseWindow", delegate
		{
			window.Close();
		});
		RecoveredMethod79<Grid>("TitleBar").MouseLeftButtonDown += delegate(object obj, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2)
			{
				window.WindowState = ((window.WindowState != WindowState.Maximized) ? WindowState.Maximized : WindowState.Normal);
			}
			else if (e.ButtonState == MouseButtonState.Pressed)
			{
				window.DragMove();
			}
		};
		RecoveredMethod79<Button>("Refresh").Click += async delegate
		{
			await RecoveredMethod94();
		};
		RecoveredMethod79<Button>("AttachAll").Click += async delegate
		{
			RecoveredType137 row = null;
RecoveredType137[] array = rows.ToArray();
			int num2 = 0;
			goto IL_00f2;
			IL_004f:
			try
			{
				await row.Session.RecoveredMethod511();
			}
			catch (Exception ex)
			{
				RecoveredMethod93(ex.Message);
			}
			num2++;
			goto IL_00f2;
			IL_00f2:
			if (num2 >= array.Length)
			{
				return;
			}
			row = array[num2];
			goto IL_004f;
		};
		RecoveredMethod79<Button>("Start").Click += async delegate
		{
			try
			{
				if (IsTotalSelected)
				{
					await RecoveredMethod159();
				}
				else
				{
					RecoveredType137 selected = Selected;
					if (selected != null && selected.Session.RecoveredMethod509().Running && selected.Session.RecoveredMethod509().AutoFish)
					{
						await selected.Session.RecoveredMethod513();
					}
					else
					{
						RecoveredMethod104(true);
					}
				}
			}
			catch (Exception ex)
			{
				RecoveredMethod93(ex.Message);
			}
		};
		RecoveredMethod83("ReloadProfile", RecoveredMethod101);
		RecoveredMethod83("Observe", delegate
		{
			RecoveredMethod104(false);
		});
		RecoveredMethod79<Button>("StopAll").Click += async delegate
		{
			await RecoveredMethod106();
		};
		RecoveredMethod79<Button>("SaveProfile").Click += async delegate
		{
			if (RecoveredMethod103(true))
			{
				await RecoveredMethod149();
			}
		};
		RecoveredMethod83("Export", RecoveredMethod116);
		RecoveredMethod83("ExportRounds", RecoveredMethod107);
		RecoveredMethod79<Button>("Diagnose").Click += async delegate
		{
			RecoveredType137 row = Selected;
			if (row == null)
			{
				return;
			}
			try
			{
				RecoveredMethod93((await row.Session.RecoveredMethod514()).Replace("\r\n", " | "));
			}
			catch (Exception ex)
			{
				RecoveredMethod93(ex.Message);
			}
		};
		RecoveredMethod83("OpenLogs", delegate
		{
			Process.Start("explorer.exe", System.IO.Path.Combine(folder, "logs"));
		});
		RecoveredMethod83("OpenFolder", delegate
		{
			Process.Start("explorer.exe", System.IO.Path.Combine(folder, "profiles"));
		});
		RecoveredMethod132();
		RecoveredMethod140();
		RecoveredMethod163();
		if (mode != RecoveredType308.Worker)
		{
			RecoveredMethod91(window);
		}
		window.Closing += delegate(object obj, CancelEventArgs e)
		{
			if (!closing)
			{
				e.Cancel = true;
				if (!stopping)
				{
					stopping = true;
					window.Dispatcher.BeginInvoke(new Action(RecoveredMethod90));
				}
			}
		};
		window.Closed += delegate
		{
			settingsTimer.Stop();
			timer.Stop();
			liveTimer.Stop();
			RecoveredMethod78(hwnd, 910);
			RecoveredMethod78(hwnd, 911);
			RecoveredMethod78(hwnd, 912);
			RecoveredMethod95();
			foreach (RecoveredType137 row2 in rows)
			{
				row2.Session.Dispose();
				if (row2.Inventory != null)
				{
					row2.Inventory.Dispose();
				}
			}
			RecoveredMethod131();
			if (alerts != null)
			{
				alerts.Dispose();
			}
			previewQueue.Dispose();
		};
		timer.Interval = TimeSpan.FromMilliseconds(250.0);
		timer.Tick += RecoveredMethod162;
		window.StateChanged += delegate
		{
			RecoveredMethod165();
		};
		window.IsVisibleChanged += delegate
		{
			RecoveredMethod165();
		};
		timer.Start();
		RecoveredMethod93("twist ready. Fishing starts stopped.");
		RecoveredMethod93(RecoveredType422.LastStatus);
		if (ledger.Error != "")
		{
			RecoveredMethod93(ledger.Error);
		}
		window.Loaded += async delegate
		{
			await RecoveredMethod94();
		};
	}

	private void RecoveredMethod84(string P_0)
	{
		currentPage = P_0;
		if (P_0 == "Tracker")
		{
			inventoryDirty = true;
			historyCount = -1;
		}
		if (P_0 == "Inventory" || P_0 == "Fruits")
		{
			RecoveredMethod111(P_0 == "Fruits");
		}
		string[] array = new string[8] { "Session", "Tracker", "Inventory", "Settings", "Connections", "Alerts", "World", "ActivityLog" };
		foreach (string text in array)
		{
			RecoveredMethod79<FrameworkElement>(text + "View").Visibility = ((!(text == P_0) && (!(text == "Inventory") || !(P_0 == "Fruits"))) ? Visibility.Collapsed : Visibility.Visible);
		}
		string[] array2 = new string[8] { "Session", "Tracker", "Inventory", "Fruits", "Settings", "Connections", "Alerts", "World" };
		foreach (string text2 in array2)
		{
			RecoveredMethod79<Button>("Nav" + text2).Background = new SolidColorBrush((text2 == P_0 || (text2 == "Inventory" && P_0 == "Fruits") || (text2 == "Settings" && (P_0 == "Connections" || P_0 == "ActivityLog"))) ? Color.FromRgb(35, 34, 42) : Colors.Transparent);
			RecoveredMethod79<Button>("Nav" + text2).Foreground = new SolidColorBrush((text2 == P_0 || (text2 == "Inventory" && P_0 == "Fruits") || (text2 == "Settings" && (P_0 == "Connections" || P_0 == "ActivityLog"))) ? Color.FromRgb(225, 214, 250) : Color.FromRgb(135, 135, 146));
		}
		FrameworkElement frameworkElement = RecoveredMethod79<FrameworkElement>("SettingsHubView");
		int visibility;
		switch (P_0)
		{
		default:
			visibility = 2;
			break;
		case "Settings":
		case "Connections":
		case "ActivityLog":
			visibility = 0;
			break;
		}
		frameworkElement.Visibility = (Visibility)visibility;
		RecoveredMethod85("InventoryFishTab", P_0 == "Inventory");
		RecoveredMethod85("SettingsGeneralTab", P_0 == "Settings");
		RecoveredMethod85("NavActivity", P_0 == "ActivityLog");
		if (catches != null)
		{
			RecoveredMethod98();
			RecoveredMethod161();
		}
	}

	private void RecoveredMethod85(string P_0, bool P_1)
	{
		RecoveredMethod79<Button>(P_0).Background = new SolidColorBrush(P_1 ? Color.FromRgb(35, 34, 42) : Colors.Transparent);
		RecoveredMethod79<Button>(P_0).Foreground = new SolidColorBrush(P_1 ? Color.FromRgb(225, 214, 250) : Color.FromRgb(135, 135, 146));
	}

	private IntPtr RecoveredMethod86(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3, ref bool P_4)
	{
		if (P_1 == 786)
		{
			switch (P_2.ToInt32())
			{
			case 910:
				P_4 = true;
				RecoveredMethod88();
				break;
			case 911:
				P_4 = true;
				if (IsTotalSelected)
				{
					RecoveredMethod87();
				}
				else if (Selected != null && Selected.Session.RecoveredMethod509().Running)
				{
					RecoveredMethod89();
				}
				else
				{
					RecoveredMethod104(true);
				}
				break;
			case 912:
				P_4 = true;
				RecoveredMethod105();
				break;
			}
		}
		return IntPtr.Zero;
	}

	private async void RecoveredMethod87()
	{
		int num = default(int);
		_ = num;
		_ = 0;
		try
		{
			await RecoveredMethod159();
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	private async void RecoveredMethod88()
	{
		int num = default(int);
		_ = num;
		_ = 0;
		try
		{
			await RecoveredMethod106("F9 emergency stop requested by user.");
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	private async void RecoveredMethod89()
	{
		int num = default(int);
		_ = num;
		_ = 0;
		try
		{
			if (Selected != null)
			{
				await Selected.Session.RecoveredMethod513("F8 stop requested by user.");
			}
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	private async void RecoveredMethod90()
	{
		RecoveredMethod148(true);
		settingsTimer.Stop();
		timer.Stop();
		try
		{
			await RecoveredMethod106("twist is closing.");
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
		RecoveredMethod131();
		RecoveredMethod95();
		RecoveredMethod171();
		RecoveredMethod50();
		await activityLog.Completion;
		await ledger.Completion;
		await catches.Completion;
		if (worldHistory != null)
		{
			await worldHistory.Completion;
		}
		if (catalogWriter != null)
		{
			await catalogWriter.Completion;
		}
		closing = true;
		window.Close();
		if (miniWindow != null)
		{
			miniWindow.Close();
		}
	}

	private void RecoveredMethod91(Window P_0)
	{
		P_0.SourceInitialized += delegate
		{
			hwnd = new WindowInteropHelper(P_0).Handle;
			source = HwndSource.FromHwnd(hwnd);
			source.AddHook(RecoveredMethod86);
			if (!RecoveredMethod77(hwnd, 911, 16384u, 119u))
			{
				RecoveredMethod93("F8 is in use by another app. Close the older fishing app.");
			}
			if (!RecoveredMethod77(hwnd, 912, 16384u, 118u))
			{
				RecoveredMethod93("F7 is in use by another app.");
			}
			if (!RecoveredMethod77(hwnd, 910, 16384u, 120u))
			{
				RecoveredMethod93("F9 is in use by another app. The Stop all button is available.");
			}
		};
	}

	public void RecoveredMethod92()
	{
		if (mode == RecoveredType308.Worker)
		{
			RecoveredMethod71();
		}
		else
		{
			window.Show();
		}
	}

	private void RecoveredMethod93(string P_0)
	{
		RecoveredMethod49(P_0, true);
	}

	private async Task RecoveredMethod94()
	{
		if (mode == RecoveredType308.Controller)
		{
			RecoveredMethod126();
			if (!PresentationHidden)
			{
				RecoveredMethod98();
			}
		}
		else
		{
			if (refreshing || closing || stopping)
			{
				return;
			}
			refreshing = true;
			try
			{
				KeyValuePair<int, long>[] found = await Task.Run(delegate
				{
					List<KeyValuePair<int, long>> list = new List<KeyValuePair<int, long>>();
					Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
					foreach (Process process in processesByName)
					{
						using (process)
						{
							try
							{
								if (process.SessionId == RecoveredType309.SessionId)
								{
									list.Add(new KeyValuePair<int, long>(process.Id, process.StartTime.ToUniversalTime().Ticks));
								}
							}
							catch
							{
							}
						}
					}
					return list.ToArray();
				});
				if (!closing && !stopping)
				{
					await RecoveredMethod66(found, RecoveredMethod62, RecoveredMethod63, DateTime.UtcNow);
				}
			}
			catch (Exception ex)
			{
				RecoveredMethod93("Could not refresh clients: " + ex.Message);
			}
			finally
			{
				refreshing = false;
			}
		}
	}

	private void RecoveredMethod95()
	{
		RoundRecord[] array = rows.SelectMany((RecoveredType137 P_0) => P_0.Session.RecoveredMethod510()).ToArray();
		if (ledger.RecoveredMethod724(array))
		{
			historyCount = -1;
		}
		if (catches != null && catches.RecoveredMethod724(array))
		{
			inventoryDirty = true;
		}
	}

	private static string RecoveredMethod96(double P_0)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(Math.Max(0.0, P_0));
		if (!(timeSpan.TotalHours >= 1.0))
		{
			return timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
		}
		return ((int)timeSpan.TotalHours).ToString("00") + ":" + timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
	}

	private static string RecoveredMethod97(RecoveredType174 P_0)
	{
		if (P_0.Reeling)
		{
			return "Reeling";
		}
		if (!P_0.Running)
		{
			return "Idle";
		}
		if (P_0.Status.Contains("waiting for fish"))
		{
			return "Waiting for a bite";
		}
		if (P_0.Status.StartsWith("Watching"))
		{
			return "Observing";
		}
		if (P_0.Status.Contains("Equip"))
		{
			return "Equip your rod";
		}
		return P_0.Status;
	}

	private void RecoveredMethod98()
	{
		RecoveredMethod51();
		RecoveredMethod173();
		RecoveredMethod73();
		RecoveredMethod115();
		RecoveredType137 selected = Selected;
		bool flag = rows.Any((RecoveredType137 P_0) => P_0.State.Running);
		RecoveredMethod82("StateBadge", flag ? "active" : "idle");
		RecoveredMethod79<Ellipse>("StateDot").Fill = (flag ? RecoveredType122.Active : RecoveredType122.Idle);
		if (IsTotalSelected)
		{
			RecoveredMethod157();
			return;
		}
		RecoveredMethod156(false);
		RecoveredMethod79<TextBlock>("RoundRate").ToolTip = null;
		if (selected == null)
		{
			RecoveredMethod82("AccountStatus", (mode == RecoveredType308.Controller) ? "Connect a worker to begin" : "Open Roblox to connect");
			RecoveredMethod79<Button>("Start").IsEnabled = false;
			RecoveredMethod82("Uptime", "00:00");
			RecoveredMethod82("Accuracy", "—");
			RecoveredMethod82("RoundCount", "0");
			RecoveredMethod82("FullCount", "0");
			RecoveredMethod82("LegendaryOwnedCount", "0");
			gauge.Update(0.5, 0.5, 0.25, show: false);
			chart.Update(new List<ChartPoint>(), clock.Elapsed.TotalSeconds);
			RecoveredMethod99("");
			return;
		}
		RecoveredType174 state = selected.State;
		RecoveredMethod79<Button>("Start").IsEnabled = !switching && state.Attached;
		RecoveredMethod79<Button>("Start").Content = ((state.Running && state.AutoFish) ? "Stop fishing" : "Start fishing");
		RecoveredMethod82("AccountStatus", state.Running ? RecoveredMethod97(state) : (state.Attached ? (((state.StopReason != "") ? ("Stopped · " + state.StopReason) : "Connected") + ((selected.Session is RecoveredType325) ? (" · S" + ((RecoveredType325)selected.Session).Peer.SessionId) : "")) : state.Status));
		RecoveredMethod79<TextBlock>("AccountStatus").ToolTip = state.Status;
		RecoveredMethod82("Uptime", RecoveredMethod96(state.ActiveSeconds));
		InventorySnapshot inventorySnapshot = ((selected.Inventory == null) ? null : selected.Inventory.RecoveredMethod515());
		int num = inventorySnapshot?.Items.Where((InventoryEntry P_0) => P_0.Metadata.IsFish).Sum((InventoryEntry P_0) => P_0.Count) ?? 0;
		int num2 = RecoveredMethod113(state.UserId);
		RecoveredMethod82("RoundCount", num2.ToString());
		RecoveredMethod82("FullCount", num.ToString());
		RecoveredMethod82("LegendaryOwnedCount", RecoveredType4.RecoveredMethod0(inventorySnapshot).ToString("N0"));
		RecoveredMethod82("RoundRate", (state.ActiveSeconds >= 30.0) ? (((double)(num2 * 3600) / state.ActiveSeconds).ToString("0.0") + " / hr") : "— / hr");
		RecoveredMethod82("Accuracy", (state.TrackedSeconds > 0.0) ? (state.OnTargetSeconds / state.TrackedSeconds).ToString("P0") : "—");
		RecoveredMethod82("LivePhase", RecoveredMethod97(state));
		RecoveredMethod82("ProgressLabel", state.Reeling ? state.Progress.ToString("P0") : "—");
		RecoveredMethod82("ContactLabel", (!state.Reeling) ? "" : ((Math.Abs(state.Player - state.Goal) <= state.BarHeight / 2.0) ? "on target" : "following"));
		if (currentPage == "Session")
		{
			chart.Update(selected.Points, clock.Elapsed.TotalSeconds);
			gauge.Update(state.Player, state.Goal, state.BarHeight, state.Reeling);
		}
		if (profiles.TryGetValue(RecoveredMethod80(selected), out var value))
		{
			RecoveredMethod82("GoalHint", (value.StopAfterRounds > 0) ? ("run goal · " + value.StopAfterRounds + " full rounds") : ((value.StopAfterMinutes > 0.0) ? ("run limit · " + value.StopAfterMinutes.ToString("0.#") + " min") : ""));
		}
		RecoveredMethod82("FruitStatus", state.FruitsStored + " stored · " + state.FruitsDropped + " duplicates dropped" + ((state.LastFruit == "") ? "" : (" · last: " + state.LastFruit)));
		RecoveredMethod82("BaitStatus", (state.CommonBait < 0) ? "" : (((state.Bait == "") ? "Bait" : state.Bait) + " · Common stock " + state.CommonBait));
		RecoveredMethod99(state.UserId);
	}

	private void RecoveredMethod99(string P_0)
	{
		if (historyCount >= 0 && historyKey == P_0)
		{
			return;
		}
		RecoveredMethod82("TrackerScope", (P_0 == "") ? "All accounts · saved on this device." : ("Saved history for @" + ((Selected == null) ? "account" : Selected.Account)));
		RoundRecord[] array = ledger.RecoveredMethod848(P_0);
		if (historyCount == array.Length && !(historyKey != P_0))
		{
			return;
		}
		historyCount = array.Length;
		historyKey = P_0;
		RecoveredMethod79<ItemsControl>("RecentRounds").ItemsSource = array.Take(3).ToArray();
		if (currentPage == "Tracker")
		{
			RecoveredMethod79<ItemsControl>("HistoryRows").ItemsSource = array.Take(200).ToArray();
		}
		RecoveredMethod79<TextBlock>("NoRounds").Visibility = ((array.Length != 0) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod79<TextBlock>("HistoryEmpty").Visibility = ((array.Length != 0) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod82("HistoryCount", array.Length.ToString());
		RecoveredMethod82("AverageRound", (array.Length > 0) ? (array.Average((RoundRecord roundRecord) => roundRecord.Seconds).ToString("0.0") + "s") : "—");
		int val = 0;
		int num = 0;
		foreach (RoundRecord item in array.Reverse())
		{
			num = (item.Full ? (num + 1) : 0);
			val = Math.Max(val, num);
		}
		RecoveredMethod82("BestStreak", val.ToString());
	}

	private RecoveredType170 RecoveredMethod100()
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		RecoveredType170 recoveredType = new RecoveredType170();
		recoveredType.CastX = double.Parse(RecoveredMethod79<TextBox>("CastX").Text, invariantCulture) / 100.0;
		recoveredType.CastY = double.Parse(RecoveredMethod79<TextBox>("CastY").Text, invariantCulture) / 100.0;
		recoveredType.CastHoldMs = int.Parse(RecoveredMethod79<TextBox>("CastHold").Text);
		recoveredType.BiteTimeoutSeconds = int.Parse(RecoveredMethod79<TextBox>("BiteTimeout").Text);
		recoveredType.RecastDelayMs = int.Parse(RecoveredMethod79<TextBox>("RecastWait").Text);
		recoveredType.EquipSlot = int.Parse(RecoveredMethod79<TextBox>("EquipSlot").Text);
		recoveredType.StopAfterRounds = int.Parse(RecoveredMethod79<TextBox>("RoundGoal").Text);
		recoveredType.StopAfterMinutes = double.Parse(RecoveredMethod79<TextBox>("TimeLimit").Text, invariantCulture);
		recoveredType.BaitMode = ((RecoveredMethod79<ComboBox>("BaitMode").SelectedIndex == 1) ? "best" : "common");
		recoveredType.AutoRestockCommon = RecoveredMethod79<CheckBox>("AutoRestock").IsChecked == true;
		recoveredType.RestockBelow = int.Parse(RecoveredMethod79<TextBox>("RestockBelow").Text);
		recoveredType.RestockBuy = int.Parse(RecoveredMethod79<TextBox>("RestockBuy").Text);
		recoveredType.AutoStoreFruits = RecoveredMethod79<CheckBox>("AutoStoreFruits").IsChecked == true;
		recoveredType.DropDuplicateFruits = RecoveredMethod79<CheckBox>("DropDuplicateFruits").IsChecked == true;
		RecoveredType170 recoveredType2 = recoveredType;
		recoveredType2.RecoveredMethod50();
		return recoveredType2;
	}

	private void RecoveredMethod101()
	{
		if (profileDirty && !loadingSettings)
		{
			RecoveredMethod145(false);
		}
		profileDirty = false;
		loadingSettings = true;
		try
		{
			RecoveredMethod102();
		}
		finally
		{
			settingsRow = Selected;
			loadingSettings = false;
		}
	}

	private void RecoveredMethod102()
	{
		RecoveredType137 selected = Selected;
		RecoveredMethod156(IsTotalSelected);
		if (IsTotalSelected)
		{
			RecoveredMethod82("ProfileTitle", "Total uses each account’s saved settings. Select an account to edit.");
		}
		else
		{
			if (selected == null)
			{
				return;
			}
			try
			{
				RecoveredType325 recoveredType = selected.Session as RecoveredType325;
				RecoveredMethod79<TextBox>("CastX").IsReadOnly = recoveredType != null;
				RecoveredMethod79<TextBox>("CastY").IsReadOnly = recoveredType != null;
				TextBox textBox = RecoveredMethod79<TextBox>("CastX");
				object toolTip = (RecoveredMethod79<TextBox>("CastY").ToolTip = ((recoveredType == null) ? null : "This position is saved inside the worker. Use Select cursor point there."));
				textBox.ToolTip = toolTip;
				RecoveredType170 value;
				if (recoveredType != null)
				{
					value = RecoveredMethod151(selected, recoveredType.Profile);
					profiles[RecoveredMethod80(selected)] = value;
				}
				else if (!profiles.TryGetValue(RecoveredMethod80(selected), out value))
				{
					value = RecoveredType170.RecoveredMethod569(RecoveredMethod81(selected));
					profiles[RecoveredMethod80(selected)] = value;
				}
				RecoveredMethod82("ProfileTitle", "Fishing settings for @" + selected.Account);
				RecoveredMethod79<ComboBox>("BaitMode").SelectedIndex = ((value.BaitMode == "best") ? 1 : 0);
				RecoveredMethod79<CheckBox>("AutoRestock").IsChecked = value.AutoRestockCommon;
				RecoveredMethod79<TextBox>("RestockBelow").Text = value.RestockBelow.ToString();
				RecoveredMethod79<TextBox>("RestockBuy").Text = value.RestockBuy.ToString();
				RecoveredMethod79<CheckBox>("AutoStoreFruits").IsChecked = value.AutoStoreFruits;
				RecoveredMethod79<CheckBox>("DropDuplicateFruits").IsChecked = value.DropDuplicateFruits;
				RecoveredMethod79<TextBox>("CastX").Text = (value.CastX * 100.0).ToString(CultureInfo.InvariantCulture);
				RecoveredMethod79<TextBox>("CastY").Text = (value.CastY * 100.0).ToString(CultureInfo.InvariantCulture);
				RecoveredMethod79<TextBox>("CastHold").Text = value.CastHoldMs.ToString();
				RecoveredMethod79<TextBox>("BiteTimeout").Text = value.BiteTimeoutSeconds.ToString();
				RecoveredMethod79<TextBox>("RecastWait").Text = value.RecastDelayMs.ToString();
				RecoveredMethod79<TextBox>("EquipSlot").Text = value.EquipSlot.ToString();
				RecoveredMethod79<TextBox>("RoundGoal").Text = value.StopAfterRounds.ToString();
				RecoveredMethod79<TextBox>("TimeLimit").Text = value.StopAfterMinutes.ToString(CultureInfo.InvariantCulture);
				RecoveredMethod82("CastPointLabel", (value.CastX * 100.0).ToString("0.#") + "% / " + (value.CastY * 100.0).ToString("0.#") + "%");
				RecoveredMethod82("SavedNotice", "");
			}
			catch (Exception ex)
			{
				RecoveredMethod93("Profile: " + ex.Message);
			}
		}
	}

	private bool RecoveredMethod103(bool P_0)
	{
		if (Selected == null)
		{
			RecoveredMethod93("Select an account first.");
			return false;
		}
		settingsRow = Selected;
		return RecoveredMethod145(P_0);
	}

	private async void RecoveredMethod104(bool P_0)
	{
		if (IsTotalSelected)
		{
			if (P_0)
			{
				await RecoveredMethod158();
			}
			else
			{
				RecoveredMethod93("Select an account to observe a reel.");
			}
		}
		else if (pointPicker != null)
		{
			RecoveredMethod93("Finish the right-click point selection, or cancel it first.");
		}
		else
		{
			if (stopping || closing || switching)
			{
				return;
			}
			RecoveredType137 row = Selected;
			if (row == null)
			{
				RecoveredMethod93("Select an account first.");
			}
			else
			{
				if (!RecoveredMethod103(false))
				{
					return;
				}
				RecoveredType170 p = profiles[RecoveredMethod80(row)];
				switching = true;
				try
				{
					if (mode == RecoveredType308.Worker && (workerLink == null || !workerLink.Connected))
					{
						throw new Exception("Connect this worker to its controller first.");
					}
					if (P_0)
					{
						RecoveredType137[] active = rows.Where((RecoveredType137 recoveredType2) => recoveredType2.Session.InputScope == row.Session.InputScope && recoveredType2.Session.RecoveredMethod509().Running && recoveredType2.Session.RecoveredMethod509().AutoFish).ToArray();
						RecoveredType137[] array = active;
						foreach (RecoveredType137 recoveredType in array)
						{
							recoveredType.Session.RecoveredMethod48("Another client started in this input session.");
						}
						await Task.WhenAll(active.Select((RecoveredType137 recoveredType2) => recoveredType2.Session.RecoveredMethod513("Another client started in this input session.")));
					}
					await row.Session.RecoveredMethod513();
					if (P_0 && !(row.Session is RecoveredType325) && !RecoveredType249.RecoveredMethod694(row.Session.Pid))
					{
						throw new Exception("Bring Roblox forward, then press F8.");
					}
					await row.Session.RecoveredMethod512(p, P_0);
					RecoveredMethod93((P_0 ? "Started foreground fishing for @" : "Observing @") + row.Account);
				}
				catch (Exception ex)
				{
					RecoveredMethod93("Could not start fishing: " + ex.Message);
				}
				finally
				{
					switching = false;
				}
			}
		}
	}

	private void RecoveredMethod105()
	{
		RecoveredMethod74();
		RecoveredType137 selected = Selected;
		if (selected != null && selected.Session is RecoveredType325)
		{
			RecoveredMethod93("Set the cast point inside that worker’s RDP session with F7, then reselect the account here.");
			return;
		}
		if (selected == null)
		{
			RecoveredMethod93("Select an account first.");
			return;
		}
		if (!RecoveredType249.RecoveredMethod695(selected.Session.Pid, out var num, out var num2))
		{
			RecoveredMethod93("Point inside Roblox, then press F7.");
			return;
		}
		RecoveredMethod79<TextBox>("CastX").Text = (num * 100.0).ToString("0.00", CultureInfo.InvariantCulture);
		RecoveredMethod79<TextBox>("CastY").Text = (num2 * 100.0).ToString("0.00", CultureInfo.InvariantCulture);
		RecoveredMethod103(false);
		RecoveredMethod93("Cast point saved.");
	}

	private async Task RecoveredMethod106(string P_0 = "Stop all requested by user.")
	{
		RecoveredMethod74();
		RecoveredType137[] all = rows.ToArray();
		RecoveredType137[] array = all;
		foreach (RecoveredType137 recoveredType in array)
		{
			recoveredType.Session.RecoveredMethod48(P_0);
		}
		try
		{
			await Task.WhenAll(all.Select((RecoveredType137 recoveredType2) => recoveredType2.Session.RecoveredMethod513(P_0)));
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
		RecoveredMethod95();
		RecoveredMethod93(P_0);
	}

	private void RecoveredMethod107()
	{
		try
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "CSV file|*.csv";
			saveFileDialog.FileName = "twist-rounds.csv";
			SaveFileDialog saveFileDialog2 = saveFileDialog;
			if (saveFileDialog2.ShowDialog(window) == true)
			{
				ledger.RecoveredMethod82(saveFileDialog2.FileName, (Selected == null) ? "" : Selected.State.UserId);
				RecoveredMethod93("History exported.");
			}
		}
		catch (Exception ex)
		{
			RecoveredMethod93("Export failed: " + ex.Message);
		}
	}

	private void RecoveredMethod108(ItemCard P_0, ItemMetadata P_1, bool P_2)
	{
		previewQueue.RecoveredMethod747(P_1, delegate(BitmapSource value, string error)
		{
			if (!window.Dispatcher.HasShutdownStarted)
			{
				window.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
				{
					P_0.SetIcon(value, error);
				});
			}
		}, P_2);
	}

	private void RecoveredMethod109(string[] P_0)
	{
		if (!(RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource is ItemCard[] array))
		{
			return;
		}
		foreach (string key in P_0)
		{
			previewQueue.RecoveredMethod48(key);
			Func<ItemCard, bool> predicate = (ItemCard itemCard) => itemCard.Key == key && itemCard.Icon == null;
			foreach (ItemCard item in array.Where(predicate))
			{
				if (displayedPreviewMetadata.TryGetValue(key, out var value))
				{
					RecoveredMethod108(item, value, true);
				}
			}
		}
	}

	private static string[] RecoveredMethod110(bool P_0)
	{
		return new string[1] { "All rarities" }.Concat(RarityStyle.Names.Where((string text) => text != "Collectable" && text != "Unknown" && (P_0 || text != "Mythical")).OrderByDescending(RarityStyle.SortRank)).ToArray();
	}

	private void RecoveredMethod111(bool P_0)
	{
		if (showFruitInventory != P_0)
		{
			showFruitInventory = P_0;
			RecoveredMethod79<TextBox>("InventorySearch").Text = "";
			RecoveredMethod79<ComboBox>("InventoryRarity").ItemsSource = RecoveredMethod110(P_0);
			RecoveredMethod79<ComboBox>("InventoryRarity").SelectedIndex = 0;
			cardsSignature = "";
		}
		RecoveredMethod82("InventoryTitle", "Inventory");
		RecoveredMethod82("InventoryPlaceholder", P_0 ? "Search fruits…" : "Search fish…");
		inventoryDirty = true;
		RecoveredMethod115();
	}

	private bool RecoveredMethod1(InventoryEntry P_0)
	{
		if (P_0 != null && P_0.Metadata != null)
		{
			if (!showFruitInventory)
			{
				return P_0.Metadata.IsFish;
			}
			return P_0.Metadata.IsFruit;
		}
		return false;
	}

	private void RecoveredMethod112()
	{
		catalogWriter = new RecoveredType121(System.IO.Path.Combine(folder, "data", "item-catalog.json"), delegate(string P_0)
		{
			if (!closing)
			{
				RecoveredMethod93("Item metadata could not be saved: " + P_0);
			}
		});
		catches = new RecoveredType266(System.IO.Path.Combine(folder, "data"));
		previewQueue = new RecoveredType276(System.IO.Path.Combine(folder, "assets", "icons"));
		try
		{
			string path = System.IO.Path.Combine(folder, "data", "item-catalog.json");
			if (File.Exists(path))
			{
				JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
				javaScriptSerializer.MaxJsonLength = 8000000;
				ItemMetadata[] array = javaScriptSerializer.Deserialize<ItemMetadata[]>(File.ReadAllText(path));
				if (array != null)
				{
					ItemMetadata[] array2 = array;
					foreach (ItemMetadata itemMetadata in array2)
					{
						RecoveredType219.RecoveredMethod619(itemMetadata);
						catalog[itemMetadata.Name] = itemMetadata;
					}
				}
			}
		}
		catch (Exception ex)
		{
			RecoveredMethod93("Item catalog: " + ex.Message);
		}
		RecoveredMethod79<ComboBox>("InventoryCategory").ItemsSource = new string[1] { "Fish" };
		RecoveredMethod79<ComboBox>("InventoryCategory").SelectedIndex = 0;
		RecoveredMethod79<ComboBox>("InventoryRarity").ItemsSource = RecoveredMethod110(false);
		RecoveredMethod79<ComboBox>("InventoryRarity").SelectedIndex = 0;
		RecoveredMethod79<TextBox>("InventorySearch").TextChanged += delegate
		{
			inventoryDirty = true;
			itemLimit = 200;
			RecoveredMethod115();
		};
		string[] array3 = new string[2] { "InventoryCategory", "InventoryRarity" };
		foreach (string text in array3)
		{
			RecoveredMethod79<ComboBox>(text).SelectionChanged += delegate
			{
				inventoryDirty = true;
				itemLimit = 200;
				RecoveredMethod115();
			};
		}
		RecoveredMethod83("MoreItems", delegate
		{
			itemLimit += 200;
			inventoryDirty = true;
			RecoveredMethod115();
		});
	}

	private int RecoveredMethod113(string P_0)
	{
		if (catches == null)
		{
			return 0;
		}
		if (!object.ReferenceEquals(launchLedger, catches) || launchRevision != catches.Revision)
		{
			launchCounts.Clear();
			string since = openedUtc.ToString("o");
			foreach (IGrouping<string, CatchRecord> item in from catchRecord in catches.RecoveredMethod727("")
				where string.CompareOrdinal(catchRecord.AtUtc, since) >= 0
				group catchRecord by catchRecord.UserId ?? "")
			{
				launchCounts[item.Key] = item.Sum((CatchRecord catchRecord) => catchRecord.Count);
			}
			launchCounts[""] = launchCounts.Values.Sum();
			launchRevision = catches.Revision;
			launchLedger = catches;
		}
		if (!launchCounts.TryGetValue(P_0 ?? "", out var value))
		{
			return 0;
		}
		return value;
	}

	private void RecoveredMethod114()
	{
		bool flag = false;
		foreach (RecoveredType137 row in rows)
		{
			if (row.Inventory == null)
			{
				continue;
			}
			InventorySnapshot inventorySnapshot = row.Inventory.RecoveredMethod515();
			if (inventorySnapshot.Updated == row.InventoryUpdated && inventorySnapshot.Valid == row.InventoryValid)
			{
				if (!inventorySnapshot.Valid && row == Selected)
				{
					RecoveredMethod82("InventoryStatus", inventorySnapshot.Status);
				}
				continue;
			}
			row.InventoryUpdated = inventorySnapshot.Updated;
			row.InventoryValid = inventorySnapshot.Valid;
			inventoryDirty = true;
			if (!inventorySnapshot.Valid)
			{
				continue;
			}
			catches.RecoveredMethod725(inventorySnapshot);
			if (catches.Error != "" && catches.Error != catchError)
			{
				catchError = catches.Error;
				RecoveredMethod93(catchError);
			}
			InventoryEntry[] items = inventorySnapshot.Items;
			foreach (InventoryEntry inventoryEntry in items)
			{
				ItemMetadata metadata = inventoryEntry.Metadata;
				if (metadata != null)
				{
					string text = metadata.Rarity + "|" + metadata.Category + "|" + metadata.PreviewFingerprint.ToString("X");
					if (!catalogStamps.TryGetValue(inventoryEntry.Name, out var value) || value != text)
					{
						catalogStamps[inventoryEntry.Name] = text;
						catalog[inventoryEntry.Name] = metadata;
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			catalogWriter.RecoveredMethod489(catalog.Values.OrderBy((ItemMetadata P_0) => P_0.Name).ToArray());
		}
	}

	private void RecoveredMethod115()
	{
		if (catches == null || !inventoryDirty || (currentPage != "Inventory" && currentPage != "Fruits" && currentPage != "Tracker"))
		{
			return;
		}
		inventoryDirty = false;
		RecoveredMethod79<TextBlock>("InventoryLegendaryCount").Visibility = (showFruitInventory ? Visibility.Collapsed : Visibility.Visible);
		RecoveredType137 selected = Selected;
		string text = ((selected == null) ? "" : selected.State.UserId);
		if (currentPage == "Tracker")
		{
			CatchRecord[] history = catches.RecoveredMethod727(text);
			RecoveredMethod82("TotalCaught", history.Sum((CatchRecord P_0) => P_0.Count).ToString("N0"));
			RecoveredMethod82("LaunchCaught", RecoveredMethod113(text).ToString("N0"));
			RecoveredMethod82("SpeciesCaught", (from P_0 in history
				where P_0.Name != "Unidentified fish"
				select P_0.Name).Distinct().Count().ToString());
			string text2 = text + "|" + string.Join("|", history.Select((CatchRecord P_0) => P_0.Id + ":" + P_0.Count + ":" + P_0.Rarity + ":" + P_0.Name));
			if (!(text2 != catchSignature))
			{
				return;
			}
			catchSignature = text2;
			RecoveredMethod79<ItemsControl>("RarityTotals").ItemsSource = RarityStyle.Names.Select((string P_0) => new RarityTotal
			{
				Name = P_0,
				Count = history.Where((CatchRecord catchRecord) => catchRecord.Rarity == P_0).Sum((CatchRecord catchRecord) => catchRecord.Count)
			}).ToArray();
			RecoveredMethod79<ItemsControl>("CatchRows").ItemsSource = history.Take(25).ToArray();
			RecoveredMethod79<TextBlock>("CatchesEmpty").Visibility = ((history.Length != 0) ? Visibility.Collapsed : Visibility.Visible);
			return;
		}
		if (!IsTotalSelected && (selected == null || selected.Inventory == null))
		{
			RecoveredMethod82("InventoryStatus", "Open Roblox to connect");
			RecoveredMethod82("InventoryCount", "0 items");
			RecoveredMethod82("InventoryFishCount", showFruitInventory ? "0 fruits stored" : "0 fish owned");
			RecoveredMethod82("InventoryLegendaryCount", "0 Legendary fish");
			cardsSignature = "";
			RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource = null;
			RecoveredMethod82("InventoryEmpty", showFruitInventory ? "Your stored fruits will appear here." : "Your fish will appear here.");
			RecoveredMethod79<TextBlock>("InventoryEmpty").Visibility = Visibility.Visible;
			return;
		}
		InventorySnapshot inventorySnapshot = (IsTotalSelected ? RecoveredType5.RecoveredMethod4(RecoveredMethod155()).Inventory : selected.Inventory.RecoveredMethod515());
		RecoveredMethod82("InventoryStatus", IsTotalSelected ? inventorySnapshot.Status : (inventorySnapshot.Valid ? ("Live · @" + inventorySnapshot.Account + " · updated " + inventorySnapshot.Updated.ToLocalTime().ToString("HH:mm:ss")) : inventorySnapshot.Status));
		RecoveredMethod82("InventoryLegendaryCount", RecoveredType4.RecoveredMethod0(inventorySnapshot).ToString("N0") + " Legendary fish");
		int num = inventorySnapshot.Items.Count(RecoveredMethod1);
		RecoveredMethod82("InventoryCount", num + (showFruitInventory ? " fruit" : " fish") + ((num == 1) ? " type" : " types"));
		RecoveredMethod82("InventoryFishCount", inventorySnapshot.Items.Where(RecoveredMethod1).Sum((Func<InventoryEntry, long>)((InventoryEntry P_0) => P_0.Count)).ToString("N0") + (showFruitInventory ? " fruits stored" : " fish owned"));
		string search = RecoveredMethod79<TextBox>("InventorySearch").Text.Trim();
		_ = RecoveredMethod79<ComboBox>("InventoryCategory").SelectedItem;
		string rarity = RecoveredMethod79<ComboBox>("InventoryRarity").SelectedItem as string;
		InventoryEntry[] array = (from P_0 in inventorySnapshot.Items
			where RecoveredMethod1(P_0) && P_0.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 && (rarity == null || rarity == "All rarities" || P_0.Metadata.Rarity == rarity)
			orderby RarityStyle.SortRank(P_0.Metadata.Rarity) descending
			select P_0).ThenBy((InventoryEntry P_0) => P_0.Name, StringComparer.OrdinalIgnoreCase).ToArray();
		InventoryEntry[] array2 = array.Take(itemLimit).ToArray();
		string text3 = (showFruitInventory ? "fruits:" : "fish:") + (IsTotalSelected ? "total" : text) + "|" + string.Join("|", array2.Select((InventoryEntry P_0) => P_0.Name + ":" + P_0.Count + ":" + P_0.Metadata.Rarity + ":" + P_0.Metadata.IconKey));
		if (text3 != cardsSignature)
		{
			cardsSignature = text3;
			ItemCard[] first = (RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource as ItemCard[]) ?? new ItemCard[0];
			Dictionary<string, ItemCard> reuse = first.ToDictionary((ItemCard P_0) => P_0.Key, (ItemCard P_0) => P_0);
			ItemCard[] array3 = array2.Select(delegate(InventoryEntry P_0)
			{
				if (!reuse.TryGetValue(P_0.Metadata.IconKey, out var value))
				{
					value = new ItemCard
					{
						Name = P_0.Name,
						Count = P_0.Count,
						Rarity = P_0.Metadata.Rarity,
						Category = P_0.Metadata.Category,
						Key = P_0.Metadata.IconKey
					};
				}
				value.SetCount(P_0.Count);
				return value;
			}).ToArray();
			if (!first.SequenceEqual(array3))
			{
				RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource = array3;
			}
			displayedPreviewMetadata.Clear();
			for (int num2 = 0; num2 < array3.Length; num2++)
			{
				ItemCard itemCard = array3[num2];
				displayedPreviewMetadata[itemCard.Key] = array2[num2].Metadata;
				if (itemCard.Icon == null)
				{
					RecoveredMethod108(itemCard, array2[num2].Metadata, IsTotalSelected || selected.Session is RecoveredType325);
				}
			}
		}
		RecoveredMethod82("InventoryEmpty", inventorySnapshot.Items.Any(RecoveredMethod1) ? (showFruitInventory ? "No fruits match your filters." : "No fish match your filters.") : ((!inventorySnapshot.Valid) ? (showFruitInventory ? "Waiting for fruit inventory…" : "Waiting for fish inventory…") : (showFruitInventory ? "No fruits stored yet." : "No fish in this inventory yet.")));
		RecoveredMethod79<TextBlock>("InventoryEmpty").Visibility = ((array2.Length != 0) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod82("InventoryHint", array.Length + " matches · " + array2.Length + " shown");
		RecoveredMethod79<Button>("MoreItems").Visibility = ((array.Length <= array2.Length) ? Visibility.Collapsed : Visibility.Visible);
	}

	private void RecoveredMethod116()
	{
		try
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "CSV file|*.csv";
			saveFileDialog.FileName = "twist-catches.csv";
			SaveFileDialog saveFileDialog2 = saveFileDialog;
			if (saveFileDialog2.ShowDialog(window) == true)
			{
				catches.RecoveredMethod82(saveFileDialog2.FileName, (Selected == null) ? "" : Selected.State.UserId);
				RecoveredMethod93("Catches exported.");
			}
		}
		catch (Exception ex)
		{
			RecoveredMethod93("Export failed: " + ex.Message);
		}
	}

	private RecoveredType82[] RecoveredMethod117()
	{
		int revision = activityLog.Revision;
		if (publishedActivityRevision != revision)
		{
			publishedActivity = RecoveredMethod117();
			publishedActivityRevision = revision;
		}
		return publishedActivity;
	}

	private void RecoveredMethod118()
	{
		Interlocked.Exchange(ref workerSessions, (from P_0 in rows
			where !(P_0.Session is RecoveredType325)
			select P_0.Session).ToArray());
	}

	private void RecoveredMethod119(string P_0 = "Controller connection ended.")
	{
		RecoveredType131[] array = Interlocked.CompareExchange(ref workerSessions, null, null);
		foreach (RecoveredType131 recoveredType in array)
		{
			try
			{
				recoveredType.RecoveredMethod48(P_0);
			}
			catch
			{
			}
		}
	}

	private void RecoveredMethod120()
	{
		RecoveredMethod82("NetworkRole", (mode == RecoveredType308.Controller) ? "Controller" : ((mode == RecoveredType308.Worker) ? "Session worker" : "Local fishing"));
		RecoveredMethod82("NetworkHelp", (mode == RecoveredType308.Controller) ? "Workers in other Windows sessions connect automatically. Manual pairing is available when needed." : ((mode == RecoveredType308.Worker) ? "Paste the pairing code from your main desktop. Fishing stays inside this Windows session." : "Standalone mode. Start the controller and a session worker to use RDP control."));
		RecoveredMethod82("ThisSession", "Windows user " + Environment.UserName + " · session " + RecoveredType309.SessionId);
		RecoveredMethod79<FrameworkElement>("ControllerPanel").Visibility = ((mode != RecoveredType308.Controller) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod79<FrameworkElement>("WorkerPanel").Visibility = ((mode != RecoveredType308.Worker) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod79<TextBlock>("WorkerSetupHelp").Text = "After connecting: equip your rod, point at water, and press F7 here. Leave Roblox foreground in this session. Use the controller to start fishing.";
		RecoveredMethod83("CopyPairing", delegate
		{
			try
			{
				Clipboard.SetText(RecoveredMethod79<TextBox>("PairingCode").Text);
				RecoveredMethod93("Pairing code copied. Paste it into the worker.");
			}
			catch (Exception ex)
			{
				RecoveredMethod93(ex.Message);
			}
		});
		RecoveredMethod83("ConnectWorker", RecoveredMethod122);
		RecoveredMethod83("DisconnectWorker", delegate
		{
			RecoveredMethod119("Worker disconnected by user.");
			if (workerLink != null)
			{
				workerLink.Dispose();
			}
			workerLink = null;
			RecoveredMethod119();
			RecoveredMethod82("NetworkStatus", "Disconnected. Fishing stopped.");
		});
		RecoveredMethod83("RestartHub", RecoveredMethod121);
		RecoveredMethod83("ScanWorkers", delegate
		{
			discoveryAt = DateTime.MinValue;
			RecoveredMethod129();
		});
		RecoveredMethod79<CheckBox>("AutoWorkers").IsChecked = RecoveredType352.RecoveredMethod846(folder).AutoWorkers;
		if (mode == RecoveredType308.Controller)
		{
			pairing = RecoveredType321.RecoveredMethod781(System.IO.Path.Combine(folder, "controller-pairing.txt"), delegate
			{
				RecoveredMethod93("Recovered a damaged controller pairing file. Workers can reconnect through automatic discovery.");
			});
			RecoveredType352 recoveredType = RecoveredType352.RecoveredMethod846(folder);
			if (recoveredType.Port != 0)
			{
				pairing.Port = recoveredType.Port;
			}
			RecoveredMethod79<TextBox>("ControllerPort").Text = pairing.Port.ToString();
			RecoveredMethod121();
		}
		if (mode != RecoveredType308.Worker)
		{
			return;
		}
		string path = System.IO.Path.Combine(folder, "worker-id.txt");
		workerId = (File.Exists(path) ? File.ReadAllText(path).Trim() : Guid.NewGuid().ToString("N"));
		if (!Guid.TryParseExact(workerId, "N", out var _))
		{
			workerId = Guid.NewGuid().ToString("N");
		}
		File.WriteAllText(path, workerId);
		string path2 = System.IO.Path.Combine(folder, "worker-pairing.txt");
		if (File.Exists(path2))
		{
			RecoveredMethod79<TextBox>("WorkerPairing").Text = File.ReadAllText(path2);
			RecoveredMethod122();
		}
		discovery = new RecoveredType95(workerId, () => workerLink != null && workerLink.Connected, () => activePairCode, delegate(string P_0)
		{
			if (!window.Dispatcher.HasShutdownStarted)
			{
				window.Dispatcher.BeginInvoke((Action)delegate
				{
					if (workerLink == null || !workerLink.Connected || !(activePairCode == P_0))
					{
						RecoveredMethod79<TextBox>("WorkerPairing").Text = P_0;
						RecoveredMethod122();
						RecoveredMethod93("Controller discovered through Windows authentication.");
					}
				});
			}
		});
	}

	private void RecoveredMethod121()
	{
		try
		{
			if (!int.TryParse(RecoveredMethod79<TextBox>("ControllerPort").Text, out var result) || result < 1024 || result > 65535)
			{
				throw new Exception("Use a port from 1024 to 65535.");
			}
			if (hub != null)
			{
				hub.Dispose();
				hub = null;
			}
			pairing.Port = result;
			RecoveredType321.RecoveredMethod782(System.IO.Path.Combine(folder, "controller-pairing.txt"), pairing);
			RecoveredMethod79<TextBox>("PairingCode").Text = pairing.Code;
			hub = new RecoveredType332(pairing, System.IO.Path.Combine(folder, "assets", "icons"), delegate
			{
			});
			RecoveredMethod82("NetworkStatus", "Listening on this computer · port " + result);
			RecoveredMethod93("Controller ready. Waiting for session workers.");
		}
		catch (Exception ex)
		{
			RecoveredMethod82("NetworkStatus", "Could not start controller: " + ex.Message);
			RecoveredMethod93("Controller: " + ex.Message);
		}
	}

	private void RecoveredMethod122()
	{
		try
		{
			RecoveredType321 recoveredType = RecoveredType321.RecoveredMethod780(RecoveredMethod79<TextBox>("WorkerPairing").Text);
			activePairCode = recoveredType.Code;
			if (workerLink != null)
			{
				workerLink.Dispose();
			}
			File.WriteAllText(System.IO.Path.Combine(folder, "worker-pairing.txt"), recoveredType.Code);
			workerLink = new RecoveredType392(recoveredType, workerId, delegate
			{
				if (window.Dispatcher.HasShutdownStarted)
				{
					throw new Exception("Worker is closing.");
				}
				return window.Dispatcher.Invoke((Func<RecoveredType311>)RecoveredMethod123);
			}, delegate(RecoveredType318 P_0)
			{
				if (window.Dispatcher.HasShutdownStarted)
				{
					throw new Exception("Worker is closing.");
				}
				return window.Dispatcher.Invoke(() => RecoveredMethod125(P_0));
			}, delegate
			{
				RecoveredMethod119();
			}, previewQueue, 0, null, RecoveredMethod119);
			RecoveredMethod82("NetworkStatus", "Connecting to controller…");
		}
		catch (Exception ex)
		{
			RecoveredMethod82("NetworkStatus", ex.Message);
			RecoveredMethod93(ex.Message);
		}
	}

	private RecoveredType311 RecoveredMethod123()
	{
		RecoveredType311 recoveredType = new RecoveredType311();
		recoveredType.Activity = activityLog.RecoveredMethod368().Take(128).Reverse()
			.ToArray();
		RecoveredType311 recoveredType2 = recoveredType;
		recoveredType2.Accounts = rows.Where((RecoveredType137 P_0) => !(P_0.Session is RecoveredType325)).Select(delegate(RecoveredType137 P_0)
		{
			RecoveredType170 value;
			try
			{
				if (!profiles.TryGetValue(RecoveredMethod80(P_0), out value))
				{
					value = RecoveredType170.RecoveredMethod569(RecoveredMethod81(P_0));
					profiles[RecoveredMethod80(P_0)] = value;
				}
			}
			catch
			{
				value = new RecoveredType170();
			}
			return new RecoveredType310
			{
				Key = RecoveredMethod124(P_0.Session),
				State = P_0.Session.RecoveredMethod509(),
				Profile = value,
				Rounds = P_0.Session.RecoveredMethod510()
			};
		}).ToArray();
		foreach (RecoveredType137 item in rows.Where((RecoveredType137 P_0) => P_0.Inventory != null))
		{
			recoveredType2.RecoveredMethod779(RecoveredMethod124(item.Session), item.Inventory.RecoveredMethod515());
		}
		return recoveredType2;
	}

	private static string RecoveredMethod124(RecoveredType131 P_0)
	{
		return P_0.Pid + "-" + P_0.Created;
	}

	private async Task<string> RecoveredMethod125(RecoveredType318 P_0)
	{
		RecoveredType137 row = rows.FirstOrDefault((RecoveredType137 recoveredType) => RecoveredMethod124(recoveredType.Session) == P_0.Key && !(recoveredType.Session is RecoveredType325));
		if (row == null)
		{
			throw new Exception("This Roblox client closed or changed identity.");
		}
		if (P_0.Action == "stop")
		{
			RecoveredMethod74();
			await row.Session.RecoveredMethod513(string.IsNullOrWhiteSpace(P_0.Reason) ? "Stopped from controller." : RecoveredType84.RecoveredMethod364(P_0.Reason, 500));
			return "Stopped";
		}
		if (P_0.Action == "attach")
		{
			await row.Session.RecoveredMethod511();
			return "Attached";
		}
		if (P_0.Action == "diagnose")
		{
			return await row.Session.RecoveredMethod514();
		}
		if (P_0.Action == "profile")
		{
			P_0.Profile = RecoveredType129.RecoveredMethod507(P_0.Profile, RecoveredType170.RecoveredMethod569(RecoveredMethod81(row)));
			RecoveredType322.RecoveredMethod128(P_0.Profile);
			P_0.Profile.RecoveredMethod414(RecoveredMethod81(row));
			profiles[RecoveredMethod80(row)] = P_0.Profile;
			if (Selected == row)
			{
				RecoveredMethod101();
			}
			return "Settings saved";
		}
		if (P_0.Action != "start")
		{
			throw new Exception("Unsupported worker command.");
		}
		if (pointPicker != null)
		{
			throw new Exception("Finish the right-click cursor selection, or cancel it before starting.");
		}
		P_0.Profile = RecoveredType129.RecoveredMethod507(P_0.Profile, RecoveredType170.RecoveredMethod569(RecoveredMethod81(row)));
		RecoveredType322.RecoveredMethod128(P_0.Profile);
		if (workerLink == null || !workerLink.Connected)
		{
			throw new Exception("Controller disconnected.");
		}
		string desktop = RecoveredType322.RecoveredMethod357();
		if (desktop != "Ready")
		{
			throw new Exception(desktop);
		}
		foreach (RecoveredType137 other in rows.Where((RecoveredType137 recoveredType) => recoveredType.Session.InputScope == row.Session.InputScope))
		{
			other.Session.RecoveredMethod48("Another client started in this input session.");
			await other.Session.RecoveredMethod513("Another client started in this input session.");
		}
		P_0.Profile.RecoveredMethod414(RecoveredMethod81(row));
		profiles[RecoveredMethod80(row)] = P_0.Profile;
		if (P_0.AutoFish && !RecoveredType249.RecoveredMethod694(row.Session.Pid))
		{
			throw new Exception("Bring Roblox to the foreground inside this RDP session, then start again.");
		}
		await row.Session.RecoveredMethod512(P_0.Profile, P_0.AutoFish);
		RecoveredMethod93("Controller started @" + row.Account);
		return "Started";
	}

	private void RecoveredMethod126()
	{
		if (hub == null)
		{
			return;
		}
		RecoveredType327[] array = hub.RecoveredMethod803();
		foreach (RecoveredType327 recoveredType in array)
		{
			if (activityLog != null)
			{
				activityLog.RecoveredMethod369(recoveredType.RecoveredMethod368());
			}
		}
		RecoveredType325[] array2 = hub.RecoveredMethod804();
		foreach (RecoveredType325 recoveredType2 in array2)
		{
			RecoveredMethod64(recoveredType2, recoveredType2.Inventory);
		}
		RecoveredMethod127((from P_0 in hub.RecoveredMethod803()
			where P_0.Connected
			select P_0).SelectMany((RecoveredType327 P_0) => P_0.RecoveredMethod795()).ToArray());
	}

	private void RecoveredMethod127(RecoveredType325[] P_0)
	{
		RecoveredType137[] array = rows.Where((RecoveredType137 recoveredType5) => recoveredType5.Session is RecoveredType325).ToArray();
		foreach (RecoveredType137 recoveredType in array)
		{
			RecoveredType325 old = (RecoveredType325)recoveredType.Session;
			if (!P_0.Any((RecoveredType325 recoveredType5) => recoveredType5.Peer.Id == old.Peer.Id && recoveredType5.Key == old.Key))
			{
				RecoveredType174 recoveredType2 = old.RecoveredMethod509();
				activityLog.RecoveredMethod367(new RecoveredType82
				{
					Account = recoveredType2.Account,
					UserId = recoveredType2.UserId,
					Source = "Worker S" + old.Peer.SessionId,
					Category = "Connection",
					Level = "Warning",
					Message = (old.Peer.Connected ? "Roblox client closed or was removed by its worker." : ("Worker disconnected. Fishing stops on the worker connection watchdog. " + RecoveredType84.RecoveredMethod364(old.Peer.Failure)))
				});
				RecoveredMethod65(recoveredType);
			}
		}
		foreach (RecoveredType325 session in P_0)
		{
			ObservableCollection<RecoveredType137> observableCollection = rows;
			Func<RecoveredType137, bool> predicate = (RecoveredType137 recoveredType6) => recoveredType6.Session is RecoveredType325 recoveredType5 && recoveredType5.Peer.Id == session.Peer.Id && recoveredType5.Key == session.Key;
			RecoveredType137 recoveredType3 = observableCollection.FirstOrDefault(predicate);
			if (recoveredType3 == null)
			{
				RecoveredType137 recoveredType4 = new RecoveredType137(session);
				recoveredType4.Inventory = session.Inventory;
				recoveredType3 = recoveredType4;
				rows.Add(recoveredType3);
				historyCount = -1;
				inventoryDirty = true;
			}
			else if (!object.ReferenceEquals(recoveredType3.Session, session))
			{
				RecoveredMethod64(recoveredType3.Session, recoveredType3.Inventory);
				recoveredType3.Session.Dispose();
				if (recoveredType3.Inventory != null)
				{
					recoveredType3.Inventory.Dispose();
				}
				recoveredType3.Session = session;
				recoveredType3.Inventory = session.Inventory;
				recoveredType3.InventoryUpdated = DateTime.MinValue;
				historyCount = -1;
				inventoryDirty = true;
			}
			recoveredType3.RecoveredMethod519(clock.Elapsed.TotalSeconds);
			string text = session.ProfileVersion + "|" + session.RecoveredMethod509().UserId;
			if (!(recoveredType3.RemoteProfileVersion != text))
			{
				continue;
			}
			recoveredType3.RemoteProfileVersion = text;
			if (Selected == recoveredType3)
			{
				RecoveredMethod128(session.Profile);
				if (!profileDirty && !RecoveredMethod79<FrameworkElement>("SettingsView").IsKeyboardFocusWithin)
				{
					RecoveredMethod101();
				}
			}
		}
		if (RecoveredMethod79<ComboBox>("Clients").SelectedItem == null && rows.Count > 0)
		{
			RecoveredMethod79<ComboBox>("Clients").SelectedIndex = 0;
		}
	}

	private void RecoveredMethod128(RecoveredType170 P_0)
	{
		RecoveredMethod79<TextBox>("CastX").Text = (P_0.CastX * 100.0).ToString(CultureInfo.InvariantCulture);
		RecoveredMethod79<TextBox>("CastY").Text = (P_0.CastY * 100.0).ToString(CultureInfo.InvariantCulture);
		RecoveredMethod82("CastPointLabel", "Worker point · " + (P_0.CastX * 100.0).ToString("0.#") + "% / " + (P_0.CastY * 100.0).ToString("0.#") + "%");
	}

	private async void RecoveredMethod129()
	{
		if (mode != RecoveredType308.Controller || hub == null || discovering || RecoveredMethod79<CheckBox>("AutoWorkers").IsChecked != true || DateTime.UtcNow - discoveryAt < TimeSpan.FromSeconds(5.0))
		{
			return;
		}
		discovering = true;
		discoveryAt = DateTime.UtcNow;
		try
		{
			int num = default(int);
			_ = num;
			_ = 0;
			try
			{
				string code = pairing.Code;
				int[] connected = (from P_0 in hub.RecoveredMethod803()
					where P_0.Connected
					select P_0.SessionId).ToArray();
				RecoveredMethod82("DiscoveryStatus", await Task.Run(() => RecoveredType97.RecoveredMethod389(code, connected)));
			}
			catch (Exception ex)
			{
				RecoveredMethod82("DiscoveryStatus", ex.Message);
			}
		}
		finally
		{
			discovering = false;
		}
	}

	private void RecoveredMethod130()
	{
		if (networkDisposed)
		{
			return;
		}
		RecoveredMethod129();
		if (previewEpoch != RecoveredType323.Value)
		{
			previewEpoch = RecoveredType323.Value;
			RecoveredMethod109(RecoveredType323.RecoveredMethod790());
		}
		if (hub != null)
		{
			hub.RecoveredMethod45();
			RecoveredMethod126();
			RecoveredType327[] array = (from P_0 in hub.RecoveredMethod803()
				where P_0.Connected
				select P_0).ToArray();
			string text = string.Join("|", array.Select((RecoveredType327 P_0) => P_0.Id + ":" + P_0.Connected + ":" + P_0.Desktop + ":" + P_0.RecoveredMethod795().Length + ":" + P_0.RecoveredMethod795().Count((RecoveredType325 recoveredType) => recoveredType.RecoveredMethod509().Attached)));
			if (text != lastPeers)
			{
				lastPeers = text;
				RecoveredMethod79<ItemsControl>("WorkerCards").ItemsSource = array.Select((RecoveredType327 P_0) => new WorkerCard
				{
					Title = P_0.User + " · session " + P_0.SessionId,
					Detail = P_0.Name,
					Status = (P_0.Connected ? P_0.Desktop : ("Offline" + ((P_0.Failure == "") ? "" : (" · " + P_0.Failure)))),
					Accounts = P_0.RecoveredMethod795().Count((RecoveredType325 recoveredType) => recoveredType.RecoveredMethod509().Attached) + " Roblox clients"
				}).ToArray();
			}
			RecoveredMethod82("NetworkStatus", array.Count((RecoveredType327 P_0) => P_0.Connected) + " workers connected · port " + pairing.Port);
		}
		else if (workerLink != null)
		{
			string text2 = workerLink.Status + " · " + workerLink.Desktop;
			if (text2 != networkStatus)
			{
				networkStatus = text2;
				RecoveredMethod82("NetworkStatus", text2);
				RecoveredMethod93(text2);
			}
		}
	}

	private void RecoveredMethod131()
	{
		if (!networkDisposed)
		{
			networkDisposed = true;
			RecoveredMethod74();
			if (discovery != null)
			{
				discovery.Dispose();
			}
			RecoveredMethod119("twist worker is closing.");
			if (workerLink != null)
			{
				workerLink.Dispose();
			}
			if (hub != null)
			{
				hub.Dispose();
			}
		}
	}

	private void RecoveredMethod132()
	{
		uiPreferences = RecoveredType342.RecoveredMethod834(folder);
		RecoveredMethod135();
		CheckBox checkBox = RecoveredMethod79<CheckBox>("HardwareAcceleration");
		checkBox.IsChecked = uiPreferences.HardwareAcceleration;
		checkBox.Checked += delegate
		{
			RecoveredMethod134(true);
		};
		checkBox.Unchecked += delegate
		{
			RecoveredMethod134(false);
		};
		RenderCapability.TierChanged += RecoveredMethod133;
		window.Closed += delegate
		{
			RenderCapability.TierChanged -= RecoveredMethod133;
		};
	}

	private void RecoveredMethod133(object P_0, EventArgs P_1)
	{
		RecoveredMethod136();
	}

	private void RecoveredMethod134(bool P_0)
	{
		uiPreferences.HardwareAcceleration = P_0;
		RecoveredMethod135();
		try
		{
			uiPreferences.RecoveredMethod414(folder);
		}
		catch (Exception ex)
		{
			RecoveredMethod93("Display setting could not be saved: " + ex.Message);
		}
	}

	private void RecoveredMethod135()
	{
		RenderOptions.ProcessRenderMode = ((!uiPreferences.HardwareAcceleration) ? RenderMode.SoftwareOnly : RenderMode.Default);
		RecoveredMethod136();
	}

	private void RecoveredMethod136()
	{
		RecoveredMethod82("RenderingStatus", (!uiPreferences.HardwareAcceleration) ? "Software rendering selected" : ((RenderCapability.Tier >> 16 > 0) ? "Hardware acceleration allowed · Windows chooses the available renderer" : "Hardware acceleration requested · this session reports software rendering"));
	}

	private static string RecoveredMethod137(RecoveredType170 P_0)
	{
		return new JavaScriptSerializer().Serialize(P_0);
	}

	private void RecoveredMethod138()
	{
		if (mode != RecoveredType308.Controller)
		{
			return;
		}
		try
		{
			if (!File.Exists(PendingProfilesFile))
			{
				return;
			}
			Dictionary<string, RecoveredType170> dictionary = new JavaScriptSerializer().Deserialize<Dictionary<string, RecoveredType170>>(File.ReadAllText(PendingProfilesFile));
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<string, RecoveredType170> item in dictionary)
			{
				item.Value.RecoveredMethod50();
				if (item.Key.Length > 0 && item.Key.Length <= 100)
				{
					pendingProfiles[item.Key] = item.Value;
				}
			}
		}
		catch (Exception ex)
		{
			RecoveredMethod93("Pending settings could not be loaded: " + ex.Message);
		}
	}

	private void RecoveredMethod139()
	{
		RecoveredType351.RecoveredMethod82(PendingProfilesFile, new JavaScriptSerializer().Serialize(pendingProfiles));
	}

	private void RecoveredMethod140()
	{
		RecoveredMethod138();
		settingsRow = Selected;
		string[] array = new string[10] { "CastX", "CastY", "CastHold", "BiteTimeout", "RecastWait", "EquipSlot", "RoundGoal", "TimeLimit", "RestockBelow", "RestockBuy" };
		foreach (string text in array)
		{
			RecoveredMethod79<TextBox>(text).TextChanged += delegate
			{
				RecoveredMethod141(false);
			};
		}
		RecoveredMethod79<ComboBox>("BaitMode").SelectionChanged += delegate
		{
			RecoveredMethod141(true);
		};
		string[] array2 = new string[3] { "AutoRestock", "AutoStoreFruits", "DropDuplicateFruits" };
		foreach (string text2 in array2)
		{
			RecoveredMethod79<CheckBox>(text2).Checked += delegate
			{
				RecoveredMethod141(true);
			};
			RecoveredMethod79<CheckBox>(text2).Unchecked += delegate
			{
				RecoveredMethod141(true);
			};
		}
		if (alerts != null)
		{
			try
			{
				string text3 = System.IO.Path.Combine(folder, "discord-draft.json");
				if (File.Exists(text3))
				{
					RecoveredType141 recoveredType = RecoveredType143.RecoveredMethod528(text3, false);
					RecoveredMethod79<PasswordBox>("DiscordUrl").Password = recoveredType.Url;
					RecoveredMethod79<CheckBox>("DiscordEnabled").IsChecked = recoveredType.Enabled;
					RecoveredMethod79<CheckBox>("WorldSpawnEnabled").IsChecked = recoveredType.SpawnEnabled;
					RecoveredMethod79<CheckBox>("MythPingEnabled").IsChecked = recoveredType.PingMythical;
					RecoveredMethod79<ComboBox>("MythPingKind").SelectedItem = recoveredType.PingKind;
					RecoveredMethod79<TextBox>("MythPingId").Text = recoveredType.PingId;
					alertsDirty = true;
				}
			}
			catch
			{
				RecoveredMethod93("Saved Discord draft could not be read; active settings were preserved.");
			}
			RecoveredMethod79<PasswordBox>("DiscordUrl").PasswordChanged += delegate
			{
				RecoveredMethod142(false);
			};
			RecoveredMethod79<TextBox>("MythPingId").TextChanged += delegate
			{
				RecoveredMethod142(false);
			};
			RecoveredMethod79<ComboBox>("MythPingKind").SelectionChanged += delegate
			{
				RecoveredMethod142(true);
			};
			string[] array3 = new string[3] { "DiscordEnabled", "MythPingEnabled", "WorldSpawnEnabled" };
			foreach (string text4 in array3)
			{
				RecoveredMethod79<CheckBox>(text4).Checked += delegate
				{
					RecoveredMethod142(true);
				};
				RecoveredMethod79<CheckBox>(text4).Unchecked += delegate
				{
					RecoveredMethod142(true);
				};
			}
		}
		if (mode == RecoveredType308.Controller)
		{
			RecoveredMethod79<CheckBox>("AutoWorkers").Checked += delegate
			{
				RecoveredMethod143(true);
			};
			RecoveredMethod79<CheckBox>("AutoWorkers").Unchecked += delegate
			{
				RecoveredMethod143(true);
			};
			RecoveredMethod79<TextBox>("ControllerPort").TextChanged += delegate
			{
				RecoveredMethod143(false);
			};
		}
		settingsTimer.Interval = TimeSpan.FromMilliseconds(600.0);
		settingsTimer.Tick += async delegate
		{
			if (!stopping && !closing)
			{
				RecoveredMethod148();
				await RecoveredMethod149();
			}
		};
		autosaveReady = true;
		if (alertsDirty)
		{
			RecoveredMethod146();
		}
		settingsTimer.Start();
	}

	private void RecoveredMethod141(bool P_0)
	{
		if (autosaveReady && !loadingSettings && settingsRow != null && !settingsRow.IsTotal)
		{
			profileDirty = true;
			profileEditAt = DateTime.UtcNow;
			if (P_0)
			{
				RecoveredMethod145(false);
			}
		}
	}

	private void RecoveredMethod142(bool P_0)
	{
		if (autosaveReady && !loadingSettings)
		{
			alertsDirty = true;
			alertsEditAt = DateTime.UtcNow;
			if (P_0)
			{
				RecoveredMethod146();
			}
		}
	}

	private void RecoveredMethod143(bool P_0)
	{
		if (autosaveReady && !loadingSettings)
		{
			preferencesDirty = true;
			preferencesEditAt = DateTime.UtcNow;
			if (P_0)
			{
				RecoveredMethod147();
			}
		}
	}

	private RecoveredType170 RecoveredMethod144(RecoveredType137 P_0)
	{
		RecoveredType170 recoveredType = RecoveredMethod100();
		RecoveredType325 recoveredType2 = P_0.Session as RecoveredType325;
		RecoveredType170 value;
		if (recoveredType2 != null)
		{
			value = recoveredType2.Profile;
		}
		else if (!profiles.TryGetValue(RecoveredMethod80(P_0), out value))
		{
			value = RecoveredType170.RecoveredMethod569(RecoveredMethod81(P_0));
		}
		recoveredType.PredictionMs = value.PredictionMs;
		recoveredType.DeadZone = value.DeadZone;
		recoveredType.UiOffsetX = value.UiOffsetX;
		recoveredType.UiOffsetY = value.UiOffsetY;
		if (recoveredType2 != null)
		{
			recoveredType.CastX = value.CastX;
			recoveredType.CastY = value.CastY;
		}
		recoveredType.RecoveredMethod50();
		return recoveredType;
	}

	private bool RecoveredMethod145(bool P_0)
	{
		if (settingsRow == null || settingsRow.IsTotal)
		{
			return false;
		}
		try
		{
			RecoveredType137 recoveredType = settingsRow;
			RecoveredType170 recoveredType2 = RecoveredMethod144(recoveredType);
			recoveredType2.RecoveredMethod414(RecoveredMethod81(recoveredType));
			profiles[RecoveredMethod80(recoveredType)] = recoveredType2;
			RecoveredType325 recoveredType3 = recoveredType.Session as RecoveredType325;
			if (recoveredType3 != null && !string.IsNullOrEmpty(recoveredType.State.UserId))
			{
				pendingProfiles[recoveredType.State.UserId] = recoveredType2.RecoveredMethod568();
				RecoveredMethod139();
			}
			profileDirty = false;
			lastProfileError = "";
			RecoveredMethod82("SavedNotice", (recoveredType3 == null) ? "Saved automatically" : "Saved · syncing to worker");
			if (P_0)
			{
				RecoveredMethod93("Settings saved. They apply on the next start.");
			}
			return true;
		}
		catch (Exception ex)
		{
			string text = "Settings not saved: " + ex.Message;
			RecoveredMethod82("SavedNotice", text);
			if (lastProfileError != text)
			{
				lastProfileError = text;
				RecoveredMethod93(text);
			}
			return false;
		}
	}

	private void RecoveredMethod146()
	{
		if (alerts == null)
		{
			return;
		}
		try
		{
			RecoveredType141 recoveredType = RecoveredMethod57();
			RecoveredType143.RecoveredMethod527(System.IO.Path.Combine(folder, "discord-draft.json"), recoveredType, false);
			alertsDirty = false;
			try
			{
				recoveredType.RecoveredMethod50();
				if (new JavaScriptSerializer().Serialize(recoveredType) != new JavaScriptSerializer().Serialize(alerts.Settings))
				{
					alerts.RecoveredMethod532(recoveredType);
				}
				alertsUiError = "";
				RecoveredMethod82("AlertsStatus", "Saved automatically. " + alerts.Status);
			}
			catch (Exception ex)
			{
				if (!recoveredType.Enabled && alerts.Settings.Enabled)
				{
					RecoveredType141 settings = alerts.Settings;
					settings.Enabled = false;
					alerts.RecoveredMethod532(settings);
				}
				alertsUiError = "Draft saved. " + ex.Message;
				RecoveredMethod82("AlertsStatus", alertsUiError);
			}
		}
		catch (Exception ex2)
		{
			RecoveredMethod54(ex2);
		}
	}

	private void RecoveredMethod147()
	{
		try
		{
			RecoveredType352 recoveredType = RecoveredType352.RecoveredMethod846(folder);
			recoveredType.AutoWorkers = RecoveredMethod79<CheckBox>("AutoWorkers").IsChecked == true;
			if (int.TryParse(RecoveredMethod79<TextBox>("ControllerPort").Text, out var result) && result >= 1024 && result <= 65535)
			{
				recoveredType.Port = result;
			}
			RecoveredType351.RecoveredMethod82(System.IO.Path.Combine(folder, "controller-preferences.json"), new JavaScriptSerializer().Serialize(recoveredType));
			preferencesDirty = false;
		}
		catch (Exception ex)
		{
			RecoveredMethod93("Connection settings could not be saved: " + ex.Message);
		}
	}

	private void RecoveredMethod148(bool P_0 = false)
	{
		DateTime utcNow = DateTime.UtcNow;
		if (profileDirty && (P_0 || utcNow - profileEditAt >= TimeSpan.FromMilliseconds(600.0)))
		{
			RecoveredMethod145(false);
		}
		if (alertsDirty && (P_0 || utcNow - alertsEditAt >= TimeSpan.FromMilliseconds(600.0)))
		{
			RecoveredMethod146();
		}
		if (preferencesDirty && (P_0 || utcNow - preferencesEditAt >= TimeSpan.FromMilliseconds(600.0)))
		{
			RecoveredMethod147();
		}
	}

	private Task RecoveredMethod149()
	{
		if (!settingsSend.IsCompleted)
		{
			return settingsSend;
		}
		settingsSend = RecoveredMethod150();
		return settingsSend;
	}

	private async Task RecoveredMethod150()
	{
		if (mode != RecoveredType308.Controller || closing)
		{
			return;
		}
		KeyValuePair<string, RecoveredType170>[] array = pendingProfiles.ToArray();
		int num2 = 0;
		goto IL_029f;
		IL_029f:
		RecoveredType72 recoveredType = default(RecoveredType72);
		RecoveredType137 row = default(RecoveredType137);
		if (num2 < array.Length)
		{
			recoveredType = new RecoveredType72();
			recoveredType.item = array[num2];
			ObservableCollection<RecoveredType137> observableCollection = rows;
			Func<RecoveredType137, bool> predicate = recoveredType.RecoveredMethod345;
			row = observableCollection.FirstOrDefault(predicate);
			if (row != null)
			{
				goto IL_00d9;
			}
			goto IL_0291;
		}
		return;
		IL_00d9:
		try
		{
			Func<RecoveredType325, RecoveredType170, Task> func = settingsWriter;
			RecoveredType325 arg = (RecoveredType325)row.Session;
			KeyValuePair<string, RecoveredType170> keyValuePair = recoveredType.item;
			await func(arg, keyValuePair.Value.RecoveredMethod568());
			Dictionary<string, RecoveredType170> dictionary = pendingProfiles;
			KeyValuePair<string, RecoveredType170> keyValuePair2 = recoveredType.item;
			if (dictionary.TryGetValue(keyValuePair2.Key, out var current))
			{
				string text = RecoveredMethod137(current);
				KeyValuePair<string, RecoveredType170> keyValuePair3 = recoveredType.item;
				if (text == RecoveredMethod137(keyValuePair3.Value))
				{
					Dictionary<string, RecoveredType170> dictionary2 = pendingProfiles;
					KeyValuePair<string, RecoveredType170> keyValuePair4 = recoveredType.item;
					dictionary2.Remove(keyValuePair4.Key);
					RecoveredMethod139();
					if (settingsRow == row && !profileDirty)
					{
						RecoveredMethod82("SavedNotice", "Saved automatically");
					}
				}
			}
			lastSendError = "";
		}
		catch (Exception ex)
		{
			string text2 = "Settings saved locally; waiting for worker: " + ex.Message;
			if (text2 != lastSendError)
			{
				lastSendError = text2;
				RecoveredMethod93(text2);
			}
		}
		goto IL_0291;
		IL_0291:
		num2++;
		goto IL_029f;
	}

	private RecoveredType170 RecoveredMethod151(RecoveredType137 P_0, RecoveredType170 P_1)
	{
		if (string.IsNullOrEmpty(P_0.State.UserId) || !pendingProfiles.TryGetValue(P_0.State.UserId, out var value))
		{
			return P_1;
		}
		return RecoveredType129.RecoveredMethod507(value, P_1);
	}

	private static void RecoveredMethod152(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Settings autosave: " + P_1);
		}
	}

	private void RecoveredMethod153()
	{
		RecoveredType137 row = null;
RecoveredType137[] array = rows.ToArray();
		foreach (RecoveredType137 recoveredType in array)
		{
			RecoveredMethod65(recoveredType);
		}
		RecoveredType312 recoveredType2 = new RecoveredType312();
		recoveredType2.WorkerId = Guid.NewGuid().ToString("N");
		recoveredType2.Name = "Autosave";
		recoveredType2.User = "Test";
		recoveredType2.SessionId = 9992;
		RecoveredType312 recoveredType3 = recoveredType2;
		RecoveredType327 recoveredType4 = new RecoveredType327(recoveredType3, null, folder, delegate
		{
		});
		string firstId = "autosave-one";
		string secondId = "autosave-two";
		RecoveredType310 recoveredType5 = new RecoveredType310();
		recoveredType5.Key = "951-1";
		recoveredType5.State = new RecoveredType174
		{
			Pid = 951,
			Created = 1L,
			UserId = firstId,
			Account = "First",
			Attached = true
		};
		recoveredType5.Profile = new RecoveredType170
		{
			CastX = 0.23,
			CastY = 0.64,
			UiOffsetX = 7.0,
			UiOffsetY = -4.0,
			PredictionMs = 91.0,
			DeadZone = 0.034
		};
		RecoveredType310 recoveredType6 = recoveredType5;
		RecoveredType310 recoveredType7 = new RecoveredType310();
		recoveredType7.Key = "952-2";
		recoveredType7.State = new RecoveredType174
		{
			Pid = 952,
			Created = 2L,
			UserId = secondId,
			Account = "Second",
			Attached = true
		};
		recoveredType7.Profile = new RecoveredType170
		{
			CastX = 0.72,
			CastY = 0.38
		};
		RecoveredType310 recoveredType8 = recoveredType7;
		recoveredType4.RecoveredMethod798(new RecoveredType315
		{
			Desktop = "Ready",
			Accounts = new RecoveredType310[2] { recoveredType6, recoveredType8 }
		});
		RecoveredMethod127(recoveredType4.RecoveredMethod795());
		RecoveredType137 recoveredType9 = rows.Single((RecoveredType137 P_0) => P_0.State.UserId == firstId);
		RecoveredType137 recoveredType10 = rows.Single((RecoveredType137 P_0) => P_0.State.UserId == secondId);
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = recoveredType9;
		RecoveredMethod79<ComboBox>("BaitMode").SelectedIndex = 1;
		RecoveredMethod79<CheckBox>("AutoRestock").IsChecked = false;
		RecoveredMethod79<CheckBox>("AutoStoreFruits").IsChecked = false;
		RecoveredMethod79<CheckBox>("DropDuplicateFruits").IsChecked = false;
		RecoveredType170 recoveredType11 = RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType9));
		RecoveredMethod152(recoveredType11.BaitMode == "best" && !recoveredType11.AutoRestockCommon && !recoveredType11.AutoStoreFruits && !recoveredType11.DropDuplicateFruits, "Bait and fruit toggles save immediately without Save or Close");
		RecoveredMethod152(recoveredType11.CastX == 0.23 && recoveredType11.CastY == 0.64 && recoveredType11.UiOffsetX == 7.0 && recoveredType11.UiOffsetY == -4.0 && recoveredType11.PredictionMs == 91.0 && recoveredType11.DeadZone == 0.034, "Autosave preserves worker point, alignment and hidden calibration");
		RecoveredMethod79<TextBox>("RestockBelow").Text = "80";
		RecoveredMethod79<TextBox>("RestockBuy").Text = "250";
		profileEditAt = DateTime.UtcNow.AddSeconds(-1.0);
		RecoveredMethod148();
		RecoveredMethod152(RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType9)).RestockBelow == 80 && RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType9)).RestockBuy == 250, "Custom restock fields autosave after typing pause");
		RecoveredMethod79<TextBox>("RestockBuy").Text = "";
		RecoveredMethod148(true);
		RecoveredMethod152(RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType9)).RestockBuy == 250, "Incomplete restock amount preserves saved value");
		RecoveredMethod79<TextBox>("RestockBuy").Text = "250";
		RecoveredMethod148(true);
		RecoveredMethod79<TextBox>("RoundGoal").Text = "12";
		RecoveredMethod148();
		RecoveredMethod152(RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType9)).StopAfterRounds == 0, "Text changes wait for a typing pause");
		profileEditAt = DateTime.UtcNow.AddSeconds(-1.0);
		RecoveredMethod148();
		RecoveredMethod152(RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType9)).StopAfterRounds == 12, "Paused text edits save without a button");
		RecoveredMethod79<TextBox>("TimeLimit").Text = "42";
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = recoveredType10;
		RecoveredMethod152(RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType9)).StopAfterMinutes == 42.0, "Switching accounts flushes pending edits for the previous account");
		RecoveredMethod79<CheckBox>("AutoRestock").IsChecked = false;
		RecoveredMethod152(RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType10)).BaitMode == "common" && RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType9)).BaitMode == "best", "Accounts keep independent settings");
		RecoveredMethod79<TextBox>("CastHold").Text = "";
		RecoveredMethod148(true);
		RecoveredMethod152(RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType10)).CastHoldMs == 350 && RecoveredMethod79<TextBlock>("SavedNotice").Text.Contains("not saved"), "Incomplete numeric entry cannot overwrite the last valid profile");
		RecoveredMethod79<TextBox>("CastHold").Text = "500";
		RecoveredMethod148(true);
		RecoveredMethod152(RecoveredType170.RecoveredMethod569(RecoveredMethod81(recoveredType10)).CastHoldMs == 500, "Corrected numeric entry is saved");
		RecoveredMethod152(pendingProfiles.Count == 2 && File.Exists(PendingProfilesFile), "Remote edits are durably queued before delivery");
		pendingProfiles.Clear();
		RecoveredMethod138();
		RecoveredMethod152(pendingProfiles[firstId].BaitMode == "best" && pendingProfiles[secondId].CastHoldMs == 500, "Pending remote settings survive reload");
		settingsWriter = delegate
		{
			throw new Exception("Simulated disconnected worker");
		};
		RecoveredMethod149().GetAwaiter().GetResult();
		RecoveredMethod152(pendingProfiles.Count == 2, "Unavailable worker retains both queued profiles");
		int sends = 0;
		Dictionary<string, RecoveredType170> applied = new Dictionary<string, RecoveredType170>();
		settingsWriter = delegate(RecoveredType325 P_0, RecoveredType170 P_1)
		{
			sends++;
			RecoveredType170 recoveredType18 = RecoveredType129.RecoveredMethod507(P_1, P_0.Profile);
			applied[P_0.RecoveredMethod509().UserId] = recoveredType18;
			P_0.RecoveredMethod792(new RecoveredType310
			{
				Key = P_0.Key,
				State = P_0.RecoveredMethod509(),
				Profile = recoveredType18,
				Rounds = P_0.RecoveredMethod510()
			});
			return Task.FromResult(0);
		};
		RecoveredMethod149().GetAwaiter().GetResult();
		RecoveredMethod152(sends == 2 && pendingProfiles.Count == 0 && new JavaScriptSerializer().Deserialize<Dictionary<string, RecoveredType170>>(File.ReadAllText(PendingProfilesFile)).Count == 0, "Reconnected workers receive saved settings and acknowledge pending entries");
		RecoveredMethod152(applied[firstId].RestockBelow == 80 && applied[firstId].RestockBuy == 250 && applied[secondId].RestockBelow == 50 && applied[firstId].StopAfterMinutes == 42.0 && applied[firstId].CastX == 0.23 && applied[secondId].CastX == 0.72 && !rows.Any((RecoveredType137 P_0) => P_0.Session.RecoveredMethod509().Running), "Worker settings sync preserves each point and never starts fishing");
		settingsWriter = (RecoveredType325 P_0, RecoveredType170 P_1) => P_0.RecoveredMethod793(P_1);
		RecoveredMethod79<CheckBox>("AutoWorkers").IsChecked = false;
		TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 0);
		tcpListener.Start();
		int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
		tcpListener.Stop();
		RecoveredMethod79<TextBox>("ControllerPort").Text = port.ToString();
		RecoveredMethod148(true);
		RecoveredType352 recoveredType12 = RecoveredType352.RecoveredMethod846(folder);
		RecoveredMethod152(!recoveredType12.AutoWorkers && recoveredType12.Port == port, "Discovery and port settings persist without restarting the listener");
		alerts.Dispose();
		RecoveredType90 recoveredType13 = new RecoveredType90();
		alerts = new RecoveredType150(folder, delegate
		{
		}, recoveredType13, (int P_0, CancellationToken P_1) => Task.FromResult(0));
		string text = "https://discord.com/api/webhooks/123456789012345678/abcdefghijklmnopqrstuvwxyz_1234567890";
		RecoveredMethod79<PasswordBox>("DiscordUrl").Password = text;
		RecoveredMethod79<ComboBox>("MythPingKind").SelectedItem = "Role";
		RecoveredMethod79<CheckBox>("MythPingEnabled").IsChecked = true;
		RecoveredMethod79<TextBox>("MythPingId").Text = "";
		RecoveredMethod148(true);
		RecoveredType141 recoveredType14 = RecoveredType143.RecoveredMethod528(System.IO.Path.Combine(folder, "discord-draft.json"), false);
		RecoveredMethod152(recoveredType14.Url == text && recoveredType14.PingMythical && recoveredType14.PingKind == "Role" && recoveredType14.PingId == "", "Optional ping target is retained without blocking the webhook");
		RecoveredMethod152(!File.ReadAllText(System.IO.Path.Combine(folder, "discord-draft.json")).Contains("abcdefghijklmnopqrstuvwxyz"), "Draft webhook credentials are encrypted");
		RecoveredMethod79<CheckBox>("DiscordEnabled").IsChecked = true;
		RecoveredMethod152(alerts.Settings.Enabled && alerts.Settings.PingMythical, "Empty optional ping does not disable ordinary fruit notifications");
		RecoveredMethod79<TextBox>("MythPingId").Text = "123456789012345678";
		RecoveredMethod148(true);
		RecoveredMethod79<CheckBox>("DiscordEnabled").IsChecked = true;
		RecoveredType141 recoveredType15 = RecoveredType143.RecoveredMethod528(System.IO.Path.Combine(folder, "discord-settings.json"));
		RecoveredMethod152(recoveredType15.Enabled && recoveredType15.Url == text && recoveredType15.PingMythical && recoveredType15.PingId == "123456789012345678" && recoveredType15.PingKind == "Role", "Webhook and ping options autosave and activate once valid");
		RecoveredMethod152(!File.ReadAllText(System.IO.Path.Combine(folder, "discord-settings.json")).Contains("abcdefghijklmnopqrstuvwxyz") && recoveredType13.Calls == 0, "Autosave protects the token and sends no test notification");
		RecoveredMethod79<PasswordBox>("DiscordUrl").Password = "incomplete-url";
		RecoveredMethod148(true);
		RecoveredMethod152(alerts.Settings.Url == text, "An incomplete URL draft cannot replace valid active settings");
		RecoveredMethod79<CheckBox>("DiscordEnabled").IsChecked = false;
		RecoveredMethod152(!alerts.Settings.Enabled, "Disabling notifications takes effect even with an incomplete draft");
		string text2 = RecoveredType309.Folder;
		RecoveredType16 recoveredType16 = null;
		try
		{
			RecoveredType309.Folder = folder;
			recoveredType16 = new RecoveredType16();
			recoveredType16.timer.Stop();
			recoveredType16.settingsTimer.Stop();
			int num;
			if (recoveredType16.RecoveredMethod79<PasswordBox>("DiscordUrl").Password == "incomplete-url")
			{
				bool? isChecked = recoveredType16.RecoveredMethod79<CheckBox>("MythPingEnabled").IsChecked;
				if (isChecked == true && isChecked.HasValue && recoveredType16.RecoveredMethod79<TextBox>("MythPingId").Text == "123456789012345678")
				{
					num = ((recoveredType16.RecoveredMethod79<CheckBox>("DiscordEnabled").IsChecked == false) ? 1 : 0);
					goto IL_0d0a;
				}
			}
			num = 0;
			goto IL_0d0a;
			IL_0d0a:
			RecoveredMethod152((byte)num != 0, "Reopened UI restores all encrypted draft fields without enabling invalid settings");
		}
		finally
		{
			RecoveredType309.Folder = text2;
			if (recoveredType16 != null)
			{
				recoveredType16.RecoveredMethod131();
				recoveredType16.closing = true;
				recoveredType16.window.Close();
			}
		}
		profileDirty = (alertsDirty = (preferencesDirty = false));
		RecoveredType137[] array2 = rows.ToArray();
		foreach (RecoveredType137 recoveredType17 in array2)
		{
			RecoveredMethod65(recoveredType17);
		}
		settingsTimer.Stop();
		Console.WriteLine("PASS: actual settings-change handlers; immediate toggles, typed-field pause, account isolation, atomic profile persistence, preserved worker points, durable offline sync, protected webhook drafts/reopen, valid activation and disable, connection preferences. No game input or Discord messages.");
	}

	private void RecoveredMethod154()
	{
		if (mode != RecoveredType308.Controller)
		{
			RecoveredMethod79<ComboBox>("Clients").ItemsSource = rows;
			return;
		}
		accountChoices.Add(totalChoice);
		RecoveredMethod79<ComboBox>("Clients").ItemsSource = accountChoices;
		rows.CollectionChanged += delegate
		{
			RecoveredType137[] array = accountChoices.Where((RecoveredType137 recoveredType) => !recoveredType.IsTotal && !rows.Contains(recoveredType)).ToArray();
			foreach (RecoveredType137 item in array)
			{
				accountChoices.Remove(item);
			}
			foreach (RecoveredType137 row in rows)
			{
				if (!accountChoices.Contains(row))
				{
					accountChoices.Add(row);
				}
			}
			if (RecoveredMethod79<ComboBox>("Clients").SelectedItem == null)
			{
				RecoveredMethod79<ComboBox>("Clients").SelectedItem = totalChoice;
			}
			inventoryDirty = true;
		};
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = totalChoice;
	}

	private RecoveredType2[] RecoveredMethod155()
	{
		return rows.Select((RecoveredType137 P_0) => new RecoveredType2
		{
			Key = P_0.Session.InputScope + ":" + P_0.Session.Pid + ":" + P_0.Session.Created,
			Scope = P_0.Session.InputScope,
			Row = P_0,
			State = P_0.Session.RecoveredMethod509(),
			Inventory = ((P_0.Inventory == null) ? null : P_0.Inventory.RecoveredMethod515()),
			Caught = ((!string.IsNullOrEmpty(P_0.State.UserId)) ? RecoveredMethod113(P_0.State.UserId) : 0)
		}).ToArray();
	}

	private void RecoveredMethod156(bool P_0)
	{
		RecoveredMethod79<FrameworkElement>("TotalAccountsPanel").Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod79<FrameworkElement>("LiveDetails").Visibility = (P_0 ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod79<Button>("Observe").IsEnabled = !P_0;
		RecoveredMethod79<Button>("SaveProfile").IsEnabled = !P_0;
		RecoveredMethod79<Button>("ReloadProfile").IsEnabled = !P_0;
		FrameworkElement frameworkElement = RecoveredMethod79<FrameworkElement>("FishingSettingsPanel");
		if (frameworkElement != null)
		{
			frameworkElement.IsEnabled = !P_0;
		}
		RecoveredMethod82("SessionTimeTitle", P_0 ? "Longest account session" : "Session time");
	}

	private void RecoveredMethod157()
	{
		RecoveredType3 recoveredType = RecoveredType5.RecoveredMethod4(RecoveredMethod155());
		RecoveredMethod156(true);
		RecoveredType2[] array = RecoveredType5.RecoveredMethod5(recoveredType.Accounts);
		RecoveredMethod79<Button>("Start").IsEnabled = !switching && (array.Length > 0 || recoveredType.Running > 0);
		RecoveredMethod79<Button>("Start").Content = ((array.Length == 0 && recoveredType.Running > 0) ? "Stop all fishing" : ((recoveredType.Running > 0) ? "Start remaining" : "Start all fishing"));
		RecoveredMethod82("AccountStatus", recoveredType.Running + " / " + recoveredType.Accounts.Length + " fishing · " + recoveredType.Ready + " ready");
		RecoveredMethod82("Uptime", RecoveredMethod96(recoveredType.Seconds));
		RecoveredMethod82("RoundCount", RecoveredMethod113("").ToString("N0"));
		RecoveredMethod82("FullCount", recoveredType.Owned.ToString("N0"));
		RecoveredMethod82("LegendaryOwnedCount", recoveredType.LegendaryOwned.ToString("N0"));
		RecoveredMethod82("RoundRate", recoveredType.Accounts.Any((RecoveredType2 P_0) => P_0.State.ActiveSeconds >= 30.0) ? (recoveredType.Rate.ToString("0.0") + " / hr") : "— / hr");
		RecoveredMethod79<TextBlock>("RoundRate").ToolTip = "Sum of the per-account catch rates. Each account uses its own session duration.";
		RecoveredMethod82("Accuracy", (recoveredType.Tracked > 0.0) ? (recoveredType.Contact / recoveredType.Tracked).ToString("P0") : "—");
		RecoveredMethod82("GoalHint", "Each account uses its saved settings");
		RecoveredMethod82("FruitStatus", ((IEnumerable<RecoveredType2>)recoveredType.Accounts).Sum((Func<RecoveredType2, long>)((RecoveredType2 P_0) => P_0.State.FruitsStored)) + " stored · " + ((IEnumerable<RecoveredType2>)recoveredType.Accounts).Sum((Func<RecoveredType2, long>)((RecoveredType2 P_0) => P_0.State.FruitsDropped)) + " duplicates dropped across all accounts");
		RecoveredMethod82("BaitStatus", recoveredType.Accounts.Count((RecoveredType2 P_0) => P_0.State.CommonBait >= 0) + " accounts reporting bait · Common stock " + recoveredType.Accounts.Where((RecoveredType2 P_0) => P_0.State.CommonBait >= 0).Sum((Func<RecoveredType2, long>)((RecoveredType2 P_0) => P_0.State.CommonBait)));
		RecoveredMethod82("TotalAccountsStatus", recoveredType.Inventory.Status);
		TotalAccountCard[] array2 = recoveredType.Accounts.Select((RecoveredType2 P_0) => new TotalAccountCard
		{
			Account = "@" + P_0.State.Account,
			Status = (P_0.State.Running ? RecoveredMethod97(P_0.State) : ((P_0.State.StopReason != "") ? ("Stopped · " + P_0.State.StopReason) : (P_0.State.Attached ? "Ready" : P_0.State.Status))),
			Caught = P_0.Caught.ToString("N0") + " caught",
			Owned = ((P_0.Inventory == null) ? 0 : P_0.Inventory.Items.Where((InventoryEntry inventoryEntry) => inventoryEntry.Metadata.IsFish).Sum((Func<InventoryEntry, long>)((InventoryEntry inventoryEntry) => inventoryEntry.Count))).ToString("N0") + " owned",
			Rate = ((P_0.State.ActiveSeconds >= 30.0) ? (((double)P_0.Caught * 3600.0 / P_0.State.ActiveSeconds).ToString("0.0") + " / hr") : "— / hr")
		}).ToArray();
		string text = string.Join("|", array2.Select((TotalAccountCard P_0) => P_0.Account + P_0.Status + P_0.Caught + P_0.Owned + P_0.Rate));
		if (text != totalCards)
		{
			totalCards = text;
			RecoveredMethod79<ItemsControl>("TotalAccountRows").ItemsSource = array2;
		}
		RecoveredMethod79<TextBlock>("TotalAccountsEmpty").Visibility = ((array2.Length != 0) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod99("");
	}

	private async Task RecoveredMethod158()
	{
		if (mode != RecoveredType308.Controller || switching || stopping || closing)
		{
			return;
		}
		switching = true;
		try
		{
			RecoveredType2[] all = RecoveredType5.RecoveredMethod4(RecoveredMethod155()).Accounts;
			RecoveredType2[] targets = RecoveredType5.RecoveredMethod5(all);
			if (targets.Length == 0)
			{
				RecoveredMethod93("No additional ready accounts to start.");
				return;
			}
			RecoveredType6 result = await RecoveredType7.RecoveredMethod38(targets, async delegate(RecoveredType2 P_0)
			{
				RecoveredType137 row = P_0.Row;
				RecoveredType170 profile = ((row.Session is RecoveredType325 remote) ? remote.Profile.RecoveredMethod568() : RecoveredType170.RecoveredMethod569(RecoveredMethod81(row)));
				await row.Session.RecoveredMethod512(profile, true);
			});
			string[] failures = result.Failures;
			foreach (string text in failures)
			{
				RecoveredMethod93("Start all · " + text);
			}
			int shared = all.Count((RecoveredType2 P_0) => P_0.State.Attached && !P_0.State.Running) - targets.Length;
			RecoveredMethod93("Start all · " + result.Started + " started" + ((result.Failures.Length > 0) ? (" · " + result.Failures.Length + " unavailable") : "") + ((shared > 0) ? (" · " + shared + " share an input session") : ""));
		}
		finally
		{
			switching = false;
			RecoveredMethod98();
		}
	}

	private async Task RecoveredMethod159()
	{
		RecoveredType3 total = RecoveredType5.RecoveredMethod4(RecoveredMethod155());
		if (RecoveredType5.RecoveredMethod5(total.Accounts).Length != 0 || total.Running <= 0)
		{
			await RecoveredMethod158();
		}
		else
		{
			await RecoveredMethod106();
		}
	}

	private void RecoveredMethod160(string P_0)
	{
		if (!IsTotalSelected)
		{
			throw new Exception("Controller must default to Total.");
		}
		RecoveredType356 recoveredType = new RecoveredType356();
		recoveredType.Scope = "session:test-one";
		recoveredType.State = new RecoveredType174
		{
			Pid = 101,
			Created = 1L,
			UserId = "totals-one",
			Account = "One",
			Attached = true,
			ActiveSeconds = 3600.0,
			TrackedSeconds = 100.0,
			OnTargetSeconds = 80.0
		};
		RecoveredType356 recoveredType2 = recoveredType;
		RecoveredType356 recoveredType3 = new RecoveredType356();
		recoveredType3.Scope = "session:test-two";
		recoveredType3.State = new RecoveredType174
		{
			Pid = 102,
			Created = 2L,
			UserId = "totals-two",
			Account = "Two",
			Attached = true,
			ActiveSeconds = 1800.0,
			TrackedSeconds = 50.0,
			OnTargetSeconds = 25.0
		};
		RecoveredType356 recoveredType4 = recoveredType3;
		ItemMetadata itemMetadata = new ItemMetadata();
		itemMetadata.Name = "Tigerfin";
		itemMetadata.Rarity = "Common";
		itemMetadata.Category = "Fish";
		ItemMetadata metadata = itemMetadata;
		RecoveredType356[] array = new RecoveredType356[2] { recoveredType2, recoveredType4 };
		foreach (RecoveredType356 session in array)
		{
			int count = ((session == recoveredType2) ? 3 : 4);
			int count2 = ((session == recoveredType2) ? 2 : 3);
			session.Rounds = (from num in Enumerable.Range(0, count2)
				select new RoundRecord
				{
					Id = session.State.UserId + "-" + num,
					UserId = session.State.UserId,
					Account = session.State.Account,
					AtUtc = DateTime.UtcNow.ToString("o"),
					Full = true
				}).ToArray();
			rows.Add(new RecoveredType137(session)
			{
				Inventory = new RecoveredType357
				{
					Value = new InventorySnapshot
					{
						Account = session.State.Account,
						UserId = session.State.UserId,
						Valid = true,
						Updated = DateTime.UtcNow,
						Items = new InventoryEntry[4]
						{
							new InventoryEntry
							{
								Name = "Tigerfin",
								Count = count,
								Metadata = metadata
							},
							new InventoryEntry
							{
								Name = "Anglerfish",
								Count = ((session == recoveredType2) ? 2 : 3),
								Metadata = new ItemMetadata
								{
									Name = "Anglerfish",
									Rarity = "Legendary",
									Category = "Fish"
								}
							},
							new InventoryEntry
							{
								Name = "Ope",
								Count = ((session != recoveredType2) ? 1 : 2),
								Metadata = new ItemMetadata
								{
									Name = "Ope",
									Category = "Fruit",
									Rarity = "Mythical"
								}
							},
							new InventoryEntry
							{
								Name = "Common Fish Bait",
								Count = 500,
								Metadata = new ItemMetadata
								{
									Name = "Common Fish Bait",
									Category = "Item",
									Rarity = "Common"
								}
							}
						},
						Gains = new InventoryGain[1]
						{
							new InventoryGain
							{
								Name = "Tigerfin",
								Count = count2,
								Fishing = true,
								AtUtc = DateTime.UtcNow.ToString("o")
							}
						}
					}
				}
			});
		}
		RecoveredMethod114();
		RecoveredMethod95();
		RecoveredMethod98();
		if (RecoveredMethod79<TextBlock>("FullCount").Text != "12" || RecoveredMethod79<TextBlock>("RoundCount").Text != "5" || RecoveredMethod79<ItemsControl>("TotalAccountRows").Items.Count != 2)
		{
			throw new Exception("Total metrics did not aggregate both accounts.");
		}
		RecoveredMethod84("Inventory");
		if (RecoveredMethod79<ItemsControl>("InventoryCards").Items.Count != 2)
		{
			throw new Exception("Total inventory did not merge the fish card.");
		}
		if (RecoveredMethod79<TextBlock>("LegendaryOwnedCount").Text != "5" || RecoveredMethod79<TextBlock>("InventoryLegendaryCount").Text != "5 Legendary fish")
		{
			throw new Exception("Total Legendary-owned metrics did not merge both inventories.");
		}
		RecoveredMethod84("Fruits");
		if (RecoveredMethod79<TextBlock>("InventoryLegendaryCount").Visibility != Visibility.Collapsed)
		{
			throw new Exception("Fish-only Legendary count leaked into fruit inventory.");
		}
		ItemCard[] array2 = RecoveredMethod79<ItemsControl>("InventoryCards").Items.Cast<ItemCard>().ToArray();
		if (array2.Length != 1 || array2[0].Name != "Ope" || array2[0].Count != 3 || RecoveredMethod79<TextBlock>("InventoryFishCount").Text != "3 fruits stored")
		{
			throw new Exception("Fruit Total does not merge stored fruit independently from fish and bait.");
		}
		RecoveredMethod84("Inventory");
		if (RecoveredMethod79<ItemsControl>("InventoryCards").Items.Cast<ItemCard>().Any((ItemCard itemCard) => itemCard.Name == "Ope"))
		{
			throw new Exception("Fruit leaked into fish-only inventory.");
		}
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = rows[0];
		if (!RecoveredMethod79<Button>("SaveProfile").IsEnabled || RecoveredMethod79<FrameworkElement>("LiveDetails").Visibility != Visibility.Visible)
		{
			throw new Exception("Individual account controls did not restore.");
		}
		if (RecoveredMethod79<TextBlock>("LegendaryOwnedCount").Text != "2")
		{
			throw new Exception("Individual Legendary-owned count did not restore.");
		}
		RecoveredMethod84("Fruits");
		if (RecoveredMethod79<ItemsControl>("InventoryCards").Items.Cast<ItemCard>().Single().Count != 2)
		{
			throw new Exception("Per-account fruit quantity is incorrect.");
		}
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = totalChoice;
		RecoveredMethod84("Alerts");
		if (!RecoveredMethod79<FrameworkElement>("AlertsForm").IsEnabled || RecoveredMethod79<FrameworkElement>("AlertsView").Visibility != Visibility.Visible)
		{
			throw new Exception("Global alerts are disabled under Total.");
		}
		RecoveredMethod61();
		RecoveredMethod158().GetAwaiter().GetResult();
		if (recoveredType2.Starts != 1 || recoveredType4.Starts != 1)
		{
			throw new Exception("Total Start All did not dispatch both accounts.");
		}
		RecoveredMethod158().GetAwaiter().GetResult();
		if (recoveredType2.Starts != 1 || recoveredType4.Starts != 1)
		{
			throw new Exception("Start All restarted accounts already fishing.");
		}
		foreach (RecoveredType137 row in rows)
		{
			row.RecoveredMethod519(clock.Elapsed.TotalSeconds);
		}
		RecoveredMethod98();
		if (P_0 != null)
		{
			RecoveredMethod84((P_0.IndexOf("fruit", StringComparison.OrdinalIgnoreCase) >= 0) ? "Fruits" : ((P_0.IndexOf("alert", StringComparison.OrdinalIgnoreCase) >= 0) ? "Alerts" : "Session"));
			DateTime dateTime = DateTime.UtcNow.AddSeconds(2.0);
			while (DateTime.UtcNow < dateTime && RecoveredMethod79<ItemsControl>("InventoryCards").Items.Cast<ItemCard>().Any((ItemCard itemCard) => itemCard.Icon == null))
			{
				DispatcherFrame frame = new DispatcherFrame();
				window.Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, (Action)delegate
				{
					frame.Continue = false;
				});
				Dispatcher.PushFrame(frame);
				Thread.Sleep(10);
			}
			FrameworkElement frameworkElement = (FrameworkElement)window.Content;
			frameworkElement.Width = 1100.0;
			frameworkElement.Height = 780.0;
			frameworkElement.Measure(new Size(1100.0, 780.0));
			frameworkElement.Arrange(new Rect(0.0, 0.0, 1100.0, 780.0));
			frameworkElement.UpdateLayout();
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(1100, 780, 96.0, 96.0, PixelFormats.Pbgra32);
			renderTargetBitmap.Render(frameworkElement);
			PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
			pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
			using FileStream stream = File.Create(P_0);
			pngBitmapEncoder.Save(stream);
		}
		RecoveredMethod106().GetAwaiter().GetResult();
		if (recoveredType2.State.Running || recoveredType4.State.Running)
		{
			throw new Exception("Stop All did not stop both accounts.");
		}
		Console.WriteLine("PASS: Total selection, merged inventory/catches, individual selection restore, Start All/no restart and Stop All UI actions. Inputs mocked.");
	}

	private void RecoveredMethod161()
	{
		bool presentationHidden = PresentationHidden;
		timer.Interval = TimeSpan.FromMilliseconds(RecoveredType373.RecoveredMethod868(presentationHidden, mode == RecoveredType308.Worker, Selected != null && Selected.State.Reeling, currentPage));
		bool flag = !presentationHidden && currentPage == "Session" && mode != RecoveredType308.Worker && !IsTotalSelected;
		gauge.SetPresentationEnabled(flag);
		if (flag)
		{
			if (!liveTimer.IsEnabled)
			{
				liveTimer.Start();
			}
		}
		else
		{
			liveTimer.Stop();
			RecoveredMethod79<ProgressBar>("FishProgress").BeginAnimation(RangeBase.ValueProperty, null);
			progressTarget = double.NaN;
		}
		if (previewQueue != null && mode != RecoveredType308.Worker)
		{
			previewQueue.RecoveredMethod72(presentationHidden);
		}
	}

	private async void RecoveredMethod162(object P_0, EventArgs P_1)
	{
		if (uiTickRunning || closing || stopping)
		{
			return;
		}
		uiTickRunning = true;
		try
		{
			int num = default(int);
			_ = num;
			_ = 0;
			try
			{
				RecoveredMethod161();
				RecoveredMethod130();
				foreach (RecoveredType137 row in rows)
				{
					row.RecoveredMethod519(clock.Elapsed.TotalSeconds);
				}
				long now = clock.ElapsedMilliseconds;
				if (now - maintenanceAt >= 1000)
				{
					maintenanceAt = now;
					RecoveredMethod95();
					RecoveredMethod114();
					RecoveredMethod171();
					RecoveredMethod60();
					RecoveredMethod50();
				}
				if (!PresentationHidden)
				{
					RecoveredMethod98();
				}
				if (now - clientsAt >= 6000)
				{
					clientsAt = now;
					await RecoveredMethod94();
				}
			}
			catch (Exception ex)
			{
				RecoveredMethod93("Dashboard refresh: " + ex.Message);
			}
		}
		finally
		{
			uiTickRunning = false;
		}
	}

	private void RecoveredMethod163()
	{
		liveTimer.Interval = TimeSpan.FromMilliseconds(33.0);
		liveTimer.Tick += delegate
		{
			RecoveredMethod164();
		};
	}

	private void RecoveredMethod164()
	{
		if (PresentationHidden || currentPage != "Session" || IsTotalSelected)
		{
			return;
		}
		RecoveredType137 selected = Selected;
		if (selected == null)
		{
			return;
		}
		selected.RecoveredMethod519(clock.Elapsed.TotalSeconds);
		RecoveredType174 state = selected.State;
		gauge.Update(state.Player, state.Goal, state.BarHeight, state.Reeling);
		chart.Update(selected.Points, clock.Elapsed.TotalSeconds);
		double num = (state.Reeling ? Math.Max(0.0, Math.Min(1.0, state.Progress)) : 0.0);
		if (num != progressTarget)
		{
			progressTarget = num;
			ProgressBar progressBar = RecoveredMethod79<ProgressBar>("FishProgress");
			if (!state.Reeling)
			{
				progressBar.BeginAnimation(RangeBase.ValueProperty, null);
				progressBar.Value = 0.0;
			}
			else
			{
				progressBar.BeginAnimation(RangeBase.ValueProperty, new DoubleAnimation(num, TimeSpan.FromMilliseconds(80.0))
				{
					FillBehavior = FillBehavior.HoldEnd
				});
			}
		}
		RecoveredMethod82("ProgressLabel", state.Reeling ? state.Progress.ToString("P0") : "—");
		RecoveredMethod82("LivePhase", RecoveredMethod97(state));
		RecoveredMethod82("ContactLabel", (!state.Reeling) ? "" : ((Math.Abs(state.Player - state.Goal) <= state.BarHeight / 2.0) ? "on target" : "following"));
	}

	private void RecoveredMethod165()
	{
		RecoveredMethod161();
		if (!PresentationHidden)
		{
			inventoryDirty = true;
			RecoveredMethod98();
		}
	}

	private void RecoveredMethod166()
	{
		CheckBox checkBox = RecoveredMethod79<CheckBox>("HardwareAcceleration");
		bool value = checkBox.IsChecked == true;
		checkBox.IsChecked = false;
		if (RenderOptions.ProcessRenderMode != RenderMode.SoftwareOnly || RecoveredType342.RecoveredMethod834(folder).HardwareAcceleration)
		{
			throw new Exception("Software rendering setting did not apply/save.");
		}
		checkBox.IsChecked = true;
		if (RenderOptions.ProcessRenderMode != RenderMode.Default || !RecoveredType342.RecoveredMethod834(folder).HardwareAcceleration)
		{
			throw new Exception("Hardware preference did not apply/save.");
		}
		if (mode == RecoveredType308.Controller)
		{
			RecoveredMethod79<ComboBox>("Clients").SelectedItem = totalChoice;
			RecoveredMethod156(true);
			if (!checkBox.IsEnabled)
			{
				throw new Exception("Total selection disabled display preferences.");
			}
		}
		checkBox.IsChecked = value;
	}

	private void RecoveredMethod167()
	{
		ItemMetadata itemMetadata = new ItemMetadata();
		itemMetadata.Name = "Tigerfin";
		itemMetadata.Category = "Fish";
		itemMetadata.Rarity = "Common";
		ItemMetadata itemMetadata2 = itemMetadata;
		RecoveredType357 recoveredType = new RecoveredType357();
		recoveredType.Value = new InventorySnapshot
		{
			Valid = true,
			UserId = "reuse",
			Updated = DateTime.UtcNow,
			Items = new InventoryEntry[1]
			{
				new InventoryEntry
				{
					Name = "Tigerfin",
					Count = 1,
					Metadata = itemMetadata2
				}
			}
		};
		RecoveredType357 recoveredType2 = recoveredType;
		RecoveredType356 recoveredType3 = new RecoveredType356();
		recoveredType3.State = new RecoveredType174
		{
			Account = "Demo",
			UserId = "reuse",
			Pid = 99
		};
		recoveredType3.Scope = "reuse";
		RecoveredType356 recoveredType4 = recoveredType3;
		RecoveredType137 recoveredType5 = new RecoveredType137(recoveredType4);
		recoveredType5.Inventory = recoveredType2;
		RecoveredType137 recoveredType6 = recoveredType5;
		rows.Add(recoveredType6);
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = recoveredType6;
		RecoveredMethod84("Inventory");
		IEnumerable itemsSource = RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource;
		recoveredType2.Value.Items[0].Count = 2;
		inventoryDirty = true;
		RecoveredMethod115();
		if (!object.ReferenceEquals(itemsSource, RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource) || ((ItemCard[])itemsSource)[0].Count != 2)
		{
			throw new Exception("Quantity update rebuilt inventory cards.");
		}
		RecoveredMethod109(new string[1] { itemMetadata2.IconKey });
		if (!object.ReferenceEquals(itemsSource, RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource))
		{
			throw new Exception("Preview arrival rebuilt inventory cards.");
		}
		RecoveredMethod65(recoveredType6);
		RecoveredMethod84("Session");
	}

	private void RecoveredMethod168()
	{
		RecoveredMethod166();
		RecoveredMethod84("Connections");
		inventoryDirty = true;
		object itemsSource = RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource;
		RecoveredMethod115();
		if (!inventoryDirty || !object.ReferenceEquals(itemsSource, RecoveredMethod79<ItemsControl>("InventoryCards").ItemsSource))
		{
			throw new Exception("Hidden inventory tab still rebuilt cards.");
		}
		RecoveredMethod84("Inventory");
		if (inventoryDirty)
		{
			throw new Exception("Opening inventory did not refresh pending data.");
		}
		RecoveredMethod84("Session");
		RecoveredMethod161();
		if (liveTimer.IsEnabled)
		{
			throw new Exception("Hidden dashboard kept live presentation sampling active.");
		}
		if (timer.Interval.TotalMilliseconds != 1000.0)
		{
			throw new Exception("Hidden UI did not enter its idle cadence.");
		}
		gauge.Update(0.3, 0.7, 0.2, show: true);
		gauge.SetPresentationEnabled(value: false);
		if ((bool)typeof(ReelGauge).GetField("subscribed", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(gauge))
		{
			throw new Exception("Hidden gauge kept a rendering subscription.");
		}
		string text = "performance-" + Guid.NewGuid().ToString("N");
		int num = RecoveredMethod113(text);
		catches.RecoveredMethod724(new RoundRecord[1]
		{
			new RoundRecord
			{
				Id = text,
				UserId = text,
				Account = "Demo",
				Full = true,
				AtUtc = DateTime.UtcNow.AddSeconds(1.0).ToString("o")
			}
		});
		if (RecoveredMethod113(text) != num + 1)
		{
			throw new Exception("Cached catch totals did not refresh after a completed round.");
		}
		RecoveredMethod167();
		Console.WriteLine("PASS: hidden-tab deferral, refresh on opening, minimized cadence, animation suspension and catch-cache invalidation in the actual dashboard. No windows shown.");
	}

	public static void RecoveredMethod169(string P_0 = null)
	{
		string text = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "twist-ui-" + Guid.NewGuid().ToString("N"));
		Application application = new Application();
		application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
		Application application2 = application;
		try
		{
			RecoveredType308[] array = new RecoveredType308[3]
			{
				RecoveredType308.Controller,
				RecoveredType308.Worker,
				RecoveredType308.Local
			};
			for (int i = 0; i < array.Length; i++)
			{
				RecoveredType308 recoveredType = (RecoveredType309.Mode = array[i]);
				RecoveredType309.Folder = System.IO.Path.Combine(text, recoveredType.ToString());
				Directory.CreateDirectory(RecoveredType309.Folder);
				if (recoveredType == RecoveredType308.Controller)
				{
					TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 0);
					tcpListener.Start();
					int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
					tcpListener.Stop();
					File.WriteAllText(System.IO.Path.Combine(RecoveredType309.Folder, "controller-pairing.txt"), new RecoveredType321
					{
						Port = port,
						Secret = RecoveredType321.RecoveredMethod357()
					}.Code);
				}
				RecoveredType16 recoveredType2 = new RecoveredType16(recoveredType);
				recoveredType2.timer.Stop();
				recoveredType2.settingsTimer.Stop();
				if (recoveredType == RecoveredType308.Worker)
				{
					recoveredType2.RecoveredMethod72(false);
				}
				string[] array2 = new string[9] { "Clients", "BaitMode", "AutoRestock", "ConnectionsView", "InventoryCards", "NavFruits", "AlertsView", "DiscordUrl", "MythPingKind" };
				foreach (string text2 in array2)
				{
					if (recoveredType2.window.FindName(text2) == null)
					{
						throw new Exception("Missing UI control " + text2);
					}
				}
				if (recoveredType == RecoveredType308.Worker && (recoveredType2.miniWindow == null || recoveredType2.miniWindow.FindName("MiniAlign") == null))
				{
					throw new Exception("Compact worker alignment is missing.");
				}
				if (recoveredType == RecoveredType308.Worker && recoveredType2.RecoveredMethod79<FrameworkElement>("AlertsForm").IsEnabled)
				{
					throw new Exception("Workers must not configure independent webhooks.");
				}
				if (recoveredType2.window.IsVisible || (recoveredType2.miniWindow != null && recoveredType2.miniWindow.IsVisible))
				{
					throw new Exception("UI test showed a window.");
				}
				if (recoveredType == RecoveredType308.Controller)
				{
					recoveredType2.RecoveredMethod160(P_0);
					RecoveredType137[] array3 = recoveredType2.rows.ToArray();
					foreach (RecoveredType137 recoveredType3 in array3)
					{
						recoveredType2.RecoveredMethod65(recoveredType3);
					}
					recoveredType2.RecoveredMethod69();
					recoveredType2.RecoveredMethod153();
				}
				if (recoveredType == RecoveredType308.Worker)
				{
					recoveredType2.RecoveredMethod68();
				}
				recoveredType2.RecoveredMethod168();
				recoveredType2.RecoveredMethod174();
				recoveredType2.RecoveredMethod53();
				recoveredType2.RecoveredMethod131();
				recoveredType2.activityLog.Completion.GetAwaiter().GetResult();
				recoveredType2.ledger.Completion.GetAwaiter().GetResult();
				recoveredType2.catches.Completion.GetAwaiter().GetResult();
				if (recoveredType2.worldHistory != null)
				{
					recoveredType2.worldHistory.Completion.GetAwaiter().GetResult();
				}
				if (recoveredType2.catalogWriter != null)
				{
					recoveredType2.catalogWriter.Completion.GetAwaiter().GetResult();
				}
				recoveredType2.closing = true;
				recoveredType2.window.Close();
				if (recoveredType2.miniWindow != null)
				{
					recoveredType2.miniWindow.Close();
				}
				Console.WriteLine(string.Concat("PASS: ", recoveredType, " UI wiring and compact panel without showing windows."));
			}
		}
		finally
		{
			application2.Shutdown();
			if (Directory.Exists(text))
			{
				string[] files = Directory.GetFiles(text, "*", SearchOption.AllDirectories);
				foreach (string path in files)
				{
					File.Delete(path);
				}
				string[] directories = Directory.GetDirectories(text, "*", SearchOption.AllDirectories);
				Array.Sort(directories, (string text4, string text3) => text3.Length.CompareTo(text4.Length));
				string[] array4 = directories;
				foreach (string path2 in array4)
				{
					Directory.Delete(path2);
				}
				Directory.Delete(text);
			}
		}
	}

	private void RecoveredMethod170()
	{
		worldHistory = new RecoveredType416(System.IO.Path.Combine(folder, "data"));
	}

	private void RecoveredMethod171()
	{
		if (worldHistory != null)
		{
			worldHistory.RecoveredMethod898(rows.SelectMany((RecoveredType137 P_0) => (P_0.Session.RecoveredMethod509().World != null) ? P_0.Session.RecoveredMethod509().World.Events : new WorldFruitRecord[0]));
			if (worldHistory.Error != "" && worldHistory.Error != worldHistoryError)
			{
				worldHistoryError = worldHistory.Error;
				RecoveredMethod93(worldHistoryError);
			}
		}
	}

	private void RecoveredMethod172()
	{
		if (worldHistory == null)
		{
			return;
		}
		string text = (IsTotalSelected ? "" : ((Selected == null) ? "" : Selected.Account));
		if (worldHistoryRevision == worldHistory.Revision && worldHistoryScope == text)
		{
			return;
		}
		worldHistoryRevision = worldHistory.Revision;
		worldHistoryScope = text;
		WorldFruitRecord[] array = worldHistory.RecoveredMethod899(text);
		RecoveredMethod79<ItemsControl>("WorldHistoryRows").ItemsSource = (from P_0 in array.Take(100)
			select new WorldFruitCard
			{
				Time = (DateTime.TryParse(P_0.AtUtc, null, DateTimeStyles.RoundtripKind, out var result) ? result.ToLocalTime().ToString("MMM d · HH:mm:ss") : ""),
				Announcement = (P_0.Announcement ?? (P_0.Name + " spawned")),
				Name = P_0.Name + " spawned",
				Coordinates = "Coords: " + ((P_0.Position == null) ? "Unavailable" : P_0.Position.Compact),
				Detail = P_0.Rarity + " · " + P_0.Hub + " · " + string.Join(", ", (P_0.Observers ?? new string[1] { P_0.Account }).Select((string text2) => "@" + text2))
			}).ToArray();
		RecoveredMethod82("WorldHistoryCount", array.Length + " saved spawn" + ((array.Length == 1) ? "" : "s") + " · newest 100 shown");
		RecoveredMethod79<TextBlock>("WorldHistoryEmpty").Visibility = ((array.Length != 0) ? Visibility.Collapsed : Visibility.Visible);
	}

	private void RecoveredMethod173()
	{
		if (currentPage != "World")
		{
			return;
		}
		RecoveredMethod172();
		RecoveredType137[] array = (IsTotalSelected ? rows.ToArray() : ((Selected == null) ? new RecoveredType137[0] : new RecoveredType137[1] { Selected }));
		WorldWorkerCard[] itemsSource = array.Select(delegate(RecoveredType137 P_0)
		{
			RecoveredType174 recoveredType = P_0.Session.RecoveredMethod509();
			WorldSnapshot worldSnapshot = recoveredType.World ?? new WorldSnapshot();
			bool flag = recoveredType.Attached && worldSnapshot.Valid && DateTime.UtcNow - worldSnapshot.Updated < TimeSpan.FromSeconds(5.0);
			return new WorldWorkerCard
			{
				Account = "@" + recoveredType.Account,
				Coordinates = ((worldSnapshot.Position == null) ? "Position unavailable" : worldSnapshot.Position.Label),
				Timer = (worldSnapshot.HasEye ? worldSnapshot.EyeDescription : "All Seeing Eye timer unavailable"),
				Status = (flag ? worldSnapshot.Hub : "Last seen / unavailable") + ((P_0.Session is RecoveredType325) ? (" · S" + ((RecoveredType325)P_0.Session).Peer.SessionId) : "")
			};
		}).ToArray();
		RecoveredMethod82("WorldScope", IsTotalSelected ? "All connected accounts" : "Selected account · coordinates in studs");
		string text = string.Join("|", itemsSource.Select((WorldWorkerCard P_0) => P_0.Account + P_0.Coordinates + P_0.Timer + P_0.Status));
		if (text != worldWorkersSignature)
		{
			worldWorkersSignature = text;
			RecoveredMethod79<ItemsControl>("WorldWorkers").ItemsSource = itemsSource;
		}
		WorldFruitCard[] array2 = (from P_0 in (from P_0 in array.SelectMany(delegate(RecoveredType137 P_0)
				{
					RecoveredType174 state = P_0.Session.RecoveredMethod509();
					WorldSnapshot world = state.World ?? new WorldSnapshot();
					return (!state.Attached || !world.Valid || !(DateTime.UtcNow - world.Updated < TimeSpan.FromSeconds(5.0))) ? new WorldFruitRecord[0].Select((WorldFruitRecord worldFruitRecord) => new J<WorldFruitRecord, WorldSnapshot, string>(worldFruitRecord, world, state.Account)).ToArray() : world.Fruits.Select((WorldFruitRecord worldFruitRecord) => new J<WorldFruitRecord, WorldSnapshot, string>(worldFruitRecord, world, state.Account)).ToArray();
				})
				group P_0 by P_0.Fruit.Fingerprint() into P_0
				select P_0.First()).Select(delegate(J<WorldFruitRecord, WorldSnapshot, string> P_0)
			{
				WorldFruitRecord fruit = P_0.Fruit;
				WorldPoint position = P_0.World.Position;
				return new WorldFruitCard
				{
					Announcement = (fruit.Announcement ?? ""),
					Name = fruit.Name + " spawned",
					Coordinates = "Coords: " + ((fruit.Position == null) ? "Waiting for pulse target" : fruit.Position.Compact),
					Detail = fruit.Rarity + " · " + fruit.Hub + " · @" + P_0.Account + ((!(fruit.Source == "Eye pulse")) ? (fruit.Visible ? " · tap pickup" : " · last seen, outside current view") : (fruit.Visible ? " · Eye pulse target" : " · last known pulse target")),
					Direction = ((position == null || fruit.Position == null) ? "" : (position.Distance(fruit.Position).ToString("0", CultureInfo.InvariantCulture) + " studs away · ΔX " + (fruit.Position.RecoveredField2015 - position.RecoveredField2015).ToString("+0;-0;0", CultureInfo.InvariantCulture) + "  ΔY " + (fruit.Position.RecoveredField2016 - position.RecoveredField2016).ToString("+0;-0;0", CultureInfo.InvariantCulture) + "  ΔZ " + (fruit.Position.RecoveredField2017 - position.RecoveredField2017).ToString("+0;-0;0", CultureInfo.InvariantCulture)))
				};
			})
			orderby P_0.Name
			select P_0).ToArray();
		string text2 = string.Join("|", array2.Select((WorldFruitCard P_0) => P_0.Announcement + P_0.Name + P_0.Coordinates + P_0.Detail + P_0.Direction));
		if (text2 != worldFruitsSignature)
		{
			worldFruitsSignature = text2;
			RecoveredMethod79<ItemsControl>("WorldFruits").ItemsSource = array2;
		}
		RecoveredMethod79<TextBlock>("WorldEmpty").Visibility = ((array2.Length != 0) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod82("WorldCount", array2.Length + " fruit marker" + ((array2.Length == 1) ? "" : "s") + " available");
	}

	private void RecoveredMethod174()
	{
		RecoveredMethod79<Button>("NavInventory").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		if (RecoveredMethod79<FrameworkElement>("InventoryView").Visibility != Visibility.Visible)
		{
			throw new Exception("Inventory navigation failed.");
		}
		RecoveredMethod79<Button>("NavFruits").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		if (!showFruitInventory || currentPage != "Fruits")
		{
			throw new Exception("Fruit subtab failed.");
		}
		RecoveredMethod79<Button>("InventoryFishTab").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		if (showFruitInventory || currentPage != "Inventory")
		{
			throw new Exception("Fish subtab failed.");
		}
		RecoveredMethod79<Button>("NavSettings").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		RecoveredMethod79<Button>("NavConnections").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		if (RecoveredMethod79<FrameworkElement>("SettingsHubView").Visibility != Visibility.Visible || RecoveredMethod79<FrameworkElement>("ConnectionsView").Visibility != Visibility.Visible || RecoveredMethod79<FrameworkElement>("SettingsView").Visibility == Visibility.Visible)
		{
			throw new Exception("Connections settings subtab failed.");
		}
		RecoveredMethod79<Button>("SettingsGeneralTab").RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
		if (RecoveredMethod79<FrameworkElement>("SettingsView").Visibility != Visibility.Visible)
		{
			throw new Exception("General settings subtab failed.");
		}
		DateTime utcNow = DateTime.UtcNow;
		WorldSnapshot worldSnapshot = new WorldSnapshot();
		worldSnapshot.Valid = true;
		worldSnapshot.Updated = utcNow;
		worldSnapshot.HasEye = true;
		worldSnapshot.Hub = "Fishing Hub";
		worldSnapshot.EyeDescription = "All Seeing Eye: 5 mins until next fruit spawn";
		worldSnapshot.Position = new WorldPoint
		{
			RecoveredField2015 = -0.1,
			RecoveredField2016 = 4.0,
			RecoveredField2017 = -1400.0
		};
		worldSnapshot.Fruits = new WorldFruitRecord[1]
		{
			new WorldFruitRecord
			{
				Id = "demo",
				Name = "Kilo",
				Rarity = "Common",
				Server = "demo-server",
				Hub = "Fishing Hub",
				Account = "Demo",
				Position = new WorldPoint
				{
					RecoveredField2015 = 594.6,
					RecoveredField2016 = 1.6,
					RecoveredField2017 = -1485.7
				},
				AtUtc = utcNow.ToString("o"),
				LastSeenUtc = utcNow.ToString("o")
			}
		};
		WorldSnapshot worldSnapshot2 = worldSnapshot;
		RecoveredType356 recoveredType = new RecoveredType356();
		recoveredType.Scope = "world-demo";
		recoveredType.State = new RecoveredType174
		{
			Account = "Demo",
			UserId = "world-demo",
			Pid = 999,
			Attached = true,
			World = worldSnapshot2
		};
		RecoveredType356 recoveredType2 = recoveredType;
		RecoveredType137 recoveredType3 = new RecoveredType137(recoveredType2);
		rows.Add(recoveredType3);
		RecoveredMethod79<ComboBox>("Clients").SelectedItem = recoveredType3;
		RecoveredMethod84("World");
		if (RecoveredMethod79<ItemsControl>("WorldWorkers").Items.Cast<WorldWorkerCard>().Single().Coordinates != "X -1   Y 4   Z -1400" || !RecoveredMethod79<ItemsControl>("WorldWorkers").Items.Cast<WorldWorkerCard>().Single().Timer.Contains("5 mins"))
		{
			throw new Exception("World coordinates/Eye timer did not reach UI.");
		}
		if (RecoveredMethod79<ItemsControl>("WorldFruits").Items.Cast<WorldFruitCard>().Single().Coordinates != "Coords: 594, 1, -1486")
		{
			throw new Exception("Fruit coordinates not rendered correctly.");
		}
		worldSnapshot2.Fruits[0].Visible = false;
		RecoveredMethod173();
		if (!RecoveredMethod79<ItemsControl>("WorldFruits").Items.Cast<WorldFruitCard>().Single().Detail.Contains("last seen"))
		{
			throw new Exception("Unstreamed fruit marker not labelled last seen.");
		}
		if (mode == RecoveredType308.Controller)
		{
			RecoveredMethod79<ComboBox>("Clients").SelectedItem = totalChoice;
			RecoveredMethod173();
			if (RecoveredMethod79<ItemsControl>("WorldWorkers").Items.Count != 1)
			{
				throw new Exception("Total World view lost worker coordinates.");
			}
		}
		worldSnapshot2.Events = worldSnapshot2.Fruits;
		RecoveredMethod84("Session");
		RecoveredMethod171();
		RecoveredMethod84("World");
		if (RecoveredMethod79<ItemsControl>("WorldHistoryRows").Items.Count != 1)
		{
			throw new Exception("Background spawn history did not appear in World.");
		}
		RecoveredMethod65(recoveredType3);
		RecoveredMethod84("Session");
		Console.WriteLine("PASS: World tab account/Total coordinates, Eye timer, fruit position and explicit last-seen state. No windows shown.");
	}

	[CompilerGenerated]
	private void RecoveredMethod175()
	{
		RecoveredMethod84("ActivityLog");
	}

	[CompilerGenerated]
	private void RecoveredMethod176()
	{
		RecoveredMethod84("ActivityLog");
	}

	[CompilerGenerated]
	private void RecoveredMethod177(object P_0, SelectionChangedEventArgs P_1)
	{
		RecoveredMethod51();
	}

	[CompilerGenerated]
	private void RecoveredMethod178(object P_0, TextChangedEventArgs P_1)
	{
		RecoveredMethod51();
	}

	[CompilerGenerated]
	private void RecoveredMethod179()
	{
		Process.Start("explorer.exe", System.IO.Path.Combine(folder, "logs"));
	}

	[CompilerGenerated]
	private void RecoveredMethod180()
	{
		if (RecoveredMethod79<ListBox>("ActivityList").SelectedItem is ActivityCard activityCard)
		{
			try
			{
				Clipboard.SetText(activityCard.Full);
			}
			catch (Exception ex)
			{
				RecoveredMethod93("Copy failed: " + ex.Message);
			}
		}
	}

	[CompilerGenerated]
	private static RecoveredType174 RecoveredMethod181(RecoveredType137 P_0)
	{
		return P_0.Session.RecoveredMethod509();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod182(RecoveredType82 P_0)
	{
		if (!(P_0.Category == "Stopped"))
		{
			return P_0.Category == "Crash";
		}
		return true;
	}

	[CompilerGenerated]
	private static ActivityCard RecoveredMethod183(RecoveredType82 P_0)
	{
		return new ActivityCard
		{
			Time = RecoveredMethod52(P_0.AtUtc),
			Scope = ((P_0.Account == "") ? "twist" : ("@" + P_0.Account)) + ((P_0.Source == "") ? "" : (" · " + P_0.Source)),
			Kind = P_0.Category + " · " + P_0.Level,
			Message = P_0.Message,
			Color = ((P_0.Level == "Error") ? "#E6A3A3" : ((P_0.Level == "Warning") ? "#E5C27C" : "#BCA7ED"))
		};
	}

	[CompilerGenerated]
	private void RecoveredMethod184(object P_0, SelectionChangedEventArgs P_1)
	{
		RecoveredMethod56();
	}

	[CompilerGenerated]
	private void RecoveredMethod185(object P_0, TextChangedEventArgs P_1)
	{
		RecoveredMethod56();
	}

	[CompilerGenerated]
	private void RecoveredMethod186()
	{
		alertsDirty = true;
		RecoveredMethod146();
	}

	[CompilerGenerated]
	private void RecoveredMethod187()
	{
		try
		{
			alerts.RecoveredMethod414(RecoveredMethod79<PasswordBox>("DiscordUrl").Password.Trim());
			alertsUiError = "";
			RecoveredMethod82("AlertsStatus", "Sending test without pings.");
		}
		catch (Exception ex)
		{
			RecoveredMethod54(ex);
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod188()
	{
		try
		{
			alerts.RecoveredMethod50();
			alertsUiError = "";
			RecoveredMethod82("AlertsStatus", alerts.Status);
		}
		catch (Exception ex)
		{
			RecoveredMethod54(ex);
		}
	}

	[CompilerGenerated]
	private string RecoveredMethod189(FruitStoredRecord P_0)
	{
		if (catalog.TryGetValue(P_0.Name, out var value) && value.IsFruit && value.Rarity != "Unknown")
		{
			return value.Rarity;
		}
		if (!string.IsNullOrEmpty(P_0.Rarity) && !(P_0.Rarity == "Unknown"))
		{
			return P_0.Rarity;
		}
		return RecoveredType219.RecoveredMethod52(P_0.Name);
	}

	[CompilerGenerated]
	private static IEnumerable<WorldFruitRecord> RecoveredMethod190(RecoveredType137 P_0)
	{
		if (P_0.Session.RecoveredMethod509().World != null)
		{
			return P_0.Session.RecoveredMethod509().World.Events;
		}
		return new WorldFruitRecord[0];
	}

	[CompilerGenerated]
	private static IEnumerable<FruitStoredRecord> RecoveredMethod191(RecoveredType137 P_0)
	{
		return P_0.Session.RecoveredMethod509().FruitStores ?? new FruitStoredRecord[0];
	}

	[CompilerGenerated]
	private static void RecoveredMethod192(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod193(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static bool RecoveredMethod194(RecoveredType137 P_0)
	{
		return !(P_0.Session is RecoveredType325);
	}

	[CompilerGenerated]
	private static Task RecoveredMethod195(RecoveredType137 P_0)
	{
		RecoveredType132 recoveredType = (RecoveredType132)P_0.Session;
		recoveredType.RecoveredMethod511().GetAwaiter().GetResult();
		if (recoveredType.State.Attached && P_0.Inventory == null)
		{
			P_0.Inventory = new RecoveredType134();
		}
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private static bool RecoveredMethod196(RecoveredType137 P_0)
	{
		return P_0.Inventory != null;
	}

	[CompilerGenerated]
	private static void RecoveredMethod197()
	{
	}

	[CompilerGenerated]
	private void RecoveredMethod198(object P_0, SelectionChangedEventArgs P_1)
	{
		if (!miniSelection)
		{
			object selectedItem = RecoveredMethod70<ComboBox>("MiniAccounts").SelectedItem;
			RecoveredMethod74();
			RecoveredMethod79<ComboBox>("Clients").SelectedItem = selectedItem;
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod199(object P_0, RoutedEventArgs P_1)
	{
		miniWindow.WindowState = WindowState.Minimized;
	}

	[CompilerGenerated]
	private void RecoveredMethod200(object P_0, RoutedEventArgs P_1)
	{
		miniWindow.Close();
	}

	[CompilerGenerated]
	private void RecoveredMethod201(object P_0, MouseButtonEventArgs P_1)
	{
		if (P_1.ButtonState == MouseButtonState.Pressed)
		{
			miniWindow.DragMove();
		}
	}

	[CompilerGenerated]
	private async void RecoveredMethod202(object P_0, RoutedEventArgs P_1)
	{
		await RecoveredMethod106();
	}

	[CompilerGenerated]
	private async void RecoveredMethod203(object P_0, RoutedEventArgs P_1)
	{
		if (pointPicker != null)
		{
			RecoveredMethod74();
			return;
		}
		await RecoveredMethod106();
		RecoveredType137 row = Selected;
		if (row == null)
		{
			return;
		}
		try
		{
			pickRow = row;
			int token = ++pickToken;
			pointPicker = new RecoveredType344(row.Session.Pid, row.Session.Created, delegate(double num, double num2)
			{
				if (!window.Dispatcher.HasShutdownStarted)
				{
					window.Dispatcher.BeginInvoke((Action)delegate
					{
						RecoveredMethod76(row, num, num2, token);
					});
				}
			});
			RecoveredMethod73();
		}
		catch (Exception ex)
		{
			RecoveredMethod74();
			RecoveredMethod93(ex.Message);
		}
	}

	[CompilerGenerated]
	private async void RecoveredMethod204(object P_0, RoutedEventArgs P_1)
	{
		if (pointPicker != null)
		{
			RecoveredMethod74();
			return;
		}
		await RecoveredMethod106();
		RecoveredType137 row = Selected;
		if (row == null)
		{
			return;
		}
		try
		{
			string bait;
			using (RecoveredType172 recoveredType = new RecoveredType172(row.Session.Pid, row.Session.Created, row.Offsets ?? offsets))
			{
				RecoveredType104 recoveredType2 = recoveredType.RecoveredMethod571(null).RecoveredMethod401();
				bait = RecoveredType106.RecoveredMethod404(recoveredType2.Counts, "best");
				if (bait == null)
				{
					throw new Exception("No bait is available to align.");
				}
				((RecoveredType118)recoveredType.RecoveredMethod571(null)).RecoveredMethod481(bait);
			}
			pickRow = row;
			pickBait = bait;
			int token = ++pickToken;
			pointPicker = new RecoveredType344(row.Session.Pid, row.Session.Created, delegate(double num, double num2)
			{
				if (!window.Dispatcher.HasShutdownStarted)
				{
					window.Dispatcher.BeginInvoke((Action)delegate
					{
						RecoveredMethod75(row, bait, num, num2, token);
					});
				}
			});
			RecoveredMethod73();
		}
		catch (Exception ex)
		{
			RecoveredMethod74();
			RecoveredMethod93(ex.Message);
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod205(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod74();
		RecoveredType137 selected = Selected;
		if (selected == null)
		{
			return;
		}
		try
		{
			RecoveredType170 recoveredType = RecoveredType170.RecoveredMethod569(RecoveredMethod81(selected));
			recoveredType.UiOffsetX = (recoveredType.UiOffsetY = 0.0);
			recoveredType.RecoveredMethod414(RecoveredMethod81(selected));
			profiles[RecoveredMethod80(selected)] = recoveredType;
			RecoveredMethod93("Worker UI alignment reset.");
			RecoveredMethod73();
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod206(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod79<TextBox>("WorkerPairing").Text = RecoveredMethod70<TextBox>("MiniCode").Text;
		RecoveredMethod122();
	}

	[CompilerGenerated]
	private void RecoveredMethod207(object P_0, EventArgs P_1)
	{
		RecoveredMethod165();
	}

	[CompilerGenerated]
	private void RecoveredMethod208(object P_0, DependencyPropertyChangedEventArgs P_1)
	{
		RecoveredMethod165();
	}

	[CompilerGenerated]
	private void RecoveredMethod209(object P_0, CancelEventArgs P_1)
	{
		if (!closing)
		{
			P_1.Cancel = true;
			if (!stopping)
			{
				stopping = true;
				window.Dispatcher.BeginInvoke(new Action(RecoveredMethod90));
			}
		}
	}

	[CompilerGenerated]
	private async void RecoveredMethod210(object P_0, RoutedEventArgs P_1)
	{
		await RecoveredMethod94();
	}

	[CompilerGenerated]
	private static Task RecoveredMethod211(RecoveredType325 P_0, RecoveredType170 P_1)
	{
		return P_0.RecoveredMethod793(P_1);
	}

	[CompilerGenerated]
	private void RecoveredMethod212(object P_0, SelectionChangedEventArgs P_1)
	{
		RecoveredMethod101();
		inventoryDirty = true;
		historyCount = -1;
		RecoveredMethod98();
	}

	[CompilerGenerated]
	private void RecoveredMethod213()
	{
		RecoveredMethod84("Inventory");
	}

	[CompilerGenerated]
	private void RecoveredMethod214()
	{
		RecoveredMethod84("Settings");
	}

	[CompilerGenerated]
	private void RecoveredMethod215()
	{
		RecoveredMethod84("World");
	}

	[CompilerGenerated]
	private void RecoveredMethod216()
	{
		RecoveredMethod84("Connections");
	}

	[CompilerGenerated]
	private void RecoveredMethod217()
	{
		RecoveredMethod84("Inventory");
	}

	[CompilerGenerated]
	private void RecoveredMethod218()
	{
		RecoveredMethod84("Fruits");
	}

	[CompilerGenerated]
	private void RecoveredMethod219()
	{
		RecoveredMethod84("Alerts");
	}

	[CompilerGenerated]
	private void RecoveredMethod220()
	{
		RecoveredMethod84("Session");
	}

	[CompilerGenerated]
	private void RecoveredMethod221()
	{
		RecoveredMethod84("Tracker");
	}

	[CompilerGenerated]
	private void RecoveredMethod222()
	{
		RecoveredMethod84("Settings");
	}

	[CompilerGenerated]
	private void RecoveredMethod223()
	{
		RecoveredMethod119("twist encountered a fatal error.");
	}

	[CompilerGenerated]
	private void RecoveredMethod224()
	{
		window.WindowState = WindowState.Minimized;
	}

	[CompilerGenerated]
	private void RecoveredMethod225()
	{
		window.Close();
	}

	[CompilerGenerated]
	private void RecoveredMethod226(object P_0, MouseButtonEventArgs P_1)
	{
		if (P_1.ClickCount == 2)
		{
			window.WindowState = ((window.WindowState != WindowState.Maximized) ? WindowState.Maximized : WindowState.Normal);
		}
		else if (P_1.ButtonState == MouseButtonState.Pressed)
		{
			window.DragMove();
		}
	}

	[CompilerGenerated]
	private async void RecoveredMethod227(object P_0, RoutedEventArgs P_1)
	{
		await RecoveredMethod94();
	}

	[CompilerGenerated]
	private async void RecoveredMethod228(object P_0, RoutedEventArgs P_1)
	{
		RecoveredType137 row = null;
RecoveredType137[] array = rows.ToArray();
		int num2 = 0;
		goto IL_00f2;
		IL_004f:
		try
		{
			await row.Session.RecoveredMethod511();
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
		num2++;
		goto IL_00f2;
		IL_00f2:
		if (num2 < array.Length)
		{
			row = array[num2];
			goto IL_004f;
		}
	}

	[CompilerGenerated]
	private async void RecoveredMethod229(object P_0, RoutedEventArgs P_1)
	{
		try
		{
			if (IsTotalSelected)
			{
				await RecoveredMethod159();
				return;
			}
			RecoveredType137 selected = Selected;
			if (selected != null && selected.Session.RecoveredMethod509().Running && selected.Session.RecoveredMethod509().AutoFish)
			{
				await selected.Session.RecoveredMethod513();
			}
			else
			{
				RecoveredMethod104(true);
			}
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod230()
	{
		RecoveredMethod104(false);
	}

	[CompilerGenerated]
	private async void RecoveredMethod231(object P_0, RoutedEventArgs P_1)
	{
		await RecoveredMethod106();
	}

	[CompilerGenerated]
	private async void RecoveredMethod232(object P_0, RoutedEventArgs P_1)
	{
		if (RecoveredMethod103(true))
		{
			await RecoveredMethod149();
		}
	}

	[CompilerGenerated]
	private async void RecoveredMethod233(object P_0, RoutedEventArgs P_1)
	{
		RecoveredType137 row = Selected;
		if (row == null)
		{
			return;
		}
		try
		{
			RecoveredMethod93((await row.Session.RecoveredMethod514()).Replace("\r\n", " | "));
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod234()
	{
		Process.Start("explorer.exe", System.IO.Path.Combine(folder, "logs"));
	}

	[CompilerGenerated]
	private void RecoveredMethod235()
	{
		Process.Start("explorer.exe", System.IO.Path.Combine(folder, "profiles"));
	}

	[CompilerGenerated]
	private void RecoveredMethod236(object P_0, CancelEventArgs P_1)
	{
		if (!closing)
		{
			P_1.Cancel = true;
			if (!stopping)
			{
				stopping = true;
				window.Dispatcher.BeginInvoke(new Action(RecoveredMethod90));
			}
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod237(object P_0, EventArgs P_1)
	{
		settingsTimer.Stop();
		timer.Stop();
		liveTimer.Stop();
		RecoveredMethod78(hwnd, 910);
		RecoveredMethod78(hwnd, 911);
		RecoveredMethod78(hwnd, 912);
		RecoveredMethod95();
		foreach (RecoveredType137 row in rows)
		{
			row.Session.Dispose();
			if (row.Inventory != null)
			{
				row.Inventory.Dispose();
			}
		}
		RecoveredMethod131();
		if (alerts != null)
		{
			alerts.Dispose();
		}
		previewQueue.Dispose();
	}

	[CompilerGenerated]
	private void RecoveredMethod238(object P_0, EventArgs P_1)
	{
		RecoveredMethod165();
	}

	[CompilerGenerated]
	private void RecoveredMethod239(object P_0, DependencyPropertyChangedEventArgs P_1)
	{
		RecoveredMethod165();
	}

	[CompilerGenerated]
	private async void RecoveredMethod240(object P_0, RoutedEventArgs P_1)
	{
		await RecoveredMethod94();
	}

	[CompilerGenerated]
	private static KeyValuePair<int, long>[] RecoveredMethod241()
	{
		List<KeyValuePair<int, long>> list = new List<KeyValuePair<int, long>>();
		Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
		foreach (Process process in processesByName)
		{
			using (process)
			{
				try
				{
					if (process.SessionId == RecoveredType309.SessionId)
					{
						list.Add(new KeyValuePair<int, long>(process.Id, process.StartTime.ToUniversalTime().Ticks));
					}
				}
				catch
				{
				}
			}
		}
		return list.ToArray();
	}

	[CompilerGenerated]
	private static IEnumerable<RoundRecord> RecoveredMethod242(RecoveredType137 P_0)
	{
		return P_0.Session.RecoveredMethod510();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod243(RecoveredType137 P_0)
	{
		return P_0.State.Running;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod244(InventoryEntry P_0)
	{
		return P_0.Metadata.IsFish;
	}

	[CompilerGenerated]
	private static int RecoveredMethod245(InventoryEntry P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static double RecoveredMethod246(RoundRecord P_0)
	{
		return P_0.Seconds;
	}

	[CompilerGenerated]
	private static Task RecoveredMethod247(RecoveredType137 P_0)
	{
		return P_0.Session.RecoveredMethod513("Another client started in this input session.");
	}

	[CompilerGenerated]
	private void RecoveredMethod248(string P_0)
	{
		if (!closing)
		{
			RecoveredMethod93("Item metadata could not be saved: " + P_0);
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod249(object P_0, TextChangedEventArgs P_1)
	{
		inventoryDirty = true;
		itemLimit = 200;
		RecoveredMethod115();
	}

	[CompilerGenerated]
	private void RecoveredMethod250(object P_0, SelectionChangedEventArgs P_1)
	{
		inventoryDirty = true;
		itemLimit = 200;
		RecoveredMethod115();
	}

	[CompilerGenerated]
	private void RecoveredMethod251()
	{
		itemLimit += 200;
		inventoryDirty = true;
		RecoveredMethod115();
	}

	[CompilerGenerated]
	private static string RecoveredMethod252(CatchRecord P_0)
	{
		return P_0.UserId ?? "";
	}

	[CompilerGenerated]
	private static int RecoveredMethod253(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static string RecoveredMethod254(ItemMetadata P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static int RecoveredMethod255(CatchRecord P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod256(CatchRecord P_0)
	{
		return P_0.Name != "Unidentified fish";
	}

	[CompilerGenerated]
	private static string RecoveredMethod257(CatchRecord P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static string RecoveredMethod258(CatchRecord P_0)
	{
		return P_0.Id + ":" + P_0.Count + ":" + P_0.Rarity + ":" + P_0.Name;
	}

	[CompilerGenerated]
	private static long RecoveredMethod259(InventoryEntry P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private static int RecoveredMethod260(InventoryEntry P_0)
	{
		return RarityStyle.SortRank(P_0.Metadata.Rarity);
	}

	[CompilerGenerated]
	private static string RecoveredMethod261(InventoryEntry P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static string RecoveredMethod262(InventoryEntry P_0)
	{
		return P_0.Name + ":" + P_0.Count + ":" + P_0.Metadata.Rarity + ":" + P_0.Metadata.IconKey;
	}

	[CompilerGenerated]
	private static string RecoveredMethod263(ItemCard P_0)
	{
		return P_0.Key;
	}

	[CompilerGenerated]
	private static ItemCard RecoveredMethod264(ItemCard P_0)
	{
		return P_0;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod265(RecoveredType137 P_0)
	{
		return !(P_0.Session is RecoveredType325);
	}

	[CompilerGenerated]
	private static RecoveredType131 RecoveredMethod266(RecoveredType137 P_0)
	{
		return P_0.Session;
	}

	[CompilerGenerated]
	private void RecoveredMethod267()
	{
		try
		{
			Clipboard.SetText(RecoveredMethod79<TextBox>("PairingCode").Text);
			RecoveredMethod93("Pairing code copied. Paste it into the worker.");
		}
		catch (Exception ex)
		{
			RecoveredMethod93(ex.Message);
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod268()
	{
		RecoveredMethod119("Worker disconnected by user.");
		if (workerLink != null)
		{
			workerLink.Dispose();
		}
		workerLink = null;
		RecoveredMethod119();
		RecoveredMethod82("NetworkStatus", "Disconnected. Fishing stopped.");
	}

	[CompilerGenerated]
	private void RecoveredMethod269()
	{
		discoveryAt = DateTime.MinValue;
		RecoveredMethod129();
	}

	[CompilerGenerated]
	private void RecoveredMethod270()
	{
		RecoveredMethod93("Recovered a damaged controller pairing file. Workers can reconnect through automatic discovery.");
	}

	[CompilerGenerated]
	private bool RecoveredMethod271()
	{
		if (workerLink != null)
		{
			return workerLink.Connected;
		}
		return false;
	}

	[CompilerGenerated]
	private string RecoveredMethod272()
	{
		return activePairCode;
	}

	[CompilerGenerated]
	private void RecoveredMethod273(string P_0)
	{
		if (window.Dispatcher.HasShutdownStarted)
		{
			return;
		}
		window.Dispatcher.BeginInvoke((Action)delegate
		{
			if (workerLink == null || !workerLink.Connected || !(activePairCode == P_0))
			{
				RecoveredMethod79<TextBox>("WorkerPairing").Text = P_0;
				RecoveredMethod122();
				RecoveredMethod93("Controller discovered through Windows authentication.");
			}
		});
	}

	[CompilerGenerated]
	private static void RecoveredMethod274()
	{
	}

	[CompilerGenerated]
	private RecoveredType311 RecoveredMethod275()
	{
		if (window.Dispatcher.HasShutdownStarted)
		{
			throw new Exception("Worker is closing.");
		}
		return window.Dispatcher.Invoke((Func<RecoveredType311>)RecoveredMethod123);
	}

	[CompilerGenerated]
	private Task<string> RecoveredMethod276(RecoveredType318 P_0)
	{
		if (window.Dispatcher.HasShutdownStarted)
		{
			throw new Exception("Worker is closing.");
		}
		return window.Dispatcher.Invoke(() => RecoveredMethod125(P_0));
	}

	[CompilerGenerated]
	private void RecoveredMethod277()
	{
		RecoveredMethod119();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod278(RecoveredType137 P_0)
	{
		return !(P_0.Session is RecoveredType325);
	}

	[CompilerGenerated]
	private RecoveredType310 RecoveredMethod279(RecoveredType137 P_0)
	{
		RecoveredType170 value;
		try
		{
			if (!profiles.TryGetValue(RecoveredMethod80(P_0), out value))
			{
				value = RecoveredType170.RecoveredMethod569(RecoveredMethod81(P_0));
				profiles[RecoveredMethod80(P_0)] = value;
			}
		}
		catch
		{
			value = new RecoveredType170();
		}
		return new RecoveredType310
		{
			Key = RecoveredMethod124(P_0.Session),
			State = P_0.Session.RecoveredMethod509(),
			Profile = value,
			Rounds = P_0.Session.RecoveredMethod510()
		};
	}

	[CompilerGenerated]
	private static bool RecoveredMethod280(RecoveredType137 P_0)
	{
		return P_0.Inventory != null;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod281(RecoveredType327 P_0)
	{
		return P_0.Connected;
	}

	[CompilerGenerated]
	private static IEnumerable<RecoveredType325> RecoveredMethod282(RecoveredType327 P_0)
	{
		return P_0.RecoveredMethod795();
	}

	[CompilerGenerated]
	private static bool RecoveredMethod283(RecoveredType137 P_0)
	{
		return P_0.Session is RecoveredType325;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod284(RecoveredType327 P_0)
	{
		return P_0.Connected;
	}

	[CompilerGenerated]
	private static int RecoveredMethod285(RecoveredType327 P_0)
	{
		return P_0.SessionId;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod286(RecoveredType327 P_0)
	{
		return P_0.Connected;
	}

	[CompilerGenerated]
	private static string RecoveredMethod287(RecoveredType327 P_0)
	{
		return P_0.Id + ":" + P_0.Connected + ":" + P_0.Desktop + ":" + P_0.RecoveredMethod795().Length + ":" + P_0.RecoveredMethod795().Count((RecoveredType325 recoveredType) => recoveredType.RecoveredMethod509().Attached);
	}

	[CompilerGenerated]
	private static WorkerCard RecoveredMethod288(RecoveredType327 P_0)
	{
		return new WorkerCard
		{
			Title = P_0.User + " · session " + P_0.SessionId,
			Detail = P_0.Name,
			Status = (P_0.Connected ? P_0.Desktop : ("Offline" + ((P_0.Failure == "") ? "" : (" · " + P_0.Failure)))),
			Accounts = P_0.RecoveredMethod795().Count((RecoveredType325 recoveredType) => recoveredType.RecoveredMethod509().Attached) + " Roblox clients"
		};
	}

	[CompilerGenerated]
	private static bool RecoveredMethod289(RecoveredType327 P_0)
	{
		return P_0.Connected;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod290(RecoveredType325 P_0)
	{
		return P_0.RecoveredMethod509().Attached;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod291(RecoveredType325 P_0)
	{
		return P_0.RecoveredMethod509().Attached;
	}

	[CompilerGenerated]
	private void RecoveredMethod292(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod134(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod293(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod134(false);
	}

	[CompilerGenerated]
	private void RecoveredMethod294(object P_0, EventArgs P_1)
	{
		RenderCapability.TierChanged -= RecoveredMethod133;
	}

	[CompilerGenerated]
	private void RecoveredMethod295(object P_0, TextChangedEventArgs P_1)
	{
		RecoveredMethod141(false);
	}

	[CompilerGenerated]
	private void RecoveredMethod296(object P_0, SelectionChangedEventArgs P_1)
	{
		RecoveredMethod141(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod297(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod141(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod298(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod141(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod299(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod142(false);
	}

	[CompilerGenerated]
	private void RecoveredMethod300(object P_0, TextChangedEventArgs P_1)
	{
		RecoveredMethod142(false);
	}

	[CompilerGenerated]
	private void RecoveredMethod301(object P_0, SelectionChangedEventArgs P_1)
	{
		RecoveredMethod142(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod302(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod142(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod303(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod142(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod304(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod143(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod305(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod143(true);
	}

	[CompilerGenerated]
	private void RecoveredMethod306(object P_0, TextChangedEventArgs P_1)
	{
		RecoveredMethod143(false);
	}

	[CompilerGenerated]
	private async void RecoveredMethod307(object P_0, EventArgs P_1)
	{
		if (!stopping && !closing)
		{
			RecoveredMethod148();
			await RecoveredMethod149();
		}
	}

	[CompilerGenerated]
	private static void RecoveredMethod308()
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod309(RecoveredType325 P_0, RecoveredType170 P_1)
	{
		throw new Exception("Simulated disconnected worker");
	}

	[CompilerGenerated]
	private static bool RecoveredMethod310(RecoveredType137 P_0)
	{
		return P_0.Session.RecoveredMethod509().Running;
	}

	[CompilerGenerated]
	private static Task RecoveredMethod311(RecoveredType325 P_0, RecoveredType170 P_1)
	{
		return P_0.RecoveredMethod793(P_1);
	}

	[CompilerGenerated]
	private static void RecoveredMethod312(string P_0)
	{
	}

	[CompilerGenerated]
	private static Task RecoveredMethod313(int P_0, CancellationToken P_1)
	{
		return Task.FromResult(0);
	}

	[CompilerGenerated]
	private void RecoveredMethod314(object P_0, NotifyCollectionChangedEventArgs P_1)
	{
		RecoveredType137[] array = accountChoices.Where((RecoveredType137 recoveredType) => !recoveredType.IsTotal && !rows.Contains(recoveredType)).ToArray();
		foreach (RecoveredType137 item in array)
		{
			accountChoices.Remove(item);
		}
		foreach (RecoveredType137 row in rows)
		{
			if (!accountChoices.Contains(row))
			{
				accountChoices.Add(row);
			}
		}
		if (RecoveredMethod79<ComboBox>("Clients").SelectedItem == null)
		{
			RecoveredMethod79<ComboBox>("Clients").SelectedItem = totalChoice;
		}
		inventoryDirty = true;
	}

	[CompilerGenerated]
	private bool RecoveredMethod315(RecoveredType137 P_0)
	{
		if (!P_0.IsTotal)
		{
			return !rows.Contains(P_0);
		}
		return false;
	}

	[CompilerGenerated]
	private RecoveredType2 RecoveredMethod316(RecoveredType137 P_0)
	{
		return new RecoveredType2
		{
			Key = P_0.Session.InputScope + ":" + P_0.Session.Pid + ":" + P_0.Session.Created,
			Scope = P_0.Session.InputScope,
			Row = P_0,
			State = P_0.Session.RecoveredMethod509(),
			Inventory = ((P_0.Inventory == null) ? null : P_0.Inventory.RecoveredMethod515()),
			Caught = ((!string.IsNullOrEmpty(P_0.State.UserId)) ? RecoveredMethod113(P_0.State.UserId) : 0)
		};
	}

	[CompilerGenerated]
	private static bool RecoveredMethod317(RecoveredType2 P_0)
	{
		return P_0.State.ActiveSeconds >= 30.0;
	}

	[CompilerGenerated]
	private static long RecoveredMethod318(RecoveredType2 P_0)
	{
		return P_0.State.FruitsStored;
	}

	[CompilerGenerated]
	private static long RecoveredMethod319(RecoveredType2 P_0)
	{
		return P_0.State.FruitsDropped;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod9(RecoveredType2 P_0)
	{
		return P_0.State.CommonBait >= 0;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod10(RecoveredType2 P_0)
	{
		return P_0.State.CommonBait >= 0;
	}

	[CompilerGenerated]
	private static long RecoveredMethod320(RecoveredType2 P_0)
	{
		return P_0.State.CommonBait;
	}

	[CompilerGenerated]
	private static TotalAccountCard RecoveredMethod321(RecoveredType2 P_0)
	{
		return new TotalAccountCard
		{
			Account = "@" + P_0.State.Account,
			Status = (P_0.State.Running ? RecoveredMethod97(P_0.State) : ((P_0.State.StopReason != "") ? ("Stopped · " + P_0.State.StopReason) : (P_0.State.Attached ? "Ready" : P_0.State.Status))),
			Caught = P_0.Caught.ToString("N0") + " caught",
			Owned = ((P_0.Inventory == null) ? 0 : P_0.Inventory.Items.Where((InventoryEntry inventoryEntry) => inventoryEntry.Metadata.IsFish).Sum((Func<InventoryEntry, long>)((InventoryEntry inventoryEntry) => inventoryEntry.Count))).ToString("N0") + " owned",
			Rate = ((P_0.State.ActiveSeconds >= 30.0) ? (((double)P_0.Caught * 3600.0 / P_0.State.ActiveSeconds).ToString("0.0") + " / hr") : "— / hr")
		};
	}

	[CompilerGenerated]
	private static string RecoveredMethod322(TotalAccountCard P_0)
	{
		return P_0.Account + P_0.Status + P_0.Caught + P_0.Owned + P_0.Rate;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod323(InventoryEntry P_0)
	{
		return P_0.Metadata.IsFish;
	}

	[CompilerGenerated]
	private static long RecoveredMethod324(InventoryEntry P_0)
	{
		return P_0.Count;
	}

	[CompilerGenerated]
	private async Task RecoveredMethod325(RecoveredType2 P_0)
	{
		RecoveredType137 row = P_0.Row;
		RecoveredType170 profile = ((row.Session is RecoveredType325 remote) ? remote.Profile.RecoveredMethod568() : RecoveredType170.RecoveredMethod569(RecoveredMethod81(row)));
		await row.Session.RecoveredMethod512(profile, true);
	}

	[CompilerGenerated]
	private static bool RecoveredMethod326(RecoveredType2 P_0)
	{
		if (P_0.State.Attached)
		{
			return !P_0.State.Running;
		}
		return false;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod327(ItemCard P_0)
	{
		return P_0.Name == "Ope";
	}

	[CompilerGenerated]
	private static bool RecoveredMethod328(ItemCard P_0)
	{
		return P_0.Icon == null;
	}

	[CompilerGenerated]
	private void RecoveredMethod329(object P_0, EventArgs P_1)
	{
		RecoveredMethod164();
	}

	[CompilerGenerated]
	private static int RecoveredMethod330(string P_0, string P_1)
	{
		return P_1.Length.CompareTo(P_0.Length);
	}

	[CompilerGenerated]
	private static IEnumerable<WorldFruitRecord> RecoveredMethod331(RecoveredType137 P_0)
	{
		if (P_0.Session.RecoveredMethod509().World != null)
		{
			return P_0.Session.RecoveredMethod509().World.Events;
		}
		return new WorldFruitRecord[0];
	}

	[CompilerGenerated]
	private static WorldFruitCard RecoveredMethod332(WorldFruitRecord P_0)
	{
		DateTime result;
		return new WorldFruitCard
		{
			Time = (DateTime.TryParse(P_0.AtUtc, null, DateTimeStyles.RoundtripKind, out result) ? result.ToLocalTime().ToString("MMM d · HH:mm:ss") : ""),
			Announcement = (P_0.Announcement ?? (P_0.Name + " spawned")),
			Name = P_0.Name + " spawned",
			Coordinates = "Coords: " + ((P_0.Position == null) ? "Unavailable" : P_0.Position.Compact),
			Detail = P_0.Rarity + " · " + P_0.Hub + " · " + string.Join(", ", (P_0.Observers ?? new string[1] { P_0.Account }).Select((string text) => "@" + text))
		};
	}

	[CompilerGenerated]
	private static string RecoveredMethod333(string P_0)
	{
		return "@" + P_0;
	}

	[CompilerGenerated]
	private static WorldWorkerCard RecoveredMethod334(RecoveredType137 P_0)
	{
		RecoveredType174 recoveredType = P_0.Session.RecoveredMethod509();
		WorldSnapshot worldSnapshot = recoveredType.World ?? new WorldSnapshot();
		bool flag = recoveredType.Attached && worldSnapshot.Valid && DateTime.UtcNow - worldSnapshot.Updated < TimeSpan.FromSeconds(5.0);
		return new WorldWorkerCard
		{
			Account = "@" + recoveredType.Account,
			Coordinates = ((worldSnapshot.Position == null) ? "Position unavailable" : worldSnapshot.Position.Label),
			Timer = (worldSnapshot.HasEye ? worldSnapshot.EyeDescription : "All Seeing Eye timer unavailable"),
			Status = (flag ? worldSnapshot.Hub : "Last seen / unavailable") + ((P_0.Session is RecoveredType325) ? (" · S" + ((RecoveredType325)P_0.Session).Peer.SessionId) : "")
		};
	}

	[CompilerGenerated]
	private static string RecoveredMethod335(WorldWorkerCard P_0)
	{
		return P_0.Account + P_0.Coordinates + P_0.Timer + P_0.Status;
	}

	[CompilerGenerated]
	private static IEnumerable<J<WorldFruitRecord, WorldSnapshot, string>> RecoveredMethod336(RecoveredType137 P_0)
	{
		RecoveredType174 state = P_0.Session.RecoveredMethod509();
		WorldSnapshot world = state.World ?? new WorldSnapshot();
		if (!state.Attached || !world.Valid || !(DateTime.UtcNow - world.Updated < TimeSpan.FromSeconds(5.0)))
		{
			return new WorldFruitRecord[0].Select((WorldFruitRecord worldFruitRecord) => new J<WorldFruitRecord, WorldSnapshot, string>(worldFruitRecord, world, state.Account)).ToArray();
		}
		return world.Fruits.Select((WorldFruitRecord worldFruitRecord) => new J<WorldFruitRecord, WorldSnapshot, string>(worldFruitRecord, world, state.Account)).ToArray();
	}

	[CompilerGenerated]
	private static string RecoveredMethod337(J<WorldFruitRecord, WorldSnapshot, string> P_0)
	{
		return P_0.Fruit.Fingerprint();
	}

	[CompilerGenerated]
	private static J<WorldFruitRecord, WorldSnapshot, string> RecoveredMethod338(IGrouping<string, J<WorldFruitRecord, WorldSnapshot, string>> P_0)
	{
		return P_0.First();
	}

	[CompilerGenerated]
	private static WorldFruitCard RecoveredMethod339(J<WorldFruitRecord, WorldSnapshot, string> P_0)
	{
		WorldFruitRecord fruit = P_0.Fruit;
		WorldPoint position = P_0.World.Position;
		return new WorldFruitCard
		{
			Announcement = (fruit.Announcement ?? ""),
			Name = fruit.Name + " spawned",
			Coordinates = "Coords: " + ((fruit.Position == null) ? "Waiting for pulse target" : fruit.Position.Compact),
			Detail = fruit.Rarity + " · " + fruit.Hub + " · @" + P_0.Account + ((!(fruit.Source == "Eye pulse")) ? (fruit.Visible ? " · tap pickup" : " · last seen, outside current view") : (fruit.Visible ? " · Eye pulse target" : " · last known pulse target")),
			Direction = ((position == null || fruit.Position == null) ? "" : (position.Distance(fruit.Position).ToString("0", CultureInfo.InvariantCulture) + " studs away · ΔX " + (fruit.Position.RecoveredField2015 - position.RecoveredField2015).ToString("+0;-0;0", CultureInfo.InvariantCulture) + "  ΔY " + (fruit.Position.RecoveredField2016 - position.RecoveredField2016).ToString("+0;-0;0", CultureInfo.InvariantCulture) + "  ΔZ " + (fruit.Position.RecoveredField2017 - position.RecoveredField2017).ToString("+0;-0;0", CultureInfo.InvariantCulture)))
		};
	}

	[CompilerGenerated]
	private static string RecoveredMethod340(WorldFruitCard P_0)
	{
		return P_0.Name;
	}

	[CompilerGenerated]
	private static string RecoveredMethod341(WorldFruitCard P_0)
	{
		return P_0.Announcement + P_0.Name + P_0.Coordinates + P_0.Detail + P_0.Direction;
	}
}
