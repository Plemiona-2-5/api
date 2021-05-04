using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class VillageStatistic
    {
        public int Id { get; set; }
        public int MaterialsCapacity { get; set; }
        public int PeopleCapacity { get; set; }
        public int WallDefence { get; set; }
        public int VillageId { get; set; }
        public virtual Village Village { get; set; }
    }
}
