using ReactiveUI;
using System;

namespace avaRoute.ViewModels;

public class FirstViewModel : ReactiveObject, IRoutableViewModel
{
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString();
    public IScreen HostScreen { get; }

    public FirstViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}
