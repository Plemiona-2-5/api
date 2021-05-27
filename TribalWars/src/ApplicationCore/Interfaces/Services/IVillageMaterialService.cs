using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageMaterialService
    {
        Task UseVillageMaterials(int villageId, int level, int buildingId);
    }
}
