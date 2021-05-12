using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    public class RequiredBuildingsController : Controller
    {
        private readonly IBuildingRequiredService _buildingRequiredService;

        public RequiredBuildingsController(IBuildingRequiredService buildingRequiredService)
        {
            _buildingRequiredService = buildingRequiredService;
        }

        [HttpGet("api/v1/getRequiredBuildings")]
        public IEnumerable<BuildingRequiredBuilding> GetRequiredBuildings(int buildingId)
        {
            return _buildingRequiredService.GetRequiredBuildings(buildingId);
        }
    }
}
