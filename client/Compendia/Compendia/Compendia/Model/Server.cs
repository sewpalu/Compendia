using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
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

            uri = "http://compendidata.herokuapp.com/";
            client = new HttpClient();
            // GetHTTPResquestAsync();
            // var result = await PostHTTPRequestAsync("{\"sender\": \"client\",\"command\": \"addUser\",\"userName\": \"Max Mustermann\"}");

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


    }
}
