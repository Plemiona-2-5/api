using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
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
        public async Task AddToBuildingQueueGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).AddToGroup($"{Context.ConnectionId} has joined the group {groupName }.");
        }

        public async Task RemoveFromBuildingQueueGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).RemoveFromGroup($"{Context.ConnectionId} has left the group {groupName}.");
        }

        [Authorize]
        public async Task BuildingQueueGroup(int viilageId, int buildingId)
        {
                await _buildingsQueueService.CreateBuildingQueue(viilageId, buildingId);
                await AddToBuildingQueueGroup(GroupType.BuildingsQueue.ToString());
        }

        [Authorize]
        public async Task BuildingWasConstructed()
        {
            if(Guid.TryParse(Context.UserIdentifier, out Guid userId))
            {
                var buildingQueue = await _buildingsQueueService.BuildingQueueByUserId(userId);
                if (await _buildingsQueueService.ConstructionCompletion(buildingQueue))
                {
                    await RemoveFromBuildingQueueGroup(GroupType.BuildingsQueue.ToString());
                    await Clients.Caller.ConstructionCompleted("The construction of the building has been completed");
                }
            }
            else
            {
                await Clients.Caller.IdDoesNotExist("Such an id does not exist");
            }         
        }
    }
}
