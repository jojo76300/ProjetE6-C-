using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErastourApp.Models;

namespace ErastourApp.ViewModels;

public partial class VoyageursViewModel : ObservableObject
{
    [ObservableProperty]
    private string currentUserName = "admin";

    public ObservableCollection<Utilisateur> Voyageurs { get; set; } = new ObservableCollection<Utilisateur>();

    public VoyageursViewModel()
    {
        LoadVoyageurs();
    }

    private void LoadVoyageurs()
    {
        // Données factices pour l'UI, à remplacer par la DatabaseService une fois remise en place
        Voyageurs.Clear();
        Voyageurs.Add(new Utilisateur { Util_Id = 1, Util_Nom = "Dupont", Util_Prenom = "Pierre", Util_Login = "Pierre.Dupont", Util_Email = "pierre.dupont@campus-la-chataigneraie.org", Util_Tel = "+33 6 54 25 67 95" });
        Voyageurs.Add(new Utilisateur { Util_Id = 2, Util_Nom = "Fontaine", Util_Prenom = "Clara", Util_Login = "Clara.Fontaine", Util_Email = "clara.fontaine@campus-la-chataigneraie.org", Util_Tel = "+33 7 32 95 21 02" });
        Voyageurs.Add(new Utilisateur { Util_Id = 3, Util_Nom = "Szylobryt", Util_Prenom = "Stanislas", Util_Login = "Stanislas.Szylobryt", Util_Email = "stanislas.szylobryt@campus-la-chataigneraie.org", Util_Tel = "+33 6 29 67 30 54" });
    }

    [RelayCommand]
    private async Task Deconnexion()
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    [RelayCommand]
    private async Task NavigateToDashboard()
    {
        await Shell.Current.GoToAsync("//DashboardPage");
    }

    [RelayCommand]
    private async Task NavigateToVoyageurs()
    {
        await Shell.Current.GoToAsync("//VoyageursPage");
    }

    [RelayCommand]
    private async Task NavigateToLieux()
    {
        await Shell.Current.GoToAsync("//LieuxPage");
    }

    [RelayCommand]
    private async Task NavigateToTransports()
    {
        await Shell.Current.GoToAsync("//TransportsPage");
    }

    [RelayCommand]
    private async Task NavigateToTrajets()
    {
        await Shell.Current.GoToAsync("//TrajetsPage");
    }

    [RelayCommand]
    private async Task AjouterVoyageur()
    {
        // await Shell.Current.GoToAsync(nameof(AddVoyageurPage));
        await Application.Current.MainPage.DisplayAlert("Ajouter", "Action d'ajout à implémenter", "OK");
    }

    [RelayCommand]
    private async Task EditVoyageur(Utilisateur voyageur)
    {
        if (voyageur == null) return;
        await Application.Current.MainPage.DisplayAlert("Modifier", $"Modifier le profil de {voyageur.Util_Nom} {voyageur.Util_Prenom}", "OK");
    }

    [RelayCommand]
    private async Task DeleteVoyageur(Utilisateur voyageur)
    {
        if (voyageur == null) return;
        bool answer = await Application.Current.MainPage.DisplayAlert("Confirmation", $"Voulez-vous vraiment supprimer {voyageur.Util_Nom} {voyageur.Util_Prenom} ?", "Oui", "Non");
        if (answer)
        {
            Voyageurs.Remove(voyageur);
        }
    }
}
