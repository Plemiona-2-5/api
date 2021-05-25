using ApplicationCore.Interfaces;
using ApplicationCore.Resources;
using ApplicationCore.Responses;
using AutoMapper;
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

        [HttpPost("/add-building-to-queue")]
        public async Task<IActionResult> AddBuildingToQueue([FromHeader] int buildingId)
        {
            var village = 5;
            var result = await _buildingsQueueService.AddBuildingsToQueue(village, buildingId);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer[""]))
                : BadRequest(new ErrorsResponse(result.Errors));
        }
    }
}
