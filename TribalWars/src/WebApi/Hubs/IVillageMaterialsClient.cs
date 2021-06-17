using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public interface IVillageMaterialsClient
    {
        Task AddToGroup(string message);
        Task RemoveFromGroup(string message);
        Task RefreshVillageMaterials(string message);
        Task UpdateVillageMaterials(string message);
        Task IdDoesNotExist(string message);
    }
}
