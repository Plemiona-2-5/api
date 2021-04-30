using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Attack
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public DateTime EndedAt { get; set; }
        public virtual AttackReport AttackReport { get; set; }
        public virtual ICollection<BattleUnit> BattleUnits { get; set; }
        public virtual ICollection<AttackVillage> AttackVillages { get; set; }
        public virtual ICollection<StolenMaterial> StolenMaterials { get; set; }
    }
}
