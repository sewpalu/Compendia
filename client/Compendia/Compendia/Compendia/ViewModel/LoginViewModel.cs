using Compendia.Database;
using Compendia.Model;
using Compendia.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string userLogIn;
        private string passwordLogIn;
        public LoginViewModel()
        {

        }

        public string EntryUserLogIn
        {
            get
            {
                return userLogIn;
            }
            set
            {
                userLogIn = value;

                OnPropertyChanged(nameof(EntryUserLogIn));
            }
        }

        public string EntryPasswordLogIn
        {
            get
            {
                return passwordLogIn;
            }
            set
            {
                passwordLogIn = value;

                OnPropertyChanged(nameof(EntryPasswordLogIn));
            }
        }
        public ICommand LogInCommand
        {

            get
            {

                return new Command(async () =>
                {
                    if (userLogIn != null && passwordLogIn != null)
                    {
                        //User und Passwort überprüfen von großer Datenbank

                        //Falls richtig: Userdaten in lokale Datenbank schreiben
                        var result = await DatabaseService._LogInRepository.AddObjectAsync(new DbLogIn(userLogIn, passwordLogIn));

                        // await PushModalAsync(new MainView());
                        await PopModalAsync();

                    }

                });

            }
            set
            {

            }
        }


        public ICommand SignUpCommandLogIn
        {
            get
            {

                return new Command(async () =>
                {
                    //await PushModalAsync(new SignUpView());
                });
            }
        }

    }
}
