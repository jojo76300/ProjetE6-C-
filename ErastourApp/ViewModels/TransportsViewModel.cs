using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErastourApp.Models;

namespace ErastourApp.ViewModels;

public partial class TransportsViewModel : ObservableObject
{
    [ObservableProperty]
    private string currentUserName = "admin";

    public ObservableCollection<Transport> Transports { get; set; } = new ObservableCollection<Transport>();

    public TransportsViewModel()
    {
        LoadTransports();
    }

    private void LoadTransports()
    {
        // Données factices pour l'UI, à remplacer par la DatabaseService une fois remise en place
        Transports.Clear();
        Transports.Add(new Transport { Tran_Id = 1, Tran_Type = "Bus", Tran_Numero = "67", Tran_Compagnie = "Nomad" });
        Transports.Add(new Transport {Tran_Id = 2, Tran_Type = "Avion", Tran_Numero = "45B731", Tran_Compagnie = "AirFrance" });
        Transports.Add(new Transport {Tran_Id = 3, Tran_Type = "Vélo", Tran_Numero = "5", Tran_Compagnie = "Vélib" });
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
    private async Task AjouterTransport()
    {
        // await Shell.Current.GoToAsync(nameof(AddTransportPage));
        await Application.Current.MainPage.DisplayAlert("Ajouter", "Action d'ajout à implémenter", "OK");
    }

    [RelayCommand]
    private async Task EditTransport(Transport transport)
    {
        if (transport == null) return;
        await Application.Current.MainPage.DisplayAlert("Modifier", $"Modifier le transport numéro {transport.Tran_Numero}", "OK");
    }

    [RelayCommand]
    private async Task DeleteTransport(Transport transport)
    {
        if (transport == null) return;
        bool answer = await Application.Current.MainPage.DisplayAlert("Confirmation", $"Voulez-vous vraiment supprimer le transport numéro {transport.Tran_Numero} ?", "Oui", "Non");
        if (answer)
        {
            Transports.Remove(transport);
        }
    }
}