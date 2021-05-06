using Lil.Search.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class ProductsServices : IProductsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductsServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Product> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("productsService");

            var response = await client.GetAsync($"api/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var customer = JsonConvert.DeserializeObject<Product>(content);

                return customer;
            }

            return null;
        }
    }
}
