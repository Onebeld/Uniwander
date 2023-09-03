using Godot;
using Uniwander.Scripts;
using Uniwander.Scripts.Enums;

public partial class GalaxyScene : Uniwander.Scripts.Scenes.GameScene
{
	[Export]
	public GalaxyPlayerSpaceship Player { get; set; } = null!;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		
		Global.GameScene = GameScene.GalaxyScene;
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
	}
}
