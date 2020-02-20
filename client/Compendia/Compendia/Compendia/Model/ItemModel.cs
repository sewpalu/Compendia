using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public class ItemModel
    {
        public string Name { get; set; }
       
        public View Child { get; set; }

        public ItemModel(View child)
        {
            Child = child;
            
        }
        public ItemModel()
        {

        }

        public override string ToString()
        {
            return Name;
        }

    }
}
