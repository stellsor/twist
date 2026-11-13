using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace TwistApp;

public sealed class TrackingChart : FrameworkElement
{
	public IList<ChartPoint> Points = new List<ChartPoint>();

	public double CurrentTime;

	private static readonly Brush faint = new SolidColorBrush(Color.FromRgb(40, 41, 47));

	private static readonly Brush muted = new SolidColorBrush(Color.FromRgb(110, 112, 124));

	private static readonly Brush bar = new SolidColorBrush(Color.FromRgb(186, 166, 245));

	private static readonly Brush fish = new SolidColorBrush(Color.FromRgb(180, 183, 193));

	private int pointCount;

	private double lastPoint = double.NaN;

	public void Update(IList<ChartPoint> points, double time)
	{
		double num = ((points.Count == 0) ? double.NaN : points[points.Count - 1].Time);
		bool flag = points.Count < 2 || num < time - 30.0;
		bool flag2 = Points.Count < 2 || lastPoint < CurrentTime - 30.0;
		if (!object.ReferenceEquals(Points, points) || pointCount != points.Count || (num != lastPoint && (!double.IsNaN(num) || !double.IsNaN(lastPoint))) || ((!flag || !flag2) && !(Math.Abs(time - CurrentTime) < 0.05)))
		{
			Points = points;
			pointCount = points.Count;
			lastPoint = num;
			CurrentTime = time;
			InvalidateVisual();
		}
	}

	protected override void OnRender(DrawingContext dc)
	{
		base.OnRender(dc);
		double actualWidth = base.ActualWidth;
		double num = base.ActualHeight - 22.0;
		if (!(actualWidth < 10.0) && !(num < 10.0))
		{
			for (int i = 0; i < 3; i++)
			{
				double y = 8.0 + (num - 16.0) * (double)i / 2.0;
				dc.DrawLine(new Pen(faint, 1.0), new Point(0.0, y), new Point(actualWidth, y));
			}
			RecoveredMethod492(dc, "30s ago", 0.0, num + 5.0, muted, 10.0);
			RecoveredMethod492(dc, "now", Math.Max(0.0, actualWidth - 23.0), num + 5.0, muted, 10.0);
			if (Points.Count < 2 || Points[Points.Count - 1].Time < CurrentTime - 30.0)
			{
				RecoveredMethod492(dc, "Your next reel will appear here.", Math.Max(0.0, actualWidth / 2.0 - 88.0), num / 2.0 - 8.0, muted, 11.0);
				return;
			}
			double currentTime = CurrentTime;
			double num2 = currentTime - 30.0;
			RecoveredMethod491(dc, num2, currentTime, actualWidth, num, false, new Pen(fish, 1.3));
			RecoveredMethod491(dc, num2, currentTime, actualWidth, num, true, new Pen(bar, 2.0));
		}
	}

	private void RecoveredMethod491(DrawingContext P_0, double P_1, double P_2, double P_3, double P_4, bool P_5, Pen P_6)
	{
		StreamGeometry streamGeometry = new StreamGeometry();
		using (StreamGeometryContext streamGeometryContext = streamGeometry.Open())
		{
			bool flag = false;
			double num = -100.0;
			foreach (ChartPoint point2 in Points)
			{
				if (!(point2.Time < P_1))
				{
					double num2 = Math.Max(0.0, Math.Min(1.0, P_5 ? point2.Player : point2.Fish));
					Point point = new Point((point2.Time - P_1) / 30.0 * P_3, 8.0 + num2 * (P_4 - 16.0));
					if (!flag || point2.Time - num > 0.6)
					{
						streamGeometryContext.BeginFigure(point, isFilled: false, isClosed: false);
						flag = true;
					}
					else
					{
						streamGeometryContext.LineTo(point, isStroked: true, isSmoothJoin: false);
					}
					num = point2.Time;
				}
			}
		}
		streamGeometry.Freeze();
		P_0.DrawGeometry(null, P_6, streamGeometry);
	}

	private void RecoveredMethod492(DrawingContext P_0, string P_1, double P_2, double P_3, Brush P_4, double P_5)
	{
		P_0.DrawText(new FormattedText(P_1, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Segoe UI"), P_5, P_4, VisualTreeHelper.GetDpi(this).PixelsPerDip), new Point(P_2, P_3));
	}
}
