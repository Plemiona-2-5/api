using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using ApplicationCore.Results.Generic;
using ApplicationCore.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class VillageService : IVillageService
    {
        private readonly IVillageRepository _villageRepository;
        private readonly IStringLocalizer<MessageResource> _localizer;
        private readonly IMapper _mapper;
        private readonly IVillageBuildingRepository _villageBuildingRepository;

        public VillageService(IVillageRepository villageRepository,
            IStringLocalizer<MessageResource> localizer,
            IMapper mapper,
            IVillageBuildingRepository villageBuildingRepository)
        {
            _villageRepository = villageRepository;
            _localizer = localizer;
            _mapper = mapper;
            _villageBuildingRepository = villageBuildingRepository;
        }

        public async Task<List<VillageBuildingVM>> GetVillageBuildings(Guid playerId)
        {
            var buildings = await _villageBuildingRepository.GetVillageBuildingsByPlayerId(playerId);
            return _mapper.Map <List<VillageBuildingVM>>(buildings);

        }

        public async Task<ServiceResult> GetVillageCoordinates(Guid playerId)
        {
            var village = await _villageRepository.GetVillageByPlayerId(playerId);
            if(village != null)
            {
                return ServiceResult<CoordinatesVM>.Success(_mapper.Map<CoordinatesVM>(village));
            }
            return ServiceResult.Failure(_localizer["GetCooredinatesError"]);
        }
    }
}
