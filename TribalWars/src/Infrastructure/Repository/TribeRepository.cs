using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TribeRepository : BaseRepository, ITribeRepository
    {
        public TribeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> CreateTribe(Tribe tribe)
        {
            await Context.Tribes.AddAsync(tribe);
            await Context.SaveChangesAsync();
            return tribe.Id;
        }

        public async Task AddPlayerToTribe(TribePlayer player)
        {
            await Context.TribePlayers.AddAsync(player);
            await Context.SaveChangesAsync();
        }

        public async Task<Tribe> GetTribeByName(string tribeName)
        {
            return await Context.Tribes.FirstOrDefaultAsync(tribe => tribe.Name == tribeName);
        }
    }
}
