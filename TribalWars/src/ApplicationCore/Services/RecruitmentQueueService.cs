using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class RecruitmentQueueService
    {
        private readonly IRecruitmentQueueRepository _recruitmentQueueRepository;
        private readonly IArmyUnitTypeRepository _armyUnitTypeRepository;
        public RecruitmentQueueService(IRecruitmentQueueRepository recruitmentQueueRepository,
            IArmyUnitTypeRepository armyUnitTypeRepository)
        {
            _recruitmentQueueRepository = recruitmentQueueRepository;
            _armyUnitTypeRepository = armyUnitTypeRepository;
        }

        public async Task<RecruitmentQueue> CreateRecruitmentQueue(int villageId, int armyUnitTypeId, int quantity)
        {
            var armyUnitType = await _armyUnitTypeRepository.GetArmyUnitTypeById(armyUnitTypeId);
            RecruitmentQueue recruitmentQueue = new RecruitmentQueue()
            {
                VillageId = villageId,
                ArmyUnitTypeId = armyUnitTypeId,
                Quantity = quantity,
                StartData = DateTime.Now,
                Duration = armyUnitType.RecruitmentTime
            };
            return recruitmentQueue;
        }

        public async Task AddMilitaryUnitsToQueue(int villageId, int armyUnitTypeId, int quantity)
        {
            var createRecruitmentQueue = await CreateRecruitmentQueue(villageId, armyUnitTypeId, quantity);
            await _recruitmentQueueRepository
                .AddMilitaryUnitsToQueue(createRecruitmentQueue);
        }
    }
}
