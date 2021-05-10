using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
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

        public List<BuildingQueue> QueueBuildings(int vilageId)
        {
            return Context.BuildingQueues.Where(buildingQueue => buildingQueue.VillageId == vilageId).ToList();
        }

        public void AddingBuildingsToQueue(BuildingQueue buildingQueue)
        {
            if (QueueBuildings(buildingQueue.VillageId).Count < 1)
            {
                Context.BuildingQueues.Add(buildingQueue);
            }
        }

        public void DeletingBuildingsFromQueue(BuildingQueue buildingQueue)
        {
            Context.BuildingQueues.Remove(buildingQueue);
        }

    }
}
