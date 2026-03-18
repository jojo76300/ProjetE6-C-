using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ErastourApp.Models
{
    public class Voyage
    {
        [PrimaryKey, AutoIncrement] public int Voyage_Id { get; set; }
    }
}
