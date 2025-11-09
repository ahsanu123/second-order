using System;
using avaRoute.ViewModels;
using avaRoute.Views;
using ReactiveUI;

namespace avaRoute;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        FirstViewModel context => new FirstView { DataContext = context },
        SecondViewModel context => new SecondView { DataContext = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}
