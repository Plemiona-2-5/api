using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class VillageMaterialServices : IVillageMaterialServices
    {
        private readonly IVillageMaterialRepository _villageMaterialRepository;

        public VillageMaterialServices(IVillageMaterialRepository villageMaterialRepository)
        {
            _villageMaterialRepository = villageMaterialRepository;
        }

        public async Task<IEnumerable<VillageMaterial>> GetActualMaterials(int villageId)
        {
            return await _villageMaterialRepository.GetVillageMaterials(villageId);
        }

        public async Task UpdateVillageMaterials(IEnumerable<VillageMaterial> villageMaterials)
        {
            foreach (var villageMaterial in villageMaterials)
            {
                villageMaterial.Quantity += (int)villageMaterial.PerMinute;
                await _villageMaterialRepository.UpdateVillageMaterials(villageMaterial);
            }           
        }
    }
}
