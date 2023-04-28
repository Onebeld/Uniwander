using Uniwander.Global.Constants;
using Uniwander.Global.Interfaces.SpaceObjects.Star;

namespace Uniwander.Global.SpaceObjects.Star;

[Tool]
public partial class DoubleGalaxyStar : GalaxyStar, IDoubleStar
{
    protected Sprite3D? FirstStarSprite;
    protected Sprite3D? SecondStarSprite;
    
    virtual public Color GetFirstColor() => StarColors.White;
    virtual public Color GetSecondColor() => StarColors.White;
    
    public override void _Ready()
    {
        FirstStarSprite = GetNode<Sprite3D>("FirstStarSprite");
        SecondStarSprite = GetNode<Sprite3D>("SecondStarSprite");
        
        FirstStarSprite.Modulate = GetFirstColor();
        SecondStarSprite.Modulate = GetSecondColor();
        
        ChangeSprites();
    }

    public virtual void ChangeSprites() { }
    
    public override void _Process(double delta)
    {
        Viewport viewport = GetViewport();
        Camera3D? camera3D = viewport?.GetCamera3D();
        if (camera3D is null) return;
		
        Vector3 cameraPos = camera3D.GlobalTransform.Origin;
        cameraPos.Y = 0;
        
        FirstStarSprite?.LookAt(cameraPos, new Vector3(0, 1, 0));
        SecondStarSprite?.LookAt(cameraPos, new Vector3(0, 1, 0));
    }
}