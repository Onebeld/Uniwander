using Godot;
using Godot.Collections;
using Uniwander.Scripts.GameObjects.SpaceObjects.SolarSystem;

namespace Uniwander.Scripts.GameObjects.SpaceObjects.Stars;

[GlobalClass]
public partial class StarStats : Resource
{
    [Export] public uint Id;
    [Export] public string DisplayName = "Star";
    [Export] public bool IsGenerated;

    [Export] public Array<PlanetStats>? Planets;
}