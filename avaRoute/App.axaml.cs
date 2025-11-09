using Avalonia;
using Splat.Microsoft.Extensions.Logging;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using avaRoute.ExtensionMethods;
using avaRoute.Views;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using System;
using avaRoute.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReactiveUI.Avalonia;

namespace avaRoute;

public partial class App : Application
{
    public IServiceProvider? Container { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var hostBuilder = Host.CreateDefaultBuilder();
        hostBuilder.ConfigureServices(services =>
        {
            services.UseMicrosoftDependencyResolver();

            var resolver = Locator.CurrentMutable;

            resolver.InitializeSplat();
            resolver.InitializeReactiveUI();
            RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;

            services.AddServices();
        });

        hostBuilder.ConfigureLogging(builder =>
        {
            builder.ClearProviders();

            builder.AddConsole();
            builder.AddDebug();
            builder.AddSplat();
            builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
        });
        hostBuilder.UseEnvironment(Environments.Development);

        var host = hostBuilder.Build();

        Container = host.Services;
        Container.UseMicrosoftDependencyResolver();

        /// =====================
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Container!.GetService<MainWindowViewModel>()
            };

            desktop.MainWindow.AttachDevTools();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
