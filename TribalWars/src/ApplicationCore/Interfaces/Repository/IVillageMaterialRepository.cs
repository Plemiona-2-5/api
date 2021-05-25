using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVillageMaterialRepository
    {
        Task<IEnumerable<VillageMaterial>> GetVillageMaterials(int villageId);
        Task UpdateVillageMaterial(VillageMaterial material);
    }
}
