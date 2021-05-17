using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public class BuildingsQueueHub : Hub<IBuildingsQueueClient>
    {
        private readonly IBuildingsQueueService _buildingsQueueService;

        public BuildingsQueueHub(IBuildingsQueueService buildingsQueueService)
        {
            _buildingsQueueService = buildingsQueueService;
        }

        [Authorize]
        public async Task<bool> BuildingWasConstructed()
        {
            Guid userId =  Guid.Parse(Context.UserIdentifier);
            var buildingQueue = _buildingsQueueService.BuildingQueueByUserId(userId);
            if (_buildingsQueueService.ConstructionCompletion(buildingQueue))
            {
                return true;
            }
            return false;
        }
    }
}
