using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IBuildingRequiredService
    {
        Task<IEnumerable<BuildingRequiredBuilding>> GetRequiredBuildings(int id);
        Task<IEnumerable<BuildingRequiredMaterial>> GetRequiredMaterials(int level, int buildingId);
        Task<bool> HasMaterial(int buildingId, int level, int villageId);
        Task<bool> HasRequiredBuilding(int buildingId, int villageId);
        Task<bool> CanBuild(int buildingId, int level, int villageId);
    }
}
