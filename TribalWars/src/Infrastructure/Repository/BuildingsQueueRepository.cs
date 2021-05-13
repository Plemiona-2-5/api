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

        public List<BuildingQueue> GetQueueBuildings(int vilageId)
        {
            return Context.BuildingQueues
                .Where(buildingQueue => buildingQueue.VillageId == vilageId)
                .ToList();
        }

        public void AddBuildingsToQueue(BuildingQueue buildingQueue)
        {          
            Context.BuildingQueues
                .Add(buildingQueue);
        }

        public void RemoveBuildingsFromQueue(BuildingQueue buildingQueue)
        {
            Context.BuildingQueues
                .Remove(buildingQueue);
        }
    }
}
