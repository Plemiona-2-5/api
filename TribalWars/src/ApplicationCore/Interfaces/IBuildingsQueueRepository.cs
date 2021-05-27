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
        Task<BuildingQueue> GetBuildingQueueByVillageId(int villageId);
        Task AddBuildingsToQueue(BuildingQueue buildingQueue);
        Task RemoveBuildingsFromQueue(BuildingQueue buildingQueue);
    }
}