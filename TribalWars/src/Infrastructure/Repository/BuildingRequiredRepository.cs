using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<BuildingRequiredBuilding>> GetRequiredBuildings(int buildingId)
        {
            return await Context.BuildingRequiredBuildings
                    .Where(building => building.BuildingId == buildingId)
                    .Include(building => building.RequiredBuilding)
                    .ThenInclude(building => building.Building)
                    .ToListAsync();
        }

        public async Task<IEnumerable<BuildingRequiredMaterial>> GetBaseRequiredMaterials(int buildingId)
        {
            var materials = Context.BuildingRequiredMaterials
                            .Include(material => material.Material)
                            .Where(material => material.BuildingId == buildingId)
                            .ToListAsync();

            return await materials;
        }
    }
}
