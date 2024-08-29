using Blog.Signal.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public class StockServiceBackgroundCaller : BackgroundService
    {
        public IStockData _stockData { get; }
        public IHubContext<StockDataHub> _stockDataHub { get; }


        private int productId = 1;

        public StockServiceBackgroundCaller(IStockData stockData, IHubContext<StockDataHub> stockDataHub)
        {
            _stockData = stockData;
            _stockDataHub = stockDataHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                //var product = await _stockData.GetStockData(productId);
                var posts = await _stockData.GetPostsCount();
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
