using ErastourApp.ViewModels;

namespace ErastourApp.Pages;

public partial class LieuxPage : ContentPage
{
	public LieuxPage(LieuxViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
