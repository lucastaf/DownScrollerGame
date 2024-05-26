using Godot;
using System;

public static class Global
{

	public static int coins = 1000;
	public static int highScore = 0;

	public static int selectedLevel = 0;

	public static class shop
	{
		public enum levels
		{
			forestLevel,
			hillsLevel,
			desertLevel,
			iceLevel
		}
		public static bool forestLevel = true;
		public static bool hillsLevel = false;
		public static bool desertLevel = false;
		public static bool iceLevel = false;
	}
}
