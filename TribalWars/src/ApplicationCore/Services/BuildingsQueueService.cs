using ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{ 
    public class BuildingsQueueService
    {
        private readonly IBuildingsQueueRepository _buildingsQueueRepository;
        public BuildingsQueueService(IBuildingsQueueRepository buildingsQueueRepository)
        {
            _buildingsQueueRepository = buildingsQueueRepository;
        }

    }
}
