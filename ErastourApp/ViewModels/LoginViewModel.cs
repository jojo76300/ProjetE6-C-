using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ErastourApp.ViewModels;

public class LoginViewModel
{
    public string Login { get; set; }
    public string Password { get; set; }

    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new Command(OnLogin);
    }

    private async void OnLogin()
    {
        if (Login == "admin" && Password == "1234")
        {
            await Shell.Current.DisplayAlert("Succès", "Connexion OK", "OK");
        }
        else
        {
            await Shell.Current.DisplayAlert("Erreur", "Identifiants incorrects", "OK");
        }
    }
}