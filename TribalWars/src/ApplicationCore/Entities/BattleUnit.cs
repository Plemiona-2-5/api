using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class BattleUnit
    {
        public int Id { get; set; }
        public int AttackId { get; set; }
        public int ArmyUnitTypeId { get; set; }
        public int BeforQuantity { get; set; }
        public int AfterQuantity { get; set; }
        public BattleSide Side { get; set; }
        public virtual Attack Attack { get; set; }
        public virtual ArmyUnitType ArmyUnitType { get; set; }
    }
}
