using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class TileSetGenerator : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TileMap tilemap = this.GetNode<TileMap>("Padrao101");
		TileSet tileset = tilemap.TileSet;
		TileSetAtlasSource atlas = (TileSetAtlasSource)tileset.GetSource(0);
		atlas.Margins = new Vector2I(0, Global.selectedLevel * 16);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public TileMap GetTileSet()
	{
		String[] tiles = {
			"Padrao201",
			

			"Padrao202",
			"Padrao203",
			"Padrao204",
			"Padrao205",
			"Padrao206",
			"Padrao207",
			"Padrao208",
			"Padrao209",
			"Padrao210",
			"Padrao211",
			"Padrao212",
			"Padrao213",
			"Padrao214",
			"Padrao215",
			
		};

		return this.GetNode<TileMap>(tiles[GD.RandRange(0, tiles.Length - 1)]);
	}
}

