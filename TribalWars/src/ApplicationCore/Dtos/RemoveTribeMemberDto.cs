using System;

namespace ApplicationCore.Dtos
{
    public class RemoveTribeMemberDto
    {
        public Guid OwnerId { get; set; }
        public Guid MemberId { get; set; }
    }
}
