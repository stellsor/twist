using System.Windows.Media;

namespace TwistApp;

public sealed class RarityTotal
{
	public string Name { get; set; }

	public int Count { get; set; }

	public Brush Color => RarityStyle.Brush(Name);
}
