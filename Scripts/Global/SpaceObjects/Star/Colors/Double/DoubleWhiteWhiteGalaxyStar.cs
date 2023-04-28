using Uniwander.Global.Constants;

namespace Uniwander.Global.SpaceObjects.Star.Colors.Double;

public partial class DoubleWhiteWhiteGalaxyStar : DoubleGalaxyStar
{
    public override Color GetFirstColor() => StarColors.White;

    public override Color GetSecondColor() => StarColors.White;
    
    public override void ChangeSprites()
    {
        FirstStarSprite.Scale *= StarSizes.White;
        SecondStarSprite.Scale *= StarSizes.White;
    }
}