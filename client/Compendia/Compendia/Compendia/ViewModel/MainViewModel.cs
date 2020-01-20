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

        private void connectUser()
        {
            //connect with Database 

            //Benutzername und Passwort aus Datenbank holen

            

            //Falls Leer: LogInView, Nur in die Datenbank schreiben, wenn die Daten korrekt sind

        }
        
    }

}
