using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverServer
{
    public class SocketServer
    {
        const int PORT_NO = 5200;
        const string SERVER_IP = "127.0.0.1";
        
        //---listen at the specified IP and port no.---
        private IPAddress localAdd;
        private TcpListener listener;
        private Thread socketThread;

        public SocketServer()
        {
            localAdd = IPAddress.Parse(SERVER_IP);
            listener = new TcpListener(localAdd, PORT_NO);
        }
        
        public void Run()
        {
            Task.Run(Start);
        }

        private void Start()
        {
            Console.WriteLine($"Server sockets (PORT :: {PORT_NO} listening..");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            //---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            //---convert the data received into a string---
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received : " + dataReceived);

            //---write back the text to the client---
            Console.WriteLine("Sending back : " + dataReceived);
            nwStream.Write(buffer, 0, bytesRead);
            client.Close();
            listener.Stop();
            Console.ReadLine();
        }

        // public async Task DisplayAllOrders()
        // {
        //     HttpResponseMessage httpResponseMessage = await webServiceClient.GetAsync(baseURL + "orders");
        //     if (httpResponseMessage.IsSuccessStatusCode)
        //     {
        //         Console.WriteLine("Yes");
        //     }
        //     else
        //     {
        //         Console.WriteLine("No");
        //     }
        // }
    }
}