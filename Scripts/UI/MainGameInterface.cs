using Godot;
using System;
using JLeb.Estragonia;

public partial class MainGameInterface : AvaloniaControl
{
	public Uniwander.UI.GameMenus.MainGameInterface Interface = null!;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Control = Interface = new Uniwander.UI.GameMenus.MainGameInterface();
		
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
