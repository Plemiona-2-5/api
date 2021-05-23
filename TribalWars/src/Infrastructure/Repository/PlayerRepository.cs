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

        public async Task<bool> GetPlayerById(Guid playerId)
        {
            return await Context.Players.AnyAsync(p => p.Id == playerId);
        }
    }
}
