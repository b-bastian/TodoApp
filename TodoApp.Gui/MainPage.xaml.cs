using TodoApp.Core.ViewModels;

namespace TodoApp.Gui;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}


