namespace Uniwander.Global;

public partial class Wormhole : ClickableSpaceObject
{
	[Export]
	public Wormhole TargetWormhole { get; set; }
	
	[Export]
	public string Name { get; set; }
}
