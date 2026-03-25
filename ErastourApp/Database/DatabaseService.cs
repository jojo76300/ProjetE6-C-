using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ErastourApp.Models;
using Microsoft.Data.SqlClient;


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
        string queryString = "PS_S_LIEUX";
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
    public Lieu GetLieu(int id)
    {
        string queryString = "PS_S_LIEU_BY_ID";
        SqlCommand command = new SqlCommand(queryString, Connexion);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("Id", id);
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();
        return new Lieu
        {
            Lieu_Id = (int)reader["Lieu_Id"],
            Lieu_Nom = (string?)reader["Lieu_Nom"],
            Lieu_Ville = (string?)reader["Lieu_Ville"],
            Lieu_Pays = (string?)reader["Lieu_Pays"],
            Lieu_CP = (string?)reader["Lieu_CP"],
            Lieu_Adresse = (string?)reader["Lieu_Adresse"],
            Lieu_LienMap = (string?)reader["Lieu_LienMap"],
            Lieu_Commentaire = (string?)reader["Lieu_Commentaire"]
        };
    }

    public List<Transport> GetTransports()
    {
        string queryString = "PS_S_TRANSPORTS";
        SqlCommand command = new SqlCommand(queryString, Connexion);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader reader = command.ExecuteReader();
        var transports = new List<Transport>();
        while (reader.Read())
        {
            transports.Add(
                new Transport
                {
                    Tran_Id = (int)reader["Tran_Id"],
                    Tran_Type = (string?)reader["Tran_Type"],
                    Tran_Numero = (string?)reader["Tran_Numero"],
                    Tran_Compagnie = (string?)reader["Tran_Compagnie"]
                });
        }
        return transports;
    }

    public Transport GetTransport(int id)
    {
        string queryString = "PS_S_TRANSPORT_BY_ID";
        SqlCommand command = new SqlCommand(queryString, Connexion);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("Id", id);
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();
        return new Transport
        {
            Tran_Id = (int)reader["Tran_Id"],
            Tran_Type = (string?)reader["Tran_Type"],
            Tran_Numero = (string?)reader["Tran_Numero"],
            Tran_Compagnie = (string?)reader["Tran_Compagnie"]
        };
    }

    public List<Utilisateur> GetUtilisateurs()
    {
        string queryString = "PS_S_UTILISATEURS";
        SqlCommand command = new SqlCommand(queryString, Connexion);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader reader = command.ExecuteReader();
        var utilisateurs = new List<Utilisateur>();
        while (reader.Read())
        {
            utilisateurs.Add(
                new Utilisateur
                {
                    Util_Id = (int)reader["Util_Id"],
                    Util_Nom = (string?)reader["Util_Nom"],
                    Util_Prenom = (string?)reader["Util_Prenom"],
                    Util_Login = (string?)reader["Util_Login"],
                    Util_Password = (string?)reader["Util_Password"],
                    Util_Tel = (string?)reader["Util_Tel"],
                    Util_Email = (string?)reader["Util_Email"],
                    Util_estGestionnaire = (bool?)reader["Util_estGestionnaire"]
                });
        }
        return utilisateurs;
    }

    public Utilisateur GetUtilisateur(int id)
    {
        string queryString = "PS_S_UTILISATEUR_BY_ID";
        SqlCommand command = new SqlCommand(queryString, Connexion);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("Id", id);
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();
        return new Utilisateur
        {
            Util_Id = (int)reader["Util_Id"],
            Util_Nom = (string?)reader["Util_Nom"],
            Util_Prenom = (string?)reader["Util_Prenom"],
            Util_Login = (string?)reader["Util_Login"],
            Util_Password = (string?)reader["Util_Password"],
            Util_Tel = (string?)reader["Util_Tel"],
            Util_Email = (string?)reader["Util_Email"],
            Util_estGestionnaire = (bool?)reader["Util_estGestionnaire"]
        };
    }
}
