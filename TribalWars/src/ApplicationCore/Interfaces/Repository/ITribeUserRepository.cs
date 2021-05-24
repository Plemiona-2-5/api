using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface ITribeUserRepository
    {
        Task<List<TribePlayer>> GetTribeUsersByTribeId(int tribeId);
        Task<TribePlayer> GetTribeUserById(Guid playerId);
        Task AddNewMember(TribePlayer player);
        Task RemoveMember(TribePlayer player);
        Task<bool> IsOwner(Guid playerId);
    }
}
