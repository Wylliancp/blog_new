using Blog.Signal.Models;
using Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public class StockData : IStockData
    {

        public IHttpClientFactory _httpClientFactory;
        public IPostsRepository _repository;

        public StockData(IHttpClientFactory httpClientFactory, IPostsRepository repository)
        {
            _httpClientFactory = httpClientFactory;
            _repository = repository;
        }

        public async Task<PostModel> GetPostsCount()
        {
            try
            {

                var item  = _repository.GetAll();
                if (item is null) return new PostModel();
                var quantidade = item.Count();

                //Aqui esta propositalmente, como estou usando um banco InMemory... N pega a mesma instacia da API
                Random rnd = new Random();

                var number = rnd.Next(1, 50);
                return new PostModel(title: "Soma de Post", sum: number); //number);// models.Count()
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //public async Task<PostModel> GetPostsCount()//Outra possibilidade com resalvas
        //{
        //    try
        //    {
        //        var client = _httpClientFactory.CreateClient();
        //        var url = $"https://localhost:55126/Posts/GetAll";
        //        var response = await client.GetAsync(url);

        //        if (!response.IsSuccessStatusCode) return new PostModel();

        //        response.EnsureSuccessStatusCode();
        //        return JsonSerializer.Deserialize<PostModel>(await response.Content.ReadAsStringAsync());
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }


        //}
    }
}
