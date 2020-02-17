using Compendia.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class EditEntryViewModel : BaseViewModel
    {
        public EditEntryViewModel()
        {

        }

        public ICommand CloseCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await PopModalAsync();
                });
            }
            set { }
        }

        
    }
}
