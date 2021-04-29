using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class TribePlayer
    {
        public int Id { get; set; }
        public Guid PlayerId { get; set; }
        public int TribeId { get; set; }
        public TribeRole TribeRole { get;set; }
        public virtual Tribe Tribe { get; set; }
        public virtual Player Player { get; set; }
    }
}
