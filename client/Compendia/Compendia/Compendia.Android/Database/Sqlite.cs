using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Compendia.Database;
using Compendia.Database.Base;
using Compendia.Droid.Database;
using Microsoft.Data.Sqlite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqlite))]
namespace Compendia.Droid.Database
{
    public class Sqlite : ISqlite
    {
        private SqliteConnection _connection;
        public bool CloseDatabaseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;

                //Activate the garbage collector to delete unused resources
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return true;
            }
            return false;
        }

        public bool DeleteDatabase()
        {
            //throw new NotImplementedException();
            var databasePath = GetDatabasePath();
            try
            {
                if (_connection != null)
                {
                    _connection.Close();
                }
                if (File.Exists(databasePath))
                {
                    File.Delete(databasePath);
                }

                _connection = null;
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public SqliteConnection GetDatabaseConnection()
        {
            var databasePath = GetDatabasePath();
            _connection = new SqliteConnection(databasePath);
            return _connection;
        }

        public string GetDatabasePath()
        {

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, DatabaseService.Name + ".db");

            return path;
        }
    }
}