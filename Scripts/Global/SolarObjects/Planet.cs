namespace Uniwander.Global;

using Uniwander.Global.SolarObjects;

[Tool]
public partial class Planet : OrbitingSolarObjects
{
	private bool _loaded;
	private Resource? _planetData;

	[Signal]
	public delegate void ChangedEventHandler();
	
	[Export(PropertyHint.ResourceType)]
	public Resource? PlanetData
	{
		get => _planetData;
		set
		{
			_planetData = value;
			
			if (!_loaded) return;
			OnDataChanged();

			if (PlanetData is not null && !PlanetData.IsConnected(Resource.SignalName.Changed, Callable.From(OnDataChanged)))
			{
				PlanetData.Connect(Resource.SignalName.Changed, Callable.From(OnDataChanged));
			}
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		OnDataChanged();
		
		_loaded = true;
	}
	
	private void OnDataChanged()
	{
		PlanetData?.Set("min_height", 99999.0f);
		PlanetData?.Set("max_height", 0.0f);

		
		
		// Parallel.ForEach(GetChildren(), node =>
		// {
		// 	Generation.PlanetMeshFace? face = node as Generation.PlanetMeshFace;
		// 	
		// 	Stopwatch stopwatch = new();
		//
		// 	stopwatch.Start();
		// 	face?.RegenerateMesh(PlanetData);
		// 	stopwatch.Stop();
		// 	
		// 	GD.Print(stopwatch.Elapsed.Milliseconds);
		// });

		List<int> milliseconds = new();

		foreach (Node child in GetChildren())
		{
			PlanetMeshFace? face = child as PlanetMeshFace;
			
			Stopwatch stopwatch = new();
		
			stopwatch.Start();
			face?.RegenerateMesh(PlanetData);
			stopwatch.Stop();
			
			milliseconds.Add(stopwatch.Elapsed.Milliseconds);
		}
		
		GD.Print(milliseconds.Sum());
	}
}
