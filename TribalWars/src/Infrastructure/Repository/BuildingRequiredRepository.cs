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


        public bool HasMaterial(int buildingId, int level, int villageId)
        {
            var requiredMaterial = RequiredMaterials(level, buildingId);
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

        public bool HasRequiredBuilding(int buildingId, int villageId)
        {
            var requiredBuilding = RequiredBuilding(buildingId);
            var villageBuilding = _context.VillageBuildings.Where(building => building.VillageId == villageId).ToList();
            foreach (var building in villageBuilding)
            {
                var required = requiredBuilding.FirstOrDefault(b => b.BuildingId == building.BuildingId);
                if (required == null)
                {
                    return false;
                }
                else if(required.Level > building.CurrentLevel)
                {
                    return false;
                }
            }
            return true;

        }

        public IEnumerable<BuildingRequiredBuilding> RequiredBuilding(int buildingId)
        {
            return _context.BuildingRequiredBuildings.Where(building => building.BuildingId == buildingId).ToList();
        }

        public IEnumerable<BuildingRequiredMaterial> RequiredMaterials(int level, int buildingId)
        {
            var materials = _context.BuildingRequiredMaterials.Include(material => material.Material).Where(material => material.BuildingId == buildingId).ToList();
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
            return materials;
        }
    }
}
