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
    public class VillageMaterialsHub : Hub<IVillageMaterialsClient>
    {
        private readonly IVillageMaterialServices _villageMaterialServices;
        private readonly IMapper _mapper;

        public VillageMaterialsHub(IVillageMaterialServices villageMaterialServices,
            IMapper mapper)
        {
            _villageMaterialServices = villageMaterialServices;
            _mapper = mapper;
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

        [Authorize]
        public async Task VillageMaterialsGroup()
        {
            await AddToVillageMaterialsGroup(GroupType.VillageMaterials.ToString());
        }

        public async Task UpdateVillageMaterials(IEnumerable<VillageMaterial> actualVillageMaterials)
        {
           await _villageMaterialServices.UpdateVillageMaterials(actualVillageMaterials);
        }

        [Authorize]
        public async Task<IEnumerable<VillageMaterialVM>> BartekZDrungiemZaPociungiem()
        {
            var villageId = 1;
            var villageMaterials = await _villageMaterialServices.GetActualMaterials(villageId);
            return _mapper.Map<List<VillageMaterialVM>>(villageMaterials);
        }
    }
}
