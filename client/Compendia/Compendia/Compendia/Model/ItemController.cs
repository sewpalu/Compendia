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
    public static  class ItemController
    {


        //public static  byte[] data;


        static ItemController()
        {


        }


        public static string Serialize(View child)
        {
            string data;

                try
                {
                    data = JsonConvert.SerializeObject(child);

                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    throw e;
                }

            return data;

        }

        public static View Deserialize(string viewitem)
        {
            View data = JsonConvert.DeserializeObject<View>(viewitem);
            return data;
        }

    }
}
