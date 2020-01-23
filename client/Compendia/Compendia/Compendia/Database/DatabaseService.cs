using Compendia.Database.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Database
{
    public static class DatabaseService
    {
        public static DatabaseContext _DatabaseContext;
        public static string Name { get; }

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
                Debug.WriteLine(e.Message.ToString());

            }
        }
        private static void Init()
        {
            _LogInRepository = new LogInRepository(_DatabaseContext);
          

        }
    }
}
