using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Nickname { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Village Village { get; set; }
        public ICollection<TribePlayer> TribePlayer { get; set; }

    }
}
