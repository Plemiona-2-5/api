using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVillageUnitRepository
    {
        Task<List<VillageUnit>> GetVillageUnits(Guid playerId);
    }
}
