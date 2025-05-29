        using System;
        using System.Text;
        using System.Net;
        using System.Net.Sockets;
        using System.Threading;
        using UnityEngine;

public class ServerScript : MonoBehaviour
    {
        TcpListener server = null;
        TcpClient client = null;
        NetworkStream stream = null;
        Thread thread;

        private void Start()
        {
            thread = new Thread(new ThreadStart(SetupServer));
            thread.Start();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToClient("Hello");
            }
        }

        public void SetupServer()
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse("192.168.77.166");
                server = new TcpListener(localAddr, 2004);
                server.Start();

                byte[] buffer = new byte[1024];
                string data = null;

                while (true)
                {
                    Debug.Log("Waiting for connection...");
                    client = server.AcceptTcpClient();
                    Debug.Log("Connected!");

                    data = null;
                    stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        data = Encoding.UTF8.GetString(buffer, 0, i);
                        Debug.Log("Received: " + data);

                        string response = "Server response: " + data.ToString();
                        SendMessageToClient(message: response);
                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Debug.Log("SocketException: " + e);
            }
            finally
            {
                server.Stop();
            }
        }

        private void OnApplicationQuit()
        {
            stream.Close();
            client.Close();
            server.Stop();
            thread.Abort();
        }

        public void SendMessageToClient(string message)
        {
            byte[] msg = Encoding.UTF8.GetBytes(message);
            stream.Write(msg, 0, msg.Length);
            Debug.Log("Sent: " + message);
        }
    }
// Code from https://medium.com/@rabeeqiblawi/implementing-a-basic-tcp-server-in-unity-a-step-by-step-guide-449d8504d1c5
