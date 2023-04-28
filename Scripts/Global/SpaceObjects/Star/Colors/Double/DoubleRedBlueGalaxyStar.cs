using Uniwander.Global.Constants;

namespace Uniwander.Global.SpaceObjects.Star.Colors.Double;

public partial class DoubleRedBlueGalaxyStar : DoubleGalaxyStar
{
    public override Color GetFirstColor() => StarColors.Red;

    public override Color GetSecondColor() => StarColors.Blue;
    
    public override void ChangeSprites()
    {
        FirstStarSprite.Scale *= StarSizes.Red;
        SecondStarSprite.Scale *= StarSizes.Blue;
    }
}