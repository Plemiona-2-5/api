using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageMaterialRepository
    {
        Task<IEnumerable<VillageMaterial>> GetVillageMaterials(int villageId);
    }
}
