using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BuildingRepository : BaseRepository, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Building> GetBuilding(int buildingId)
        {
            return await Context.Buildings
                .FirstOrDefaultAsync(b => b.Id == buildingId);
        }
    }
}
