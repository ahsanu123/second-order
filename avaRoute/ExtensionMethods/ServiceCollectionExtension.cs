using avaRoute.ViewModels;
using avaRoute.Views;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace avaRoute.ExtensionMethods;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<RoutingState>();

        services.AddSingleton<MainWindowViewModel>();

        services.AddSingleton<IScreen, MainWindowViewModel>(sp => sp.GetRequiredService<MainWindowViewModel>());
        services.AddSingleton<IViewFor<MainWindowViewModel>, MainWindow>();

        services.AddSingleton<FirstViewModel>();
        services.AddSingleton<SecondViewModel>();
    }
}
