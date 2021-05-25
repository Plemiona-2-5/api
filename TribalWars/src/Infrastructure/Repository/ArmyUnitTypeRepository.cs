using ApplicationCore.Entities;
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
    public class ArmyUnitTypeRepository : BaseRepository, IArmyUnitTypeRepository
    {
        public ArmyUnitTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ArmyUnitType> GetArmyUnitTypeById(int armyUnitTypeId)
        {
            return await Context.ArmyUnitTypes
                .FirstOrDefaultAsync(armyUnitType => armyUnitType.Id == armyUnitTypeId);
        }
    }
}
