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

        public bool CanBuild()
        {
            throw new NotImplementedException();
        }

        public bool HasMaterial(int buildingId, int level, int villageId)
        {
           return _buildingRequiredRepository.HasMaterial(buildingId, level, villageId);
        }

        public bool HasRequiredBuilding()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BuildingRequiredBuilding>> RequiredBuilding(int id)
        {
            return await _buildingRequiredRepository.RequiredBuilding(id);
        }

        public IEnumerable<BuildingRequiredMaterial> RequiredMaterials(int level, int id)
        {
            return _buildingRequiredRepository.RequiredMaterials(level, id);
        }
    }
}
