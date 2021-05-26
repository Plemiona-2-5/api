using ApplicationCore.Interfaces.Services;
using ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    public class VillageController : Controller
    {
        private readonly IVillageService _villageService;

        public VillageController(IVillageService villageService)
        {
            _villageService = villageService;
        }

        [HttpGet("/village-coordinates")]
        public async Task<ActionResult<CoordinatesVM>> TribeDetails()
        {
            var playerId = new Guid();  //TODO: Read playerId from session

            var result = await _villageService.GetVillageCoordinates(playerId);
            return result.Succeeded
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
