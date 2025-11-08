using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace avaTodoList.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string? _newItemContent;

    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        TodoItems.Add(new TodoItemViewModel { Content = NewItemContent });
        NewItemContent = null;
    }

    [RelayCommand]
    private void RemoveItem(TodoItemViewModel item)
    {
        TodoItems.Remove(item);
    }

    private bool CanAddItem() => !string.IsNullOrEmpty(NewItemContent);

    public ObservableCollection<TodoItemViewModel> TodoItems { get; } =
        new ObservableCollection<TodoItemViewModel>();
}
