using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class BuildingRequiredBuilding
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int RequiredBuildingId { get; set; }
        public int Level { get; set; }
        public virtual Building Building { get; set; }

    }
}
