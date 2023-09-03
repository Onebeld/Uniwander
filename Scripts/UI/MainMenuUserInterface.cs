using Godot;
using System;
using JLeb.Estragonia;
using Uniwander.UI;

public partial class MainMenuUserInterface : AvaloniaControl
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetWindow().SetImeActive(true);

		Control = new MainMenuView();
		
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		
		base._Process(delta);
	}
}
