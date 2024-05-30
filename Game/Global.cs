using Godot;
using System;

public partial class Global : Node
{
	public override void _Ready()
	{
		loadData();
	}
	private const string saveDataLocation = "user://data.save";
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

	private void loadData()
	{
		if (FileAccess.FileExists(saveDataLocation))
		{
			FileAccess file = FileAccess.Open(saveDataLocation, FileAccess.ModeFlags.Read);
			coins = (int)file.GetVar();
			highScore = (int)file.GetVar();
			file.Close();
		}
	}
	public static void saveData()
	{
		FileAccess file = FileAccess.Open(saveDataLocation, FileAccess.ModeFlags.Write);
		file.StoreVar(coins);
		file.StoreVar(highScore);
		file.Close();
	}


}
