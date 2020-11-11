using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RestSharp;

namespace LogicLayer
{
    public class NotificationHub : Hub
    {
        private readonly string baseUrl = "http://localhost:8080/";
        private readonly Rozetka _rozetka;

        // public NotificationHub(Rozetka rozetka)
        // {
        //     _rozetka = rozetka;
        // }
        
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"New connection established :: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public void CreateOrder(string jsonOrder)
        {
            Console.WriteLine("SignalR called to create a order");
            var client = new RestClient(baseUrl);
            
            var request = new RestRequest("orders", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(jsonOrder);
            
            var response = client.Execute(request);
            
            // _rozetka.SendOrder();
        }
    }
}