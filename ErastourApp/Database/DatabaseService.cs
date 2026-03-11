using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ErastourApp.Database;

public partial class DatabaseService
{
    private readonly SQLiteConnection _database;
    public const string DatabaseFileName = "erastour.db";
    public const SQLiteOpenFlags Flags = 
    SQLiteOpenFlags.ReadWrite |
    SQLiteOpenFlags.Create |
    SQLiteOpenFlags.SharedCache;

    public DatabaseService()
    {

    }
}
