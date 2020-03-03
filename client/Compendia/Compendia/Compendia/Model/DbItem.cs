using Compendia.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public class DbItem : TableModel
    {
        //public View view { get; set; }
        
        public DBMask DbMask { get; set; }

        public string Viewitem { get; set; }

        public int Maskid
        {
            get
            {
                return DbMask.Id;
            }

            set
            {
                DbMask.Id = value;
            }
        }
        public DbItem()
        {

        }

        public DbItem(DbItem item)
        {
            //view = item.view;
            Id = item.Id;

        }
        public DbItem(View view, DBMask mask)
        {
           Viewitem = ItemController.Serialize(view);
            DbMask = mask;
        }
       /* public DbItem(View _view, DBMask mask)
        {
           // view = _view;
            DbMask = mask;
        }*/
    }
}
