using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public class DBMask
    {
        public string Name { get; set; }
        public List<View> ViewList { get; set; }

        public DBMask()
        {

        }
        public DBMask(string name, List<View> viewList)
        {
            Name = name;
            ViewList = viewList;
        }
        
    }
}
