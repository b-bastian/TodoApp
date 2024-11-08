using System;
using TodoApp.Core;
using TodoApp.Core.Models;

namespace TodoApp.TodoData;

public class StaticData : IRepository
{
    List<Todo> _list = new();

    public StaticData()
    {
        _list.Add(new Todo(1, "Lernen"));
        _list.Add(new Todo(2, "Fenster putzen"));
        _list.Add(new Todo(3, "Hausübung erledigen"));
        _list.Add(new Todo(4, "Auto waschen"));
        _list.Add(new Todo(5, "Küche aufräumen"));
        _list.Add(new Todo(6, "Büroarbeit erledigen"));
    }

    public bool Add(Todo item)
    {
        _list.Add(item);
        return true;
    }

    public List<Todo> GetAll()
    {
        return _list;
    }
}

