using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<bool> AddAsync(Player player); 
        Task<Player> GetByNicknameAsync(string nickname); 
    }
}