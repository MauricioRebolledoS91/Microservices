using Lil.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class SalesService : ISalesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var client = _httpClientFactory.CreateClient("salesService");

            var response = await client.GetAsync($"api/sales/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var order = JsonConvert.DeserializeObject<ICollection<Order>>(content);

                return order;
            }

            return null;
        }
    }
}
