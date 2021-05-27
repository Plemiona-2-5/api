using ApplicationCore.Interfaces;
using ApplicationCore.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    [Authorize]
    public class BuildingsQueueHub : Hub<IBuildingsQueueClient>
    {
        private readonly IBuildingsQueueService _buildingsQueueService;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public BuildingsQueueHub(IBuildingsQueueService buildingsQueueService,
            IStringLocalizer<MessageResource> localizer)
        {
            _buildingsQueueService = buildingsQueueService;
            _localizer = localizer;
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

        public async Task BuildingQueueGroup()
        {
                await AddToBuildingQueueGroup(GroupType.BuildingsQueue.ToString());
        }

        public async Task BuildingWasConstructed()
        {
            if(Guid.TryParse(Context.UserIdentifier, out Guid userId))
            {
                var buildingQueue = await _buildingsQueueService.BuildingQueueByUserId(userId);
                if (await _buildingsQueueService.ConstructionCompletion(buildingQueue))
                {
                    await RemoveFromBuildingQueueGroup(GroupType.BuildingsQueue.ToString());
                    await Clients.Caller.ConstructionCompleted(_localizer["ConstructionCompleted"]);
                }
            }
            else
            {
                await Clients.Caller.IdDoesNotExist(_localizer["IdDoesNotExist"]);
            }         
        }
    }
}
