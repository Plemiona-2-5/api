using ApplicationCore.Resources;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Hubs;

namespace WebApi.Workers
{
    public class VillageMaterialsTimerWorker : BackgroundService
    {
        private const int RefreshDelayInMilliseconds = 1000;
        private const int RefreshDelayOfOneMinute = 60000;
        private readonly IHubContext<VillageMaterialsHub, IVillageMaterialsClient> _hubContext;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public VillageMaterialsTimerWorker(IHubContext<VillageMaterialsHub, IVillageMaterialsClient> hubContext,
            IStringLocalizer<MessageResource> localizer)
        {
            _hubContext = hubContext;
            _localizer = localizer;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                List<Task> taskList = new List<Task>();
                taskList.Add(RefreshUpdateVillageMaterials(stoppingToken));
                taskList.Add(RefreshVillageMaterials(stoppingToken));
                await Task.WhenAll(taskList);
            }
        }

        public async Task RefreshUpdateVillageMaterials(CancellationToken stoppingToken)
        {
            await _hubContext.Clients.Group(GroupType.VillageMaterials.ToString())
                .UpdateVillageMaterials(_localizer["UpdateVillageMaterials"]);
            await Task.Delay(RefreshDelayOfOneMinute, stoppingToken);
        }

        public async Task RefreshVillageMaterials(CancellationToken stoppingToken)
        {
            await _hubContext.Clients.Group(GroupType.VillageMaterials.ToString())
                    .RefreshVillageMaterials(_localizer["RefreshVillageMaterials"]);
            await Task.Delay(RefreshDelayInMilliseconds, stoppingToken);
        }
    }
}
