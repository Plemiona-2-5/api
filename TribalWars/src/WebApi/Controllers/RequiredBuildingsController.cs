using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    public class RequiredBuildingsController : Controller
    {
        private readonly IBuildingRequiredService _buildingRequiredService;
        private readonly IMapper _mapper;

        public RequiredBuildingsController(IBuildingRequiredService buildingRequiredService, IMapper mapper)
        {
            _buildingRequiredService = buildingRequiredService;
            _mapper = mapper;
        }

        [HttpGet("api/v1/getRequiredBuildings")]
        public async Task<ActionResult<BuildingRequiredBuildingViewModel>> GetRequiredBuildings([FromHeader]int buildingId)
        {
            var requiredBuildings = await _buildingRequiredService.GetRequiredBuildings(buildingId);
            var mappedRequiredBuildings =  _mapper.Map<List<BuildingRequiredBuildingViewModel>>(requiredBuildings);
            return Ok(mappedRequiredBuildings);
        }
    }
}
