using Compendia.Database.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Database
{
    public static class DatabaseService
    {
        public static DatabaseContext _DatabaseContext;
        public static string Name { get; }
        //public static ObjectRepository _ObjectRepository { get; private set; }
        //public static KategorieRepository _KategorieRepository { get; private set; }
        //public static ObjectKategorieRepository _ObjectKategorieRepository { get; private set; }
        public static LogInRepository _LogInRepository { get; private set; }

        static DatabaseService()
        {

            Name = "Database";

            try
            {
                var databasePath = DependencyService.Get<ISqlite>().GetDatabasePath();

                _DatabaseContext = new DatabaseContext(databasePath);
                Init();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());

            }
        }
        private static void Init()
        {
            //_ObjectRepository = new ObjectRepository(_DatabaseContext);
            //_KategorieRepository = new KategorieRepository(_DatabaseContext);
            //_ObjectKategorieRepository = new ObjectKategorieRepository(_DatabaseContext);

        }
    }
}
