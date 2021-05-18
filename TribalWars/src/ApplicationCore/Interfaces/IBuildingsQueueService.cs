using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingsQueueService
    {
        Task<BuildingQueue> CreateBuildingQueue(int villageId, int buildingId);
        Task<List<BuildingQueue>> QueueBuildings(int villageId);
        Task<BuildingQueue> BuildingQueueByUserId(Guid userId);
        Task AddBuildingsToQueue(int villageId, int buildingId);
        void RemoveBuildingsFromQueue(BuildingQueue buildingQueue);
        bool ConstructionCompletion(BuildingQueue buildingQueue);
    }
}
