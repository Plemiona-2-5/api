using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Results;
using ApplicationCore.Results.Generic;
using ApplicationCore.ViewModels;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITribeService
    {
        Task<ServiceResult> CreateTribe(Tribe tribe, Guid playerId);
        Task<bool> TribeExists(string tribeName);
        Task<ServiceResult<TribeDetailsVM>> TribeDetails(Guid playerId);
        Task<ServiceResult> EditTribeDescription(Guid playerId, TribeDescriptionDto tribe, int tribeId);
    }
}
