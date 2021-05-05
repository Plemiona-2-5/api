using System.Collections.Generic;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IBuildingRequiredService _buildingRequiredService;
        public TestController(IBuildingRequiredService buildingRequiredService)
        {
            _buildingRequiredService = buildingRequiredService;
        }
        [HttpGet("api/v1/tests")]
        public IActionResult GetTests()
        {
            _buildingRequiredService.HasMaterial(1,7,1);
            return Ok(new List<object>{new {Id = 1, Message = "works fine"}, new {Id = 2, Message = "works good"}});
        }
        
        [HttpGet("api/v1/tests/{testId}")]
        public IActionResult GetTestById([FromRoute] int testId)
        {
            return Ok(new {Id = testId, Message = "works fine"});
        }

        [HttpPost("api/v1/tests")]
        public IActionResult Post([FromBody] CreateMessageRequest request)
        {
            return NoContent();
        }
    }

    public class CreateMessageRequest
    {
        public string Message { get; set; }
    }
}