using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Dtos;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageService
    {
        Task<ServiceResult> CreateNewVillageAsync(Guid playerId);
        Task<VillageDto> GetVillageDtoByPlayerId(Guid playerId);
        Task<(IEnumerable<VillageDto>, MapDto)> GetVillagesDtoExceptPlayerAsync(Guid playerId);
    }
}