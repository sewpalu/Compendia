using Compendia.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public class DbItem : TableModel
    {
        public View view { get; set; }
        public DBMask DbMask { get; set; }

        public DbItem(DbItem item)
        {
            view = item.view;
            Id = item.Id;

        }
        public DbItem(View _view, DBMask mask)
        {
            view = _view;
            DbMask = mask;
        }
    }
}
