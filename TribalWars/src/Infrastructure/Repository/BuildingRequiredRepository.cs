using ApplicationCore.Entities;
using ApplicationCore.Enums;
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

        public bool CanBuild()
        {
            throw new NotImplementedException();
        }

        public bool HasMaterial(int buildingId, int level, int villageId)
        {
            var requiredMaterial = RequiredMaterials(level, buildingId);
            int count = requiredMaterial.Count();
            var playerMaterials = _context.VillageMaterials.Where(material => material.VillageId == villageId).ToList();
            if (playerMaterials.Count < requiredMaterial.Count())
            {
                return false;
            }
            foreach (var material in playerMaterials)
            {
                var required = requiredMaterial.FirstOrDefault(m => m.MaterialId == material.MaterialId);
                if(material.Quantity < required.Quantity)
                {
                    return false;
                }
            }
            return true;
        }

        public bool HasRequiredBuilding()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BuildingRequiredBuilding>> RequiredBuilding(int id)
        {
            return await _context.BuildingRequiredBuildings.Where(building => building.BuildingId == id).ToListAsync();
        }

        public IEnumerable<BuildingRequiredMaterial> RequiredMaterials(int level, int id)
        {
            var materials = _context.BuildingRequiredMaterials.Include(material => material.Material).Where(material => material.BuildingId == id).ToList();
            foreach (var material in materials)
            {
                if (material.Material.Name == MaterialType.People.ToString())
                {
                    material.Quantity = level * material.Quantity;
                }
                else
                {
                    material.Quantity = level * level * material.Quantity;
                }
            }
            return  materials;
        }
    }
}
