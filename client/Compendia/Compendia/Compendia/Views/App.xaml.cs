using Compendia.Database;
using Compendia.Model;
using Compendia.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Compendia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA1NDU3QDMxMzcyZTM0MmUzMEY1eW9qVHEyK1JxOVgyTmRuejNhanFvLzVDM05pSStlQjI1MHN3UUJwRUk9");

            //MainPage = new NavigationPage(new LogInView());
            MainPage = new MainPage();

            StdInit();

        }

        private async void StdInit()
        {

            var getStdMask =  await DatabaseService._MaskRepository.GetObjectsAsync();

            if (getStdMask != null)
            {
                foreach (var mask in getStdMask)
                {
                    if (mask.name.Equals("Standardmaske"))
                    {
                        return;
                    }
                }
            }
            Entry titel = new Entry();
            titel.Placeholder= "Titel";
            Editor text = new Editor();
            List<View> list = new List<View>();
            list.Add(titel);
            list.Add(text);


            var stdmask = new DBMask(
                "Standardmaske",list);
            var tmp =  DatabaseService._MaskRepository.AddObject(stdmask);
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
