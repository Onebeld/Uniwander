using Uniwander.Global.Constants;
using Uniwander.Global.Interfaces.SpaceObjects.Star;

namespace Uniwander.Global.SpaceObjects.Star.Colors.Single;

[Tool]
public partial class SingleRedGalaxyStarColor : SingleGalaxyStar
{
    public override Color GetColor() => StarColors.Red;
    
    protected override void ChangeSprites()
    {
        StarSprite.Scale *= StarSizes.Red;
    }
}