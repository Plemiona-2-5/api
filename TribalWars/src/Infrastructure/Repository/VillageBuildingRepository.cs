﻿using ApplicationCore.Entities;
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
    public class VillageBuildingRepository : BaseRepository, IVillageBuildingRepository
    {
        public VillageBuildingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VillageBuilding>> GetVillageBuildings(int villageId)
        {
            var villageBuildings = await Context.VillageBuildings
                .Where(building => building.VillageId == villageId)
                .ToListAsync();
            return villageBuildings;
        }
    }
}
