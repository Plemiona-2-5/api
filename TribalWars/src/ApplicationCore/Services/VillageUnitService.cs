using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class VillageUnitService : IVillageUnitService
    {
        private readonly IVillageUnitRepository _villageUnitRepository;
        private readonly IMapper _mapper;

        public VillageUnitService(IVillageUnitRepository villageUnitRepository, IMapper mapper)
        {
            _villageUnitRepository = villageUnitRepository;
            _mapper = mapper;
        }

        public async Task<List<VillageUnitVM>> GetVillageUnits(Guid playerId)
        {
            var villageUnits = await _villageUnitRepository.GetVillageUnits(playerId);

            return _mapper.Map<List<VillageUnitVM>>(villageUnits);
        }
    }
}
