using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public static  class ItemController
    {


        //public static  byte[] data;


        static ItemController()
        {


        }


        public static byte[] Serialize(View child)
        {
            byte[] data;
            using (MemoryStream stream = new MemoryStream())
            {
                var tmp = new BinaryFormatter();
                tmp.Serialize(stream, child);
                data = stream.ToArray();
                stream.Close();
            }
            return data;

        }


    }
}
