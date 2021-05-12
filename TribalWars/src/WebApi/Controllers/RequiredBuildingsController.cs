using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<RequiredBuildingViewModel> GetRequiredBuildings(int buildingId)
        {
            var requiredBuildings = _buildingRequiredService.GetRequiredBuildings(buildingId).ToList();     
            var mappedRequiredBuildings =  _mapper.Map<List<BuildingViewModel>>(requiredBuildings);
            return Ok(mappedRequiredBuildings);
        }
    }
}
