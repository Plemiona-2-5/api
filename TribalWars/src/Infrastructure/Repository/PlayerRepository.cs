using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PlayerRepository : BaseRepository, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Player> GetByUserId(Guid userId)
        {
            return await Context.Players.FirstOrDefaultAsync(p => p.Id == userId);
        }

        public async Task<bool> PlayerExistById(Guid playerId)
        {
            return await Context.Players.AnyAsync(p => p.Id == playerId);
        }

        public async Task<bool> AddAsync(Player player)
        {
            Context.Players.Add(player);
            return await SaveChangesAsync();
        }

        public async Task<Player> GetByNicknameAsync(string nickname) =>
            await Context.Players.FirstOrDefaultAsync(player => player.Nickname == nickname);
    }
}