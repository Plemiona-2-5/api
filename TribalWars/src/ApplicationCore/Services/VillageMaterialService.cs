using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
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
    }
}
