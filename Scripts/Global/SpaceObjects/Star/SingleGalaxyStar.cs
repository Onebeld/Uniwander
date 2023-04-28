using Uniwander.Scripts.Global.Constants;
using Uniwander.Scripts.Global.Interfaces.SpaceObjects.Star;

namespace Uniwander.Scripts.Global.SpaceObjects.Star;

[Tool]
public partial class SingleGalaxyStar : GalaxyStar, ISingleStar
{
    protected Sprite3D? StarSprite;
    
    virtual public Color GetColor() => StarColors.White;

    public override void _Ready()
    {
        StarSprite = GetNode<Sprite3D>("StarSprite");
        StarSprite.Modulate = GetColor();
        
        ChangeSprites();
    }

    protected virtual void ChangeSprites() { }
    
    public override void _Process(double delta)
    {
        Viewport viewport = GetViewport();
        Camera3D? camera3D = viewport?.GetCamera3D();
        if (camera3D is null) return;
		
        Vector3 cameraPos = camera3D.GlobalTransform.Origin;
        cameraPos.Y = 0;
        StarSprite?.LookAt(cameraPos, new Vector3(0, 1, 0));
    }
}