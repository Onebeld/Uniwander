using Uniwander.Scripts.Global.Constants;

namespace Uniwander.Scripts.Global.SpaceObjects.Star.Colors.Double;

public partial class DoubleRedWhiteGalaxyStar : DoubleGalaxyStar
{
    public override Color GetFirstColor() => StarColors.Red;

    public override Color GetSecondColor() => StarColors.White;
    
    public override void ChangeSprites()
    {
        FirstStarSprite.Scale *= StarSizes.Red;
        SecondStarSprite.Scale *= StarSizes.White;
    }
}