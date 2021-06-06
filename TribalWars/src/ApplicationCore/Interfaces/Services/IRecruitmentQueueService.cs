using ApplicationCore.Entities;
using ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IRecruitmentQueueService
    {
        Task ReduceRecruitmentQueue(RecruitmentQueue recruitmentQueue);
        Task<bool> EndUnitRecruitment(RecruitmentQueue recruitmentQueue);
        Task<RecruitmentQueue> GetRecruitmentQueueByUserId(Guid userId);
        Task<IEnumerable<RecruitmentQueueVM>> GetRecruitmentQueues(Guid userId);
    }
}
