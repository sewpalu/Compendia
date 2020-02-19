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

            ItemsStack.BindingContextChanged += (s, e) => { ItemsStack.Children.Add(new Entry()); };
            

            
        }

        
    }
}