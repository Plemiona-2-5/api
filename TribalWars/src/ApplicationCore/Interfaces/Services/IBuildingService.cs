using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IBuildingService
    {
        Task<int> CurrentBuildingLevel(int villageId, int buildingId);
        Task UpgradeBuilding(BuildingQueue buildingQueue);
        Task<bool> HasMaxLevel(int villageId, int buildingId);
    }
}
