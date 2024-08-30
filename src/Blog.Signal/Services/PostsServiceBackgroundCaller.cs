using Blog.Signal.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public class PostsServiceBackgroundCaller : BackgroundService
    {
        public IPostsService _postsService { get; }
        public IHubContext<PostsDataHub> _stockDataHub { get; }

        public PostsServiceBackgroundCaller(IPostsService stockData, IHubContext<PostsDataHub> stockDataHub)
        {
            _postsService = stockData;
            _stockDataHub = stockDataHub;
        }
        private int productId = 1;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                var posts = await _postsService.GetPostsCount();
                await _stockDataHub.Clients.All.SendAsync("populatedata", JsonSerializer.Serialize(posts));
                Interlocked.Increment(ref productId);

                if(productId == 20)
                {
                    productId = 1;
                }

                if (productId > 1)
                {
                    await Task.Delay(2000);

                }

            }
        }
    }
}
