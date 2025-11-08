using avaTodoList.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace avaTodoList.ViewModels;

public partial class TodoItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isChecked;

    [ObservableProperty]
    private string? _content;

    public TodoItemViewModel() { }

    public TodoItemViewModel(TodoItem item)
    {
        IsChecked = item.IsChecked;
        Content = item.Content;
    }

    public TodoItem GetTodoItem() =>
        new TodoItem { IsChecked = this.IsChecked, Content = this.Content };
}
