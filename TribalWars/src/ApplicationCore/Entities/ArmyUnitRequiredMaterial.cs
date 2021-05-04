using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class ArmyUnitRequiredMaterial
    {
        public int Id { get; set; }
        public int ArmyUnitTypeId { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
        public virtual ArmyUnitType ArmyUnitType { get; set; }
        public virtual Material Material { get; set; }
    }
}
