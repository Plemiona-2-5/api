﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class RequiredBuilding
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int Level { get; set; }
        public virtual ICollection<BuildingRequiredBuilding> Buildings { get; set; }
    }
}
