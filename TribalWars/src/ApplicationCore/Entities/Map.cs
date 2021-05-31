using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Map
    {
        public int Id { get; set; }
        public int SideSize { get; set; }
        public int Capacity { get; set; }

        public IEnumerable<Village> Villages { get; set; }
    }
}