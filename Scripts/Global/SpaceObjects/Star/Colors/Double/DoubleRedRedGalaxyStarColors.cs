using Uniwander.Scripts.Global.Constants;
using Uniwander.Scripts.Global.Interfaces.SpaceObjects.Star;

namespace Uniwander.Scripts.Global.SpaceObjects.Star.Colors.Double;

public partial class DoubleRedRedGalaxyStarColors : DoubleGalaxyStar
{
    public override Color GetFirstColor() => StarColors.Red;

    public override Color GetSecondColor() => StarColors.Red;
    
    public override void ChangeSprites()
    {
        FirstStarSprite.Scale *= StarSizes.Red;
        SecondStarSprite.Scale *= StarSizes.Red;
    }
}