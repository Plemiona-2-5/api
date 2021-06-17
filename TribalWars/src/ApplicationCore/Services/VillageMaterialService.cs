using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class VillageMaterialService : IVillageMaterialService
    {
        private readonly IVillageMaterialRepository _villageMaterialRepository;
        private readonly IBuildingRequiredService _buildingRequiredService;

        public VillageMaterialService(IVillageMaterialRepository villageMaterialRepository, IBuildingRequiredService buildingRequiredService)
        {
            _villageMaterialRepository = villageMaterialRepository;
            _buildingRequiredService = buildingRequiredService;
        }

        public async Task UseVillageMaterials(int villageId, int level, int buildingId)
        {
            var villageMaterails = await _villageMaterialRepository.GetVillageMaterials(villageId);
            var requiredMaterials = await _buildingRequiredService.GetRequiredMaterials(level, buildingId);
            foreach (var required in requiredMaterials)
            {
                var material = villageMaterails
                    .FirstOrDefault(b => b.MaterialId == required.MaterialId);
                material.Quantity -= required.Quantity;
                await _villageMaterialRepository.UpdateVillageMaterial(material);
            }
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
                await _villageMaterialRepository.UpdateVillageMaterial(villageMaterial);
            }
        }
    }
}
