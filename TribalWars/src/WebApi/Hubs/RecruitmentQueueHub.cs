using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    [Authorize]
    public class RecruitmentQueueHub : Hub<IRecruitmentQueueClient>
    {
        private readonly IRecruitmentQueueService _recruitmentQueueService;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public RecruitmentQueueHub(IRecruitmentQueueService recruitmentQueueService,
            IStringLocalizer<MessageResource> localizer)
        {
            _recruitmentQueueService = recruitmentQueueService;
            _localizer = localizer;
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

        public async Task RecruitmentQueueGroup()
        {
            await AddToRecruitmentQueueHubGroup(GroupType.RecruitmentQueue.ToString());
        }

        public async Task BuildingWasConstructed()
        {
            if (Guid.TryParse(Context.UserIdentifier, out Guid userId))
            {
                var recruitmentQueue = await _recruitmentQueueService.GetRecruitmentQueueByUserId(userId) ;
                if (await _recruitmentQueueService.EndUnitRecruitment(recruitmentQueue))
                {
                    await RemoveFromRecruitmentQueueHubGroup(GroupType.BuildingsQueue.ToString());
                    await Clients.Caller.RefreshQueueRequest(_localizer["RefreshQueueRequest"]);
                }
                else
                {
                    await _recruitmentQueueService.ReduceRecruitmentQueue(recruitmentQueue);
                }
            }
            else
            {
                await Clients.Caller.IdDoesNotExist(_localizer["IdDoesNotExist"]);
            }
        }

        [Authorize]
        public async Task<IEnumerable<RecruitmentQueueVM>> GetArmyQueues()
        {
            if (Guid.TryParse(Context.UserIdentifier, out Guid userId))
            {
                return await _recruitmentQueueService.GetRecruitmentQueues(userId);
            }
            return null;
        }
    }
}
