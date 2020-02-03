using Compendia.Database;
using Compendia.Model.Base;
using Compendia.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Compendia.Model
{
    public static class ViewService
    {
        private static NavigationPage Detail;
        private static MainPage MainPage;
        static Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        static ViewService()
        {
            MenuPages.Add((int)MenuItemType.Main, (NavigationPage)Detail);
        }

        public static void setDetail(NavigationPage detail)
        {
            Detail = detail;
        }

        public static async Task NavigateFromMenu(int id)
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
                        await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new LogInView()));
                        //MenuPages.Add(id, new NavigationPage(new LogInView()));
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

                MainPage.setPresented(false);
            }

        }

        internal static void GetMainPage(MainPage mainPage)
        {
            MainPage = mainPage;
        }

        private static async void logOut()
        {
            try
            {
                await DatabaseService._LogInRepository.DeleteObjectAsync(DatabaseService._LogInRepository.GetLastObjectAsync().Id);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

    }
}
