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
        public int UnitId { get; set; }
        public int BeforQuantity { get; set; }
        public int AfterQuantity { get; set; }
        public string Side { get; set; }
    }
}
