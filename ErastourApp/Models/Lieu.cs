using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ErastourApp.Models;

public class Lieu
{
    [PrimaryKey, AutoIncrement] public int Lieu_Id { get; set; }
    public string? Lieu_Nom { get; set; }
    public string? Lieu_Ville { get; set; }
    public string? Lieu_Pays { get; set; }
    public string? Lieu_CP { get; set; }
    public string? Lieu_Adresse { get; set; }
    public string? Lieu_LienMap { get; set; }
    public string? Lieu_Commentaire { get; set; }
}
