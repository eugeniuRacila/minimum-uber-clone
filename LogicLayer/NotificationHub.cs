using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LogicLayer
{
    public class NotificationHub : Hub
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string baseUrl = "https://jsonplaceholder.typicode.com/posts";
        
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"New connection established :: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public async void SendNotification(string message)
        {
            await Clients.All.SendAsync("notification", message);
        }

        public async void GetOrders()
        {
            await Clients.All.SendAsync("notification", "GetOrders - before http request");
            HttpResponseMessage httpResponseMessage = await _client.GetAsync(baseUrl);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Response 200");
        
                await Clients.All.SendAsync("notification", "GetOrders - after http request");
            }
            else
            {
                Console.WriteLine("Response not 200");
            }
        }
    }
}