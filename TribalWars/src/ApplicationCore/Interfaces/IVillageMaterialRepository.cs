using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IVillageMaterialRepository
    {
        IEnumerable<VillageMaterial> GetVillageMaterials(int villageId);
    }
}
