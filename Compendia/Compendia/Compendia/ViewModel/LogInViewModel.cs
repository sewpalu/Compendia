using Compendia.ViewModel.Base;
using Compendia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class LogInViewModel : BaseViewModel
    {
        public LogInViewModel()
        {

        }


        //NextClickedCommand
        public ICommand NextClickedCommand
        {

            get
            {

                return new Command(async() =>
                {
                    await PushAsync(new MainView());

                });


            }
            set
            {

            }
        }
    }
}
