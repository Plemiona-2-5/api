using ApplicationCore.Results;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageService
    {
        Task<ServiceResult> GetVillageCoordinates(Guid playerId);
    }
}
