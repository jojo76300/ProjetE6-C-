using ErastourApp.ViewModels;

namespace ErastourApp.Pages;

public partial class LieuxUpdate : ContentPage
{
    public LieuxUpdate(LieuxViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}