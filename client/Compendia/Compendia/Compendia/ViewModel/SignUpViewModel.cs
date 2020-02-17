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
    public class SignUpViewModel : BaseViewModel
    {
        private string userSignUp;
        private string passwordSignUp;

        public SignUpViewModel()
        {

        }

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
        

        //Label to Login wurde geklicket
        public ICommand LabelCommandSignUp
        {

            get
            {

                return new Command(async () =>
                {
                    await PopModalAsync();
                });
            }
            set
            {

            }
        }
    }
}
