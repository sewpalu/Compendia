using Compendia.Database;
using Compendia.ViewModel.Base;
using Compendia.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public  MainViewModel()
        {
            connectUser();

        }

        private async void connectUser()
        {
            //connect with Database 

            //Benutzername und Passwort aus Datenbank holen
            try
            {
                var userdata = await DatabaseService._LogInRepository.GetLastObjectAsync();
            }
            catch (Exception e)
            {
               // await PushAsync(new LogInView());
                
            }
            

            //Falls Leer: LogInView, Nur in die Datenbank schreiben, wenn die Daten korrekt sind
           

            

        }
        
    }

}
