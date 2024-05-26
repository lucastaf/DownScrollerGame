using Godot;
using System;

public partial class MainGame : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private TileSetGenerator newLineGenerator;
	private int tilesCount = 0;
	private void generateNewLine()
	{
		Node2D autoDeleteComponent = (Node2D)ResourceLoader.Load<PackedScene>("res://Game/Scenary/auto_delete_component.tscn").Instantiate();


		TileMap gettedTile = newLineGenerator.getTileSet(3);

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

	public void _on_player_level_passed()
	{
		generateNewLine();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private float velocity = 0.4f;
	public override void _Process(double delta)
	{
		Node2D camera = this.GetNode<Node2D>("Camera2D");
		CharacterBody2D player = GetNode<CharacterBody2D>("Player");
		camera.GlobalPosition += new Vector2(0, velocity);
		if (player.GlobalPosition.Y > camera.GlobalPosition.Y)
		{
			camera.GlobalPosition = new Vector2(camera.GlobalPosition.X,
			player.GlobalPosition.Y
			);
		}
		velocity += 0.001f;
	}

	public void _on_player_player_out_of_screen(){
		Node2D camera = this.GetNode<Node2D>("Camera2D");
		Node2D player = GetNode<Node2D>("Player");
		if(player.GlobalPosition.Y < camera.GlobalPosition.Y){
			GetTree().ReloadCurrentScene();
		}
	}
}
