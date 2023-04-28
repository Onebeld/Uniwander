namespace Uniwander;

public partial class StarInformation : Control
{
	[Export]
	private Label? _labelStarId;
	
	private string _starName = string.Empty;

	public string StarName
	{
		get => _starName;
		set
		{
			_starName = value;

			if (_labelStarId is not null)
				_labelStarId.Text = StarName;
		}
	}
}
