using System;
using Godot;

namespace Uniwander.Scripts.Global.SolarObjects;

[Tool]
public partial class OrbitingSolarObjects : ClickableSolarObject
{
    [Export]
    public ClickableSolarObject TargetToOrbiting { get; set; } = null!;

    [Export]
    public float OrbitRadiusA { get; set; } = 5f;

    [Export]
    public float OrbitRadiusB { get; set; } = 3f;

    [Export]
    public float Speed { get; set; } = 0.1f;
    
    private float _angle = 0;

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(double delta)
    {
        if (TargetToOrbiting is null)
            throw new NullReferenceException();
        
        Vector3 pos = new(OrbitRadiusA * Mathf.Cos(_angle), 0f, OrbitRadiusB * Mathf.Sin(_angle));
        Transform = new Transform3D(Basis.Identity, pos);

        Transform3D transform3D = TargetToOrbiting.GlobalTransform;
        Transform = Transform.Translated(transform3D.Origin);
        Transform = Transform.Rotated(Vector3.Up, _angle);
        Transform = Transform.Translated(-transform3D.Origin);

        _angle += Speed * (float)delta;
    }
}