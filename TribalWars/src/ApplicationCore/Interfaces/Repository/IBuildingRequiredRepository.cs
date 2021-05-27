using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IBuildingRequiredRepository
    {
        Task<IEnumerable<BuildingRequiredBuilding>> GetRequiredBuildings(int buildingId);
        Task<IEnumerable<BuildingRequiredMaterial>> GetBaseRequiredMaterials(int buildingId);
    }
}
