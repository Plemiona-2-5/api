using ApplicationCore.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IVillageService
    {
        Task<ServiceResult> GetVillageCoordinates(Guid playerId);
    }
}
