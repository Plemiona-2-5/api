using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PlayerRepository : BaseRepository, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Player> GetPlayerByUserId(Guid userId)
        {
            return await Context.Players
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<bool> PlayerExistById(Guid playerId)
        {
            return await Context.Players.AnyAsync(p => p.Id == playerId);
        }
    }
}
