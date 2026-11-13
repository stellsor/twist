using System.Windows.Media;

namespace A;

internal static class RecoveredType122
{
	public static readonly Brush Active = RecoveredMethod490(Color.FromRgb(190, 170, 243));

	public static readonly Brush Idle = RecoveredMethod490(Color.FromRgb(119, 119, 128));

	public static readonly Brush Connected = RecoveredMethod490(Color.FromRgb(155, 205, 171));

	public static readonly Brush Disconnected = RecoveredMethod490(Color.FromRgb(119, 114, 128));

	private static Brush RecoveredMethod490(Color P_0)
	{
		SolidColorBrush solidColorBrush = new SolidColorBrush(P_0);
		solidColorBrush.Freeze();
		return solidColorBrush;
	}
}
