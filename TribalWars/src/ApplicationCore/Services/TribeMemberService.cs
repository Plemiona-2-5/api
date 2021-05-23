using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class TribeMemberService : ITribeMemberService
    {
        private readonly ITribeUserRepository _tribeUserRepository;
        private readonly ITribeRepository _tribeRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public TribeMemberService(ITribeUserRepository tribeUserRepository,
            IStringLocalizer<MessageResource> localizer,
            ITribeRepository tribeRepository,
            IPlayerRepository playerRepository)
        {
            _tribeUserRepository = tribeUserRepository;
            _localizer = localizer;
            _tribeRepository = tribeRepository;
            _playerRepository = playerRepository;
        }

        public async Task<ServiceResult> InviteNewMember(Guid playerId, Guid invitedPlayerId)
        {
            var tribe = await _tribeRepository.GetTribeByUser(playerId);
            if (tribe != null && await _playerRepository.GetPlayerById(invitedPlayerId))
            {
                if (await HasTribe(invitedPlayerId))
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
            return await _tribeRepository.GetTribeByUser(invitedPlayerId) == null;
        }
    }
}
