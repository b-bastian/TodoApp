using System;
namespace TodoApp.Core.Models;

public class Todo
{
	public int Id { get; set; } = 0;

	public string Title { get; set; }

	public Todo(string title)
	{
		this.Title = title;
	}

	public Todo(int id, string title)
	{
		this.Id = id;
		this.Title = title;
	}

	public override string ToString()
	{
		return this.Title;
	}
}

