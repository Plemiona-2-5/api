using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public interface IBuildingsQueueClient
    {
        Task ConstructionCompleted(string message);
        Task RequestQueueRefresh(string message);
    }
}
