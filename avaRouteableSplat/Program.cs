using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI.Avalonia;
using System;

namespace avaRouteableSplat;

// splat Microsoft DependencyInjection 
//
// https://github.com/reactiveui/splat/blob/main/src/Splat.Microsoft.Extensions.DependencyInjection/README.md

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseReactiveUI()
            .WithInterFont()
            .LogToTrace();
}
