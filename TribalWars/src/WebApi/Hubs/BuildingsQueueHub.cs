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
        public async Task BuildingWasConstructed()
        {
            Guid userId =  Guid.Parse(Context.UserIdentifier);
            var buildingQueue = await _buildingsQueueService.BuildingQueueByUserId(userId);
            if (_buildingsQueueService.ConstructionCompletion(buildingQueue))
            {
                await Clients.Caller.ConstructionCompleted("The construction of the building has been completed");
            }            
        }
    }
}
