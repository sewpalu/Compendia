using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Compendia.Model
{
    public static class Server
    {
        private static Socket ClientSocket;
        //private static bool connected = false;
        public static bool connected { get; set; }
        private static ManualResetEvent connectDone;
        private static ManualResetEvent sendDone;
        private static ManualResetEvent receiveDone;
        private static String response = String.Empty;

        static Server()
        {
            connected = false;

            connectDone = new ManualResetEvent(false);
            sendDone = new ManualResetEvent(false);
            receiveDone = new ManualResetEvent(false);

            ConnectToServer();
            
        }

        private static void ConnectToServer()
        {
            if (connected == false)
            {
                try
                {
                    string host = "compendidata.herokuapp.com";  // URI

                    IPHostEntry hostEntry = Dns.GetHostEntry(host);

                    int port = 8080;
                    IPAddress[] ipAddresses = hostEntry.AddressList; //Get IP-Adress from URI
                    IPEndPoint end = new IPEndPoint(IPAddress.Parse(ipAddresses[0].ToString()), port);

                    ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    // Connect to the remote endpoint.  
                    ClientSocket.BeginConnect(end,
                        new AsyncCallback(ConnectCallback), ClientSocket);
                    connectDone.WaitOne();

                    Send(ClientSocket,"{\"sender\": \"client\",\"command\": \"addUser\",\"userName\": \"Max Mustermann\"}");
                    sendDone.WaitOne();


                    Receive(ClientSocket);
                    receiveDone.WaitOne();


                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
               


            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Debug.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Debug.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
            {
                try
                {
                    // Create the state object.  
                    StateObject state = new StateObject();
                    state.workSocket = client;

                    // Begin receiving the data from the remote device.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private static void ReceiveCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the state object and the client socket   
                    // from the asynchronous state object.  
                    StateObject state = (StateObject)ar.AsyncState;
                    Socket client = state.workSocket;

                    // Read data from the remote device.  
                    int bytesRead = client.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.  
                        state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                        // Get the rest of the data.  
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                    else
                    {
                        // All the data has arrived; put it in response.  
                        if (state.sb.Length > 1)
                        {
                            response = state.sb.ToString();
                        }
                        // Signal that all bytes have been received.  
                        receiveDone.Set();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }


    }
}
