using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IRecruitmentQueueRepository
    {
        Task<List<RecruitmentQueue>> GetRecruitmentQueue(int villageId);
        Task UpdateRecruitmentQueues(RecruitmentQueue recruitmentQueue);
        Task AddMilitaryUnitsToQueue(RecruitmentQueue recruitmentQueue);
        Task RemoveMilitaryUnitsToQueue(RecruitmentQueue recruitmentQueue);
    }
}
