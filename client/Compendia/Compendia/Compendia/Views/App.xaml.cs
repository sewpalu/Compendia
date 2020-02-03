using Compendia.Database;
using Compendia.Model;
using Compendia.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Syncfusion.SfCalendar.XForms;


namespace Compendia
{
    public partial class App : Application
    {
        public App()
        {
            
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA1NDU3QDMxMzcyZTM0MmUzMEY1eW9qVHEyK1JxOVgyTmRuejNhanFvLzVDM05pSStlQjI1MHN3UUJwRUk9");
            InitializeComponent();

            //var log = DatabaseService.Name;

            //var data = getConnectionAsync();


            MainPage = new MainPage();

        }

       /* private bool getConnectionAsync()
        {
            var userdata =  DatabaseService._LogInRepository.GetLastObject();
            if (userdata != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
