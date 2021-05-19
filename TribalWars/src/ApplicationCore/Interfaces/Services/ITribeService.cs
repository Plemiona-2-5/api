using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITribeService
    {
        Task<string> CreateTribe(Tribe tribe, Guid playerId);
        Task<bool> TribeExist(string tribeName);
    }
}
