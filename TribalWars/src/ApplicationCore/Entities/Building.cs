using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ConstructionTime { get; set; }
        public int MaxLevel { get; set; }
        public string Type { get; set; }
        public int BaseValue { get; set; }
        public virtual ICollection<ArmyUnitType> ArmyUnitTypes { get; set; }
        public virtual ICollection<BuildingQueue> BuildingQueues { get; set; }
        public virtual ICollection<BuildingRequiredBuilding> BuildingRequiredBuildings { get; set; }
        public virtual ICollection<VillageBuilding> VillageBuildings { get; set; }
        public virtual ICollection<BuildingRequiredMaterial> BuildingRequiredMaterials { get; set; }
        public virtual RequiredBuilding RequiredBuilding { get; set; }
    }
}
