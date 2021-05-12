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

        public IEnumerable<Building> GetRequiredBuildings(int buildingId)
        {
            return Context.Buildings
                .Where(building => building.Id == buildingId)
                .Include(x => x.BuildingRequiredBuildings)
                .ToList();
                
                /*Context.BuildingRequiredBuildings
                    .Where(building => building.BuildingId == buildingId)
                    .Include(building => building.Building)
                    .ToList();*/
        }

        public IEnumerable<BuildingRequiredMaterial> GetBaseRequiredMaterials(int buildingId)
        {
            var materials = Context.BuildingRequiredMaterials
                            .Include(material => material.Material)
                            .Where(material => material.BuildingId == buildingId)
                            .ToList();

            return materials;
        }
    }
}
