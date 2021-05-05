using System.Collections.Generic;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public TestController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("api/v1/tests")]
        public IActionResult GetTests()
        {
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
        
        [Authorize]
        [HttpGet("api/v1/tests/authorized")]
        public IActionResult Authorized()
        {
            return Ok("Authorized value");
        }
        
        [HttpPost("api/v1/tests/generate-access-token")]
        public IActionResult GenerateAccessToken(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                userId = "exampleId";
                
            return Ok(new {Token = _jwtService.GenerateJwtToken(userId)});
        }
    }

    public class CreateMessageRequest
    {
        public string Message { get; set; }
    }
}