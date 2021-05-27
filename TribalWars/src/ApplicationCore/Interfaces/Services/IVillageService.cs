using ApplicationCore.Results;
using ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageService
    {
        Task<ServiceResult> GetVillageCoordinates(Guid playerId);
        Task<List<VillageBuildingVM>> GetVillageBuildings(Guid playerId);
    }
}
