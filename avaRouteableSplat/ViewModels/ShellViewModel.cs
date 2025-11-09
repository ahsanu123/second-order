using ReactiveUI;

namespace avaRouteableSplat.ViewModels;

public class ShellViewModel : ReactiveObject, IScreen
{
    public ShellViewModel(RoutingState routingState)
    {
        Router = routingState;
    }

    public RoutingState Router { get; }
}
