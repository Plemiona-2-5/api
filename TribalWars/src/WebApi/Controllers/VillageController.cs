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
    public class VillageController : Controller
    {
        private readonly IVillageService _villageService;
        private readonly IPlayerService _playerService;
        public VillageController(IVillageService villageService, IPlayerService playerService)
        {
            _villageService = villageService;
            _playerService = playerService;
        }

        [Authorize]
        [HttpGet("/coordinates")]
        public async Task<ActionResult<CoordinatesVM>> TribeDetails()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var playerId = await _playerService.GetPlayerId(Guid.Parse(user));

            var result = await _villageService.GetVillageCoordinates(playerId);
            return result.Succeeded
                ? Ok(result)
                : BadRequest(result);
        }

        [Authorize]
        [HttpGet("/village-buildings")]
        public async Task<ActionResult<List<VillageBuildingVM>>> VillageBuildings()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var playerId = await _playerService.GetPlayerId(Guid.Parse(user));

            var result = await _villageService.GetVillageBuildings(playerId);
            return result;
        }
    }
}
