using Avalonia;
using avaRouteableSplat.ExtensionMethods;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using avaRouteableSplat.ViewModels;
using avaRouteableSplat.Views;
using Microsoft.Extensions.Hosting;
using Splat.Microsoft.Extensions.DependencyInjection;
using Splat.Microsoft.Extensions.Logging;
using Splat;
using ReactiveUI;
using System;

namespace avaRouteableSplat;

public partial class App : Application
{
    public IServiceProvider? Container { get; private set; }

    public override void Initialize()
    {
        SetupHost();
        AvaloniaXamlLoader.Load(this);
    }

    public void SetupHost()
    {
        var hostBuilder = Host.CreateDefaultBuilder();
        hostBuilder.ConfigureServices(services =>
        {
            services.UseMicrosoftDependencyResolver();

            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();

            services.RegisterServices();
        });

        hostBuilder.ConfigureLogging(builder => builder.AddSplat());
        hostBuilder.UseEnvironment(Environments.Development);

        var host = hostBuilder.Build();

        Container = host.Services;
        Container.UseMicrosoftDependencyResolver();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
            desktop.MainWindow.AttachDevTools();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }

}
