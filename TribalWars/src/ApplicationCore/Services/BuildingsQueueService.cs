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

        public BuildingQueue CreateBuildingQueue(int viillageId, int buildingId)
        {
            var building = _buildingsRepository.GetBuildingById(buildingId);
            BuildingQueue buildingQueue = new BuildingQueue
            {
                VillageId = viillageId,
                BuildingId = buildingId,
                StartDate = DateTime.Now,
                Duration = building.ConstructionTime
            };            
            return buildingQueue;
        }

        public List<BuildingQueue> QueueBuildings(int vilageId)
        {
            return _buildingsQueueRepository
                .GetQueueBuildings(vilageId);
        }

        public void AddBuildingsToQueue(int viillageId,int buildingId)
        {
            var buildingsInQueue = _buildingsQueueRepository.GetQueueBuildings(viillageId);
            var buildingQueue = CreateBuildingQueue(viillageId, buildingId);
            if (buildingsInQueue.Count < 1 )
            {                
                _buildingsQueueRepository
                    .AddBuildingsToQueue(buildingQueue);
            }
        }

        public void ConstructionCompletion()
        {

        }

        public void RemoveBuildingsFromQueue(BuildingQueue buildingQueue)
        {
            _buildingsQueueRepository
                .RemoveBuildingsFromQueue(buildingQueue);
        }
    }
}
