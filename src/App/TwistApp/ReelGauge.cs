using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace TwistApp;

public sealed class ReelGauge : FrameworkElement
{
	private bool enabled = true;

	private bool subscribed;

	private TimeSpan lastFrame;

	private double drawnPlayer = 0.5;

	private double drawnFish = 0.5;

	private static readonly Brush trackBrush = RecoveredMethod490(Color.FromRgb(33, 34, 40));

	private static readonly Brush fillBrush = RecoveredMethod490(Color.FromArgb(110, 184, 161, 242));

	private static readonly Pen outline = RecoveredMethod493(RecoveredMethod490(Color.FromRgb(193, 172, 249)), 1.0);

	private static readonly Pen targetPen = RecoveredMethod493(Brushes.White, 2.0);

	private double player = 0.5;

	private double fish = 0.5;

	private double height = 0.25;

	private bool active;

	private static Brush RecoveredMethod490(Color P_0)
	{
		SolidColorBrush solidColorBrush = new SolidColorBrush(P_0);
		solidColorBrush.Freeze();
		return solidColorBrush;
	}

	private static Pen RecoveredMethod493(Brush P_0, double P_1)
	{
		Pen pen = new Pen(P_0, P_1);
		pen.Freeze();
		return pen;
	}

	public ReelGauge()
	{
		DependencyPropertyChangedEventHandler value = delegate
		{
			RecoveredMethod50();
		};
		base.IsVisibleChanged += value;
		base.Unloaded += delegate
		{
			RecoveredMethod45();
		};
	}

	public void SetPresentationEnabled(bool value)
	{
		enabled = value;
		RecoveredMethod50();
	}

	private void RecoveredMethod45()
	{
		if (subscribed)
		{
			CompositionTarget.Rendering -= RecoveredMethod133;
			subscribed = false;
		}
		lastFrame = TimeSpan.Zero;
	}

	private void RecoveredMethod50()
	{
		if (enabled && base.IsVisible && active)
		{
			if (!subscribed)
			{
				CompositionTarget.Rendering += RecoveredMethod133;
				subscribed = true;
				lastFrame = TimeSpan.Zero;
			}
		}
		else
		{
			RecoveredMethod45();
		}
	}

	private void RecoveredMethod133(object P_0, EventArgs P_1)
	{
		RenderingEventArgs e = (RenderingEventArgs)P_1;
		double num = ((lastFrame == TimeSpan.Zero) ? (1.0 / 60.0) : (e.RenderingTime - lastFrame).TotalSeconds);
		if (num <= 0.0)
		{
			return;
		}
		lastFrame = e.RenderingTime;
		double num2 = 1.0 - Math.Exp((0.0 - Math.Min(0.1, num)) * 24.0);
		if (drawnPlayer != player || drawnFish != fish)
		{
			drawnPlayer += (player - drawnPlayer) * num2;
			drawnFish += (fish - drawnFish) * num2;
			if (Math.Abs(drawnPlayer - player) < 0.0001)
			{
				drawnPlayer = player;
			}
			if (Math.Abs(drawnFish - fish) < 0.0001)
			{
				drawnFish = fish;
			}
			InvalidateVisual();
		}
	}

	public void Update(double p, double f, double h, bool show)
	{
		if (player != p || fish != f || height != h || active != show)
		{
			player = p;
			fish = f;
			height = h;
			active = show;
			RecoveredMethod50();
			if (!subscribed)
			{
				drawnPlayer = p;
				drawnFish = f;
			}
			InvalidateVisual();
		}
	}

	protected override void OnRender(DrawingContext dc)
	{
		double actualWidth = base.ActualWidth;
		double actualHeight = base.ActualHeight;
		if (!(actualWidth < 10.0) && !(actualHeight < 10.0))
		{
			dc.DrawRoundedRectangle(rectangle: new Rect(actualWidth / 2.0 - 9.0, 0.0, 18.0, actualHeight), brush: trackBrush, pen: null, radiusX: 9.0, radiusY: 9.0);
			if (active)
			{
				double num = Math.Max(12.0, actualHeight * height);
				dc.DrawRoundedRectangle(fillBrush, outline, new Rect(actualWidth / 2.0 - 8.0, Math.Max(0.0, Math.Min(actualHeight - num, drawnPlayer * actualHeight - num / 2.0)), 16.0, num), 5.0, 5.0);
				double y = Math.Max(2.0, Math.Min(actualHeight - 2.0, drawnFish * actualHeight));
				dc.DrawLine(targetPen, new Point(actualWidth / 2.0 - 15.0, y), new Point(actualWidth / 2.0 + 15.0, y));
			}
		}
	}

	[CompilerGenerated]
	private void RecoveredMethod208(object P_0, DependencyPropertyChangedEventArgs P_1)
	{
		RecoveredMethod50();
	}

	[CompilerGenerated]
	private void RecoveredMethod199(object P_0, RoutedEventArgs P_1)
	{
		RecoveredMethod45();
	}
}
