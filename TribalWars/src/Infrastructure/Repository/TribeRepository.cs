using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TribeRepository : BaseRepository, ITribeRepository
    {
        public TribeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public int CreateTribe(Tribe tribe)
        {
            Context.Tribes.Add(tribe);
            Context.SaveChanges();
            return tribe.Id;
        }
        public void AddPlayerToTribe(TribePlayer player)
        {
            Context.TribePlayers.Add(player);
            Context.SaveChanges();
        }

        public Tribe SelectedTribe(string tribeName)
        {
            return Context.Tribes.FirstOrDefault(tribe => tribe.Name == tribeName);
        }
    }
}
