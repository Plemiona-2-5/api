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

        public void CreateTribe(Tribe tribe, Guid playerId)
        {
            if (tribe != null)
            {
                TribePlayer tribePlayer = new TribePlayer();
                tribePlayer.PlayerId = playerId;
                tribePlayer.TribeRole = Enums.TribeRole.Owner;
                tribePlayer.TribeId = _repository.CreateTribe(tribe);

                if (tribePlayer.TribeId != 0)
                {
                     _repository.AddPlayerToTribe(tribePlayer);
                }
            }
        }
    }
}
