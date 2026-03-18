using ErastourApp.ViewModels;

namespace ErastourApp.Pages;

public partial class VoyageursPage : ContentPage
{
	public VoyageursPage()
	{
		InitializeComponent();
        BindingContext = new VoyageursViewModel();
    }
}