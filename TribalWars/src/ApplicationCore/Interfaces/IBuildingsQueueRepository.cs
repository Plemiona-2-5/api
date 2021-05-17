using ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingsQueueRepository
    {
        List<BuildingQueue> GetQueueBuildings(int vilageId);
        BuildingQueue GetBuildingQueueByUserId(Guid userId);
        void AddBuildingsToQueue(BuildingQueue buildingQueue);
        void RemoveBuildingsFromQueue(BuildingQueue buildingQueue);
    }
}