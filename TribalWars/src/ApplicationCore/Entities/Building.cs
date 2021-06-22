using ApplicationCore.Enums;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ConstructionTime { get; set; }
        public int MaxLevel { get; set; }
        public int BaseValue { get; set; }
        public BuildingType BuildingType { get; set; }
        public virtual ICollection<ArmyUnitType> ArmyUnitTypes { get; set; }
        public virtual ICollection<BuildingQueue> BuildingQueues { get; set; }
        public virtual ICollection<BuildingRequiredBuilding> BuildingRequiredBuildings { get; set; }
        public virtual ICollection<VillageBuilding> VillageBuildings { get; set; }
        public virtual ICollection<BuildingRequiredMaterial> BuildingRequiredMaterials { get; set; }
        public virtual RequiredBuilding RequiredBuilding { get; set; }
    }
}
