using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class ArmyUnitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AttackStrength { get; set; }
        public int DefenceValue { get; set; }
        public int Capacity { get; set; }
        public int Speed { get; set; }
        public int RecruitmentTime { get; set; }
        public int RequiredBuildingId { get; set; }
        public int RequiredBuildingILevel { get; set; }
        public virtual Building RequiredBuilding { get; set; }
        public virtual ICollection<ArmyUnitRequiredMaterial> ArmyUnitRequiredMaterials { get; set; }
        public virtual ICollection<BattleUnit> BattleUnits { get; set; }
        public virtual ICollection<RecruitmentQueue> RecruitmentQueues { get; set; }
        public virtual ICollection<VillageUnit> VillageUnits { get; set; }
    }
}
