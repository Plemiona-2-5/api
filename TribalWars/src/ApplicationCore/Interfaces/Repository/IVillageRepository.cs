using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVillageRepository
    {
        Task<Village> GetVillageByIdAsync(int villageId);
        Task<bool> VillageExistsByCoordinatesAsync(int coordinateX, int coordinateY);
        Task<bool> AddVillageAsync(Village village);
    }
}