using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public class RecruitmentQueueHub : Hub<IRecruitmentQueueClient>
    {
        private readonly IRecruitmentQueueService _recruitmentQueueService;

        public RecruitmentQueueHub(IRecruitmentQueueService recruitmentQueueService)
        {
            _recruitmentQueueService = recruitmentQueueService;
        }

        public async Task AddToRecruitmentQueueHubGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).AddToGroup($"{Context.ConnectionId} has joined the group {groupName }.");
        }

        public async Task RemoveFromRecruitmentQueueHubGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).RemoveFromGroup($"{Context.ConnectionId} has left the group {groupName}.");
        }
        [Authorize]
        public async Task RecruitmentQueueGroup()
        {
            await AddToRecruitmentQueueHubGroup(GroupType.RecruitmentQueue.ToString());
        }

        [Authorize]
        public async Task BuildingWasConstructed()
        {
            if (Guid.TryParse(Context.UserIdentifier, out Guid userId))
            {
                var recruitmentQueue = await _recruitmentQueueService.GetRecruitmentQueueByUserId(userId) ;
                if (await _recruitmentQueueService.EndUnitRecruitment(recruitmentQueue))
                {
                    await RemoveFromRecruitmentQueueHubGroup(GroupType.BuildingsQueue.ToString());
                    await Clients.Caller.RefreshQueueRequest("The construction of the building has been completed");
                }
            }
            else
            {
                await Clients.Caller.IdDoesNotExist("Such an id does not exist");
            }
        }
    }
}
