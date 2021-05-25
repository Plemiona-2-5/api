using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
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

        public RecruitmentQueueTimerWorker(IHubContext<RecruitmentQueueHub, IRecruitmentQueueClient> hubContext)
        {
            _hubContext = hubContext;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.Group(GroupType.RecruitmentQueue.ToString()).RefreshQueueRequest("Refresh queue");
                await Task.Delay(RefreshDelayInMilliseconds, stoppingToken);
            }
        }
    }
}
