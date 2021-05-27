using ApplicationCore.Resources;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Hubs;

namespace WebApi.Workers
{
    public class VillageMaterialsTimerWorker : BackgroundService
    {
        private const int RefreshDelayInMilliseconds = 1000;
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
                await _hubContext.Clients.Group(GroupType.VillageMaterials.ToString())
                    .RefreshVillageMaterialst(_localizer["RefreshVillageMaterials"]);
                await Task.Delay(RefreshDelayInMilliseconds, stoppingToken);
            }
        }
    }
}
