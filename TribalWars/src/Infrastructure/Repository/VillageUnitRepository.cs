using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VillageUnitRepository : BaseRepository, IVillageUnitRepository
    {
        public VillageUnitRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<VillageUnit>> GetVillageUnits(Guid playerId)
        {
            return await Context.VillageUnits
                .Include(vu => vu.ArmyUnitType)
                .Where(vu => vu.Village.PlayerId == playerId)
                .ToListAsync();
        }
    }
}
