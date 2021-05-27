using ApplicationCore.Interfaces.Services;
using ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/village")]
    public class VillageUnitController : Controller
    {
        private readonly IVillageUnitService _villageUnitService;

        public VillageUnitController(IVillageUnitService villageUnitService)
        {
            _villageUnitService = villageUnitService;
        }

        [HttpGet("/village-unit")]
        public async Task<ActionResult<List<VillageUnitVM>>> VillageUnit()
        {
            var playerId = new Guid();  //TODO: Read playerId from session

            return Ok(await _villageUnitService.GetVillageUnits(playerId));
        }
    }
}
