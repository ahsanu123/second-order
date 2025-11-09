using Avalonia.Controls;
using ReactiveUI;
using avaRouteableSplat.ViewModels;
using ReactiveUI.Avalonia;

namespace avaRouteableSplat.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        // ViewModel = new MainWindowViewModel();

        this.WhenActivated(disposables =>
        {
            // this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
            //                .DisposeWith(disposables);
            // this.BindCommand(ViewModel, x => x.GoNext, x => x.GoNextButton)
            //     .DisposeWith(disposables);
            // this.BindCommand(ViewModel, x => x.GoBack, x => x.GoBackButton)
            //     .DisposeWith(disposables);
        });
    }
}
