using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Godot;
using Uniwander.Scripts.Entities.Spaceships;
using Timer = Godot.Timer;

public partial class PulseBullet : Area3D
{
	[Export] private float _speed = 400;
	[Export] private float _explosionForce = 10;

	private readonly List<RigidBody3D> _itemsInRadius = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Translate(GravityDirection.Normalized() * _speed * (float)delta);
	}

	public void OnExplosionTimeout()
	{
		Explosion();
	}

	public void OnBulletBodyEntered(Node3D body)
	{
		if (body is Player) return;
		
		Explosion();
	}

	public void OnExplosionAreaBodyEntered(Node3D body)
	{
		if (body is RigidBody3D rigidBody3D)
			_itemsInRadius.Add(rigidBody3D);
	}

	public void OnExplosionAreaBodyExited(Node3D body)
	{
		if (body is RigidBody3D rigidBody3D)
			_itemsInRadius.Remove(rigidBody3D);
	}

	private void Explosion()
	{
		Random random = new();
		
		foreach (RigidBody3D body3D in _itemsInRadius)
		{
			Vector3 forceDir = GlobalTransform.Origin.DirectionTo(body3D.GlobalTransform.Origin);
			Vector3 randomVector = new Vector3(random.NextSingle(), random.NextSingle(), random.NextSingle()) * forceDir;
			
			body3D.ApplyImpulse(randomVector, forceDir * _explosionForce);
		}
		
		QueueFree();
	}
}
