using Avalonia;
using Avalonia.Markup.Xaml;
using PleasantUI;

namespace Uniwander.UI;

public partial class App : Application
{
    public static PleasantTheme PleasantTheme { get; private set; } = null!;
    
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        PleasantTheme = new PleasantTheme();
        Styles.Add(PleasantTheme);
        
        base.OnFrameworkInitializationCompleted();
    }
}