using Compendia.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public class DBMask : TableModel
    {
        public string name { get; set; }
        public List<View> viewList { get; set; }

        public DBMask()
        {

        }
        public DBMask(string name_, List<View> viewList_)
        {
            name = name_;
            viewList = viewList_;
        }
        
    }
}
