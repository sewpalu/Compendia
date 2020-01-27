using Compendia.Database;
using Compendia.ViewModel.Base;
using Compendia.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private DateTime? _date = DateTime.Today;
        private ObservableCollection<XamForms.Controls.SpecialDate> attendances;
        public MainViewModel()
        {
            //connectUser();

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
        public ObservableCollection<XamForms.Controls.SpecialDate> Attendances
        {
            get
            {
                return attendances;
            }
            set
            {
                attendances = value;
                OnPropertyChanged(nameof(Attendances));
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
            get
            {
                return _date.ToString();   
            }
            set
            {
                _date = DateTime.Parse(value);
                OnPropertyChanged();

            }
        }

    }
}
