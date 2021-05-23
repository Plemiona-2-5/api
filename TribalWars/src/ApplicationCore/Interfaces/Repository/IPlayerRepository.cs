using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IPlayerRepository
    {
        Task<bool> GetPlayerById(Guid playerId);
    }
}
