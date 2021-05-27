using ApplicationCore.Dtos;
using ApplicationCore.Interfaces;
using ApplicationCore.Resources;
using ApplicationCore.Responses;
using Microsoft.AspNetCore.Authorization;
using ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Services;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/building")]
    public class BuildingController : Controller
    {
        private readonly IBuildingsQueueService _buildingsQueueService;
        private readonly IStringLocalizer<MessageResource> _localizer;
        private readonly IPlayerService _playerService;

        public BuildingController(IBuildingsQueueService buildingsQueueService, 
            IStringLocalizer<MessageResource> localizer,
            IPlayerService playerService)
        {
            _buildingsQueueService = buildingsQueueService;
            _localizer = localizer;
            _playerService = playerService;
        }

        [Authorize]
        [HttpPost("/add-building-to-queue")]
        public async Task<IActionResult> AddBuildingToQueue([FromBody] AddBuilidingToQueueDto dto)
        {
            var result = await _buildingsQueueService.AddBuildingsToQueue(dto.VillageId, dto.BuildingId);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["AddBuildingToQueueSuccess"]))
                : BadRequest(new ErrorsResponse(result.Errors));
        }

        [Authorize]
        [HttpGet("/building-queue")]
        public async Task<ActionResult<List<BuildingQueueVM>>> BuildingQueue()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var playerId = await _playerService.GetPlayerId(Guid.Parse(user));
            return Ok(await _buildingsQueueService.BuildingQueues(playerId));
        }       
    }
}
