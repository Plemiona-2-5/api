using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IVillageBuildingRepository _villageBuildingRepository;
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IVillageBuildingRepository villageBuildingRepository, IBuildingRepository buildingRepository)
        {
            _villageBuildingRepository = villageBuildingRepository;
            _buildingRepository = buildingRepository;
        }

        public async Task<int> CurrentBuildingLevel(int villageId, int buildingId)
        {
            var building = await _villageBuildingRepository.GetVillageBuilding(villageId, buildingId);
            return building != null ? building.CurrentLevel : 0;
        }

        public async Task<bool> HasMaxLevel(int villageId, int buildingId)
        {
            var building = await _buildingRepository.GetBuilding(buildingId);
            return building.MaxLevel <= await CurrentBuildingLevel(villageId, buildingId);
        }

        public async Task UpgradeBuilding(BuildingQueue buildingQueue)
        {
            if (!await _villageBuildingRepository.BuildingExist(buildingQueue.VillageId, buildingQueue.BuildingId))
            {
                await CreateBuilding(buildingQueue);
            }
            else
            {
                var building = await _villageBuildingRepository.GetVillageBuilding(buildingQueue.Id, buildingQueue.BuildingId);
                building.CurrentLevel++;
                await _villageBuildingRepository.UpgradeBuilding(building);
            }
        }

        public async Task CreateBuilding(BuildingQueue buildingQueue)
        {
            VillageBuilding villageBuilding = new()
            {
                VillageId = buildingQueue.VillageId,
                BuildingId = buildingQueue.BuildingId,
                CurrentLevel = 1
            };
            await _villageBuildingRepository.AddVillageBuilding(villageBuilding);
        }
    }
}
