using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class BuildingQueue
    {
        public int Id { get; set; }
        public int VillageId { get; set; }
        public int BuildingId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public virtual Village Village { get; set; }
        public virtual Building Building { get; set; }


    }
}
