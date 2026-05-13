using ErastourApp.ViewModels;

namespace ErastourApp.Pages;

public partial class LieuxInsert : ContentPage
{
	public LieuxInsert(LieuxViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }
}