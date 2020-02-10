using Compendia.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Compendia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA1NDU3QDMxMzcyZTM0MmUzMEY1eW9qVHEyK1JxOVgyTmRuejNhanFvLzVDM05pSStlQjI1MHN3UUJwRUk9");
            //MainPage = new NavigationPage(new LogInView());
            MainPage = new MainPage();

        }

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
