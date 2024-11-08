using System;
using TodoApp.Core.Models;

namespace TodoApp.Core;

/// <summary>
/// An interface for the todo app services
/// </summary>
public interface IRepository
{
    /// <summary>
    /// get all todos
    /// </summary>
    /// <returns>a list o todo items</returns>
    List<Todo> GetAll();

    /// <summary>
    /// add a todo
    /// </summary>
    /// <param name="item">todo to add</param>
    /// <returns>true if successfully added</returns>
    bool Add(Todo item);
}

