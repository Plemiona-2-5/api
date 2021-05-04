using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class BuildingRequiredMaterial
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int BuildingId { get; set; }
        public int Quantity { get; set; }
        public virtual Building Building { get; set; }
        public virtual Material Material { get; set; }
    }
}
