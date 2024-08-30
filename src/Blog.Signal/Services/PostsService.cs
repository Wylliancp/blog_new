using Blog.Signal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public class PostsService : IPostsService
    {

        public IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;

        public PostsService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(this.GetType().Name);
        }

        public async Task<PostModel> GetPostsCount()
        {
            try
            {
                PostModel obj = default;

                var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:5001/Posts/GetAll");


                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var posts =  JsonConvert.DeserializeObject<List<PostsDto>>(responseJson);
                    return new PostModel(title: "Soma de Post", sum: posts.Count());
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception e)
            {
                return new PostModel();
            }
        }
    }
}
