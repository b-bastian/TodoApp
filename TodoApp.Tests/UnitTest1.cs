using TodoApp.Core;
using TodoApp.Core.Models;
using TodoApp.Core.ViewModels;
using TodoApp.TodoData;
using Moq;

namespace TodoApp.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void TestVM()
    {
        // arrange
        IRepository rep = new StaticData();
        MainViewModel viewModel = new MainViewModel(rep);
        
        // act

        // assert
        Assert.IsNotNull(viewModel);
    }
    
    [Test]
    public void TestLoadCommand()
    {
        // arrange
        IRepository rep = new StaticData();
        MainViewModel viewModel = new MainViewModel(rep);
        
        // act
        viewModel.LoadDataCommand.Execute(null);
        
        // assert
        Assert.That(viewModel.Todos.Count, Is.EqualTo(6));
    }
    
    [Test]
    public void TestSaveCommandVM()
    {
        // arrange
        IRepository rep = new StaticData();
        MainViewModel viewModel = new MainViewModel(rep);
        
        // act
        string input = "**TEST**";
        viewModel.TodoTitle = input;
        viewModel.AddTodoCommand.Execute(null);

        // assert
        Todo? item = (from t in viewModel.Todos
            where t.Title == input
            select t).FirstOrDefault();

        Assert.Multiple(() =>
        {
            Assert.That(item, Is.Not.Null);
            Assert.That(item?.Title, Is.EqualTo(input));
            Assert.That(item?.ToString(), Is.EqualTo(input));
            Assert.That(viewModel.TodoTitle, Is.EqualTo(string.Empty));
        });
    }

    [Test]
    public void TestMock()
    {
        var mock = new Mock<IRepository>();
        mock.Setup(x => x.GetAll()).Returns(new List<Todo>()
        {
            new Todo("Test")
        });
        
        MainViewModel viewModel = new MainViewModel(mock.Object);
        
        viewModel.LoadDataCommand.Execute(null);
        viewModel.AddTodoItemCommand.Execute(new Todo("Probe"));
        
        Assert.That(viewModel.Todos.Count, Is.Not.EqualTo(1));
    }
}