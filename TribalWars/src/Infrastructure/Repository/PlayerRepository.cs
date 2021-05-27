using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
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

        public async Task<Player> GetByUserIdAsync(Guid userId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<bool> PlayerExistByIdAsync(Guid playerId)
        {
            return await _context.Players.AnyAsync(p => p.Id == playerId);
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