using Uniwander.Scripts.Global.Constants;

namespace Uniwander.Scripts.Global.SpaceObjects.Star.Colors.Double;

public partial class DoubleBlueWhiteGalaxyStar : DoubleGalaxyStar
{
    public override Color GetFirstColor() => StarColors.Blue;

    public override Color GetSecondColor() => StarColors.White;
    
    public override void ChangeSprites()
    {
        FirstStarSprite.Scale *= StarSizes.Blue;
        SecondStarSprite.Scale *= StarSizes.White;
    }
}