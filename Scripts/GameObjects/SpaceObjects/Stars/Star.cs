using System;
using Godot;
using Godot.Collections;
using Uniwander.Scripts.Enums;
using Uniwander.Scripts.GameObjects.SpaceObjects.Stars.Enums;

namespace Uniwander.Scripts.GameObjects.SpaceObjects.Stars;

[GlobalClass]
[Tool]
public partial class Star : SpaceObject
{
	private const float Rad = Mathf.Pi / 180;

	[Export]
	private Array<StarType> _starTypes = new();
	
	[Export] 
	private StarStats? _stats;

	// Needed when we make the star sprites look at the camera
	private Node3D _starsNode = null!;

	private Camera3D? _camera3D;

	public override void _Ready()
	{
		_camera3D = GetViewport().GetCamera3D();
		_starsNode = GetNode<Node3D>("Stars");
		
		foreach (Node child in _starsNode.GetChildren())
			_starsNode.RemoveChild(child);
			
		if (_starTypes.Count == 0) return;

		if (_starTypes.Count == 1)
			CreateStarSprite(_starTypes[0]);
		else
		{
			float sector = 360.0f / _starTypes.Count;
			float currentSector = sector;

			foreach (StarType starType in _starTypes)
			{
				Node3D starSprite = CreateStarSprite(starType);

				starSprite.Position = new Vector3( 0.12f * Mathf.Cos(currentSector * Rad), 0.12f * Mathf.Sin(currentSector * Rad), 0);
				currentSector += sector;
			}
		}
	}

	public override void _Process(double delta)
	{
		if (_camera3D is null)
			return;

		Vector3 cameraPos = _camera3D.GlobalTransform.Origin;

		foreach (Node child in _starsNode.GetChildren())
		{
			if (child is Node3D node3D)
				node3D.LookAt(cameraPos, new Vector3(0, 1, 0));
		}
	}

	public void SetName(string name)
	{
		Name = name;
	}
	
	public void SetStats(StarStats newStats)
	{
		_stats = newStats;
	}

	private Node3D CreateStarSprite(StarType starType)
	{
		PackedScene packedScene = ResourceLoader.Load<PackedScene>("res://GameObjects/SpaceObjects/Stars/StarSprite.tscn");
		Node3D node3D = packedScene.Instantiate<Node3D>();

		Sprite3D sprite3D = node3D.GetNode<Sprite3D>("Sprite3D");
		
		float size = GetSize(starType.StarSize);
		
		node3D.Scale = new Vector3(size, size, size);
		sprite3D.Modulate = Color.FromString($"#{(uint)starType.StarColor:X}", Colors.White);

		_starsNode.AddChild(node3D);
#if DEBUG
		node3D.Owner = GetTree().EditedSceneRoot;
#endif
		
		return node3D;
	}

	private float GetSize(StarSize starSize) => starSize switch
	{
		StarSize.Small => 0.09f,
		StarSize.Medium => 0.14f,
		StarSize.Big => 0.18f,
		StarSize.Giant => 0.23f,
		_ => throw new ArgumentOutOfRangeException(nameof(starSize), starSize, null)
	};

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