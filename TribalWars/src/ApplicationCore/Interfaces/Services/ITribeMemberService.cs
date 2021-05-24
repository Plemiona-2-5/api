using ApplicationCore.Entities;
using ApplicationCore.Results.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITribeMemberService
    {
        Task<ServiceResult<List<TribePlayer>>> GetTribeUsersByTribeId(int tribeId);
    }
}
