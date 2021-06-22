using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVillageBuildingRepository
    {
        Task<IEnumerable<VillageBuilding>> GetVillageBuildings(int villageId);
        Task<IEnumerable<VillageBuilding>> GetVillageBuildingsByPlayerId(Guid playerId);
        Task<VillageBuilding> GetVillageBuilding(int villageId, int buildingId);
        Task UpgradeBuilding(VillageBuilding building);
        Task AddVillageBuilding(VillageBuilding building);
        Task<bool> BuildingExist(int villageId, int buildingId);
        Task<VillageBuilding> GetTownHall(int villageId);
    }
}
