using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ViewModels
{
    public class TribeDetailsVM
    {
        public string TribeName { get; set; }
        public int NumberOfMembers { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
    }
}
