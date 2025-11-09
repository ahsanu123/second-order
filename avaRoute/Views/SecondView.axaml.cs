using Avalonia.Markup.Xaml;
using avaRoute.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace avaRoute.Views;

public partial class SecondView : ReactiveUserControl<SecondViewModel>
{
    public SecondView()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(disposables => { });
    }
}
