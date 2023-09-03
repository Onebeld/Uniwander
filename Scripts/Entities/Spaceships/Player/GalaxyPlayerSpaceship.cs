using Godot;
using System;
using Uniwander.Scripts.Entities.Spaceships;

public partial class GalaxyPlayerSpaceship : Player
{
	[Export]
	private Character _stats;

	[Export] 
	private Uniwander.Scripts.GameObjects.SpaceObjects.SpaceObject? _selectedSpaceObject;

	public bool IsLanding { get; private set; }

	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_selectedSpaceObject is not null && GlobalPosition.DistanceTo(_selectedSpaceObject.LandingPosition) > 0.3)
		{
			IsLanding = false;
			
			Accelerate(GlobalPosition.DirectionTo(_selectedSpaceObject.LandingPosition));

			MoveAndSlide();
		}
		else
		{
			Velocity = Vector3.Zero;
			IsLanding = true;
		}
	}

	public void SetStats(Character newStats)
	{
		_stats = newStats;
	}
	
	public void BeginMovingToSpaceObject(Uniwander.Scripts.GameObjects.SpaceObjects.SpaceObject spaceObject)
	{
		_selectedSpaceObject = spaceObject;
	}
	
	private void Accelerate(Vector3 direction)
	{
		Velocity = Velocity.MoveToward(direction * _stats.FlightSpeed, _stats.Acceleration);
	}
}
