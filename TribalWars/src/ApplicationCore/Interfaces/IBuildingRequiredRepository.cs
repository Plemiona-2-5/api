using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingRequiredRepository
    {
        IEnumerable<BuildingRequiredBuilding> GetRequiredBuildings(int buildingId);
        IEnumerable<BuildingRequiredMaterial> GetBaseRequiredMaterials(int buildingId);
    }
}
