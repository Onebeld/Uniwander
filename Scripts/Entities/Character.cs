using Godot;
using System;

[GlobalClass]
public partial class Character : Resource
{
    [Export] public string DisplayName = "Onebeld";
    [Export] public float FlightSpeed = 500.0f;
    [Export] public float Acceleration = 30.0f;
}
