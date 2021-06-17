using ApplicationCore.Resources;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Hubs;

namespace WebApi.Workers
{
    public class BuildingsQueueTimerWorker : BackgroundService
    {
        private const int RefreshDelayInMilliseconds = 1000;
        private readonly IHubContext<BuildingsQueueHub, IBuildingsQueueClient> _hubContext;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public BuildingsQueueTimerWorker(IHubContext<BuildingsQueueHub,
            IBuildingsQueueClient> hubContext,
            IStringLocalizer<MessageResource> localizer)
        {
            _hubContext = hubContext;
            _localizer = localizer;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.Group(GroupType.BuildingsQueue.ToString())
                    .RequestQueueRefresh(_localizer["RequestQueueRefresh"]);
                await Task.Delay(RefreshDelayInMilliseconds, stoppingToken);
            }
        }
    }
}
