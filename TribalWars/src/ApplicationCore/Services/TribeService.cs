using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using ApplicationCore.Results.Generic;
using ApplicationCore.ViewModels;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;
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

        public async Task<ServiceResult> TribeDetails(Guid playerId)
        {
            var tribe = await _tribeRepository.GetTribeByUser(playerId);
            if (tribe != null)
            {
                var tribeUsers = await _tribeUserRepository.GetTribeUsersById(tribe.Id);
                var owner = tribeUsers
                    .Find(player => player.TribeRole == Enums.TribeRole.Owner);
                var details = new TribeDetailsVM
                {
                    TribeName = tribe.Name,
                    Description = tribe.Description,
                    OwnerName = owner.Player.Nickname,
                    NumberOfMembers = tribeUsers.Count
                };

                return ServiceResult<TribeDetailsVM>.Success(details);
            }
            return ServiceResult.Failure(_localizer["TribeDetailsError"]);
        }

        public async Task<ServiceResult> EditTribeDescription(Guid playerId, TribeDescriptionDto dto, int tribeId)
        {
            var tribe = await _tribeRepository.GetTribeByTribeId(tribeId);
            if (tribe.TribePlayers.Where(x => x.Player.Id == playerId) != null)
            {
                tribe.Description = dto.Description;
                await _tribeRepository.UpdateTribe(tribe);
                return ServiceResult.Success();
            }
            return ServiceResult.Failure(_localizer["EditTribeDescriptionError"]);
        }

        public async Task<ServiceResult> DisbandTribe(DisbandTribeDto dto)
        {
            if (await _tribeUserRepository.IsOwner(dto.PlayerId, dto.VillageId))
            {
                var tribe = await _tribeRepository.GetTribeByUser(dto.PlayerId);
                await _tribeRepository.DisbandTribe(tribe);
                return ServiceResult.Success();
            }
            return ServiceResult.Failure(_localizer["DisbandTribeError"]);
        }
    }
}
