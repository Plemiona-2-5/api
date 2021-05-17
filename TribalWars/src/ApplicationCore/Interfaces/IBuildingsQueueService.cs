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
        BuildingQueue CreateBuildingQueue(int idVillage, int idBuilding);
        List<BuildingQueue> QueueBuildings(int vilageId);
        BuildingQueue BuildingQueueByUserId(Guid userId);
        void AddBuildingsToQueue(int idVillage, int idBuilding);
        void RemoveBuildingsFromQueue(BuildingQueue buildingQueue);
        public bool ConstructionCompletion(BuildingQueue buildingQueue);
    }
}
