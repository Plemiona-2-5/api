
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
    public class BuildingsRepository : BaseRepository, IBuildingsRepository
    {
        public BuildingsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Building GetBuildingById(int buildingId)
        {
            return Context.Buildings
                .FirstOrDefault(building => building.Id == buildingId);
        }
    }
}
