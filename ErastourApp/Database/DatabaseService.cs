using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ErastourApp.Models;


namespace ErastourApp.Database;

public partial class DatabaseService
{
    private SqlConnection Connexion { get; set; }

    public DatabaseService()
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = "localhost",
            InitialCatalog = "Erastour",
            UserID = "sa",
            Password = "Info76240#",
            TrustServerCertificate = true,
        };

        //Création de la connexion à la base de données avec la chaîne de connexion
        Connexion = new SqlConnection(connectionStringBuilder.ConnectionString);
        Connexion.Open();
    }

    public List<Lieu> GetLieux()        
    {
        string queryString = "GetLieux";
        SqlCommand command = new SqlCommand(queryString, Connexion);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader reader = command.ExecuteReader();
        var lieux = new List<Lieu>();
        while (reader.Read())
        {
            lieux.Add(
                new Lieu
                {
                    Lieu_Id = (int)reader["Lieu_Id"],
                    Lieu_Nom = (string?)reader["Lieu_Nom"],
                    Lieu_Ville = (string?)reader["Lieu_Ville"],
                    Lieu_Pays = (string?)reader["Lieu_Pays"],
                    Lieu_CP = (string?)reader["Lieu_CP"],
                    Lieu_Adresse = (string?)reader["Lieu_Adresse"],
                    Lieu_LienMap = (string?)reader["Lieu_LienMap"],
                    Lieu_Commentaire = (string?)reader["Lieu_Commentaire"] 
                });
        }
        return lieux;
    }
}
