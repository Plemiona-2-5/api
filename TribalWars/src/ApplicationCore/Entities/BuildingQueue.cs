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
    }
}
