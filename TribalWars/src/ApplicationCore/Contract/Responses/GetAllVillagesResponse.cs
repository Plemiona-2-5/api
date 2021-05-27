using System.Collections.Generic;
using ApplicationCore.Dtos;

namespace ApplicationCore.Contract.Responses
{
    public class GetAllVillagesResponse
    {
        public VillageDto UserVillage { get; set; }
        public MapDto MapInformation { get; set; }
        public IEnumerable<VillageDto> OtherVillages { get; set; }
    }
}