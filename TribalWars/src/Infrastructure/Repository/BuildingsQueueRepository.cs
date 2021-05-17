using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BuildingsQueueRepository : BaseRepository, IBuildingsQueueRepository
    {
        public BuildingsQueueRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BuildingQueue> GetQueueBuildings(int villageId)
        {
            return Context.BuildingQueues
                .Where(buildingQueue => buildingQueue.VillageId == villageId)
                .ToList();
        }

        public BuildingQueue GetBuildingQueueByUserId(Guid userId)
        {
            return Context.BuildingQueues
                .FirstOrDefault(buildingQueue => buildingQueue.Village.Player.UserId == userId);
        }

        public void AddBuildingsToQueue(BuildingQueue buildingQueue)
        {          
            Context.BuildingQueues
                .Add(buildingQueue);
            Context.SaveChanges();
        }

        public void RemoveBuildingsFromQueue(BuildingQueue buildingQueue)
        {
            Context.BuildingQueues
                .Remove(buildingQueue);
            Context.SaveChanges();
        }
    }
}
