using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IVillageRepository
    {
        Task<Village> GetVillageByIdAsync(int villageId);
        bool VillageExistsByCoordinates(int coordinateX, int coordinateY);
        Task<bool> AddVillageAsync(Village village);
        Task<Village> GetVillageByPlayerIdAsync(Guid playerId);
        Task<IEnumerable<Village>> GetAllVillagesExceptPlayerIdAsync(Guid playerId);
    }
}