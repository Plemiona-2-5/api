using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public interface IRecruitmentQueueClient
    {
        Task AddToGroup(string message);
        Task RemoveFromGroup(string message);
        Task IdDoesNotExist(string message);
        Task EndUnitRecruitment(string message);
        Task RefreshQueueRequest(string message);
        Task GetRecruitmentQueue(string message);
    }
}
