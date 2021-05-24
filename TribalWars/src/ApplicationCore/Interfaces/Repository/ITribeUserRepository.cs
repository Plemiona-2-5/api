using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface ITribeUserRepository
    {
        Task<List<TribePlayer>> GetTribeUsersById(int tribeId);
        Task AddNewMember(TribePlayer player);
        Task<bool> IsOwner(Guid playerId);
    }
}
