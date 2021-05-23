using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RecruitmentQueueRepository : BaseRepository, IRecruitmentQueueRepository
    {
        public RecruitmentQueueRepository(ApplicationDbContext context) : base(context)
        {               
        }

        public async Task<List<RecruitmentQueue>> GetRecruitmentQueue(int villageId)
        {
            return await Context.RecruitmentQueues
                .Where(recruitmentQueue => recruitmentQueue.VillageId == villageId)
                .ToListAsync();
        }

        public async Task UpdateRecruitmentQueues(RecruitmentQueue recruitmentQueue)
        {
            Context.Update(recruitmentQueue);
            await Context.SaveChangesAsync();
        }

        public async Task AddMilitaryUnitsToQueue(RecruitmentQueue recruitmentQueue)
        {
            await Context.RecruitmentQueues
                .AddAsync(recruitmentQueue);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveMilitaryUnitsToQueue(RecruitmentQueue recruitmentQueue)
        {
            Context.RecruitmentQueues
                .Remove(recruitmentQueue);
            await Context.SaveChangesAsync();
        }
    }
}
