using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVillageBuildingRepository
    {
        IEnumerable<VillageBuilding> GetVillageBuildings(int villageId);
    }
}
