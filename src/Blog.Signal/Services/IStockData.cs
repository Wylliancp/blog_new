using Blog.Signal.Models;
using Domain.Entities;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public interface IStockData
    {
        //Task<ProductModel> GetStockData(int productId);
        Task<PostModel> GetPostsCount();
    }
}
