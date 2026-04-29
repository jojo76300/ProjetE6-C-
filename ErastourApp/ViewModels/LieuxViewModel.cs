using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErastourApp.Models;
using ErastourApp.Database; // Ajout du using pour DatabaseService

namespace ErastourApp.ViewModels;

public partial class LieuxViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService; // Ajout du databaseService

    [ObservableProperty]
    private string currentUserName = "admin";

    public ObservableCollection<Lieu> Lieux { get; set; } = new ObservableCollection<Lieu>();

    public LieuxViewModel()
    {
        _databaseService = new DatabaseService(); // Initialisation
        LoadLieux();
    }

    private void LoadLieux()
    {
        Lieux.Clear();
        // Appel à la méthode de votre DatabaseService
        var lieuxFromDb = _databaseService.GetLieux(); 
        foreach (var lieu in lieuxFromDb)
        {
            Lieux.Add(lieu);
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
    private async Task AjouterLieu()
    {
        // await Shell.Current.GoToAsync(nameof(AddLieuPage));
        await Application.Current.MainPage.DisplayAlert("Ajouter", "Action d'ajout à implémenter", "OK");
    }

    [RelayCommand]
    private async Task EditLieu(Lieu lieu)
    {
        if (lieu == null) return;
        await Application.Current.MainPage.DisplayAlert("Modifier", $"Modifier le lieu {lieu.Lieu_Nom}", "OK");
    }

    [RelayCommand]
    private async Task DeleteLieu(Lieu lieu)
    {
        if (lieu == null) return;
        bool answer = await Application.Current.MainPage.DisplayAlert("Confirmation", $"Voulez-vous vraiment supprimer {lieu.Lieu_Nom} ?", "Oui", "Non");
        if (answer)
        {
            Lieux.Remove(lieu);
        }
    }

    [RelayCommand]
    private async Task OpenMap(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) return;

        try
        {
            Uri uri = new Uri(url);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            // Gérer les erreurs (lien invalide par ex)
            await Application.Current.MainPage.DisplayAlert("Erreur", "Impossible d'ouvrir le lien: " + ex.Message, "OK");
        }
    }
}
