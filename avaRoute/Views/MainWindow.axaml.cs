using Avalonia.Markup.Xaml;
using avaRoute.ViewModels;
using ReactiveUI.Avalonia;

namespace avaRoute.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        AvaloniaXamlLoader.Load(this);
    }
}
