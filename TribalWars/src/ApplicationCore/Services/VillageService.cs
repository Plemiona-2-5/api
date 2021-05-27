using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace ApplicationCore.Services
{
    public class VillageService : IVillageService
    {
        //TODO: add map entity and assign village to specific map 
        private const int MapHeight = 1000;
        private const int MapWidth = 1000;
        private readonly IVillageRepository _villageRepository;
        private readonly IStringLocalizer<MessageResource> _localizer;
        private readonly IMapper _mapper;

        public VillageService(IVillageRepository villageRepository, IStringLocalizer<MessageResource> localizer,
            IMapper mapper)
        {
            _villageRepository = villageRepository;
            _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<VillageDto> GetVillageDtoByPlayerId(Guid playerId)
        {
            var village = await _villageRepository.GetVillageByPlayerIdAsync(playerId);

            if (village == null)
                return null;

            var villageDto = _mapper.Map<VillageDto>(village);

            return villageDto;
        }

        public async Task<(IEnumerable<VillageDto>, MapDto)> GetVillagesDtoExceptPlayerAsync(Guid playerId)
        {
            var villages = await _villageRepository.GetAllVillagesExceptPlayerIdAsync(playerId);
            
            if (villages == null)
                return default;
            
            var villagesDto = _mapper.Map<IEnumerable<VillageDto>>(villages);
            var mapDto = new MapDto{ MapHeight = MapHeight, MapWidth = MapWidth};
            
            return (villagesDto, mapDto);
        }

        public async Task<ServiceResult> CreateNewVillageAsync(Guid playerId)
        {
            var newVillage = new Village
            {
                PlayerId = playerId,
            };

            GenerateNewCoordinates(newVillage);

            return await _villageRepository.AddVillageAsync(newVillage)
                ? ServiceResult.Success()
                : ServiceResult.Failure(_localizer["AddVillageError"]);
        }

        //TODO: generate new coordinates based on growing circle, its only for demonstration purposes
        private void GenerateNewCoordinates(Village village)
        {
            var random = new Random();
            bool villageExists;
            int coordinateX;
            int coordinateY;

            do
            {
                coordinateX = random.Next(MapWidth);
                coordinateY = random.Next(MapHeight);

                villageExists = _villageRepository.VillageExistsByCoordinates(coordinateX, coordinateY);
            } while (villageExists);

            village.CoordinateX = coordinateX;
            village.CoordinateY = coordinateY;
        }
    }
}