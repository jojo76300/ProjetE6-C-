using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ErastourApp.ViewModels;

public class MainViewModel
{
    public ICommand GoToAppCommand { get; }

    public MainViewModel()
    {
        GoToAppCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync("//LoginPage");
        });
    }
}