using System.Reactive;
using avaRoute.ExtensionMethods;
using ReactiveUI;
using Splat;

namespace avaRoute.ViewModels;

public partial class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; }

    // The command that navigates a user to first view model.
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

    // The command that navigates a user back.
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }

    public MainWindowViewModel()
    {
        Router = Locator.Current.GetService<RoutingState>()!;

        GoNext = Router.NavigateTo<FirstViewModel>();
        GoBack = Router.NavigateTo<SecondViewModel>();
    }
}
