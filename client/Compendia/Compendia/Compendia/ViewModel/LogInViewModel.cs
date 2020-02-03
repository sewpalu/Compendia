using Compendia.Database;
using Compendia.Model;
using Compendia.ViewModel.Base;
using Compendia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class LogInViewModel : BaseViewModel
    {
        
        private string user;
        private string password;
        public LogInViewModel()
        {
            user = "User";
            password = "Password";
            

        }

        public string EntryUser
        {
            get
            {
                return user;
            }
            set
            {
                user = value;

                OnPropertyChanged(nameof(EntryUser));
            }
        }

        public string EntryPassword
        {
            get
            {
                return password;
            }
            set
            {
                password = value;

                OnPropertyChanged(nameof(EntryPassword));
            }
        }



        //Login Button wurde geklicket
        public ICommand LogInCommand
        {

            get
            {

                return new Command(async () =>
                {
                    if(user != null && password != null)
                    {
                        //User und Passwort überprüfen von großer Datenbank

                        //Falls richtig: Userdaten in lokale Datenbank schreiben
                        var result = await DatabaseService._LogInRepository.AddObjectAsync(new DbLogIn(user, password));

                        // await PushAsync(new NavigationPage(MainView()));
                        //await PopAsync();
                        
                       // _ = ViewService.NavigateFromMenu((int)MenuItemType.Main);


                    }   
                   

                });


            }
            set
            {

            }
        }

       
        
        //Login Button wurde geklicket
        public ICommand SignUpCommand
        {
            get
            {

                return new Command(async () =>
                {
                    await PushAsync(new NavigationPage(new SignUpView()));
                });
            }
        }
    }
}
