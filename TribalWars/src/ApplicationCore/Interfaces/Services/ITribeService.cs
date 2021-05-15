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
        string CreateTribe(Tribe tribe, Guid playerId);
        bool TribeExist(string tribeName);
    }
}
