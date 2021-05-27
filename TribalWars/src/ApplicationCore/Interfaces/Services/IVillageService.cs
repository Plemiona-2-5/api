using System;
using System.Threading.Tasks;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageService
    {
        Task<ServiceResult> CreateNewVillage(Guid playerId);
    }
}