using Blog.Signal.Models;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public class StockData : IStockData
    {
        private readonly IPostsRepository _repository;

        public StockData(IPostsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PostModel> GetPostsCount()
        {
            try
            {

                //var posts = _repository.GetAll();
                //Aqui esta propositalmente, tive um problema com a geracao da migrate! e como estou usando um banco InMemory... N pega a mesma instacia da API
                Random rnd = new Random();
    
                var number = rnd.Next(1, 50);
                return new PostModel(title: "Soma de Post", sum: number);//posts.Count());
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
