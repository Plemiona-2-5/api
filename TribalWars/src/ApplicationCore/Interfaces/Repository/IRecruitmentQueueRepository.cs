using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IRecruitmentQueueRepository
    {
        Task<List<RecruitmentQueue>> GetRecruitmentQueue(int villageId);
        Task UpdateRecruitmentQueues(RecruitmentQueue recruitmentQueue);
        Task AddMilitaryUnitsToQueue(RecruitmentQueue recruitmentQueue);
        Task RemoveRecruitmentQueue(RecruitmentQueue recruitmentQueue);
        Task<RecruitmentQueue> GetRecruitmentQueueByUserId(Guid userId);
    }
}
