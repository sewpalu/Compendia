using Compendia.Database;
using Compendia.Model.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public class DBMask : TableModel
    {
        public string name { get; set; }

        public ICollection<DbItem> DbItem { get; set; } = new List<DbItem>();

        public DBMask()
        {

        }
        public DBMask(string name_)
        {
            name = name_;
        }
        public DBMask(string name_, DbItem item)
        {
            name = name_;

            DbItem.Add(new DbItem(item));
        }

        public bool AddItem(View view)
        {
            try
            {
                //DbItem item = new DbItem(view, this);
                //DatabaseService._ItemRepository.AddObject(item);
                //DbItem.Add(item);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                throw e;
                
            }


        }
        
    }
}
