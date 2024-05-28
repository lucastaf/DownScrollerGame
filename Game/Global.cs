using Godot;
using System;

public partial class Global : Node
{

	public static int coins = 0;
	public static int highScore = 0;

	public static int selectedLevel = 0;

	public static class currentLevel
	{
		public static int coins = 0;
		public static int score = 0;
	}

	public static bool[] levels = [
		true, false, false, false
	];

}
