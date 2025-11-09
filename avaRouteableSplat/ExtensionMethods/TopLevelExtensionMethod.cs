using Avalonia.Controls;
using avaRouteableSplat.ViewModels;
using avaRouteableSplat.Views;
using Splat;

namespace avaRouteableSplat.ExtensionMethods;

public static class TopLevelExtensionMethod
{
    public static void CreateMainContent(this TopLevel window)
    {
        var view = new FirstView();
        view.DataContext = Locator.Current.GetService<FirstViewModel>();

        window.Content = view;
    }

}
