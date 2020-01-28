using Compendia.Database;
using Compendia.Model;
using Compendia.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Compendia
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;



            List<DbLogIn> userdata;
            try
            {
                userdata = DatabaseService._LogInRepository.GetObjects();

            }catch(Exception e)
            {
                userdata = null;
                Debug.WriteLine(e, ToString());
            }
            
            if (userdata == null || userdata.Count == 0)
            {
                _ = NavigateFromMenu((int)MenuItemType.LogOut);
               
            }
            else
            {
                //mit Datenbank verbinden
            }

            MenuPages.Add((int)MenuItemType.Main, (NavigationPage)Detail);


        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Main:
                        MenuPages.Add(id, new NavigationPage(new MainView()));
                        break;
                    case (int)MenuItemType.Statistics:
                        MenuPages.Add(id, new NavigationPage(new StatisticView()));
                        break;
                    case (int)MenuItemType.EntryCreation:
                        MenuPages.Add(id, new NavigationPage(new EntryCreationView()));
                        break;
                    case (int)MenuItemType.EntrymaskCreation:
                        MenuPages.Add(id, new NavigationPage(new EntrymaskCreationView()));
                        break;
                    case (int)MenuItemType.Settings:
                        MenuPages.Add(id, new NavigationPage(new SettingsView()));
                        break;
                    case (int)MenuItemType.ShowEntry:
                        MenuPages.Add(id, new NavigationPage(new ShowEntryView()));
                        break;
                    case (int)MenuItemType.LogOut:
                        //Sachen aus Datenbank noch rauslöschen
                        logOut();
                        MenuPages.Add(id, new NavigationPage(new LogInView()));
                        break;
                    case (int)MenuItemType.SignUp:
                        MenuPages.Add(id, new NavigationPage(new SignUpView()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }

        }
                
        private async void logOut()
        {
            try
            {
                await DatabaseService._LogInRepository.DeleteObjectAsync(DatabaseService._LogInRepository.GetLastObjectAsync().Id);

            }catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}
