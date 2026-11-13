using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace A;

internal sealed class RecoveredType13
{
	[CompilerGenerated]
	private sealed class RecoveredType14
	{
		public RecoveredType2 info;

		public Action<int> progress;

		public CancellationToken token;

		public RecoveredType13 _003C_003E4__this;

		public string RecoveredMethod55()
		{
			RecoveredType26.RecoveredMethod64(_003C_003E4__this.folder);
			string text = RecoveredType3.RecoveredMethod8(_003C_003E4__this.folder, info, token, progress);
			return RecoveredType26.RecoveredMethod66(_003C_003E4__this.folder, text, info, token);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType19
	{
		public int percent;

		public RecoveredType13 _003C_003E4__this;

		public void RecoveredMethod11()
		{
			if (!_003C_003E4__this.updateStop.IsCancellationRequested)
			{
				_003C_003E4__this.RecoveredMethod35<TextBlock>("AppUpdateStatus").Text = "Downloading twist " + _003C_003E4__this.availableUpdate.Version + " · " + percent + "%";
			}
		}
	}

	public readonly Window Window;

	private readonly string folder;

	private readonly string preference;

	private readonly Action<ProcessStartInfo> start;

	private readonly CancellationTokenSource updateStop = new CancellationTokenSource();

	private RecoveredType2 availableUpdate;

	private bool updating;

	private bool startupChecked;

	private bool offsetsChecking;

	internal Func<RecoveredType2, Action<int>, CancellationToken, Task<string>> prepareUpdate;

	[CompilerGenerated]
	private RecoveredType11 _003CSelected_003Ek__BackingField;

	public RecoveredType11 Selected
	{
		[CompilerGenerated]
		get
		{
			return _003CSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CSelected_003Ek__BackingField = value;
		}
	}

	private A RecoveredMethod35<A>(string P_0) where A : FrameworkElement
	{
		return (A)Window.FindName(P_0);
	}

	public RecoveredType13(string P_0, string P_1, Action<ProcessStartInfo> P_2)
	{
		folder = P_0;
		preference = P_1;
		start = P_2;
		using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TwistLauncher.Main.xaml"))
		{
			if (stream == null)
			{
				throw new Exception("Launcher layout is missing.");
			}
			Window = (Window)XamlReader.Load(stream);
		}
		try
		{
			Window.Icon = BitmapFrame.Create(new Uri(Path.Combine(folder, "app", "twist.ico")));
		}
		catch
		{
		}
		RecoveredMethod35<Grid>("TitleBar").MouseLeftButtonDown += delegate(object obj2, MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed)
			{
				Window.DragMove();
			}
		};
		RecoveredMethod35<Button>("CloseButton").Click += delegate
		{
			Window.Close();
		};
		RecoveredMethod35<RadioButton>("WorkerChoice").Checked += delegate
		{
			RecoveredMethod37(RecoveredType11.Worker);
		};
		RecoveredMethod35<RadioButton>("ControllerChoice").Checked += delegate
		{
			RecoveredMethod37(RecoveredType11.Controller);
		};
		RecoveredMethod35<RadioButton>("LocalChoice").Checked += delegate
		{
			RecoveredMethod37(RecoveredType11.Local);
		};
		RecoveredMethod35<Button>("LaunchButton").Click += delegate
		{
			RecoveredMethod20();
		};
		RecoveredMethod36(RecoveredType12.RecoveredMethod33(preference));
		RecoveredMethod21();
	}

	public void RecoveredMethod36(RecoveredType11 P_0)
	{
		RecoveredMethod35<RadioButton>(P_0 switch
		{
			RecoveredType11.Controller => "ControllerChoice", 
			RecoveredType11.Worker => "WorkerChoice", 
			_ => "LocalChoice", 
		}).IsChecked = true;
	}

