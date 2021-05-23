using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IRecruitmentQueueService
    {
        Task<RecruitmentQueue> CreateRecruitmentQueue(int villageId, int armyUnitTypeId, int quantity);
        Task AddMilitaryUnitsToQueue(int villageId, int armyUnitTypeId, int quantity);
    }
}
