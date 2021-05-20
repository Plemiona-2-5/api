using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class TribeService : ITribeService
    {
        private readonly ITribeRepository _repository;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public TribeService(ITribeRepository repository, IStringLocalizer<MessageResource> localizer)
        {
            _repository = repository;
            _localizer = localizer;
        }

        public async Task<string> CreateTribe(Tribe tribe, Guid playerId)
        {
            if (tribe != null && ! await TribeExists(tribe.Name))
            {
                var tribePlayer = new TribePlayer
                {
                    PlayerId = playerId,
                    TribeRole = Enums.TribeRole.Owner,
                    TribeId = await _repository.CreateTribe(tribe)
                };

                if (tribePlayer.TribeId != 0)
                {
                    await _repository.AddPlayerToTribe(tribePlayer);

                    return _localizer["AddTribeSuccess"];
                }
                return _localizer["TribeAddError"];
            }
            return _localizer["TribeNameTaken"];
        }

        public async Task<bool> TribeExists(string tribeName)
        {
            return await _repository.GetTribeByName(tribeName) != null;
        }
    }
}
