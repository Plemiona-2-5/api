using ApplicationCore.Dtos;
using ApplicationCore.Interfaces;
using ApplicationCore.Resources;
using ApplicationCore.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    public class BuildingController : Controller
    {
        private readonly IBuildingsQueueService _buildingsQueueService;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public BuildingController(IBuildingsQueueService buildingsQueueService, 
            IStringLocalizer<MessageResource> localizer)
        {
            _buildingsQueueService = buildingsQueueService;
            _localizer = localizer;
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
    }
}
