using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.Model
{
    public class ItemModel
    {
        public string Name { get; set; }
       
        public Object Child { get; set; }

        public ItemModel(Object child, string name)
        {
            Child = child;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
