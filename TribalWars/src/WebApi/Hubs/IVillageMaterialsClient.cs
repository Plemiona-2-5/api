using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public interface IVillageMaterialsClient
    {
        Task AddToGroup(string message);
        Task RemoveFromGroup(string message);
        Task RefreshVillageMaterialst(string message);
    }
}
