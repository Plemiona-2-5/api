using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class BuildingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ConstructionTime { get; set; }
        public int MaxLevel { get; set; }
        public string Type { get; set; }
        public int BaseValue { get; set; }
        public virtual ICollection<RequiredBuildingViewModel> BuildingRequiredBuildings { get; set; }
    }
}
