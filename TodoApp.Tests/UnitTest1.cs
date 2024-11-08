using TodoApp.Core;
using TodoApp.Core.ViewModels;
using TodoApp.TodoData;

namespace TodoApp.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    [Test]
    public void TestVM()
    {
        // arrange
        IRepository rep = new StaticData();
        
        // act
        MainViewModel viewModel = new MainViewModel(rep);

        // assert
        Assert.IsNotNull(viewModel);
    }
}