using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ErastourApp.Models;

public class Habilitation
{
    [PrimaryKey, AutoIncrement] public int Hab_Id { get; set; }
    public string? Hab_Libelle { get; set; }
}
