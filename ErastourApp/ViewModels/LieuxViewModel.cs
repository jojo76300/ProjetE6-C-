using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErastourApp.Models;

namespace ErastourApp.ViewModels;

public partial class LieuxViewModel : ObservableObject
{
    [ObservableProperty]
    private string currentUserName = "admin";

    public ObservableCollection<Lieu> Lieux { get; set; } = new ObservableCollection<Lieu>();

    public LieuxViewModel()
    {
        LoadLieux();
    }

    private void LoadLieux()
    {
        // Données factices pour l'UI, à remplacer par la DatabaseService une fois remise en place
        Lieux.Clear();
        Lieux.Add(new Lieu { Lieu_Id = 1, Lieu_Nom = "Charles de Gaulle", Lieu_Ville = "Paris", Lieu_Pays = "France", Lieu_Commentaire = "Aéroport" });
        Lieux.Add(new Lieu { Lieu_Id = 2, Lieu_Nom = "Gare de Lyon", Lieu_Ville = "Paris", Lieu_Pays = "France", Lieu_Commentaire = "Gare" });
        Lieux.Add(new Lieu { Lieu_Id = 3, Lieu_Nom = "Saint-Exupéry", Lieu_Ville = "Lyon", Lieu_Pays = "France", Lieu_Commentaire = "Aéroport" });
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
}
