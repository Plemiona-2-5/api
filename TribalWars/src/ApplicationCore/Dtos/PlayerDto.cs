using System;

namespace ApplicationCore.DTOs
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Nickname { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}