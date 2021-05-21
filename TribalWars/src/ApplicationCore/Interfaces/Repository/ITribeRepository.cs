using ApplicationCore.Entities;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface ITribeRepository
    {
        Task<int> CreateTribe(Tribe tribe);
        Task AddPlayerToTribe(TribePlayer player);
        Task<Tribe> GetTribeByName(string tribeName);
        Task<Tribe> GetTribeByUser(Guid userId);
        Task UpdateTribe(Tribe tribe);

    }
}
