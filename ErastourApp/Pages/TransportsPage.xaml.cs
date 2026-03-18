using ErastourApp.ViewModels;

namespace ErastourApp.Pages;

public partial class TransportsPage : ContentPage
{
    public TransportsPage()
    {
        InitializeComponent();
        BindingContext = new TransportsViewModel();
    }
}