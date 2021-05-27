using ApplicationCore.Resources;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Hubs;

namespace WebApi.Workers
{
    public class RecruitmentQueueTimerWorker : BackgroundService
    {
        private const int RefreshDelayInMilliseconds = 1000;
        private readonly IHubContext<RecruitmentQueueHub, IRecruitmentQueueClient> _hubContext;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public RecruitmentQueueTimerWorker(IHubContext<RecruitmentQueueHub,
            IRecruitmentQueueClient> hubContext,
            IStringLocalizer<MessageResource> localizer)
        {
            _hubContext = hubContext;
            _localizer = localizer;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.Group(GroupType.RecruitmentQueue.ToString())
                    .RefreshQueueRequest(_localizer["RefreshQueueRequest"]);
                await Task.Delay(RefreshDelayInMilliseconds, stoppingToken);
            }
        }
    }
}
