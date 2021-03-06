using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TribeUserRepository : BaseRepository, ITribeUserRepository
    {
        public TribeUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddNewMember(TribePlayer player)
        {
            await Context.TribePlayers.AddAsync(player);
            await Context.SaveChangesAsync();
        }

        public Task<TribePlayer> GetTribeUserById(Guid playerId)
        {
            return Context.TribePlayers.
                FirstOrDefaultAsync(tp => tp.PlayerId == playerId);
        }

        public async Task<List<TribePlayer>> GetTribeUsersByTribeId(int tribeId)
        {
            return await Context.TribePlayers
                .Where(tribe => tribe.TribeId == tribeId)
                .Include(tribePlayer => tribePlayer.Player)
                .ToListAsync();
        }

        public async Task<bool> IsOwner(Guid playerId, int tribeId)
        {
            return await Context.TribePlayers
                .Where(tp => tp.TribeId == tribeId)
                .Where(tp => tp.PlayerId == playerId)
                .Where(tp => tp.TribeRole == TribeRole.Owner)
                .AnyAsync();
        }

        public async Task RemoveMember(TribePlayer player)
        {
            Context.TribePlayers.Remove(player);
            await Context.SaveChangesAsync();
        }
    }
}
