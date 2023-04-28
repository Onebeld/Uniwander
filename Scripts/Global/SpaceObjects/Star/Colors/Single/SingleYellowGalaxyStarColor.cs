using Uniwander.Scripts.Global.Constants;

namespace Uniwander.Scripts.Global.SpaceObjects.Star.Colors.Single;

[Tool]
public partial class SingleYellowGalaxyStarColor : SingleGalaxyStar
{
    public override Color GetColor() => StarColors.Yellow;
    
    protected override void ChangeSprites()
    {
        StarSprite.Scale *= StarSizes.Yellow;
    }
}