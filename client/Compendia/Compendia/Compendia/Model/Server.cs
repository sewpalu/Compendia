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

        public static async Task<string> AddEntry(int templateId, string entry)
        {
            string[] parameters = {templateId.ToString(), entry};
            string[] types = {"templateId", "entry"};
            string request = JsonHandler.Instance.GetRequestString("addEntry", parameters, types);
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }

        public static async Task<string> getEntries(int templateId, string date)
        {
            // date = 2020-Feb-02 12:34:56
            string[] parameters = {templateId.ToString(), date};
            string[] types = {"templateId", "since"};
            string request = JsonHandler.Instance.GetRequestString("getEntries", parameters, types);
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }
    }
}