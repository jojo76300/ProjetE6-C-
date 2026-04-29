using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErastourApp.Models;
using ErastourApp.Database;

namespace ErastourApp.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService; // Ajout du databaseService

        [ObservableProperty]
        private string currentUserName = "admin";

        public ObservableCollection<Utilisateur> Utilisateurs { get; set; } = new ObservableCollection<Utilisateur>();


    }
}
