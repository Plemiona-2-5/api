using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class RecruitmentQueue
    {
        public int Id { get; set; }
        public int VillageId { get; set; }
        public int ArmyUnitTypeId { get; set; }
        public int Quantity { get; set; }
        public DateTime StartData { get; set; }
        public int Duration { get; set; }
        public virtual Village Village { get; set; }
        public virtual ArmyUnitType ArmyUnitType { get; set; }
    }
}
