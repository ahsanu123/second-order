using System.Reactive;
using ReactiveUI;
using Splat;

namespace avaRoute.ExtensionMethods;

public static class ReactiveCommandExtensionMethod
{
    public static ReactiveCommand<Unit, IRoutableViewModel> NavigateTo<T>(this RoutingState router)
        where T : ReactiveObject, IRoutableViewModel
    {
        return ReactiveCommand.CreateFromObservable(
            () => router.Navigate.Execute(Locator.Current.GetService<T>()!)
        );
    }
}
