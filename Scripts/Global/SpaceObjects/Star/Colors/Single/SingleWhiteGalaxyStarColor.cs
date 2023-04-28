using Uniwander.Global.Constants;
using Uniwander.Global.Interfaces.SpaceObjects.Star;

namespace Uniwander.Global.SpaceObjects.Star.Colors.Single;

[Tool]
public partial class SingleWhiteGalaxyStarColor : SingleGalaxyStar
{
    public override Color GetColor() => StarColors.White;
    
    protected override void ChangeSprites()
    {
        StarSprite.Scale *= StarSizes.White;
    }
}