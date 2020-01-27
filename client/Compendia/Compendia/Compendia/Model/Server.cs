using System;
using System.Collections.Generic;
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
        }

        private async static void ConnectToServer()
        {
            if (connected == false)
            {
                string host = "compendidata.herokuapp.com";  // Uri
                
                IPHostEntry hostEntry = Dns.GetHostEntry(host);

                int port = 8080;
                IPAddress[] ipAddresses = hostEntry.AddressList;
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint end = new IPEndPoint(IPAddress.Parse(ipAddresses[0].ToString()), port);
                try
                {
                    await ClientSocket.ConnectAsync(end);


                    if (ClientSocket.Connected)
                    {
                       
                        //AddLabelList(servertext, 2);//

                        connected = true;

                    }
                }
                catch (Exception e)
                {


                }


            }
        }

    }
}
