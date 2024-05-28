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


		TileMap gettedTile = newLineGenerator.GetTileSet();

		gettedTile.Visible = true;

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
		for (int i = 0; i < 8; i++)
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
		Player player = GetNode<Player>("Player");
		camera.GlobalPosition += new Vector2(0, velocity);
		if (player.GlobalPosition.Y > camera.GlobalPosition.Y)
		{
			camera.GlobalPosition = new Vector2(0,
			player.GlobalPosition.Y
			);
		}
		camera.Rotation = -player.Rotation;

		velocity = (float)Math.Log(player.Score * 0.001f + 1, 1.3) / 5;
		GD.Print(velocity);
	}

	public void _on_player_player_out_of_screen()
	{
		Node2D camera = this.GetNode<Node2D>("Camera2D");
		Player player = GetNode<Player>("Player");
		if (player.GlobalPosition.Y < camera.GlobalPosition.Y)
		{
			Global.currentLevel.score = player.Score;
			Global.currentLevel.coins = player.CoinCount;
			GetTree().ChangeSceneToFile("res://Game/Menus/DeathScreen.tscn");
		}
	}
}
