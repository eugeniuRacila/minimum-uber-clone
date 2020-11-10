using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Rozetka
    {
        const int PORT_NO = 5200;
        const string SERVER_IP = "127.0.0.1";
        
        private Thread socketThread;
        private TcpClient client;

        public Rozetka()
        {
            client = new TcpClient(SERVER_IP, PORT_NO);
        }

        public void Run()
        {
            Task.Run(Start);
        }

        public void Start()
        {
            Console.WriteLine($"Client sockets (PORT :: {PORT_NO} listening..");
            //---data to send to the server---
            string textToSend = "Testing data";
            
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            Console.WriteLine("Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            Console.ReadLine();
            client.Close();
        }
    }
}