using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ErastourApp.Models
{
    internal class Session
    {
        public static Utilisateur User { get; set; }
        public static string ConnectionString { get; set; }
        public static SqlConnection Connexion { get; set; }
    }
}
