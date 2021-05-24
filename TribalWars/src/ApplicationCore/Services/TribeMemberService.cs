using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using Microsoft.Extensions.Localization;
using System;
using ApplicationCore.Results.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.ViewModels;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class TribeMemberService : ITribeMemberService
    {
        private readonly ITribeUserRepository _tribeUserRepository;
        private readonly ITribeRepository _tribeRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IStringLocalizer<MessageResource> _localizer;
        private readonly IMapper _mapper;

        public TribeMemberService(ITribeUserRepository tribeUserRepository,
            IStringLocalizer<MessageResource> localizer,
            ITribeRepository tribeRepository,
            IPlayerRepository playerRepository,
            IMapper mapper)
        {
            _tribeUserRepository = tribeUserRepository;
            _localizer = localizer;
            _tribeRepository = tribeRepository;
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult> InviteNewMember(Guid playerId, Guid invitedPlayerId)
        {
            var tribe = await _tribeRepository.GetTribeByUser(playerId);
            if (tribe != null && await _playerRepository.PlayerExistById(invitedPlayerId))
            {
                if (!await HasTribe(invitedPlayerId))
                {
                    var member = new TribePlayer
                    {
                        TribeId = tribe.Id,
                        PlayerId = invitedPlayerId,
                        TribeRole = Enums.TribeRole.Member
                    };
                    await _tribeUserRepository.AddNewMember(member);
                    return ServiceResult.Success();
                }
                return ServiceResult.Failure(_localizer["AddTribeMemberHasTribe"]);
            }
            return ServiceResult.Failure(_localizer["AddTribeMemberFailed"]);
        }

        public async Task<bool> HasTribe(Guid invitedPlayerId)
        {
            return await _tribeRepository.GetTribeByUser(invitedPlayerId) != null;
        }

        public async Task<ServiceResult> GetTribeUsersByTribeId(int tribeId)
        {
            var tribeMembers = await _tribeUserRepository.GetTribeUsersById(tribeId);
            if(tribeMembers.Count > 0)
            {
                return ServiceResult<List<TribeMemberVM>>.Success(_mapper.Map<List<TribeMemberVM>>(tribeMembers));
            }
            return ServiceResult.Failure(_localizer["ReturnTribeMembersError"]);
        }
    }
}
