using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class RequiredBuildingViewModel
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int RequiredBuildingId { get; set; }
        public int Level { get; set; }
    }
}
