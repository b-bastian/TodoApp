using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoApp.Core.Models;

namespace TodoApp.Core.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private IRepository _repository;

    public MainViewModel(IRepository repository)
    {
        this._repository = repository;  
    }

    public string Title => "TodoApp";

    [ObservableProperty]
    private string _todoTitle = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Todo> _todos = new();

    [RelayCommand]
    void AddTodo()
    {
        Todo t = new(TodoTitle);
        this._repository.Add(t);
        this.Todos.Add(t);

        this.TodoTitle = string.Empty;
    }

    [RelayCommand]
    void LoadData()
    {
        this.Todos.Clear();

        var todos = this._repository.GetAll();

        foreach (var todo in todos)
        {
            this.Todos.Add(todo);
        }
    }
}

