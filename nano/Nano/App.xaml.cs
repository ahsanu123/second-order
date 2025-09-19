using Nano.ExtensionMethods;

namespace Nano;

public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected Window? MainWindow { get; private set; }
    protected IHost? Host { get; private set; }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            // Add navigation support for toolkit controls such as TabBar and NavigationView
            .UseToolkitNavigation()
            .Configure(host =>
                host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                    .UseLogging(LoggingExtensionMethod.ConfigureNanoLogging, enableUnoLogging: true)
                    .UseConfiguration(
                        configure: ConfigurationExtensionMethod.ConfigureNanonConfiguration
                    )
                    // Enable localization (see appsettings.json for supported languages)
                    .UseLocalization()
                    .UseHttp(HttpExtensionMethod.ConfigureNanoHtpp)
                    .ConfigureServices(ServiceCollectionExtensionMethod.AddServiceCollections)
                    .UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes)
            );
        MainWindow = builder.Window;

        // #if DEBUG
        //         MainWindow.UseStudio();
        // #endif
        // MainWindow.SetWindowIcon();

        Host = await builder.NavigateAsync<MainPage>();
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(
            new ViewMap<MainPage, MainViewModel>(),
            new DataViewMap<SecondPage, SecondViewModel, Entity>(),
            new ViewMap(ViewModel: typeof(ShellViewModel))
        );

        routes.Register(
            new RouteMap(
                "Main",
                // View: views.FindByViewModel<ShellViewModel>(),
                View: views.FindByViewModel<MainViewModel>(),
                Nested:
                [
                    // new("Main", View: views.FindByViewModel<MainViewModel>()),
                    new("Second", View: views.FindByViewModel<SecondViewModel>()),
                ]
            )
        );
    }
}
