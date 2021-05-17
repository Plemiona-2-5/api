using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Workers
{
    public class QueueTimerWorker : BackgroundService
    {
        private const int RefreshDelayInMilliseconds = 1000;
        private readonly IHubContext<BuildingsQueueHub, IBuildingsQueueClient> hubContext;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public QueueTimerWorker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {  
                await Task.Delay(RefreshDelayInMilliseconds);
            }
        }
    }
}
