using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Village
    {
        public int Id { get; set; }
        public Guid PlayerId { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public virtual Player Player { get; set; }
        public VillageStatistic VillageStatistic { get; set; }
        public virtual ICollection<BuildingQueue> BuildingQueues { get; set; }
        public virtual ICollection<RecruitmentQueue> RecruitmentQueues{ get; set; }
        public virtual ICollection<VillageBuilding> VillageBuildings { get; set; }
        public virtual ICollection<VillageMaterial> VillageMaterials { get; set; }
        public virtual ICollection<VillageUnit> VillageUnits { get; set; }
        public virtual ICollection<AttackVillage> AttackVillages { get; set; }
    }
}
