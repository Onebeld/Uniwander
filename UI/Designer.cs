#if DEBUG

using System;
using Avalonia;

namespace Uniwander.UI;

internal static class Designer
{
    public static int Main(String[] args)
    {
        throw new NotSupportedException("This project isn't meant to be run: it's only for Avalonia designer support.");
    }
    
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder
            .Configure<App>()
            .UseSkia();
}

#endif