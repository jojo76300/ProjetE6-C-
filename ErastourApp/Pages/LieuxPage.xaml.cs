using ErastourApp.ViewModels;

namespace ErastourApp.Pages;

public partial class LieuxPage : ContentPage
{
	public LieuxPage()
	{
		InitializeComponent();
		BindingContext = new LieuxViewModel();
	}
}
