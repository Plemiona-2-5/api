using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingsQueueRepository
    {
        List<BuildingQueue> GetQueueBuildings(int vilageId);
        void AddBuildingsToQueue(BuildingQueue buildingQueue);
        void RemoveBuildingsFromQueue(BuildingQueue buildingQueue);
    }
}