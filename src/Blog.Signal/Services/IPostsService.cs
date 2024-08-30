using Blog.Signal.Models;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public interface IPostsService
    {
        Task<PostModel> GetPostsCount();
    }
}
