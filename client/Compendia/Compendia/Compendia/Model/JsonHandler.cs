using System;
using Json.Net;
using Xamarin.Forms;

namespace Compendia.Model
{
    
    //Threadsafe Singleton w/o Locks & Lazy
    public sealed class JsonHandler
    {

        private static readonly JsonHandler _jsonHandler = new JsonHandler();

        //explicit static constructor
        static JsonHandler()
        {
        }
        private JsonHandler()
        {
        }

        public static JsonHandler Instance
        {
            get
            {
                return _jsonHandler;
            }
        }

        /*private JObject handleRequestJson()
        {
            
        } */
    }
}