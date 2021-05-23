using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BuildingsQueueRepository : BaseRepository, IBuildingsQueueRepository
    {
        public BuildingsQueueRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<BuildingQueue>> GetQueueBuildings(int villageId)
        {
            return await Context.BuildingQueues
                .Where(buildingQueue => buildingQueue.VillageId == villageId)
                .ToListAsync();
        }

        public async Task<BuildingQueue> GetBuildingQueueByUserId(Guid userId)
        {
            return await Context.BuildingQueues
                .FirstOrDefaultAsync(buildingQueue => buildingQueue.Village.Player.UserId == userId);
        }

        public async Task AddBuildingsToQueue(BuildingQueue buildingQueue)
        {          
            await Context.BuildingQueues
                .AddAsync(buildingQueue);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveBuildingsFromQueue(BuildingQueue buildingQueue)
        {
            Context.BuildingQueues
                .Remove(buildingQueue);
            await Context.SaveChangesAsync();
        }
    }
}
