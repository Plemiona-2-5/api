using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{ 
    public class BuildingsQueueService : IBuildingsQueueService
    {
        private readonly IBuildingsQueueRepository _buildingsQueueRepository;
        private readonly IBuildingsRepository _buildingsRepository;

        public BuildingsQueueService(IBuildingsQueueRepository buildingsQueueRepository,
                                     IBuildingsRepository buildingsRepository)
        {
            _buildingsQueueRepository = buildingsQueueRepository;
            _buildingsRepository = buildingsRepository;
        }

        public BuildingQueue CreateBuildingQueue(int viilageId, int buildingId)
        {
            var building = _buildingsRepository.GetBuildingById(buildingId);
            BuildingQueue buildingQueue = new BuildingQueue
            {
                VillageId = viilageId,
                BuildingId = buildingId,
                StartDate = DateTime.Now,
                Duration = building.ConstructionTime
            };            
            return buildingQueue;
        }

        public List<BuildingQueue> QueueBuildings(int villageId)
        {
            return _buildingsQueueRepository
                .GetQueueBuildings(villageId);
        }
        public BuildingQueue BuildingQueueByUserId(Guid userId)
        {
            return _buildingsQueueRepository.GetBuildingQueueByUserId(userId);
        }

        public void AddBuildingsToQueue(int villageId,int buildingId)
        {
            var buildingsInQueue = _buildingsQueueRepository.GetQueueBuildings(villageId);
            var buildingQueue = CreateBuildingQueue(villageId, buildingId);
            if (buildingsInQueue.Count < 1 )
            {                
                _buildingsQueueRepository
                    .AddBuildingsToQueue(buildingQueue);
            }
        }

        public bool ConstructionCompletion(BuildingQueue buildingQueue)
        {
            DateTime timeOfCompletion = buildingQueue.StartDate.AddMinutes(buildingQueue.Duration);
            if(timeOfCompletion == DateTime.Now)
            {
                _buildingsQueueRepository.RemoveBuildingsFromQueue(buildingQueue);
                return true;
            }
            return false;
        }

        public void RemoveBuildingsFromQueue(BuildingQueue buildingQueue)
        {
            _buildingsQueueRepository
                .RemoveBuildingsFromQueue(buildingQueue);
        }
    }
}
