using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ErastourApp.Models;

public class Utilisateur
{
    [PrimaryKey, AutoIncrement] public int Util_Id { get; set; }
    public string? Util_Nom { get; set; }
    public string? Util_Prenom { get; set; }
    public string? Util_Login { get; set; }
    public string? Util_Password { get; set; }
    public string? Util_Tel { get; set; }
    public string? Util_Email { get; set; }
    public bool? Util_estGestionnaire { get; set; }
}
