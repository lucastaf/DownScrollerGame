using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class TileSetGenerator : Node2D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public TileMap getTileSet(int idx = 0)
	{
		String[] tiles = {
			"Padrao101",
			"Padrao102",
			"Padrao103",
			"Padrao104",
			"Padrao105",
			"Padrao106",
			"Padrao107",
			"Padrao108",
			"Padrao109",
			"Padrao110",
		};

		return this.GetNode<TileMap>(tiles[GD.RandRange(0, tiles.Length - 1)]);
	}
}

