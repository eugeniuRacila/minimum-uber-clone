using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RestSharp;

namespace DriverServer
{
    public class NotificationHub : Hub
    {
        private readonly string baseUrl = "http://localhost:8080/";
        
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"New connection established :: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
        
        public async void GetOrders()
        {
            var client = new RestClient(baseUrl);

            var request = new RestRequest("orders", Method.GET);

            var response = client.Get(request);
            
            await Clients.All.SendAsync("receiveOrders", response.Content);
        }
        
        public async void PushOrder(string jsonOrder)
        {
            try
            {
                await Clients.All.SendAsync("pushOrder", jsonOrder);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("DriverServer\\NotificationHub looks like there are no connected clients.");
            }
        }

        public async void TakeOrder(int orderId)
        {
            Console.WriteLine("Attempt to take an order");
        }
    }
}