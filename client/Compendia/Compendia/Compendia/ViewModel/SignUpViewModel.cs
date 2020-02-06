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
    public class SignUpViewModel : BaseViewModel
    {
        
        private string user;
        private string password;
        public SignUpViewModel()
        {

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



        //Sign Up Button wurde geklicket
        public ICommand LogInCommand
        {

            get
            {

                return new Command(async () =>
                {
                    await PushModalAsync(new SignUpView());

                });
            }
            set
            {

            }
        }
        
        //Label to Login wurde geklicket
        public ICommand LabelCommand
        {

            get
            {

                return new Command(async () => { await PopModalAsync(); });
            }
            set
            {

            }
        }

        
    }
}
