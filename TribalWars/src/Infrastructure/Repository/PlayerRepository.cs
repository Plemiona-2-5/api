using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Player player)
        {
            _context.Players.Add(player);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Player> GetByNicknameAsync(string nickname) =>
            await _context.Players.FirstOrDefaultAsync(player => player.Nickname == nickname);
    }
}