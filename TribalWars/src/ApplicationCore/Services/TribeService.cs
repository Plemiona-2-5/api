using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class TribeService : ITribeService
    {
        public readonly ITribeRepository _repository;

        public TribeService(ITribeRepository repository)
        {
            _repository = repository;
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

                    return "A tribe was created!";
                }
                return "Error while creating tribe!";
            }
            return "Tribe already exist!";
        }

        public async Task<bool> TribeExist(string tribeName)
        {
            return await _repository.SelectedTribe(tribeName) != null;
        }
    }
}
