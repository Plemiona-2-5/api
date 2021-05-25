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
            return await Context.VillageMaterials
                .Where(material => material.VillageId == villageId)
                .ToListAsync();
        }

        public async Task UpdateVillageMaterials(VillageMaterial villageMaterial)
        {
            Context.VillageMaterials.Update(villageMaterial);
            await Context.SaveChangesAsync();
        }
    }
}
