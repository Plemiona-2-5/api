using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class VillageRepository : BaseRepository, IVillageRepository
    {
        public VillageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Village> GetVillageByIdAsync(int villageId)
        {
            return await Context.Villages.AsNoTracking().SingleOrDefaultAsync(village => village.Id == villageId);
        }

        public bool VillageExistsByCoordinates(int coordinateX, int coordinateY)
        {
            return Context.Villages.AsNoTracking().Any(village =>
                village.CoordinateX == coordinateX && village.CoordinateY == coordinateY);
        }

        public async Task<bool> AddVillageAsync(Village village)
        {
            await Context.Villages.AddAsync(village);
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<Village> GetVillageByPlayerIdAsync(Guid playerId)
        {
            return await Context.Villages
                .AsNoTracking()
                .Include(village => village.Player)
                .FirstOrDefaultAsync(village => village.PlayerId == playerId);
        }

        public async Task<IEnumerable<Village>> GetAllVillagesExceptPlayerIdAsync(Guid playerId)
        {
            return await Context.Villages
                .AsNoTracking()
                .Include(village => village.Player)
                .Where(village => village.PlayerId != playerId)
                .ToListAsync();
        }
    }
}