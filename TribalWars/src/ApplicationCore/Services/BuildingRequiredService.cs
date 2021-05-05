using ApplicationCore.Entities;
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
        public BuildingRequiredService(IBuildingRequiredRepository buildingRequiredRepository)
        {
            _buildingRequiredRepository = buildingRequiredRepository;
        }

        public bool CanBuild(int buildingId, int level, int villageId)
        {
            if(HasMaterial(buildingId, level, villageId) && HasRequiredBuilding(buildingId, villageId))
            {
                return true;
            }
            return false;
        }

        public bool HasMaterial(int buildingId, int level, int villageId)
        {
           return _buildingRequiredRepository.HasMaterial(buildingId, level, villageId);
        }

        public bool HasRequiredBuilding(int buildingId, int villageId)
        {
            return _buildingRequiredRepository.HasRequiredBuilding(buildingId, villageId);
        }

        public IEnumerable<BuildingRequiredBuilding> RequiredBuilding(int id)
        {
            return _buildingRequiredRepository.RequiredBuilding(id);
        }

        public IEnumerable<BuildingRequiredMaterial> RequiredMaterials(int level, int id)
        {
            return _buildingRequiredRepository.RequiredMaterials(level, id);
        }
    }
}
