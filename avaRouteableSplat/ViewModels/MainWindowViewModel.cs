using ReactiveUI;
using System;
using Splat;

namespace avaRouteableSplat.ViewModels;

public partial class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; }

    public MainWindowViewModel()
    {
        var router = Locator.Current.GetService<RoutingState>();

        if (router == null)
            throw new ArgumentNullException();

        Router = router;
    }
}
