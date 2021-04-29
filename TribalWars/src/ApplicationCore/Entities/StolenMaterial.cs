using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class StolenMaterial
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int AttackId { get; set; }

        public int Quantity { get; set; }

    }
}
