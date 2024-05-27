using Godot;
using System;
using System.Collections.Generic;

public partial class Shop : Control
{

	private void refreshCoins()
	{
		Label coinLabel = GetNode<Label>("CenterContainer/PanelContainer/Itens/Moedas");
		coinLabel.Text = "Moedas: " + Global.coins;
	}
	private void setLevelButtonText(int level, string message = "Selecionar")
	{
		String nomeDaFase = "";
		switch (level)
		{
			case 0: nomeDaFase = "Floresta"; break;
			case 1: nomeDaFase = "Colinas"; break;
			case 2: nomeDaFase = "Deserto"; break;
			case 3: nomeDaFase = "Gelo"; break;
		}
		Button labelDaFase = GetNode<Button>("CenterContainer/PanelContainer/Itens/" + nomeDaFase + "/Button");
		labelDaFase.Text = message;
	}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		refreshCoins();
		int idx = 0;
		foreach (bool levelValue in Global.levels)
		{
			if (levelValue) setLevelButtonText(idx);
			idx++;
		}
		setLevelButtonText(Global.selectedLevel, "Selecionado");
	}

	public void _on_back_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Game/Menus/MainMenu.tscn");
	}

	private void levelClick(int level, int price)
	{
		if (Global.coins >= price && !Global.levels[level])
		{
			setLevelButtonText(level);
			Global.levels[level] = true;
			Global.coins -= price;
			refreshCoins();
		}
		else if (Global.levels[level])
		{
			setLevelButtonText(Global.selectedLevel, "Selecionar");
			Global.selectedLevel = level;
			setLevelButtonText(level, "Selecionado");
		}

	}

	public void _on_Level1_pressed()
	{
		levelClick(0, 0);
	}

	public void _on_Level2_pressed()
	{
		levelClick(1, 200);
	}

	public void _on_Level3_pressed()
	{
		levelClick(2, 500);
	}

	public void _on_Level4_pressed()
	{
		levelClick(3, 1000);
	}

}
