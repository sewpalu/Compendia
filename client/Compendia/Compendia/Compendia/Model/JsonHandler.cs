using System;
using Json.Net;
using Newtonsoft.Json.Linq;
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

        // Instance of JsonHandler - gets passed around
        public static JsonHandler Instance
        {
            get
            {
                return _jsonHandler;
            }
        }

        //generates a valid JSON String and passes it back
        //necessary for sending the Requests 
        public string GetRequestString(string command, string[] parameters, string[] types)
        {
            // Json Object to generate the JSON String
            JObject o = new JObject(); 
            
            // command Property holding info about the command that will be executed
            JProperty commandProperty = new JProperty("command", command);
            
            //Object holding the values of the params
            JObject pO = new JObject();

            for (int i = 0; i < parameters.Length; i++)
            {
                pO.Add(new JProperty(types[i],parameters[i]));
            }
            
            //parameter property holding the necessary params for executing the command
            JProperty parametersProperty = new JProperty("parameters", pO);
            
            o.Add(commandProperty);
            o.Add(parametersProperty);
            
            //returns the JSON Object as a String
            return o.ToString();
        }

        enum ParameterTypes
        {
            //Request Params
            userName, //string
            templateUuid, //string
            templateName, //string
            isPublicTemplate, //boolean
            since, //date
            entryDefinition, //Object
            templateDefinition, //Object
            
            //additional Response Params
            doesUserExist, //boolean
            entryUuid, //string
            creationTime, //date
            entries, //Array, containing Objects --> {entryUuid, creationTime, entryDefinition}
            templates ////Array, containing Objects --> {templateUuid, templateName, templateDefinition}
        }
    }
}