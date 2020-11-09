using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LogicLayer.Hubs
{
    public class EventHub
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string baseUrl = "https://jsonplaceholder.typicode.com/posts";
        
        private readonly IHubContext<NotificationHub> _hubContext;

        public EventHub(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        public async void SendNotification(string message)
        {
            Console.WriteLine("SendNotification was called by the client");
            await _hubContext.Clients.All.SendAsync("notification", message);
        }
        
        public async void GetOrders()
        {
            HttpResponseMessage httpResponseMessage = await _client.GetAsync(baseUrl);
            
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("Response 200");
                Console.WriteLine(responseContent);

                await _hubContext.Clients.All.SendAsync("receiveOrders", responseContent);

            }
            else
            {
                Console.WriteLine("Response not 200");
            }
        }
        // here place some method(s) for message from client to server
    }
}