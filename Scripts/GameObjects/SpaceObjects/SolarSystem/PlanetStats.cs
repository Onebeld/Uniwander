using Godot;
using Godot.Collections;

namespace Uniwander.Scripts.GameObjects.SpaceObjects.SolarSystem;

[GlobalClass]
public partial class PlanetStats : Resource
{
    [Export] public string DisplayName = "Planet";
    [Export] public float DistanceFromStar;
    [Export] public PlanetType Type = PlanetType.Default;

    [Export] public PlanetStats? Satellite;

    [Export] public Array<Node3D>? Objects;
}