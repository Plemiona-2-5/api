using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface ITribeUserRepository
    {
        Task<List<TribePlayer>> GetTribeUsersById(int tribeId);
    }
}
