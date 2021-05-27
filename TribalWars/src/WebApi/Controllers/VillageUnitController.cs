using ApplicationCore.Interfaces.Services;
using ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/village")]
    public class VillageUnitController : Controller
    {
        private readonly IVillageUnitService _villageUnitService;
        private readonly IPlayerService _playerService;

        public VillageUnitController(IVillageUnitService villageUnitService, IPlayerService playerService)
        {
            _villageUnitService = villageUnitService;
            _playerService = playerService;
        }

        [Authorize]
        [HttpGet("/village-unit")]
        public async Task<ActionResult<List<VillageUnitVM>>> VillageUnit()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var playerId = await _playerService.GetPlayerId(Guid.Parse(user));

            return Ok(await _villageUnitService.GetVillageUnits(playerId));
        }
    }
}
