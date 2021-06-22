using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IBuildingService
    {
        Task<int> GetCurrentBuildingLevel(int villageId, int buildingId);
        Task UpgradeBuilding(BuildingQueue buildingQueue);
        Task<bool> HasMaxLevel(int villageId, int buildingId);
        Task<int> ReductionOfConstructionTime(int villageId);
    }
}
