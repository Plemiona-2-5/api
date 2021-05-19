using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using ApplicationCore.Helper;

namespace ApplicationCore.Services
{
    public class TribeService : ITribeService
    {
        public readonly ITribeRepository _repository;
        private readonly IStringLocalizer<StringResources> _localizer;

        public TribeService(ITribeRepository repository, IStringLocalizer<StringResources> localizer)
        {
            _repository = repository;
            _localizer = localizer;
        }

        public async Task<string> CreateTribe(Tribe tribe, Guid playerId)
        {
            if (tribe != null && ! await TribeExist(tribe.Name))
            {
                TribePlayer tribePlayer = new TribePlayer();
                tribePlayer.PlayerId = playerId;
                tribePlayer.TribeRole = Enums.TribeRole.Owner;
                tribePlayer.TribeId = await _repository.CreateTribe(tribe);

                if (tribePlayer.TribeId != 0)
                {
                    await _repository.AddPlayerToTribe(tribePlayer);

                    return _localizer["AddTribeSuccess"];
                }
                return "Error while creating tribe!";
            }
            return _localizer["TribeNameTaken"];
        }

        public async Task<bool> TribeExist(string tribeName)
        {
            return await _repository.SelectedTribe(tribeName) != null;
        }
    }
}
