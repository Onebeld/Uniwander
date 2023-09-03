using System;
using Godot;

namespace Uniwander.Scripts.GameObjects.SpaceObjects.Stars;

[Tool]
public partial class StarSprite : Node3D
{
	public override void _Ready()
	{
		AnimationPlayer animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		
		Random random = new();
		
		animationPlayer.Play("glow_star");
		animationPlayer.Seek( 9 * random.NextDouble());
	}
}