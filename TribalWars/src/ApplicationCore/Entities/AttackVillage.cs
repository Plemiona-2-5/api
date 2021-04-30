using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class AttackVillage
    {
        public int Id { get; set; }
        public int AttackId { get; set; }
        public int VillageId { get; set; }
        public BattleSide BattleSide { get; set; }
        public virtual Attack Attack { get; set; }
        public virtual Village Village { get; set; }
    }
}
