using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace a;

internal static class RecoveredType220
{
	public static string RecoveredMethod381(string P_0)
	{
		if (!RecoveredType219.RecoveredMethod39(P_0))
		{
			return "";
		}
		if (P_0.Equals("Bomu", StringComparison.OrdinalIgnoreCase))
		{
			P_0 = "Bomb";
		}
		if (P_0.Equals("Pteranodon", StringComparison.OrdinalIgnoreCase))
		{
			P_0 = "Ptero";
		}
		string[] files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "fruits"), "*-fruit-preview.png");
		foreach (string text in files)
		{
			if (Path.GetFileName(text).Equals(P_0 + "-fruit-preview.png", StringComparison.OrdinalIgnoreCase))
			{
				return text;
			}
		}
		return "";
	}

	public static BitmapSource RecoveredMethod632(string P_0)
	{
		string text = RecoveredMethod381(P_0);
		if (text == "" || !File.Exists(text))
		{
			throw new Exception("Colored fruit icon is unavailable.");
		}
		using FileStream bitmapStream = File.OpenRead(text);
		BitmapFrame bitmapFrame = BitmapFrame.Create(bitmapStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
		bitmapFrame.Freeze();
		int num = Math.Max(bitmapFrame.PixelWidth, bitmapFrame.PixelHeight);
		if (num > 256)
		{
			double num2 = 256.0 / (double)num;
			TransformedBitmap transformedBitmap = new TransformedBitmap(bitmapFrame, new ScaleTransform(num2, num2));
			transformedBitmap.Freeze();
			return transformedBitmap;
		}
		return bitmapFrame;
	}
}
