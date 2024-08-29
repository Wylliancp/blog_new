using Blog.Signal.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public class StockData : IStockData
    {
        public IHttpClientFactory _httpClientFactory;

        public StockData(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ProductModel> GetStockData(int productId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var url = $"https://dummyjson.com/products/{productId}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<ProductModel>(await response.Content.ReadAsStringAsync());
            }
            catch(Exception e)
            {
                throw;
            }
          

        }
    }
}
