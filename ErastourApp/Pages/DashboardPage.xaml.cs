using ErastourApp.ViewModels;

namespace ErastourApp.Pages;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
        BindingContext = new DashboardViewModel();
    }
}