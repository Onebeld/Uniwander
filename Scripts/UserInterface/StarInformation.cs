using Godot;
using System;

public partial class StarInformation : Control
{
	[Export]
	private Label? _labelStarId;
	
	private string _starName = string.Empty;

	public string StarName
	{
		get => _starName;
		set
		{
			_starName = value;

			if (_labelStarId is not null)
				_labelStarId.Text = StarName;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
