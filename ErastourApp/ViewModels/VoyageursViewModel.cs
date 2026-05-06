using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErastourApp.Database;
using ErastourApp.Models;

namespace ErastourApp.ViewModels;

public partial class VoyageursViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    [ObservableProperty]
    private string currentUserName = "admin";

    public ObservableCollection<Utilisateur> Voyageurs { get; set; } = new ObservableCollection<Utilisateur>();

    public VoyageursViewModel()
    {
        _databaseService = new DatabaseService(); // Initialisation
        LoadVoyageurs();
    }

    private void LoadVoyageurs()
    {
        Voyageurs.Clear();
        // Appel à la méthode de votre DatabaseService
        var voyageursFromDb = _databaseService.GetVoyageurs();
        foreach (var voyageur in voyageursFromDb)
        {
            Voyageurs.Add(voyageur);
        }
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
