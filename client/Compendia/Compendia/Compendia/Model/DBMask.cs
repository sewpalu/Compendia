using Compendia.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public class DBMask : TableModel
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
