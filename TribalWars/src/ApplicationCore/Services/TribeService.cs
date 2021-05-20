using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using ApplicationCore.ViewModels;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class TribeService : ITribeService
    {
        private readonly ITribeRepository _tribeRepository;
        private readonly ITribeUserRepository _tribeUserRepository;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public TribeService(ITribeRepository tribeRepository, IStringLocalizer<MessageResource> localizer, ITribeUserRepository tribeUserRepository)
        {
            _tribeRepository = tribeRepository;
            _tribeUserRepository = tribeUserRepository;
            _localizer = localizer;
        }

        public async Task<ServiceResult> CreateTribe(Tribe tribe, Guid playerId)
        {
            if (tribe != null && ! await TribeExists(tribe.Name))
            {
                var tribePlayer = new TribePlayer
                {
                    PlayerId = playerId,
                    TribeRole = Enums.TribeRole.Owner,
                    TribeId = await _tribeRepository.CreateTribe(tribe)
                };

                if (tribePlayer.TribeId != 0)
                {
                    await _tribeRepository.AddPlayerToTribe(tribePlayer);

                    return ServiceResult.Success();
                }
                return ServiceResult.Failure(_localizer["TribeAddError"]);
            }
            return ServiceResult.Failure(_localizer["TribeNameTaken"]);
        }

        public async Task<bool> TribeExists(string tribeName)
        {
            return await _tribeRepository.GetTribeByName(tribeName) != null;
        }

        public async Task<(ServiceResult, TribeDetailsVM)> TribeDetails(Guid userId)
        {
            var tribe = await _tribeRepository.GetTribeByUser(userId);
            if (tribe != null)
            {
                var tribeUsers = await _tribeUserRepository.GetTribeUsersById(tribe.Id);
                var owner = tribeUsers.Find(x => x.TribeRole == Enums.TribeRole.Owner);
                var details = new TribeDetailsVM
                {
                    TribeName = tribe.Name,
                    Description = tribe.Description,
                    OwnerName = owner.Player.Nickname,
                    NumberOfMembers = tribeUsers.Count
                };

                return (ServiceResult.Success(), details);
            }
            return (ServiceResult.Failure(_localizer["TribeDetailsError"]), null);
        }
    }
}
