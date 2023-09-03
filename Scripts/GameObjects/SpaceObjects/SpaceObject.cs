using Godot;

namespace Uniwander.Scripts.GameObjects.SpaceObjects;

[GlobalClass]
public partial class SpaceObject : StaticBody3D
{
	[Export]
	private Node3D _landing;
	public Vector3 LandingPosition { get => _landing.GlobalPosition; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}