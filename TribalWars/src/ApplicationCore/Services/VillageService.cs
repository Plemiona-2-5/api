using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
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

        public VillageService(IVillageRepository villageRepository, IStringLocalizer<MessageResource> localizer)
        {
            _villageRepository = villageRepository;
            _localizer = localizer;
        }

        public async Task<ServiceResult> CreateNewVillage(Guid playerId)
        {
            var newVillage = new Village
            {
                PlayerId = playerId,
            };

            GenerateNewCoordinatesAsync(newVillage);

            return await _villageRepository.AddVillageAsync(newVillage)
                ? ServiceResult.Success()
                : ServiceResult.Failure(_localizer["AddVillageError"]);
        }

        //TODO: generate new coordinates based on growing circle
        private async void GenerateNewCoordinatesAsync(Village village)
        {
            var random = new Random();
            bool villageExists;
            int coordinateX;
            int coordinateY;

            do
            {
                coordinateX = random.Next(MapWidth);
                coordinateY = random.Next(MapHeight);

                villageExists = await _villageRepository.VillageExistsByCoordinatesAsync(coordinateX, coordinateY);
            } while (villageExists);

            village.CoordinateX = coordinateX;
            village.CoordinateY = coordinateY;
        }
    }
}