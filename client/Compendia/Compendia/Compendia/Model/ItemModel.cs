using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Compendia.Model
{
    public class ItemModel
    {
        public string Name { get; set; }

        public byte[] data;
        public View Child { get; set; }

        public ItemModel()
        {


        }

        public override string ToString()
        {
            return Name;
        }
        public void Serialize(View child)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var tmp = new BinaryFormatter();
                tmp.Serialize(stream, child);
                data = stream.ToArray();
                stream.Close();
            }

        }


    }
}
