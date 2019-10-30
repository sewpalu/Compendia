#!/usr/bin/env rdmd

import std.stdio;
import std.socket;
import std.algorithm: remove, find;

/++
Provides the server functionality needed for the Compendia client
to query the database.
+/
class Server
{
private:
    TcpSocket m_listener;
    Socket[] m_connections;

public:

    /++
    Default ctor
    +/
    this()
    {
        m_listener = new TcpSocket;
        m_listener.blocking = false;
        m_listener.bind(new InternetAddress("127.0.0.1", 8000));
    }

    /++
    Starts the server
    +/
    void opCall()
    {
        m_listener.listen(100);
        writeln("listening on ", m_listener.localAddress.toString());

        auto sockets = new SocketSet;
        while(true)
        {
            // Fill SocketSet
            sockets.add(m_listener);
            foreach (connection; m_connections)
                sockets.add(connection);
            
            // Filter SocketSet (only keeps those, where a read occurred)
            Socket.select(sockets, null, null);

            // Handle incoming messages
            foreach (i, connection; m_connections)
                if (sockets.isSet(connection))
                    onRecv(connection);

            // Handle new connections
            if (sockets.isSet(m_listener))
                onConnect(m_listener);
            
            sockets.reset();
        }
    }

private:
    void onRecv(Socket socket)
    {

                    enum buffersize = 1024;
                    char[buffersize] buffer;
                    typeof(socket.receive(buffer)) received = buffersize;
                    static assert(buffersize != Socket.ERROR && buffersize != 0);
                    
                    writefln("SOT(%s)", socket.remoteAddress.toString());
                    while (received == buffersize)
                    {
                        received = socket.receive(buffer);
                        if (received != 0 && received != Socket.ERROR)
                            write(buffer[0 .. received]);
                    }
                    writeln("\nEOT");

                    socket.send("   HTTP/1.1 200 OK
                                    Content-Type: text/plain
                                    Connection: close

                                    <html>
                                    <body>
                                    <h1>Hello World!</h1>
                                    </body>
                                    </html>");

                    socket.close();
                    m_connections = m_connections.remove!(item => item is socket);
                    writefln("connection closed (# open connections: %d)", m_connections.length);
    }

    void onConnect(Socket socket)
    {
                auto connection = socket.accept();
                m_connections ~= connection;
                writeln("established connection with ", connection.remoteAddress.toString());
    }
}

void main()
{
    Server server = new Server;
    server();
}

