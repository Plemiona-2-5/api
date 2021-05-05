using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BuildingRequiredRepository : BaseRepository, IBuildingRequiredRepository
    {
        public BuildingRequiredRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<BuildingRequiredBuilding>> RequiredBuilding(int id)
        {
            var building = _context.BuildingRequiredBuildings.Where(building => building.BuildingId == id);
            return building;
        }
    }
}
