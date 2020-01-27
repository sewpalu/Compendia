using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Compendia.Model
{
    public static class Server
    {
        private static Socket ClientSocket;
        //private static bool connected = false;
        public static bool connected { get; set; } 
        static Server()
        {
            connected = false;
            ConnectToServer();
            Communication();
        }

        private async static void ConnectToServer()
        {
            if (connected == false)
            {
                string host = "compendidata.herokuapp.com";  // URI
                
                IPHostEntry hostEntry = Dns.GetHostEntry(host);

                int port = 8080;
                IPAddress[] ipAddresses = hostEntry.AddressList; //Get IP-Adress from URI
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint end = new IPEndPoint(IPAddress.Parse(ipAddresses[0].ToString()), port);
                try
                {
                    await ClientSocket.ConnectAsync(end);


                    if (ClientSocket.Connected)
                    {
                      
                        connected = true;

                    }
                }
                catch (Exception e)
                {


                }


            }
        }

        private static void Communication()
        {
            try
            {
                var text = "{\"sender\": \"client\",\"command\": \"addUser\",\"userName\": \"Max Mustermann\"}";
                var message = new byte[text.Length];
                message = Encoding.UTF8.GetBytes(text);

                //Länge des Datenpacketes
                //message wird gesendet
                ClientSocket.Send(message);


                var received = new byte[100];   
                var size =  ClientSocket.Receive(received);

            }catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

        }





    }
}
