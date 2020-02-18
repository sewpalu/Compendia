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
        private string username;
        private string password;
        private string passwordConfirm;
        private string name;
        private string surname;


        public SignUpViewModel()
        {

        }
        #region Properties

        public string EntryUsername
        {
            get
            {
                return username;
            }
            set
            {
                username = value;

                OnPropertyChanged(nameof(EntryUsername));
            }
        }
        public string EntryName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

                OnPropertyChanged(nameof(EntryName));
            }
        }
        public string EntrySurname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;

                OnPropertyChanged(nameof(EntrySurname));
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
        public string EntryConfirmPassword
        {
            get
            {
                return passwordConfirm;
            }
            set
            {
                passwordConfirm = value;

                OnPropertyChanged(nameof(EntryConfirmPassword));
            }
        }

        //Label to Login wurde geklicket
        public ICommand LabelCommand
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
        public ICommand SignUpCommand
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
        #endregion Properties
    }
}
