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
        Task<IEnumerable<BuildingRequiredBuilding>> RequiredBuilding(int id);
        Task<IEnumerable<BuildingRequiredMaterial>> RequiredMaterials(int level, int id);
    }
}
