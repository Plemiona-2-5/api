using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
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
        public async Task<IEnumerable<BuildingRequiredBuilding>> RequiredBuilding(int id)
        {
            return await _context.BuildingRequiredBuildings.Where(building => building.BuildingId == id).ToListAsync();
        }

        public async Task<IEnumerable<BuildingRequiredMaterial>> RequiredMaterials(int level, int id)
        {
            var materials = _context.BuildingRequiredMaterials.Include(material => material.Material).Where(material => material.BuildingId == id).ToListAsync();
            foreach (var material in await materials)
            {
                if (material.Material.Name == "People")
                {
                    material.Quantity = level * material.Quantity;
                }
                else
                {
                    material.Quantity = level * level * material.Quantity;
                }
            }
            return await materials;
        }
    }
}
