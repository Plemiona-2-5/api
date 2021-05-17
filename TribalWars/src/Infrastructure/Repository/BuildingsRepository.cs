using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BuildingsRepository : BaseRepository, IBuildingsRepository
    {
        public BuildingsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Building> GetBuildingById(int buildingId)
        {
            return await Context.Buildings
                .FirstOrDefaultAsync(building => building.Id == buildingId);
        }
    }
}
