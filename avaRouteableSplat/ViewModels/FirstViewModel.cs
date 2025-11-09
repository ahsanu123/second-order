using ReactiveUI;
using System;

namespace avaRouteableSplat.ViewModels;

public class FirstViewModel : ReactiveObject, IRoutableViewModel
{
    public string UrlPathSegment => "first";
    public IScreen HostScreen { get; }

    public FirstViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}
