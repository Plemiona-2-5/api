using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class RecruitmentQueueService : IRecruitmentQueueService
    {
        private readonly IRecruitmentQueueRepository _recruitmentQueueRepository;

        public RecruitmentQueueService(IRecruitmentQueueRepository recruitmentQueueRepository)
        {
            _recruitmentQueueRepository = recruitmentQueueRepository;
        }

        public async Task<RecruitmentQueue> GetRecruitmentQueueByUserId(Guid userId)
        {
            return await _recruitmentQueueRepository.GetRecruitmentQueueByUserId(userId);
        }

        public async Task ReduceRecruitmentQueue(RecruitmentQueue recruitmentQueue)
        {
            var constructionTimePerUnit = recruitmentQueue.ArmyUnitType.RecruitmentTime;
            if (recruitmentQueue.StartData.AddSeconds(constructionTimePerUnit) <= DateTime.Now)
            {
                recruitmentQueue.Quantity -= 1;
                recruitmentQueue.StartData = recruitmentQueue.StartData
                    .AddSeconds(constructionTimePerUnit);
                await _recruitmentQueueRepository
                    .UpdateRecruitmentQueues(recruitmentQueue);
            }
        }

        public async Task<bool> EndUnitRecruitment(RecruitmentQueue recruitmentQueue)
        {
            var endUnitRecruitmentTime = recruitmentQueue.StartData
                .AddSeconds(recruitmentQueue.Duration);
            if (endUnitRecruitmentTime <= DateTime.Now)
            {
                await _recruitmentQueueRepository
                    .RemoveRecruitmentQueue(recruitmentQueue);
                return true;
            }
            return false;
        }
    }
}
