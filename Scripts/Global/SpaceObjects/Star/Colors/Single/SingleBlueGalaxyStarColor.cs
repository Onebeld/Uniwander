using Uniwander.Global.Constants;
using Uniwander.Global.Interfaces.SpaceObjects.Star;

namespace Uniwander.Global.SpaceObjects.Star.Colors.Single;

[Tool]
public partial class SingleBlueGalaxyStarColor : SingleGalaxyStar
{
    public override Color GetColor() => StarColors.Blue;
    
    protected override void ChangeSprites()
    {
        StarSprite.Scale *= StarSizes.Blue;
    }
}