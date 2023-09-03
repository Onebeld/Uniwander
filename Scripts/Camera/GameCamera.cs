using Godot;

namespace Uniwander.Scripts.Camera;

public partial class GameCamera : Camera3D
{
    [Export] private float _acceleration = 50;
    [Export] private float _moveSpeed = 8;
    [Export] private float _mouseSpeed = 300;
    
    private bool _freeFlightMode;
    
    private Vector3 _velocity = Vector3.Zero;

    private Vector2 _lookAngles = Vector2.Zero;

    public override void _Process(double delta)
    {
        if (_freeFlightMode)
        {
            Input.MouseMode = Input.MouseModeEnum.Captured;
            FreeFlightProcess(delta);
        }
        else
            Input.MouseMode = Input.MouseModeEnum.Visible;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
            _lookAngles -= mouseMotion.Relative / _mouseSpeed;
    }

    public void SwitchFreeFlightMode(bool isEnabled)
    {
        _freeFlightMode = isEnabled;

    }
    
    private void FreeFlightProcess(double delta)
    {
        _lookAngles.Y = Mathf.Clamp(_lookAngles.Y, Mathf.Pi / -2, Mathf.Pi / 2);
        Rotation = new Vector3(_lookAngles.Y, _lookAngles.X, 0);

        Vector3 direction = Vector3.Zero;

        if (Input.IsActionPressed("move_forward"))
            direction += Vector3.Forward;
        if (Input.IsActionPressed("move_backward"))
            direction += Vector3.Back;
        if (Input.IsActionPressed("rotate_left"))
            direction += Vector3.Left;
        if (Input.IsActionPressed("rotate_right"))
            direction += Vector3.Right;

        direction = direction.Normalized();

        if (direction.LengthSquared() > 0)
            _velocity += direction * _acceleration * (float)delta;
        else
            _velocity += _velocity.DirectionTo(Vector3.Zero) * _acceleration * (float)delta;

        if (_velocity.Length() < 0.05)
            _velocity = Vector3.Zero;

        if (_velocity.Length() > _moveSpeed)
            _velocity = _velocity.Normalized() * _moveSpeed;
        
        Translate(_velocity * (float)delta);
    }
}