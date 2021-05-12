using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public bool CanBuild(int buildingId, int level, int villageId)
        {
            return HasMaterial(buildingId, level, villageId) && HasRequiredBuilding(buildingId, villageId);
        }

        public bool HasMaterial(int buildingId, int level, int villageId)
        {
            var playerMaterials = _villageMaterialRepository.GetVillageMaterials(villageId);
            var requiredMaterials = GetRequiredMaterials(level, buildingId);
            foreach (var required in requiredMaterials)
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

        public bool HasRequiredBuilding(int buildingId, int villageId)
        {
            var requiredBuilding = GetRequiredBuildings(buildingId);
            var villageBuildings = _villageBuildingRepository.GetVillageBuildings(villageId);

            foreach (var required in requiredBuilding)
            {
                var building = villageBuildings
                    .FirstOrDefault(b => b.BuildingId == required.BuildingId);
                if (building == null || required.Level > building.CurrentLevel)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<BuildingRequiredBuilding> GetRequiredBuildings(int buildingId)
        {
            return _buildingRequiredRepository.GetRequiredBuildings(buildingId);
        }

        public IEnumerable<BuildingRequiredMaterial> GetRequiredMaterials(int level, int buildingId)
        {
            var materials = _buildingRequiredRepository.GetBaseRequiredMaterials(buildingId);
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
