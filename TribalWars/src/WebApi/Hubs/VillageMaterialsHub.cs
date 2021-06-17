using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    [Authorize]
    public class VillageMaterialsHub : Hub<IVillageMaterialsClient>
    {
        private readonly IVillageMaterialService _villageMaterialServices;
        private readonly IMapper _mapper;
        private readonly IVillageService _villageService;
        private readonly IPlayerService _playerService;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public VillageMaterialsHub(IVillageMaterialService villageMaterialServices,
                                   IMapper mapper,
                                   IVillageService villageService,
                                   IPlayerService playerService,
                                   IStringLocalizer<MessageResource> localizer)
        {
            _villageMaterialServices = villageMaterialServices;
            _mapper = mapper;
            _villageService = villageService;
            _playerService = playerService;
            _localizer = localizer;
        }

        public async Task AddToVillageMaterialsGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).AddToGroup($"{Context.ConnectionId} has joined the group {groupName }.");
        }

        public async Task RemoveFromVillageMaterialsGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).RemoveFromGroup($"{Context.ConnectionId} has left the group {groupName}.");
        }

        public async Task VillageMaterialsGroup()
        {
            await AddToVillageMaterialsGroup(GroupType.VillageMaterials.ToString());
        }

        public async Task UpdateVillageMaterials(IEnumerable<VillageMaterial> actualVillageMaterials)
        {
           await _villageMaterialServices.UpdateVillageMaterials(actualVillageMaterials);
        }

        public async Task<IEnumerable<VillageMaterialVM>> ActualVillageMaterials()
        {
            if(Guid.TryParse(Context.UserIdentifier, out Guid userId))
            {
                var playerId = await _playerService.GetPlayerId(userId);
                var village = await _villageService.GetVillageByPlayerId(playerId) ;
                var villageMaterials = await _villageMaterialServices.GetActualMaterials(village.Id);
                return _mapper.Map<List<VillageMaterialVM>>(villageMaterials);
            }
            return null;
        }
    }
}
