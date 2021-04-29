using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class VillageMaterial
    {
        public int Id { get; set; }
        public int VillageId { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
        public float PerMinute { get; set; }
        public virtual Village Village { get; set; }
        public virtual Material Material { get; set; }


    }
}
