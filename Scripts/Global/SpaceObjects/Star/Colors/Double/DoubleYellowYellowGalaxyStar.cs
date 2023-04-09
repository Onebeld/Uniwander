using Godot;
using Uniwander.Scripts.Global.Constants;

namespace Uniwander.Scripts.Global.SpaceObjects.Star.Colors.Double;

public partial class DoubleYellowYellowGalaxyStar : DoubleGalaxyStar
{
    public override Color GetFirstColor() => StarColors.Yellow;

    public override Color GetSecondColor() => StarColors.Yellow;
    
    public override void ChangeSprites()
    {
        FirstStarSprite.Scale *= StarSizes.Yellow;
        SecondStarSprite.Scale *= StarSizes.Yellow;
    }
}