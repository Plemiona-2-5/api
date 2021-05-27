using ApplicationCore.Entities;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVillageRepository
    {
        Task<Village> GetVillageByPlayerId(Guid playerId);
    }
}
