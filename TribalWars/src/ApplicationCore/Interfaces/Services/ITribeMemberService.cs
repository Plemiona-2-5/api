using ApplicationCore.Results;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITribeMemberService
    {
        Task<ServiceResult> InviteNewMember(Guid playerId, Guid invitedPlayerId);
        Task<ServiceResult> GetTribeUsersByTribeId(int tribeId);
        Task<ServiceResult> LeaveTribe(Guid playerId);
        Task<ServiceResult> RemoveTribeMember(Guid ownerId, Guid memberId);
    }
}
