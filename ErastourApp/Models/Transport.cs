using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ErastourApp.Models;

public class Transport
{
    [PrimaryKey, AutoIncrement] public int Tran_Id { get; set; }
    public string? Tran_Type { get; set; }
    public string? Tran_Numero { get; set; }
    public string? Tran_Compagnie { get; set; }
}
