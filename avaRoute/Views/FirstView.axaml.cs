using Avalonia.Markup.Xaml;
using avaRoute.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace avaRoute.Views;

public partial class FirstView : ReactiveUserControl<FirstViewModel>
{
    public FirstView()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(disposables => { });
    }
}
