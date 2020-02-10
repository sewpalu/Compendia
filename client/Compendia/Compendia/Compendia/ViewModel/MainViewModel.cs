using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Compendia.Database;
using Compendia.Model;
using Compendia.ViewModel.Base;
using Compendia.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private DateTime? _date = DateTime.Today;
        private string userLogIn;
        private string passwordLogIn;
        private string userSignUp;
        private string passwordSignUp;

        public MainViewModel()
        {
            _ = ConnectUserAsync();
            //ServerConnection();
        }

        #region MainView
        private async System.Threading.Tasks.Task ConnectUserAsync()
        {
            List<DbLogIn> userdata;
            try
            {
                userdata = DatabaseService._LogInRepository.GetObjects();

            }
            catch (Exception e)
            {
                userdata = null;
                Debug.WriteLine(e, ToString());
            }

            if (userdata == null || userdata.Count == 0)
            {
                //await PushModalAsync(new LogInView());
                //Popup aufrufen
                await PopupNavigation.Instance.PushAsync(new LogInView());

            }
            else
            {
                //mit Datenbank verbinden
            }

        }

        private async void ServerConnection()
        {
            var status = await Server.GetHTTPResquestAsync();
            var tmp = await Server.PostHTTPRequestAsync("{\"sender\": \"client\",\"command\": \"addUser\",\"userName\": \"Max Mustermann\"}");
        }

        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                ChosenDate = value.ToString();
                OnPropertyChanged(nameof(Date));
            }
        }


        public Command DateChosen
        {
            get
            {
                return new Command((obj) =>
                {
                    System.Diagnostics.Debug.WriteLine(obj as DateTime?);
                });
            }
        }

        public string ChosenDate
        {
            get { return _date.ToString(); }
            set
            {
                _date = DateTime.Parse(value);
                OnPropertyChanged();

            }
        }
        #endregion

        #region LogInPopUp

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
                        await PopupNavigation.Instance.PopAsync();

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
                    await PopupNavigation.Instance.PushAsync(new SignUpView());
                });
            }
        }
        #endregion

        #region SignUpPopUp

        public string EntryUserSignUp
        {
            get
            {
                return userSignUp;
            }
            set
            {
                userSignUp = value;

                OnPropertyChanged(nameof(EntryUserSignUp));
            }
        }

        public string EntryPasswordSignUp
        {
            get
            {
                return passwordSignUp;
            }
            set
            {
                passwordSignUp = value;

                OnPropertyChanged(nameof(EntryPasswordSignUp));
            }
        }



        //Sign Up Button wurde geklicket
        public ICommand SignUpCommand
        {

            get
            {

                return new Command(async () =>
                {
                    await PopupNavigation.Instance.PushAsync(new SignUpView());

                });
            }
            set
            {

            }
        }

        //Label to Login wurde geklicket
        public ICommand LabelCommandSignUp
        {

            get
            {

                return new Command(async () => {
                    await PopupNavigation.Instance.PopAsync();
                });
            }
            set
            {

            }
        }

        #endregion
    }
}
