using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BuildingsQueueService : IBuildingsQueueService
    {
        private readonly IBuildingsQueueRepository _buildingsQueueRepository;
        private readonly IBuildingsRepository _buildingsRepository;
        private readonly IBuildingService _buildingService;
        private readonly IBuildingRequiredService _buildingRequiredService;

        public BuildingsQueueService(IBuildingsQueueRepository buildingsQueueRepository,
                                     IBuildingsRepository buildingsRepository,
                                     IBuildingService buildingService,
                                     IBuildingRequiredService buildingRequiredService)
        {
            _buildingsQueueRepository = buildingsQueueRepository;
            _buildingsRepository = buildingsRepository;
            _buildingService = buildingService;
            _buildingRequiredService = buildingRequiredService;

        }

        public async Task<BuildingQueue> CreateBuildingQueue(int viilageId, int buildingId)
        {
            var building = await _buildingsRepository.GetBuildingById(buildingId);
            BuildingQueue buildingQueue = new()
            {
                VillageId = viilageId,
                BuildingId = buildingId,
                StartDate = DateTime.Now,
                Duration = building.ConstructionTime
            };
            return buildingQueue;
        }

        public async Task<List<BuildingQueue>> QueueBuildings(int villageId)
        {
            return await _buildingsQueueRepository
                .GetQueueBuildings(villageId);
        }
        public async Task<BuildingQueue> BuildingQueueByUserId(Guid userId)
        {
            return await _buildingsQueueRepository.GetBuildingQueueByUserId(userId);
        }

        public async Task<bool> CanAddToQueue(int villageId)
        {
            var buildingsInQueue = await _buildingsQueueRepository.GetQueueBuildings(villageId);
            return buildingsInQueue.Count < 0;
        }

        public async Task<ServiceResult> AddBuildingsToQueue(int villageId, int buildingId)
        {
            if (await _buildingRequiredService.CanBuild(buildingId, await _buildingService.CurrentBuildingLevel(villageId, buildingId), villageId))
            {
                if (await CanAddToQueue(villageId))
                {
                    var createBuildingQueue = await CreateBuildingQueue(villageId, buildingId);
                    var buildingQueue = await _buildingsQueueRepository.GetBuildingQueueByVillageId(villageId);

                    createBuildingQueue.StartDate = buildingQueue?
                        .StartDate.AddSeconds(buildingQueue.Duration)
                        ?? createBuildingQueue.StartDate;

                    await _buildingsQueueRepository
                            .AddBuildingsToQueue(createBuildingQueue);
                    return ServiceResult.Success();
                }
                return ServiceResult.Failure("");
            }
            return ServiceResult.Failure("");
        }

        public async Task<bool> ConstructionCompletion(BuildingQueue buildingQueue)
        {
            DateTime timeOfCompletion = buildingQueue.StartDate.AddSeconds(buildingQueue.Duration);
            if (timeOfCompletion == DateTime.Now)
            {
                await _buildingsQueueRepository.RemoveBuildingsFromQueue(buildingQueue);
                await _buildingService.UpgradeBuilding(buildingQueue);
                return true;
            }
            return false;
        }

        public async Task RemoveBuildingsFromQueue(BuildingQueue buildingQueue)
        {
            await _buildingsQueueRepository
                .RemoveBuildingsFromQueue(buildingQueue);
        }
    }
}
