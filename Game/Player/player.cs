using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class player : CharacterBody2D
{
	[Signal] public delegate void LevelPassedEventHandler();
	[Signal] public delegate void PlayerOutOfScreenEventHandler();
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	private int score = 0;
	public int Score
	{
		get { return score; }
	}
	private int coinCount = 0;
	public int CoinCount
	{
		get { return coinCount; }
	}

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if(Input.GetAccelerometer() != Vector3.Zero){
			velocity.X = Input.GetAccelerometer().X * Speed;
		}
		else if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		Rotation = (float)(direction.X / 10);
		MoveAndSlide();
	}


	public void _on_plataform_detector_body_exited(Node2D a)
	{
		this.score += 100;
		EmitSignal(SignalName.LevelPassed);
		Label scoreLabel = GetNode<Label>("Interface/ScoreLabel");
		scoreLabel.Text = "Score: " + score;
	}

	public void _on_coin_collector_area_entered(Area2D coin)
	{
		this.coinCount++;
		coin.QueueFree();
		Label coinLabel = GetNode<Label>("Interface/CoinLabel");
		coinLabel.Text = "Moedas: " + coinCount;
	}

	public void _on_visible_on_screen_notifier_2d_screen_exited(){
		EmitSignal(SignalName.PlayerOutOfScreen);	
	}
}
