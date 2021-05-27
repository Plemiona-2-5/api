using ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageUnitService
    {
        Task<List<VillageUnitVM>> GetVillageUnits(Guid playerId);
    }
}
