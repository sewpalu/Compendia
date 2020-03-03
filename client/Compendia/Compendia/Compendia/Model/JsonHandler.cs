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

        public string GetRequestString(string command, string[] parameters, int[] types)
        {
            string request = "{\"command\": \"addUser\",\"parameters\": {\"userName\":" + parameters[0] + "}}";
            return request;
        }
    }
}