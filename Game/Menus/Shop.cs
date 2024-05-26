using Godot;
using System;

public partial class Shop : Control
{

	private void refreshCoins()
	{
		Label coinLabel = GetNode<Label>("CenterContainer/PanelContainer/Itens/Moedas");
		coinLabel.Text = "Moedas: " + Global.coins;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		refreshCoins();
	}

	public void _on_back_button_pressed()
	{

	}

	public void _on_Level2_pressed()
	{
		if (Global.coins >= 200 && !Global.shop.hillsLevel)
		{
			Global.shop.hillsLevel = true;
			Global.coins -= 200;
			refreshCoins();
		}
	}

	public void _on_Level3_pressed()
	{
		if (Global.coins >= 500 && !Global.shop.desertLevel)
		{
			Global.shop.desertLevel = true;
			Global.coins -= 500;
			refreshCoins();
		}

	}

	public void _on_Level4_pressed()
	{
		if (Global.coins >= 1000 && !Global.shop.iceLevel)
		{
			Global.shop.iceLevel = true;
			Global.coins -= 1000;
			refreshCoins();
		}

	}

}
