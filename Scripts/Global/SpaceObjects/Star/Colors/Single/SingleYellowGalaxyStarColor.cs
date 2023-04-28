using Uniwander.Global.Constants;

namespace Uniwander.Global.SpaceObjects.Star.Colors.Single;

[Tool]
public partial class SingleYellowGalaxyStarColor : SingleGalaxyStar
{
    public override Color GetColor() => StarColors.Yellow;
    
    protected override void ChangeSprites()
    {
        StarSprite.Scale *= StarSizes.Yellow;
    }
}