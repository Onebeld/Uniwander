using Uniwander.Global.Constants;

namespace Uniwander.Global.SpaceObjects.Star.Colors.Double;

public partial class DoubleBlueBlueGalaxyStar : DoubleGalaxyStar
{
    public override Color GetFirstColor() => StarColors.Blue;

    public override Color GetSecondColor() => StarColors.Blue;
    
    public override void ChangeSprites()
    {
        FirstStarSprite.Scale *= StarSizes.Blue;
        SecondStarSprite.Scale *= StarSizes.Blue;
    }
}