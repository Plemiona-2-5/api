using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IBuildingRepository
    {
        Task<Building> GetBuilding(int buildingId);
    }
}
