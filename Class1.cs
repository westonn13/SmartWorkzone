using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

void networkCode()
{
    // Data buffer for incoming data.
    byte[] bytes = new Byte[1024];

    // Establish the local endpoint for the socket.
    // Dns.GetHostName returns the name of the 
    // host running the application.
    IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
    IPAddress ipAddress = ipHostInfo.AddressList[0];
    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1755);

    // Create a TCP/IP socket.
    listener = new Socket(ipAddress.AddressFamily,
        SocketType.Stream, ProtocolType.Tcp);

    // Bind the socket to the local endpoint and 
    // listen for incoming connections.
    try
    {
        listener.Bind(localEndPoint);
        listener.Listen(10);

        // Start listening for connections.
        while (true)
        {
            // Program is suspended while waiting for an incoming connection.
            Debug.Log("HELLO");     //It works
            handler = listener.Accept();
            Debug.Log("HELLO");     //It doesn't work
            data = null;

            // An incoming connection needs to be processed.
            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }

                System.Threading.Thread.Sleep(1);
            }

            System.Threading.Thread.Sleep(1);
        }
    }
    catch (Exception e)
    {
        Debug.Log(e.ToString());
    }
}