using ReactiveUI;

namespace avaRouteableSplat.ViewModels;

public class SecondViewModel : ReactiveObject, IRoutableViewModel
{
    public string UrlPathSegment => "first";
    public IScreen HostScreen { get; }

    public SecondViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}
