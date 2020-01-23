using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.Model
{
    public enum MenuItemType
    {
        
        Main,
        Statistics,
        EntrymaskCreation,
        EntryCreation,
        ShowEntry,
        Settings,
        LogOut
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