	private void RecoveredMethod37(RecoveredType11 P_0)
	{
		Selected = P_0;
		RecoveredMethod35<CheckBox>("AdminChoice").Visibility = ((P_0 != RecoveredType11.Controller) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod35<Button>("LaunchButton").Content = "Open " + P_0.ToString().ToLowerInvariant();
		RecoveredMethod35<TextBlock>("Status").Visibility = Visibility.Collapsed;
	}

	private static bool RecoveredMethod38()
	{
		using WindowsIdentity ntIdentity = WindowsIdentity.GetCurrent();
		return new WindowsPrincipal(ntIdentity).IsInRole(WindowsBuiltInRole.Administrator);
	}

	private void RecoveredMethod20()
	{
		if (updating)
		{
			return;
		}
		Button button = RecoveredMethod35<Button>("LaunchButton");
		button.IsEnabled = false;
		try
		{
			if (RecoveredType12.RecoveredMethod34(folder, Selected, RecoveredMethod35<CheckBox>("AdminChoice").IsChecked == true, RecoveredMethod38(), preference, start, out var text))
			{
				Window.Close();
				return;
			}
			RecoveredMethod35<TextBlock>("Status").Text = text;
			RecoveredMethod35<TextBlock>("Status").Visibility = Visibility.Visible;
		}
		finally
		{
			button.IsEnabled = true;
		}
	}

	public void RecoveredMethod39(string P_0)
	{
		FrameworkElement frameworkElement = (FrameworkElement)Window.Content;
		frameworkElement.Width = 420.0;
		frameworkElement.Measure(new Size(420.0, double.PositiveInfinity));
		double num = Math.Ceiling(frameworkElement.DesiredSize.Height);
		frameworkElement.Arrange(new Rect(0.0, 0.0, 420.0, num));
		frameworkElement.UpdateLayout();
		RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(420, (int)num, 96.0, 96.0, PixelFormats.Pbgra32);
		renderTargetBitmap.Render(frameworkElement);
		PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
		pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
		using FileStream stream = File.Create(P_0);
		pngBitmapEncoder.Save(stream);
	}

	private void RecoveredMethod21()
	{
		prepareUpdate = (RecoveredType2 P_0, Action<int> P_1, CancellationToken P_2) => Task.Run(delegate
		{
			RecoveredType26.RecoveredMethod64(folder);
			string text = RecoveredType3.RecoveredMethod8(folder, P_0, P_2, P_1);
			return RecoveredType26.RecoveredMethod66(folder, text, P_0, P_2);
		});
		RecoveredMethod35<Button>("DownloadUpdate").Click += async delegate
		{
			await RecoveredMethod42();
		};
		Window.Closed += delegate
		{
			updateStop.Cancel();
		};
		Window.Loaded += async delegate
		{
			if (!startupChecked)
			{
				startupChecked = true;
				Task offsets = RecoveredMethod40();
				Task application = RecoveredMethod41();
				await Task.WhenAll(offsets, application);
			}
		};
	}

	private async Task RecoveredMethod40()
	{
		Button button = RecoveredMethod35<Button>("LaunchButton");
		offsetsChecking = true;
		button.IsEnabled = false;
		try
		{
			int num = default(int);
			_ = num;
			_ = 0;
			try
			{
				string status = await Task.Run(() => RecoveredType29.RecoveredMethod5(File.ReadAllText(Path.Combine(folder, "app", "offsets.json"))));
				if (!updateStop.IsCancellationRequested)
				{
					RecoveredMethod35<TextBlock>("UpdateStatus").Text = status;
					RecoveredMethod35<TextBlock>("UpdateStatus").ToolTip = "Latest validated offsets are downloaded on each launch. Each Roblox client uses its matching version; cached/bundled offsets remain available offline.";
				}
			}
			catch
			{
				if (!updateStop.IsCancellationRequested)
				{
					RecoveredMethod35<TextBlock>("UpdateStatus").Text = "Offset check unavailable; using matching cached or bundled offsets.";
				}
			}
		}
		finally
		{
			offsetsChecking = false;
			if (!updateStop.IsCancellationRequested && !updating)
			{
				button.IsEnabled = true;
			}
		}
	}

	private async Task RecoveredMethod41()
	{
		int num = default(int);
		_ = num;
		_ = 0;
		try
		{
			RecoveredType2 release = await Task.Run(() => RecoveredType3.RecoveredMethod4());
			if (!updateStop.IsCancellationRequested)
			{
				RecoveredMethod2(release);
			}
		}
		catch
		{
			if (!updateStop.IsCancellationRequested)
			{
				RecoveredMethod35<TextBlock>("AppUpdateStatus").Text = "App update check unavailable. You can still open twist.";
			}
		}
	}

	internal void RecoveredMethod2(RecoveredType2 P_0)
	{
		RecoveredType3.RecoveredMethod2(P_0);
		availableUpdate = ((P_0.Number > RecoveredType3.Installed) ? P_0 : null);
		RecoveredMethod35<Button>("DownloadUpdate").Visibility = ((availableUpdate == null) ? Visibility.Collapsed : Visibility.Visible);
		RecoveredMethod35<TextBlock>("AppUpdateStatus").Text = ((availableUpdate == null) ? "twist is up to date." : ("twist " + P_0.Version + " is available. Download and update this folder?"));
	}

	internal async Task RecoveredMethod42()
	{
		if (updating || availableUpdate == null)
		{
			return;
		}
		updating = true;
		Button update = RecoveredMethod35<Button>("DownloadUpdate");
		Button launch = RecoveredMethod35<Button>("LaunchButton");
		bool isEnabled = (launch.IsEnabled = false);
		update.IsEnabled = isEnabled;
		try
		{
			int num = default(int);
			_ = num;
			_ = 0;
			try
			{
				RecoveredMethod35<TextBlock>("AppUpdateStatus").Text = "Preparing update… Close controllers/workers using this folder.";
				Action<int> progress = delegate(int P_0)
				{
					if (!Window.Dispatcher.HasShutdownStarted && !updateStop.IsCancellationRequested)
					{
						Window.Dispatcher.BeginInvoke((Action)delegate
						{
							if (!updateStop.IsCancellationRequested)
							{
								RecoveredMethod35<TextBlock>("AppUpdateStatus").Text = "Downloading twist " + availableUpdate.Version + " · " + P_0 + "%";
							}
						});
					}
				};
				string plan = await prepareUpdate(availableUpdate, progress, updateStop.Token);
				updateStop.Token.ThrowIfCancellationRequested();
				RecoveredMethod35<TextBlock>("AppUpdateStatus").Text = "Installing update in this folder…";
				start(RecoveredType26.RecoveredMethod67(plan));
				Window.Close();
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception ex2)
			{
				if (!updateStop.IsCancellationRequested)
				{
					RecoveredMethod35<TextBlock>("AppUpdateStatus").Text = ((ex2 is WebException) ? "Download failed. Check your connection and try again." : ex2.Message);
					update.Content = "Try update again";
				}
			}
		}
		finally
		{
			updating = false;
			if (!updateStop.IsCancellationRequested)
			{
				update.IsEnabled = true;
				launch.IsEnabled = !offsetsChecking;
			}
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod43(object P_0, MouseButtonEventArgs P_1)
	{
		if (P_1.ButtonState == MouseButtonState.Pressed)
		{
			Window.DragMove();
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod44(object P_0, RoutedEventArgs P_1)
	{
		Window.Close();
	}

	[CompilerGenerated]
	private void RecoveredMethod45(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod37(RecoveredType11.Worker);
	}

	[CompilerGenerated]
	private void RecoveredMethod46(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod37(RecoveredType11.Controller);
	}

	[CompilerGenerated]
	private void RecoveredMethod47(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod37(RecoveredType11.Local);
	}

	[CompilerGenerated]
	private void RecoveredMethod48(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod20();
	}

	[CompilerGenerated]
	private Task<string> RecoveredMethod49(RecoveredType2 P_0, Action<int> P_1, CancellationToken P_2)
	{
		return Task.Run(delegate
		{
			RecoveredType26.RecoveredMethod64(folder);
			string text = RecoveredType3.RecoveredMethod8(folder, P_0, P_2, P_1);
			return RecoveredType26.RecoveredMethod66(folder, text, P_0, P_2);
		});
	}

	[CompilerGenerated]
	private async void RecoveredMethod50(object P_0, RoutedEventArgs P_1)
	{
		await RecoveredMethod42();
	}

	[CompilerGenerated]
	private void RecoveredMethod51(object P_0, EventArgs P_1)
	{
		updateStop.Cancel();
	}

	[CompilerGenerated]
	private async void RecoveredMethod52(object P_0, RoutedEventArgs P_1)
	{
		if (!startupChecked)
		{
			startupChecked = true;
			Task offsets = RecoveredMethod40();
			Task application = RecoveredMethod41();
			await Task.WhenAll(offsets, application);
		}
	}

	[CompilerGenerated]
	private string RecoveredMethod53()
	{
		return RecoveredType29.RecoveredMethod5(File.ReadAllText(Path.Combine(folder, "app", "offsets.json")));
	}

	[CompilerGenerated]
	private static RecoveredType2 RecoveredMethod54()
	{
		return RecoveredType3.RecoveredMethod4();
	}

	[CompilerGenerated]
	private void RecoveredMethod31(int P_0)
	{
		if (Window.Dispatcher.HasShutdownStarted || updateStop.IsCancellationRequested)
		{
			return;
		}
		Window.Dispatcher.BeginInvoke((Action)delegate
		{
			if (!updateStop.IsCancellationRequested)
			{
				RecoveredMethod35<TextBlock>("AppUpdateStatus").Text = "Downloading twist " + availableUpdate.Version + " · " + P_0 + "%";
			}
		});
	}
}
