using Compendia.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Compendia.Model
{
    public static  class ItemController<T>
    {

        static ItemController()
        {


        }


        public static string ViewtoDatabase(T child, DBMask mask)
        {
            string data;
            string type;

                try
                {
                    data = JsonConvert.SerializeObject(child);
                    type = JsonConvert.SerializeObject(child.GetType());
                    var i = DatabaseService._ItemRepository.AddObject(new DbItem(type, data, mask));
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    throw e;
                }

            return data;

        }

        public static T Deserialize(string viewitem)
        {
            T data = JsonConvert.DeserializeObject<T>(viewitem);
            return data;
        }

    }
}
