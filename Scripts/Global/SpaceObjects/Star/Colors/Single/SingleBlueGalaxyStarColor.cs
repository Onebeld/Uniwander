using Godot;
using Uniwander.Scripts.Global.Constants;
using Uniwander.Scripts.Global.Interfaces.SpaceObjects.Star;

namespace Uniwander.Scripts.Global.SpaceObjects.Star.Colors.Single;

[Tool]
public partial class SingleBlueGalaxyStarColor : SingleGalaxyStar
{
    public override Color GetColor() => StarColors.Blue;
    
    protected override void ChangeSprites()
    {
        StarSprite.Scale *= StarSizes.Blue;
    }
}