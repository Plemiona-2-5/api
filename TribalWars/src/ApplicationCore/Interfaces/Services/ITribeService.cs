﻿using ApplicationCore.Entities;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITribeService
    {
        Task<string> CreateTribe(Tribe tribe, Guid playerId);
        Task<bool> TribeExists(string tribeName);
    }
}
