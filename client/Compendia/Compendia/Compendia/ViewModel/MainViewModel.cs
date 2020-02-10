using System;
using System.Collections.Generic;
using System.Diagnostics;
using Compendia.Database;
using Compendia.Model;
using Compendia.ViewModel.Base;
using Compendia.Views;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private DateTime? _date = DateTime.Today;
        public MainViewModel()
        {
            _ = connectUserAsync();
            //ServerConnection();
        }

        private async System.Threading.Tasks.Task connectUserAsync()
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
                await PushModalAsync(new LogInView());

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

    }
