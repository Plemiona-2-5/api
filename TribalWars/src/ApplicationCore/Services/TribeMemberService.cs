using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using ApplicationCore.Results.Generic;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class TribeMemberService : ITribeMemberService
    {
        private readonly ITribeUserRepository _tribeUserRepository;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public TribeMemberService(ITribeUserRepository tribeUserRepository, IStringLocalizer<MessageResource> localizer)
        {
            _tribeUserRepository = tribeUserRepository;
            _localizer = localizer;
        }

        public async Task<ServiceResult<List<TribePlayer>>> GetTribeUsersByTribeId(int tribeId)
        {
            var tribeMembers = await _tribeUserRepository.GetTribeUsersById(tribeId);
            if(tribeMembers.Count > 0)
            {
                return ServiceResult<List<TribePlayer>>.Success(tribeMembers);
            }
            return ServiceResult<List<TribePlayer>>.Failure(_localizer["ReturnTribeMembersError"]);
        }
    }
}
