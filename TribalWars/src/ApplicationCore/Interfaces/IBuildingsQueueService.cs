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
        Task<BuildingQueue> CreateBuildingQueue(int idVillage, int idBuilding);
        Task<List<BuildingQueue>> QueueBuildings(int vilageId);
        Task<BuildingQueue> BuildingQueueByUserId(Guid userId);
        Task AddBuildingsToQueue(int idVillage, int idBuilding);
        void RemoveBuildingsFromQueue(BuildingQueue buildingQueue);
        bool ConstructionCompletion(BuildingQueue buildingQueue);
    }
}
