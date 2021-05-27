using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IPlayerRepository
    {
        Task<bool> AddAsync(Player player); 
        Task<Player> GetByNicknameAsync(string nickname); 
        Task<Player> GetByUserIdAsync(Guid userId); 
        Task<bool> PlayerExistByIdAsync(Guid playerId);
    }
}