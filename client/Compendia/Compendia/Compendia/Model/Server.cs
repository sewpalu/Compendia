using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
            int[] types = {1};
            string request = JsonHandler.Instance.GetRequestString("addUser", parameters, types);
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }

        public static async Task<string> AddEntry(int templateId, string entry)
        {
            string request = "{\"command\": \"addEntry\",\"parameters\": {\"templateId\":" +
                             templateId + ",\"entry\":" + entry + "}}";
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }

        public static async Task<string> getEntries(int templateId, string date)
        {
            // date = 2020-Feb-02 12:34:56
            string request = "{\"command\": \"getEntries\",\"parameters\": {\"templateId\": " + templateId +
                             ",\"since\": " + date + "}}";
            string tmp = await PostHTTPRequestAsync(request);
            return tmp;
        }
    }
}