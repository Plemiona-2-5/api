using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VillageMaterialRepository : BaseRepository, IVillageMaterialRepository
    {
        public VillageMaterialRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<VillageMaterial> GetVillageMaterials(int villageId)
        {
            var playerMaterials = Context.VillageMaterials
                .Where(material => material.VillageId == villageId)
                .ToList();
            return playerMaterials;
        }
    }

}
