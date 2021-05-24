using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Dtos
{
    public class RemoveTribeMemberDto
    {
        public Guid OwnerId { get; set; }
        public Guid MemberId { get; set; }
    }
}
