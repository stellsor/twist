using System;
using System.Windows.Media;

namespace TwistApp;

public static class RarityStyle
{
	public static readonly string[] Names = new string[8] { "Common", "Uncommon", "Rare", "Epic", "Legendary", "Mythical", "Collectable", "Unknown" };

	public static int SortRank(string rarity)
	{
		return rarity switch
		{
			"Mythical" => 6, 
			"Legendary" => 5, 
			"Epic" => 4, 
			"Rare" => 3, 
			"Uncommon" => 2, 
			"Common" => 1, 
			"Collectable" => 0, 
			_ => -1, 
		};
	}

	public static Brush Brush(string rarity)
	{
		string[] array = new string[8] { "#B1B3BE", "#91C6A5", "#8DBBEE", "#BA9BEC", "#E5C27C", "#EA929D", "#91D6D9", "#777782" };
		int num = Array.IndexOf(Names, rarity);
		SolidColorBrush solidColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(array[(num < 0) ? 7 : num]));
		solidColorBrush.Freeze();
		return solidColorBrush;
	}
}
