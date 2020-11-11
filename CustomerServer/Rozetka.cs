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
        private NetworkStream nwStream;

        public Rozetka()
        {
            try
            {
                client = new TcpClient(SERVER_IP, PORT_NO);
                nwStream = client.GetStream();
            }
            catch (SystemException e)
            {
                Console.WriteLine("Server socket is closed");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Rozetka error :: {exception}");
            }
        }

        public void Run()
        {
            Task.Run(Start);
        }

        public void Start()
        {
            Console.WriteLine($"Client sockets (PORT :: {PORT_NO}) listening..");
            //---data to send to the server---
            // string textToSend = "Testing data";
            //
            //
            // byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
            //
            // //---send the text---
            // Console.WriteLine("Sending : " + textToSend);
            // nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            //
            // //---read back the text---
            // byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            // int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            // Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            // Console.ReadLine();
            // client.Close();
        }

        public void SendOrder(string jsonOrder)
        {
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(jsonOrder);
            Console.WriteLine("Sending a new order to Driver Socket Server :: " + jsonOrder);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        }
    }
}