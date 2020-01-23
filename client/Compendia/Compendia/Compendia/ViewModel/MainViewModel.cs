using Compendia.Database;
using Compendia.ViewModel.Base;
using Compendia.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Compendia.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            //connectUser();

        }


        /*private async void connectUser()
        {
            //connect with Database 

            
            try
            {   //Benutzername und Passwort aus Datenbank holen
                var userdata = await DatabaseService._LogInRepository.GetLastObjectAsync();
                //Userdaten überprüfen

            }
            catch (Exception e)
            {
                //await PushAsync(new LogInView());
                Debug.WriteLine(e.ToString());

            }

            //Falls Leer: LogInView, Nur in die Datenbank schreiben, wenn die Daten korrekt sind

        }*/
    }
}
