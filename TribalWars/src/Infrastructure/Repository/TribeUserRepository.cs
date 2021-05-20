using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TribeUserRepository : BaseRepository, ITribeUserRepository
    {
        public TribeUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<TribePlayer>> GetTribeUsersById(int tribeId)
        {
            return await Context.TribePlayers
                .Where(tribe => tribe.TribeId == tribeId)
                .Include(tribePlayer => tribePlayer.Player)
                .ToListAsync();
        }
    }
}
