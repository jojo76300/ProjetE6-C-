using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ErastourApp.Models
{
    public class Trajet
    {
        [PrimaryKey, AutoIncrement] public int Tra_Id { get; set; }
        public string? Tra_lieu_depart { get; set; }
        public string? Tra_lieu_arrive { get; set; }
        public bool? Tra_Status { get; set; }
    }
}
