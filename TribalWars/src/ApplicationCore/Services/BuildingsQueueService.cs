using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using ApplicationCore.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<MessageResource> _localizer;
        private readonly IVillageMaterialService _villageMaterialService;
        private const int MaxQueueCount = 2;
        private readonly IMapper _mapper;

        public BuildingsQueueService(IBuildingsQueueRepository buildingsQueueRepository,
                                     IBuildingsRepository buildingsRepository,
                                     IBuildingService buildingService,
                                     IBuildingRequiredService buildingRequiredService,
                                     IStringLocalizer<MessageResource> localizer,
                                     IVillageMaterialService villageMaterialService,
                                     IMapper mapper)
        {
            _buildingsQueueRepository = buildingsQueueRepository;
            _buildingsRepository = buildingsRepository;
            _buildingService = buildingService;
            _buildingRequiredService = buildingRequiredService;
            _localizer = localizer;
            _villageMaterialService = villageMaterialService;
            _mapper = mapper;
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
            return buildingsInQueue.Count < MaxQueueCount;
        }
        public async Task<ServiceResult> AddBuildingsToQueue(int villageId, int buildingId)
        {
            var buildingLevel =  await _buildingService.GetCurrentBuildingLevel(villageId, buildingId) + 1;
            if (await _buildingRequiredService.CanBuild(buildingId, buildingLevel, villageId))
            {
                if (await CanAddToQueue(villageId))
                {
                    if (!await _buildingService.HasMaxLevel(villageId, buildingId))
                    {
                        var createBuildingQueue = await CreateBuildingQueue(villageId, buildingId);
                        var buildingQueue = await _buildingsQueueRepository.GetBuildingQueueByVillageId(villageId);

                        createBuildingQueue.StartDate = buildingQueue?
                            .StartDate.AddSeconds(buildingQueue.Duration)
                            ?? createBuildingQueue.StartDate;

                        await _buildingsQueueRepository
                                .AddBuildingsToQueue(createBuildingQueue);
                        await _villageMaterialService.UseVillageMaterials(villageId, buildingLevel, buildingId);
                        return ServiceResult.Success();
                    }
                    return ServiceResult.Failure(_localizer["AddBuildingMaxLevelError"]);
                }
                return ServiceResult.Failure(_localizer["AddBuildingFullQueueError"]);
            }
            return ServiceResult.Failure(_localizer["AddBuildingNoRequieredError"]);
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

        public async Task<List<BuildingQueueVM>> BuildingQueues(Guid playerId)
        {
            var buildingQueues = await _buildingsQueueRepository.GetBuildingQueuesByPlayerId(playerId);

            return _mapper.Map<List<BuildingQueueVM>>(buildingQueues);
        }
    }
}
