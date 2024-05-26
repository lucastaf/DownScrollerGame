using Godot;
using System;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private TileSetGenerator newLineGenerator;
	private int tilesCount = 0;

	private void generateNewLine()
	{
		Node2D autoDeleteComponent = (Node2D)ResourceLoader.Load<PackedScene>("res://Game/Scenary/auto_delete_component.tscn").Instantiate();


		TileMap gettedTile = newLineGenerator.getTileSet(GD.RandRange(0, 2));

		PackedScene tileScene = new PackedScene();
		tileScene.Pack(gettedTile);

		TileMap newTile = tileScene.Instantiate<TileMap>();
		autoDeleteComponent.GlobalPosition = new Vector2(0, tilesCount * 70);
		autoDeleteComponent.AddChild(newTile);
		AddChild(autoDeleteComponent);
		this.tilesCount++;
	}
	public override void _Ready()
	{
		newLineGenerator = GetNode<TileSetGenerator>("TileMapGenerator");
		for (int i = 0; i < 5; i++)
		{
			generateNewLine();
		}
	}

	public void _on_player_level_passed(){
		generateNewLine();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Node2D camera = this.GetNode<Node2D>("Camera2D");
		camera.GlobalPosition = new Vector2(camera.GlobalPosition.X,
		this.GetNode<Node2D>("Player").GlobalPosition.Y
		);
	}
}
