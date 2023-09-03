using Godot;
using Uniwander.Scripts.Instruments;

namespace Uniwander.Scripts.Entities.Spaceships;

public partial class Player : Spaceship
{
    [Export]
    private Character _stats;

    [Export] public Instrument? SelectedInstrument { get; set; }

    public override void _Process(double delta)
    {
        if (SelectedInstrument is not null && Input.IsMouseButtonPressed(MouseButton.Left))
        {
            SelectedInstrument.OnActivatingWhenClickInWorld();
        }
    }

    /*[Export] private StaticBody3D _planet;
    
    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = 9.8f;
    
    private Vector3 _moveDirection = Vector3.Zero;
    private Vector3 _lastStrongDirection = Vector3.Forward;
    private Vector3 _localGravity = Vector3.Down;

    private bool _should_reset = false;*/

    /*public override void _PhysicsProcess(double delta)
    {
        Vector3 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
            velocity.Y -= gravity * (float)delta;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        if (direction != Vector3.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Z = direction.Z * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
        }

        Vector3 planetUp = GetPlanetUp();

        Velocity = velocity;
        UpDirection = planetUp;
        FloorMaxAngle = Mathf.DegToRad(40);
        
        MoveAndSlide();
        
        GlobalTransform = AlignWithY(GlobalTransform, planetUp);
    }

    private Vector3 GetPlanetUp()
    {
        Vector3 up = -(_planet.Position - GlobalTransform.Origin).Normalized();
        return up;
    }

    private Transform3D AlignWithY(Transform3D transform3D, Vector3 newY)
    {
        transform3D.Basis.Y = newY;
        transform3D.Basis.X = -transform3D.Basis.Z.Cross(newY);
        transform3D.Basis = transform3D.Basis.Orthonormalized();

        return transform3D;
    }*/
}