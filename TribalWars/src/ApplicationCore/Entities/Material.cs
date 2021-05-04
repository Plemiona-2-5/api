using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ArmyUnitRequiredMaterial> ArmyUnitRequiredMaterials { get; set; }
        public virtual ICollection<BuildingRequiredMaterial> BuildingRequiredMaterials { get; set; }
        public virtual ICollection<StolenMaterial> StolenMaterials { get; set; }
        public virtual ICollection<VillageMaterial> VillageMaterials { get; set; }
    }
}
