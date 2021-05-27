using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Repository
{
    public class VillageMaterialRepository : BaseRepository, IVillageMaterialRepository
    {
        public VillageMaterialRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VillageMaterial>> GetVillageMaterials(int villageId)
        {
            var playerMaterials = Context.VillageMaterials
                .Where(material => material.VillageId == villageId)
                .ToListAsync();
            return await playerMaterials;
        }

        public async Task UpdateVillageMaterial(VillageMaterial material)
        {
            Context.Update(material);
            await Context.SaveChangesAsync();
        }
    }
}
