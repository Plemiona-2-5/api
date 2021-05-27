using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageMaterialService
    {
        Task UseVillageMaterials(int villageId, int level, int buildingId);
        Task<IEnumerable<VillageMaterial>> GetActualMaterials(int villageId);
        Task UpdateVillageMaterials(IEnumerable<VillageMaterial> villageMaterials);
    }
}
