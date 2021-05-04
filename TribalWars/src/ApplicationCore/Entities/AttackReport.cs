using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class AttackReport
    {
        public int Id { get; set; }
        public int AttackId { get; set; }
        public DateTime AttackDate { get; set; }
        public virtual Attack Attack { get; set; }
    }
}
