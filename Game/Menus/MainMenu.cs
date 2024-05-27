using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Label>("Moedas").Text = "Moedas: " + Global.coins;
		GetNode<Label>("HighScore").Text = "HighScore: "+ Global.highScore;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_play_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Game/MainGame.tscn");
	}

	public void _on_shop_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Game/Menus/Shop.tscn");

	}
}
