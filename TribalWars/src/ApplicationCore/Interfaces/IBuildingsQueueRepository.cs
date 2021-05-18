using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingsQueueRepository
    {
        Task<List<BuildingQueue>> GetQueueBuildings(int villageId);
        Task<BuildingQueue> GetBuildingQueueByUserId(Guid userId);
        Task AddBuildingsToQueue(BuildingQueue buildingQueue);
        void RemoveBuildingsFromQueue(BuildingQueue buildingQueue);
    }
}