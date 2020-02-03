using System;
using Compendia.Model;
using Compendia.ViewModel.Base;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private DateTime? _date = DateTime.Today;
        public MainViewModel()
        {
            //connectUser();
            ServerConnection();
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
    }
}
