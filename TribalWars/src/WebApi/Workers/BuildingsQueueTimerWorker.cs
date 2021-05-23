using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Hubs;

namespace WebApi.Workers
{
    public class BuildingsQueueTimerWorker : BackgroundService
    {
        private const int RefreshDelayInMilliseconds = 1000;
        private readonly IHubContext<BuildingsQueueHub, IBuildingsQueueClient> _hubContext;

        public BuildingsQueueTimerWorker(IHubContext<BuildingsQueueHub, IBuildingsQueueClient> hubContext)
        {
            _hubContext = hubContext;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.Group(GroupType.BuildingsQueue.ToString()).RequestQueueRefresh("Refresh queue");
                await Task.Delay(RefreshDelayInMilliseconds, stoppingToken);
            }
        }
    }
}
