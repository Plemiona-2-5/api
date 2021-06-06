using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Interfaces.Repository;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationCore.ViewModels;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class RecruitmentQueueService : IRecruitmentQueueService
    {
        private readonly IRecruitmentQueueRepository _recruitmentQueueRepository;
        private readonly IMapper _mapper;

        public RecruitmentQueueService(IRecruitmentQueueRepository recruitmentQueueRepository, IMapper mapper)
        {
            _recruitmentQueueRepository = recruitmentQueueRepository;
            _mapper = mapper;
        }

        public async Task<RecruitmentQueue> GetRecruitmentQueueByUserId(Guid userId)
        {
            return await _recruitmentQueueRepository.GetRecruitmentQueueByUserId(userId);
        }

        public async Task ReduceRecruitmentQueue(RecruitmentQueue recruitmentQueue)
        {
            var constructionTimePerUnit = recruitmentQueue.ArmyUnitType.RecruitmentTime;
            if ((recruitmentQueue.StartData.AddSeconds(constructionTimePerUnit) <= DateTime.Now) && (recruitmentQueue.Quantity > 0))
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

        public async Task<IEnumerable<RecruitmentQueueVM>> GetRecruitmentQueues(Guid userId)
        {
            var recruitmentQueues = await _recruitmentQueueRepository.GetRecruitmentQueuesByUserId(userId);
            return _mapper.Map<List<RecruitmentQueueVM>>(recruitmentQueues);
        }
    }
}
