using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RestSharp;

namespace LogicLayer
{
    public class NotificationHub : Hub
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string baseUrl = "http://localhost:8080/";
        
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"New connection established :: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public async void SendNotify(string message)
        {
            await Clients.All.SendAsync("notify", message);
        }
        
        public async void SendNotification()
        {
            var client = new RestClient(baseUrl);

            var request = new RestRequest("orders", Method.GET);

            var response = client.Get(request);
            await Clients.All.SendAsync("notification", response.Content);
        }
        
        // public async void SendNotification(string message)
        // {
        //
        //
        //     var response = client.Get(request);
        //     await this.Clients.All.SendAsync("notification", response.Content);
        // }
        //
        // public async void GetOrders()
        // {
        //     var client = new RestClient("https://jsonplaceholder.typicode.com/");
        //
        //     var request = new RestRequest("posts", Method.GET);
        //     HttpResponseMessage httpResponseMessage = await _client.GetAsync(baseUrl);
        //     if (httpResponseMessage.IsSuccessStatusCode)
        //     {
        //         Console.WriteLine("Response 200");
        //
        //         await Clients.All.SendAsync("notification", "GetOrders - after http request");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Response not 200");
        //     }
        // }
    }
}