using ApplicationCore.Entities;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class VillageService : IVillageService
    {
        private readonly IVillageRepository _villageRepository;
        private readonly IStringLocalizer<MessageResource> _localizer;
        private readonly IMapper _mapper;

        public VillageService(IVillageRepository villageRepository, IStringLocalizer<MessageResource> localizer, IMapper mapper)
        {
            _villageRepository = villageRepository;
            _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<Village> GetVillageByPlayerId(Guid playerId)
        {
            return await _villageRepository.GetVillageByPlayerId(playerId);
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
