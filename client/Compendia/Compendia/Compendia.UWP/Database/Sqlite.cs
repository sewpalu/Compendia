using Compendia.Database;
using Compendia.Database.Base;
using Compendia.UWP;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqlite))]
namespace Compendia.UWP
{
    public class Sqlite : ISqlite
    {
        private SqliteConnection _connection;
        public bool CloseDatabaseConnection()
        {
            throw new NotImplementedException();
        }

        public bool DeleteDatabase()
        {
            throw new NotImplementedException();
        }

        public SqliteConnection GetDatabaseConnection()
        {
            var databasePath = GetDatabasePath();
            _connection = new SqliteConnection(databasePath);
            return _connection;
        }

        public string GetDatabasePath()
        {
            var databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DatabaseService.Name + ".db");
            return databasePath;
        }
    }
}
