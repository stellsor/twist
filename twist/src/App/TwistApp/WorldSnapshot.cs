using System;

namespace TwistApp;

public sealed class WorldSnapshot
{
	public bool Valid;

	public bool HasEye;

	public string Status = "Waiting for world data";

	public string EyeName = "";

	public string EyeDescription = "";

	public string Hub = "";

	public string Server = "";

	public WorldPoint Position;

	public DateTime Updated;

	public int Revision;

	public WorldFruitRecord[] Fruits = new WorldFruitRecord[0];

	public WorldFruitRecord[] Events = new WorldFruitRecord[0];
}
