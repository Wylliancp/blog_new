using Blog.Signal.Models;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public interface IStockData
    {
        Task<ProductModel> GetStockData(int productId);
    }
}
