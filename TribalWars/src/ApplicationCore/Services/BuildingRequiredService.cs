using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BuildingRequiredService : IBuildingRequiredService
    {
        private readonly IBuildingRequiredRepository _buildingRequiredRepository;
        private readonly IVillageBuildingRepository _villageBuildingRepository;
        private readonly IVillageMaterialRepository _villageMaterialRepository;

        public BuildingRequiredService(IBuildingRequiredRepository buildingRequiredRepository,
                                        IVillageMaterialRepository villageMaterialRepository,
                                        IVillageBuildingRepository villageBuildingRepository)
        {
            _buildingRequiredRepository = buildingRequiredRepository;
            _villageBuildingRepository = villageBuildingRepository;
            _villageMaterialRepository = villageMaterialRepository;
        }

        public async Task<bool> CanBuild(int buildingId, int level, int villageId)
        {
            return await HasMaterial(buildingId, level, villageId) && await HasRequiredBuilding(buildingId, villageId);
        }

        public async Task<bool> HasMaterial(int buildingId, int level, int villageId)
        {
            var playerMaterials = await _villageMaterialRepository.GetVillageMaterials(villageId);
            var requiredMaterials = await GetRequiredMaterials(level, buildingId);
            foreach (var required in  requiredMaterials)
            {
                var material = playerMaterials
                    .FirstOrDefault(m => m.MaterialId == required.MaterialId);
                if(material == null || material.Quantity < required.Quantity)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> HasRequiredBuilding(int buildingId, int villageId)
        {
            var requiredBuilding = await GetRequiredBuildings(buildingId);
            var villageBuildings = await _villageBuildingRepository.GetVillageBuildings(villageId);

            foreach (var required in requiredBuilding)
            {
                var building = villageBuildings
                    .FirstOrDefault(b => b.BuildingId == required.BuildingId);
                if (building == null || required.RequiredBuilding.Level > building.CurrentLevel)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<IEnumerable<BuildingRequiredBuilding>> GetRequiredBuildings(int buildingId)
        {
            return await _buildingRequiredRepository.GetRequiredBuildings(buildingId);
        }

        public async Task<IEnumerable<BuildingRequiredMaterial>> GetRequiredMaterials(int level, int buildingId)
        {
            var materials = await _buildingRequiredRepository.GetBaseRequiredMaterials(buildingId);
            foreach (var material in materials)
            {
                material.Quantity *= level;
                if (material.Material.Name != ResourceType.People.ToString())
                {
                    material.Quantity *= level;
                }
            }
            return materials;
        }
    }
}
