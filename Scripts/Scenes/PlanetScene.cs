using Godot;
using System;
using Uniwander.Scripts;
using Uniwander.Scripts.Scenes;

public partial class PlanetScene : GameScene
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		
		Global.GameScene = Uniwander.Scripts.Enums.GameScene.PlanetScene;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		
		MainGameInterface.Interface.DevInfo.Text = MouseGlobalPosition.ToString();
	}
}
