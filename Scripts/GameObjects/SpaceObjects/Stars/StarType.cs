using Godot;
using Uniwander.Scripts.GameObjects.SpaceObjects.Stars.Enums;

namespace Uniwander.Scripts.GameObjects.SpaceObjects.Stars;

[GlobalClass]
[Tool]
public partial class StarType : Resource
{
    [Export]
    public StarColor StarColor;
    
    [Export]
    public StarSize StarSize;
}