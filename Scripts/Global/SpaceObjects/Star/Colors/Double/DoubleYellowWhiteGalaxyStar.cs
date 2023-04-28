using Uniwander.Global.Constants;

namespace Uniwander.Global.SpaceObjects.Star.Colors.Double;

public partial class DoubleYellowWhiteGalaxyStar : DoubleGalaxyStar
{
    public override Color GetFirstColor() => StarColors.Yellow;

    public override Color GetSecondColor() => StarColors.White;
    
    public override void ChangeSprites()
    {
        FirstStarSprite.Scale *= StarSizes.Yellow;
        SecondStarSprite.Scale *= StarSizes.White;
    }
}