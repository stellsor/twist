using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TwistApp;

namespace a;

internal static class RecoveredType221
{
	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Fruit icon test: " + P_1);
		}
	}

	public static void RecoveredMethod45()
	{
		string[] array = "Kilo Suke Spin Heal Bari Mero Horo Gomu Bomb Yomi Spring Kira Zushi Gura Suna Hie Ito Goro Paw Mera Kage Magu Pika Yami Yuki Goru Smoke Biscuit Tori Mochi Ope Venom Buddha Ptero Dragon Soul Leopard".Split(' ');
		string[] array2 = array;
		foreach (string text in array2)
		{
			BitmapSource bitmapSource = RecoveredType220.RecoveredMethod632(text);
			RecoveredMethod42(bitmapSource.PixelWidth > 1 && bitmapSource.PixelHeight > 1 && bitmapSource.PixelWidth <= 256 && bitmapSource.PixelHeight <= 256, "Bundled PNG decodes within the RDP image bound: " + text);
		}
		RecoveredMethod42(RecoveredType220.RecoveredMethod381("Bomu") == RecoveredType220.RecoveredMethod381("Bomb") && RecoveredType220.RecoveredMethod381("Pteranodon") == RecoveredType220.RecoveredMethod381("Ptero"), "Internal fruit aliases use the same icon");
		RecoveredMethod42(RecoveredType220.RecoveredMethod381("Fruit Bag") == "" && RecoveredType220.RecoveredMethod381("../../Ope") == "", "Equipment and arbitrary paths cannot select fruit icons");
		FormatConvertedBitmap formatConvertedBitmap = new FormatConvertedBitmap(RecoveredType220.RecoveredMethod632("Ope"), PixelFormats.Bgra32, null, 0.0);
		byte[] array3 = new byte[formatConvertedBitmap.PixelWidth * formatConvertedBitmap.PixelHeight * 4];
		formatConvertedBitmap.CopyPixels(array3, formatConvertedBitmap.PixelWidth * 4, 0);
		int num = 0;
		for (int j = 0; j < array3.Length; j += 4)
		{
			if (array3[j + 3] > 100 && array3[j + 2] > array3[j + 1] + 20 && array3[j + 2] > array3[j] + 20)
			{
				num++;
			}
		}
		RecoveredMethod42(num > 10, "Ope uses a red colored icon, not a grayscale mesh render");
		string text2 = Path.Combine(Path.GetTempPath(), "twist-fruit-icons-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text2);
		try
		{
			ItemMetadata itemMetadata = new ItemMetadata();
			itemMetadata.Name = "Ope";
			itemMetadata.Category = "Fruit";
			itemMetadata.Rarity = "Mythical";
			ItemMetadata item = itemMetadata;
			ItemPreviewRenderer itemPreviewRenderer = new ItemPreviewRenderer(text2);
			File.WriteAllBytes(itemPreviewRenderer.FileFor(item), new byte[3] { 1, 2, 3 });
			RecoveredMethod42(itemPreviewRenderer.Cached(item).PixelWidth > 1 && itemPreviewRenderer.Render(item).PixelWidth > 1, "Local and remote/Total preview paths prefer wiki icons over stale mesh caches");
		}
		finally
		{
			string[] files = Directory.GetFiles(text2);
			foreach (string path in files)
			{
				File.Delete(path);
			}
			string[] directories = Directory.GetDirectories(text2);
			foreach (string path2 in directories)
			{
				Directory.Delete(path2);
			}
			Directory.Delete(text2);
		}
		File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-results.txt"), "PASS: all 37 wiki fruit PNGs decode, colored Ope pixels, Bomu/Ptero aliases, local and remote/Total icon priority over stale caches, strict name matching and RDP image bounds. No game or network input.\r\n");
	}
}
