using Godot;

public partial class ClickableSpaceObject : StaticBody3D
{
    public virtual void _OnMouseEntered()
    {
        ShowInformation();
    }

    public virtual void _OnMouseExited()
    {
        base._MouseExit();
        
        
    }

    public virtual void _OnInputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, int shape_idx)
    {
        if (@event is InputEventMouseButton { ButtonIndex: MouseButton.Left, Pressed: true })
            GD.Print($"Clicked {GetInstanceId()}!");
    }

    public virtual void ShowInformation()
    {
        
    }
}