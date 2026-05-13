using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErastourApp.Models;
using ErastourApp.Database; // Ajout du using pour DatabaseService

namespace ErastourApp.ViewModels;

public partial class LieuxViewModel : ObservableObject, IQueryAttributable
{
    private readonly DatabaseService _databaseService; // Ajout du databaseService
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public string Ville { get; set; }
    public string CP { get; set; }
    public string Pays { get; set; }
    public string LienMap { get; set; }
    public string Commentaire { get; set; }

    //[ObservableProperty]
    //private string currentUserName = Session.User.Util_Login;

    [ObservableProperty]
    private ObservableCollection<Lieu> _lieux = new ObservableCollection<Lieu>();

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
    private async Task NavigateToLieuInsert()
    {
        await Shell.Current.GoToAsync("///LieuxInsert");
    }

    [RelayCommand]
    private async Task AjouterLieu()
    {
        _databaseService.AddLieu(new Lieu
        {
            Lieu_Nom = Nom,
            Lieu_Adresse = Adresse,
            Lieu_Ville = Ville,
            Lieu_CP = CP,
            Lieu_Pays = Pays,
            Lieu_LienMap = LienMap,
            Lieu_Commentaire = Commentaire
        });
        await Shell.Current.GoToAsync("///LieuxPage");
        LoadLieux();
    }

    [RelayCommand]
    private void NavigateToLieuUpdate(Lieu lieu)
    {
        Shell.Current.GoToAsync("///LieuxUpdate", true, new Dictionary<string, object>
        {
            { "Lieu", lieu }
        });
    }

    [ObservableProperty]
    private Lieu _lieu;
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Lieu = (Lieu)query["Lieu"];
    }

    [RelayCommand]
    private async Task ModifierLieu()
    {
        _databaseService.UpdateLieu(new Lieu
        {
            Lieu_Id = Lieu.Lieu_Id,
            Lieu_Nom = Lieu.Lieu_Nom,
            Lieu_Adresse = Lieu.Lieu_Adresse,
            Lieu_Ville = Lieu.Lieu_Ville,
            Lieu_CP = Lieu.Lieu_CP,
            Lieu_Pays = Lieu.Lieu_Pays,
            Lieu_LienMap = Lieu.Lieu_LienMap,
            Lieu_Commentaire = Lieu.Lieu_Commentaire
        });
        await Shell.Current.GoToAsync("///LieuxPage");
        LoadLieux();
    }

    [RelayCommand]
    private async Task DeleteLieu(Lieu lieu)
    {
        if (lieu == null) return;
        bool answer = await Application.Current.MainPage.DisplayAlert("Confirmation", $"Voulez-vous vraiment supprimer {lieu.Lieu_Nom} ?", "Oui", "Non");
        if (answer)
        {
            _databaseService.DeleteLieu(lieu.Lieu_Id);
            LoadLieux();
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
