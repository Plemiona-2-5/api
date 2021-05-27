using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public interface IBuildingsQueueClient
    {
        Task ConstructionCompleted(string message);
        Task RequestQueueRefresh(string message);
        Task IdDoesNotExist(string message);
        Task AddToGroup(string message);
        Task RemoveFromGroup(string message);
    }
}
