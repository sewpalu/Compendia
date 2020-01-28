
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
        LogOut,
        SignUp
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
