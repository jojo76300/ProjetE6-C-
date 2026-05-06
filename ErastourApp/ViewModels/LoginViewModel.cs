using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErastourApp.Models;
using ErastourApp.Pages;
using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using ErastourApp.Database;

namespace ErastourApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    public string Email { get; set; }
    public string Password { get; set; }

    public ICommand LoginCommand { get; }

    private readonly DatabaseService _databaseService;

    public LoginViewModel()
    {
        LoginCommand = new Command(OnLogin);

        _databaseService = new DatabaseService();
    }

    private async void OnLogin()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }
        try
        {
            if (_databaseService.VerifierConnexionUtilisateur(Email, Password))
            {
                _databaseService.LoadUserData(Email, Password);
                await Shell.Current.GoToAsync("///LieuxPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Erreur", "Identifiants incorrects", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erreur", $"Une erreur est survenue : {ex.Message}", "OK");
        }
    }
}