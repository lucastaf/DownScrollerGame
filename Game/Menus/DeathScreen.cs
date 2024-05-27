using Godot;
using System;

public partial class DeathScreen : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Label score =  GetNode<Label>("Score");
		score.Text += Global.currentLevel.score;
		GetNode<Label>("Moedas").Text += Global.currentLevel.coins;
		Global.coins += Global.currentLevel.coins;
		if (Global.currentLevel.score > Global.highScore)
		{
			GetNode<Label>("NewHighscore").Text = "NOVO HIGHSCORE!";
			Global.highScore = Global.currentLevel.score;
		}
	}

	public void _on_restart_pressed()
	{
		GetTree().ChangeSceneToFile("res://Game/MainGame.tscn");
	}

	public void _on_menu_pressed()
	{
		GetTree().ChangeSceneToFile("res://Game/Menus/MainMenu.tscn");

	}
}
