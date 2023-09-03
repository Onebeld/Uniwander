using Godot;

namespace Uniwander.Scripts.GameObjects.Cameras;

public partial class GalaxyCamera : Camera3D
{
	public bool TabMode { get; set; }
	
	public GalaxyPlayerSpaceship Player { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}