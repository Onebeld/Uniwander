using Godot;
using Uniwander.Scripts.Enums;

namespace Uniwander.Scripts.GameObjects.SpaceObjects;

public partial class CenterOfGalaxy : SpaceObject
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    
	public void OnInputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, int shapeIdx)
	{
		if (Global.GameScene is not GameScene.GalaxyScene) return;

		if (@event is InputEventMouseButton { ButtonIndex: MouseButton.Left })
		{
			GalaxyScene? galaxyScene = GetTree().CurrentScene as GalaxyScene;
			
			galaxyScene?.Player.BeginMovingToSpaceObject(this);
		}
	}
}