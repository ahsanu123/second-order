using avaRouteableSplat.ViewModels;
using Avalonia.Controls;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace avaRouteableSplat.Views;

public partial class FirstView : ReactiveUserControl<FirstViewModel>
{
    public FirstView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            // this.OneWayBind(ViewModel, x => x.UrlPathSegment, x => x.PathTextBlock.Text)
            //     .DisposeWith(disposables);
        });

    }
}
