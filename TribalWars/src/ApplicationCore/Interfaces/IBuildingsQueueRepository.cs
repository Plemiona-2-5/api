using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IBuildingsQueueRepository
    {
        void AddingBuildingsToQueue(BuildingQueue buildingQueue);
        void DeletingBuildingsFromQueue(BuildingQueue buildingQueue);
        List<BuildingQueue> QueueBuildings(int vilageId);
    }
}