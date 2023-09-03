using Godot;
using Godot.Collections;
using Uniwander.Scripts.Camera;

namespace Uniwander.Scripts.Scenes;

public partial class GameScene : Node3D
{
    private bool _cameraFreeFlightMode;
    
    public GameCamera GameCamera { get; private set; } = null!;
    
    public MainGameInterface MainGameInterface { get; private set; } = null!;
    
    public Vector3? MouseGlobalPosition { get; private set; }

    public bool CameraFreeFlightMode
    {
        get => _cameraFreeFlightMode;
        set
        {
            _cameraFreeFlightMode = value;
            
            GameCamera.SwitchFreeFlightMode(value);
            MainGameInterface.Visible = !value;
        }
    }

    public override void _Ready()
    {
        GameCamera = GetNode<GameCamera>("MainCamera");
        MainGameInterface = GetNode<MainGameInterface>("MainGameInterface");
    }

    public override void _Process(double delta)
    {
        
    }

    public override void _PhysicsProcess(double delta)
    {
        SetGlobalMousePosition();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey { Keycode: Key.Tab, Pressed: true })
            CameraFreeFlightMode = !CameraFreeFlightMode;
    }

    private void SetGlobalMousePosition()
    {
        if (CameraFreeFlightMode)
        {
            MouseGlobalPosition = null;
            return;
        }
        
        Dictionary? dict = GetPositionInWorldFromMouse();
		
        if (dict is null) return;

        if (dict.TryGetValue("position", out Variant pos))
            MouseGlobalPosition = pos.AsVector3();
        else MouseGlobalPosition = null;
    }

    private Dictionary? GetPositionInWorldFromMouse()
    {
        Vector2 mousePosition = GetViewport().GetMousePosition();
		
        Vector3 from = GameCamera.ProjectRayOrigin(mousePosition);
        Vector3 to = from + GameCamera.ProjectRayNormal(mousePosition) * 100;
		
        PhysicsDirectSpaceState3D? space = GetWorld3D().DirectSpaceState;
		
        PhysicsRayQueryParameters3D rayQuery = new()
        {
            From = from,
            To = to,
            CollideWithBodies = true,
            CollisionMask = 1
        };

        return space.IntersectRay(rayQuery);
    }
}