﻿using ApplicationCore.Entities;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IRecruitmentQueueService
    {
        Task ReduceRecruitmentQueue(RecruitmentQueue recruitmentQueue);
        Task<bool> EndUnitRecruitment(RecruitmentQueue recruitmentQueue);
        Task<RecruitmentQueue> GetRecruitmentQueueByUserId(Guid userId);
    }
}
