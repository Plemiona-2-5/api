using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingRequiredService
    {
        IEnumerable<BuildingRequiredBuilding> RequiredBuilding(int id);
        IEnumerable<BuildingRequiredMaterial> RequiredMaterials(int level, int id);
        bool HasMaterial(int buildingId, int level, int villageId);
        bool HasRequiredBuilding(int buildingId, int villageId);
        bool CanBuild(int buildingId, int level, int villageId);
    }
}
