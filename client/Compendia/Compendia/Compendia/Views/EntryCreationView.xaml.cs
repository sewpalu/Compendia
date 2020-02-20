using Compendia.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Compendia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class EntryCreationView : ContentPage
    {
        public EntryCreationView()
        {
            InitializeComponent();

            ItemsStack.BindingContextChanged += (s, e) => {

                var item = (View) ItemsStack.BindingContext;
                Debug.WriteLine(item.ToString());
                //var child = new View();
                

                ItemsStack.Children.Add(item);
            };
            

            
        }

        
        
    }
}