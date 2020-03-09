using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Compendia.Model
{
    public static class Server
    {
        private static string uri;
        private static HttpClient client;

        static Server()
        {
            uri = "http://h2869529.stratoserver.net:8000";
            client = new HttpClient();
            // GetHTTPResquestAsync();
            string request = "{\"command\": \"addUser\",\"parameters\": {\"userName\": \"Max Mustermann\"}}";
            // var result = await PostHTTPRequestAsync(request);
        }

        public static async Task<string> GetHTTPResquestAsync()
        {
            var result = await client.GetAsync(uri);
            Debug.WriteLine(result.StatusCode);
            return result.ToString();
        }

        public static async Task<string> PostHTTPRequestAsync(string request)
        {
            var data = new StringContent(request, Encoding.UTF8, "application/json");
            //Anfrage an den Server wird versendet
            var response = await client.PostAsync(uri, data);

            //antwort des Servers 
            string result = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(result);
            return result;
        }

        public static async Task<string> AddUserAsync(string Username)
        {
            string[] parameters = {Username};
            string[] types = {"userName"};
            string request = JsonHandler.Instance.GetRequestString("addUser", parameters, types);
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }

        public static async Task<string> AddEntry(string username, string templateId, string entry)
        {
            string[] parameters = {username,templateId, entry};
            string[] types = {"userName", "templateUuid", "entryDefinition" };
            string request = JsonHandler.Instance.GetRequestString("addEntry", parameters, types);
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }

        public static async Task<string> getEntries(string username, string templateId, string date)
        {
            // date = 2020-Feb-02 12:34:56
            string[] parameters = {username, templateId, date};
            string[] types = { "userName", "templateUuid", "since"};
            string request = JsonHandler.Instance.GetRequestString("getEntries", parameters, types);
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }
        public static async Task<string> GetTemplates(string username)
        {
            string[] parameters = { username };
            string[] types = { "userName" };

            var request = JsonHandler.Instance.GetRequestString("getTemplates", parameters, types);
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }
        public static async Task<string> AddTemplates(string username, string templatename)
        {
            string command = "addTemplate";
            string[] types = { "userName", "isPublicTemplate", "templateName", "templateDefinition" };
            string[] parameters = { username, "false", templatename,"{}" };
            var request = JsonHandler.Instance.GetRequestString(command, parameters, types);
            string tmp = await PostHTTPRequestAsync(request);

            return tmp;
        }
            
        
    }
}