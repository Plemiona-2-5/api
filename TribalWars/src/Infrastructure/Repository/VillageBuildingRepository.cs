using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VillageBuildingRepository : BaseRepository, IVillageBuildingRepository
    {
        public VillageBuildingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VillageBuilding>> GetVillageBuildings(int villageId)
        {
            var villageBuildings = await Context.VillageBuildings
                .Where(building => building.VillageId == villageId)
                .ToListAsync();
            return villageBuildings;
        }

        public async Task<VillageBuilding> GetVillageBuilding(int villageID, int buildingId)
        {
            return await Context.VillageBuildings
                .Where(vb => vb.VillageId == villageID)
                .FirstOrDefaultAsync(vb => vb.BuildingId == buildingId);
        }

        public async Task UpgradeBuilding(VillageBuilding building)
        {
            Context.Update(building);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> BuildingExist(int villageId, int buildingId)
        {
            return await Context.VillageBuildings
                .Where(vb => vb.VillageId == villageId)
                .AnyAsync(vb => vb.BuildingId == buildingId);
        }

        public async Task AddVillageBuilding(VillageBuilding building)
        {
            await Context.VillageBuildings.AddAsync(building);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VillageBuilding>> GetVillageBuildingsByPlayerId(Guid playerId)
        {
            return await Context.VillageBuildings
                .Include(vb => vb.Building)
                .Where(vb => vb.Village.PlayerId == playerId)
                .ToListAsync();
        }

        public async Task<VillageBuilding> GetTownHall(int villageId)
        {
            return await Context.VillageBuildings
                .Where(vb => vb.VillageId == villageId)
                .FirstOrDefaultAsync(vb => vb.Building.BuildingType == BuildingType.BuildingTime);
        }
    }
}
