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

        public async Task<bool> VillageExistsByCoordinatesAsync(int coordinateX, int coordinateY)
        {
            return await Context.Villages.AsNoTracking().AnyAsync(village =>
                village.CoordinateX == coordinateX && village.CoordinateY == coordinateY);
        }

        public async Task<bool> AddVillageAsync(Village village)
        {
            await Context.Villages.AddAsync(village);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}