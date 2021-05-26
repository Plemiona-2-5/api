using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VillageRepository : BaseRepository, IVillageRepository
    {
        public VillageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Village> GetVillageByPlayerId(Guid playerId)
        {
            return await Context.Villages
                .FirstOrDefaultAsync(v => v.PlayerId == playerId);
        }
    }
}
