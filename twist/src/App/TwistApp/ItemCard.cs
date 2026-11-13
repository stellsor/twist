using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TwistApp;

public sealed class ItemCard : INotifyPropertyChanged
{
	private BitmapSource icon;

	private string status = "Loading preview…";

	public string Name { get; set; }

	public int Count { get; set; }

	public string Rarity { get; set; }

	public string Category { get; set; }

	public string Key { get; set; }

	public string Quantity => "×" + Count.ToString("N0");

	public Brush RarityBrush => RarityStyle.Brush(Rarity);

	public BitmapSource Icon => icon;

	public string PreviewStatus
	{
		get
		{
			if (icon != null)
			{
				return "";
			}
			return status;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public void SetCount(int value)
	{
		if (Count != value)
		{
			Count = value;
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs("Quantity"));
			}
		}
	}

	public void SetIcon(BitmapSource value, string error)
	{
		icon = value;
		status = ((value != null) ? "" : ((error == "Waiting for worker preview") ? "Waiting for worker…" : "Preview unavailable"));
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(null));
		}
	}
}
