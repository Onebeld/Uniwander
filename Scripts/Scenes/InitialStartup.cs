using Godot;

public partial class InitialStartup : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Menus/MenuUniwanderScene.tscn");
	}
}
