using ApplicationCore.Entities;
using ApplicationCore.Results;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageService
    {
        Task<Village> GetVillageByPlayerId(Guid playerId);
        Task<ServiceResult> GetVillageCoordinates(Guid playerId);
    }
}
