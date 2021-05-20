using ApplicationCore.Entities;
using ApplicationCore.Results;
using ApplicationCore.ViewModels;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITribeService
    {
        Task<ServiceResult> CreateTribe(Tribe tribe, Guid playerId);
        Task<bool> TribeExists(string tribeName);
        Task<(ServiceResult, TribeDetailsVM)> TribeDetails(Guid userId);
    }
}
