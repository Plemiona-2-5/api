using System;

namespace ApplicationCore.Dtos
{
    public class VillageDto
    {
        public int Id { get; set; }
        public Guid PlayerId { get; set; }
        public string Nickname { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }
}