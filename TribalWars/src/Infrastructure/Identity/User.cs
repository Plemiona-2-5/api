using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class User : IdentityUser<Guid>
    {
        public virtual Player Player { get; set; }
    }
}
