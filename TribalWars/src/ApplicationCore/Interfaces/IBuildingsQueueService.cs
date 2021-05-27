using ApplicationCore.Entities;
using ApplicationCore.Results;
using ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingsQueueService
    {
        Task<BuildingQueue> CreateBuildingQueue(int villageId, int buildingId);
        Task<List<BuildingQueue>> QueueBuildings(int villageId);
        Task<BuildingQueue> BuildingQueueByUserId(Guid userId);
        Task<ServiceResult>  AddBuildingsToQueue(int villageId, int buildingId);
        Task RemoveBuildingsFromQueue(BuildingQueue buildingQueue);
        Task<bool> ConstructionCompletion(BuildingQueue buildingQueue);
        Task<bool> CanAddToQueue(int villageId);
        Task<List<BuildingQueueVM>> BuildingQueues(Guid playerId);
    }
}
