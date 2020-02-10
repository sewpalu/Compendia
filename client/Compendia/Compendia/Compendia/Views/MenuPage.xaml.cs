using Compendia.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Compendia.Views
{
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();


            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Main, Title="Main" },
                new HomeMenuItem {Id = MenuItemType.Statistics, Title="Statistics" },
                new HomeMenuItem {Id = MenuItemType.EntrymaskCreation, Title ="Eintragsmaske erstellen"},
                new HomeMenuItem {Id = MenuItemType.EntryCreation, Title="Eintrag erstellen" },
                new HomeMenuItem {Id = MenuItemType.ShowEntry, Title="Eintrag ansehen" },
                new HomeMenuItem {Id = MenuItemType.Settings, Title ="Optionen"},
                new HomeMenuItem {Id = MenuItemType.Settings, Title = "Log Out"}

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}