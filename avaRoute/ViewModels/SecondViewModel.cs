using System;
using ReactiveUI;
using Splat;

namespace avaRoute.ViewModels;

public class SecondViewModel : ReactiveObject, IRoutableViewModel
{
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString();
    public IScreen HostScreen { get; }

    public SecondViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}
