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
        public async Task<IEnumerable<BuildingRequiredBuilding>> RequiredBuilding(int id)
        {
            return await _buildingRequiredRepository.RequiredBuilding(id);
        }
    }
}
