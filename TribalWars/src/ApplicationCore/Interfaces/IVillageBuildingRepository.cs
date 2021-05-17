using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IVillageBuildingRepository
    {
        Task<IEnumerable<VillageBuilding>> GetVillageBuildings(int villageId);
    }
}
