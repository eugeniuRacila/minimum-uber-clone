using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Server
    {
        private readonly string baseUrl = "https://jsonplaceholder.typicode.com/posts";
        private static HttpClient client = new HttpClient();

        public async Task DisplayAllOrders()
        {
            // HttpResponseMessage httpResponseMessage = await client.GetAsync(baseURL + "orders");
            HttpResponseMessage httpResponseMessage = await client.GetAsync(baseUrl);
            
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
