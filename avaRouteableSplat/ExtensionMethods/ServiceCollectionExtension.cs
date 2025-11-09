using avaRouteableSplat.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace avaRouteableSplat.ExtensionMethods;

public static class ServiceCollectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<RoutingState>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<FirstViewModel>();
        services.AddSingleton<SecondViewModel>();
    }
}
