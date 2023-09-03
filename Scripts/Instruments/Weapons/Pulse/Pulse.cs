using System;
using System.Diagnostics;
using Godot;

namespace Uniwander.Scripts.Instruments.Weapons.Pulse;

public partial class Pulse : Instrument
{
    private Stopwatch? _shootingCooldownStopwatch = default;

    private float _shotDelay = 1;
    
    public override void _Ready()
    {
        ActivatingWhenClickInWorld += OnActivatingWhenClickInWorld;
    }

    private void OnActivatingWhenClickInWorld(object? sender, EventArgs e)
    {
        float shotDelayMilliseconds = _shotDelay * 1000;
        
        if (_shootingCooldownStopwatch?.ElapsedMilliseconds < shotDelayMilliseconds)
            return;

        _shootingCooldownStopwatch = Stopwatch.StartNew();
        
        PulseBullet bullet = GD.Load<PulseBullet>("res://GameObjects/Spaceships/Instruments/Weapons/Pulse/PulseBullets.tscn");
        
        GetTree().Root.AddChild(bullet);
    }
}